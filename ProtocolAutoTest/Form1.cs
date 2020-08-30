/*
* Заказчик (label) - costumer
		 (textBox) - costumerBox

* Объект    (label) - objct 
		  (textBox) - objctBox

* Пусконаладочная орг-ция (label) - agency 
						(textBox) - agencyBox

* Присоединение: (label) - objAdd 
			   (textBox) - objAddBox

* Номер протокола: (textBox) - protNumBox

* Температура (label) - temp
			(textBox) - tempBox

* Атмосферное давление (label) - press
		(textBox) - pressBox

* Влажность (label) - wet
		  (textBox) - wetBox

* Испытания: (label) - test
		   (textBox) - testBox

* Дата испытания (label) - dateTest
			   (textBox) - dateTestBox

* Дата регистрации (label) - dateReg
				 (textBox) - dateRegBox

* Результаты проверил (label) - audit
		(textBox) - auditBox

* Испытания произвели (label) - testPers
				   (TextBox) - testPersBox1
				   (TextBox) - testPersBox2
				   (TextBox) - testPersBox3

* ФИО (testBox) - fioBox1
	  (testBox) - fioBox2
	  (testBox) - fioBox3
protListBox (CheckedListBox) - список видов протоколов

tabControlPanel - контейнер для табпейджев
mainForm - главная вкладка
cablLine - вкладка кабельные линии
*/
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ProtocolAutoTest
{
	public partial class mainForm : Form
	{
		private Word.Application wordapp; //глобальное определение Word.Application
		private Document worddocument;// для основного документа с шапкой и футажом
		private Document worddocument2;//для документа с набором таблиц

		private string SaveName;//наименование протокола для сохранения
		private string SavePath;//адрес сохранения
		private string pathToFile;//имя файла для открытия, в текущем варианте только Example.docx и TablExmp.docx

		private Object trueObj = true;// Обертка значения TRUE в объект
		private Object falseObj = false;// Обертка значения FALSE в объект
		private Object missingObj = System.Reflection.Missing.Value;// Чтото вроде NULL как объект

		private bool GeneralFault = false;//важная переменная на случай некой Генеральной ошибки, если TRUE ошибка имеет место быть
		private bool SavePathSelected; //Проверка что путь сохранения выбран, Если TRUE значит выбран.
        
		public mainForm()
		{
			InitializeComponent();//инициализация формы
			
			var srcPersTest = new AutoCompleteStringCollection();//инициализация списка автозаполнения текстбокса для "Испытания провели"
			srcPersTest.AddRange(new string[]
			{
				"Инженер-наладчик",
				"Техник-наладчик"
			});

			//
			//Список текстбоксов использующих автозаполнение "Испытание провели"
			//
			testPersBox1.AutoCompleteCustomSource = srcPersTest;
			testPersBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			testPersBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
			testPersBox2.AutoCompleteCustomSource = srcPersTest;
			testPersBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			testPersBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
			testPersBox3.AutoCompleteCustomSource = srcPersTest;
			testPersBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			testPersBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
			
			cablLine.Parent = null;
		}

		private void Create_Click(object sender, EventArgs e)//нажатие кнопки Создать
		{
			if (EmptyTest() == true && SavePathSelected == true)//проверка на заполненость полей и выбор пути сохранения
			{
				wordapp = new Word.Application();
				wordapp.Visible = true;
				GenFormat(1);//в теории вместо цифры стоит переменная, которая отвечает за выбранный чекбокс
			}
			else { GenFault(20); } //Иначе сообщение об ошибке
		}
		//
		//отдельная функция создания шаблона, актуальность не доказана
		//
		/* private void genTemplate()
		 {
			 Object newTemplate = false;
			 Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
			 Object visible = true;
			 pathToFile = "Example.docx";
			 try
			 {
				 Object template = Environment.CurrentDirectory + @"\Templates\" + pathToFile;//получает путь к exe + путь к файлу, Example заменить на переменную
				 worddocument = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
				 worddocument.Content.Font.Size=11;
			 }
			 catch (Exception)
			 {
				 wordapp.Quit(ref falseObj, ref missingObj, ref missingObj);
				 worddocument = null;
				 worddocument2 = null;
				 wordapp = null;
				 genFaultActive();
			 }

		 }*/
		//
		//Функция для создания протоколов параметр method указывает на вид протокола. Слишком объемная упростить расформировать на доп функции
		//
		private void GenFormat(int method)
		{
			//
			//Список шаблонов
			//

			TemplateTables cbLine = new TemplateTables();//Шаблон кабельные линии
			cbLine.index = new int[2] { 1, 2 };//таблица 1,2
			
			//Объявление всякой хрени
			Object findText;
			Object replaceText;
			Object newTemplate = false;
			Object documentType = WdNewDocumentType.wdNewBlankDocument;
			Object visible = true;
			pathToFile = "Example.docx";

			Table table1; //Таблица замены обьекта и присоединения
			Table table3; //Таблица нижнего колонтитула
			Table lastTable; //Последняя таблица с подписями


			try//Открытие документа 1
			{
				Object template = Environment.CurrentDirectory + @"\Templates\" + pathToFile;//получает путь к exe + путь к файлу
				worddocument = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
				worddocument.Content.Font.Size = 11;
			}
			catch (Exception)
			{
				GenFault(0);
			}

			try//Генерация основного формата
			{
				//
				//Замента номера протокола, температуры, давления и влаги
				//
				findText = "п00-0-0-0000";
				replaceText = protNumBox.Text + "-" + "ЗАМЕНИТЬ" + "-" + DateTime.Now.Year.ToString();
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);
				findText = "@Temp";
				replaceText = tempBox.Text;
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);
				findText = "@Pres";
				replaceText = pressBox.Text;
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);
				findText = "@Vlag";
				replaceText = wetBox.Text;
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);

				//
				//Замена объекта и присоединения
				//
				table1 = worddocument.Tables[1]; //Обращение к таблице по индексу 1
				table1.Cell(1, 4).Range.InsertAfter(costumerBox.Text); //вставка значения поля в ячейку таблицы
				table1.Cell(2, 4).Range.InsertAfter(objctBox.Text);
				table1.Cell(3, 4).Range.InsertAfter(agencyBox.Text);
				table1.Cell(4, 4).Range.InsertAfter(objAddBox.Text);
				//
				//замена нижнего колонтитула
				//
				foreach (Section sec in worddocument.Sections)
				{
					var range = sec.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
					table3 = range.Tables[1];
					table3.Cell(1, 1).Range.InsertAfter(protNumBox.Text + "-" + "ЗАМЕНИТЬ" + "-" + DateTime.Now.Year.ToString());
				}

				//
				//Испытания произвели, фамилии даты и прочее
				//

				var countTabl = worddocument.Tables.Count;
				lastTable = worddocument.Tables[countTabl];
				lastTable.Cell(1, 2).Range.InsertAfter(testPersBox1.Text);
				lastTable.Cell(2, 2).Range.InsertAfter(testPersBox2.Text);
				lastTable.Cell(3, 2).Range.InsertAfter(testPersBox3.Text);
				lastTable.Cell(4, 2).Range.InsertAfter(auditBox.Text);
				lastTable.Cell(1, 3).Range.InsertAfter(fioBox1.Text);
				lastTable.Cell(2, 3).Range.InsertAfter(fioBox2.Text);
				lastTable.Cell(3, 3).Range.InsertAfter(fioBox3.Text);
				lastTable.Cell(4, 3).Range.InsertAfter(fioBox4.Text);
				lastTable.Cell(5, 2).Range.InsertAfter(dateRegBox.Text);
				lastTable.Cell(6, 2).Range.InsertAfter(dateTestBox.Text);
            }
            catch (Exception) 
			{
				GenFault(1);
			}

			try//Открытие документа 2
			{
				pathToFile = "TablExmp.docx";
				Object template = Environment.CurrentDirectory + @"\Templates\" + pathToFile;//получает путь к exe + путь к файлу, Example заменить на переменную
				worddocument2 = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
				worddocument2.Content.Font.Size = 11;

			}
			catch (Exception)
			{
				GenFault(2);
			} 

			switch (method)//Переброс таблиц из 1 документа в 2 (Будет наверно очень нагружен вариантами, тут надо подумать как сделать) 
			{
				case 1:
					worddocument2.Select();
					for (int i = 0; i <= cbLine.index.Length - 1; i++)//цикл записи в шаблон соответствующих таблиц согласно данным в массиве index
					{
						cbLine.tables[i] = worddocument2.Tables[cbLine.index[i]];
					}
					cbLine.tables = ChangeTable(cbLine.tables, method);//редактирование таблиц согласно методу
					cbLine.tables[0].Range.Copy(); //Копирование таблицы
					worddocument.Select(); //Выбор основного документа
					findText = "@test";
					replaceText = "контрольных кабельных линий.";
					wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
					findText = "@body"; //Поиск @body
					wordapp.Selection.Find.Execute(ref findText); //Поиск @body и его выделение
					wordapp.Selection.Collapse(WdCollapseDirection.wdCollapseStart); //убирает выделение в начало слова @body
					wordapp.Selection.Paste(); //Вставка в выделенный фрагмент после поиска
					wordapp.Selection.InsertParagraphAfter();//Вставка параграфа после таблицы чтобы они не слиплись при добавлении следующей
					worddocument2.Select(); //Выбор документа 2
					wordapp.Selection.Collapse(0); //Сброс выделения предыдущей таблицы. Нужно для устранения каких либо ошибок, скорее всего в моем мозгу. Пусть будет
					cbLine.tables[1].Range.Copy(); //Копирование таблицы
					worddocument.Select(); //Выбор основного документа
					findText = "@body"; //Поиск @body
					wordapp.Selection.Find.Execute(ref findText); //Поиск @body и его выделение
					wordapp.Selection.Paste(); //Вставка в выделенный фрагмент после поиска с выпиливание @body нахер
					worddocument.Select();
					SaveName = "Кабельные линии";
					break;
				default:
					GenFault(3);
					break;
			} 

			Save();
		}

		//
		//Функция определяющая заполненность полей (На данном этапе проверяет только главную вкладку)
		//

		private bool EmptyTest()
		{
			var listTextBox = mainTab.Controls.OfType<TextBox>().ToList();
			bool empty = true;
			foreach (var txtB in listTextBox)
			{
				txtB.BackColor = Color.MistyRose;
				if (txtB.Text.Length == 0)
				{
					txtB.BackColor = Color.MistyRose;
					empty = false;
				}
				else
				{
					txtB.BackColor = Color.White;
				}
			}
			return empty;
		}

		//
		//Функция сохранения готового протокола
		//

		private void Save()//wordapp всё еще открыт
		{
			Object fileName = SavePath + @"\" + protNumBox.Text + "-" + "ЗАМЕНИТЬ" + "-" + DateTime.Now.Year.ToString() + " " + SaveName + ".docx";//заменить "ЗАМЕНИТЬ" на порядковый номер протокола (формируется из чекбокса)
			Object fileFormat = WdSaveFormat.wdFormatDocumentDefault;//формат сохраняемого документа
			worddocument2.Content.Font.Size = 11;//устанавливает размер шрфита всего документа
			worddocument.SaveAs2(ref fileName, ref fileFormat);//сохранить как
			worddocument.Close(ref falseObj, ref missingObj, ref missingObj);//закрытие документа
			worddocument = null;//очистка переменной
			worddocument2.Close(ref falseObj, ref missingObj, ref missingObj);//закрытие документа2
			worddocument2 = null;//очистка переменной2
		}

		//
		//Функция для вывода сообщения ошибки или предупреждения с 0 по 19 зарезервированы номера ошибок с 20 предупреждений
		//

		private void GenFault(int method)
		{
			string txtOfError;
			string txtOfHead = "Ошибка!";
			System.Windows.Forms.MessageBoxButtons MBB = MessageBoxButtons.OK;
			System.Windows.Forms.MessageBoxIcon MBI = MessageBoxIcon.Error;
			switch (method)
			{
				//
				//Ошибки
				//
				case 0:
					txtOfError = "Произошла ошибка при открытии документа 1";
					break;
				case 1:
					txtOfError = "Произошла ошибка при генерации основного формата";
					break;
				case 2:
					txtOfError = "Произошла ошибка при открытии документа 2";
					break;
				case 3:
					txtOfError = "Ошибка шаблона протокола. Некорректное значение Method в GenFormat().Switch";
					break;
				//
				//Предупреждения
				//
				case 20:
					txtOfError = "Не все поля заполнены и/или не указано место сохранения";
					txtOfHead = "Предупреждение!";
					MBI = MessageBoxIcon.Warning;
					break;
					//
					//Ошибка, при некорректном method
					//
				default:
					txtOfError = "Неизвестная ошибка в коде. Обратитесь к специалисту.";
					break;
			}
			MessageBox.Show(txtOfError, txtOfHead, MBB, MBI);
			if (method <= 19)
            {
				wordapp.Quit(ref falseObj, ref missingObj, ref missingObj);
				worddocument = null;
				worddocument2 = null;
				wordapp = null;
				GeneralFault = true;
			}
		}

		//
		//Функция для отображения вкладок, если чекбокс изменяется
		//

		private void ProtListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (protListBox.GetItemChecked(0) == true)
			{
				cablLine.Parent = tabControlPanel; //Показать
			}
			else if (protListBox.GetItemChecked(0) == false)
			{
				cablLine.Parent = null; //Скрыть
			}
		}

        private void SaveBtn_Click(object sender, EventArgs e) //Вызов окна выбора папки для сохранения и получении пути.
        {
			folderBrowserDialog1.ShowDialog(); //Открыть диалоговое окно с выбором папки
			SavePath = folderBrowserDialog1.SelectedPath; //Получить путь
			if(SavePath == null) { SavePathSelected = false; } //Проверки на то что путь выбран
			else if (SavePath == "") { SavePathSelected = false; } //Проверки на то что путь выбран
			else { SavePathSelected = true; } //Путь выбран заебись
        }

		//
		//Функция которая нужна для подключения к бд
		//

        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tableDBDataSet.Контрольные_кабели". При необходимости она может быть перемещена или удалена.
            this.контрольные_кабелиTableAdapter.Fill(this.tableDBDataSet.Контрольные_кабели);

        }

		//
		//Функция для переноса из датагридвью в таблицу
		//

		private Table[] ChangeTable(Table [] tables, int method)//Работает частично, пока не найден способ добавить новую строку, вставка работает норм
		{
			switch (method)
            {
				case 1://случай для шаблона кабельные линии таблица
					for (int i = 0; i < TableOfCableLine.Rows.Count; i++)
					{
						for (int j = 0; j < TableOfCableLine.Columns.Count; j++)
						{
							if (TableOfCableLine.Rows[i].Cells[j].Value != null)
							{
								tables[0].Cell(i + 4, j + 1).Range.InsertAfter(TableOfCableLine.Rows[i].Cells[j].Value.ToString());
							}
						}
					}
					break;
            }
			return tables;
		}

		//
		//Функция нумерация строк при создании новой строки, строки только для чтения, по ним определяется можно ли строку перенисти в таблицу или нет
		//

		private void TableOfCableLine_UserAddedRow(object sender, DataGridViewRowEventArgs e)//при создании новой строчки
		{
			for (int i = 0; i < TableOfCableLine.Rows.Count-1; i++)//перебирает все строчки
			{
				TableOfCableLine.Rows[i].Cells[0].Value = i + 1;
			}
		}

		//////////////////////////////////////////////////////////////
		//															//
		// Далеее функции, упрощающие генформат						//
		//															//
		//															//
		//////////////////////////////////////////////////////////////
		

		//
		//
		//Функция открытия документа - шаблона
		//
		private void CreateTemplate()
		{
            wordapp = new Word.Application
            {
                Visible = true
            };
            //Объявление всякой хрени
            Object newTemplate = false;
			Object documentType = WdNewDocumentType.wdNewBlankDocument;
			Object visible = true;

			pathToFile = "Example.docx";

			try
			{
				Object template = Environment.CurrentDirectory + @"\Templates\" + pathToFile;//получает путь к exe + путь к файлу
				worddocument = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
			}
			catch (Exception)
			{
				GenFault(0);
			}

			pathToFile = "TablExmp.docx";

			try
			{
				Object template = Environment.CurrentDirectory + @"\Templates\" + pathToFile;//получает путь к exe + путь к файлу
				worddocument2 = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
			}
			catch (Exception)
			{
				GenFault(2);
			}
		}

		//
		//Функция внесения данных в шаблон
		//

		private void ChangeTemplates()
        {
			try//Генерация основного формата
			{
				Object findText;
				Object replaceText;

				Table table1; //Таблица замены обьекта и присоединения
				Table table3; //Таблица нижнего колонтитула
				Table lastTable; //Последняя таблица с подписями
				//
				//Замента номера протокола, температуры, давления и влаги
				//
				findText = "п00-0-0-0000";
				replaceText = protNumBox.Text + "-" + "ЗАМЕНИТЬ" + "-" + DateTime.Now.Year.ToString();
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);
				findText = "@Temp";
				replaceText = tempBox.Text;
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);
				findText = "@Pres";
				replaceText = pressBox.Text;
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);
				findText = "@Vlag";
				replaceText = wetBox.Text;
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);

				//
				//Замена объекта и присоединения
				//
				table1 = worddocument.Tables[1]; //Обращение к таблице по индексу 1
				table1.Cell(1, 4).Range.InsertAfter(costumerBox.Text); //вставка значения поля в ячейку таблицы
				table1.Cell(2, 4).Range.InsertAfter(objctBox.Text);
				table1.Cell(3, 4).Range.InsertAfter(agencyBox.Text);
				table1.Cell(4, 4).Range.InsertAfter(objAddBox.Text);
				//
				//замена нижнего колонтитула
				//
				foreach (Section sec in worddocument.Sections)
				{
					var range = sec.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
					table3 = range.Tables[1];
					table3.Cell(1, 1).Range.InsertAfter(protNumBox.Text + "-" + "ЗАМЕНИТЬ" + "-" + DateTime.Now.Year.ToString());
				}

				//
				//Испытания произвели, фамилии даты и прочее
				//

				var countTabl = worddocument.Tables.Count;
				lastTable = worddocument.Tables[countTabl];
				lastTable.Cell(1, 2).Range.InsertAfter(testPersBox1.Text);
				lastTable.Cell(2, 2).Range.InsertAfter(testPersBox2.Text);
				lastTable.Cell(3, 2).Range.InsertAfter(testPersBox3.Text);
				lastTable.Cell(4, 2).Range.InsertAfter(auditBox.Text);
				lastTable.Cell(1, 3).Range.InsertAfter(fioBox1.Text);
				lastTable.Cell(2, 3).Range.InsertAfter(fioBox2.Text);
				lastTable.Cell(3, 3).Range.InsertAfter(fioBox3.Text);
				lastTable.Cell(4, 3).Range.InsertAfter(fioBox4.Text);
				lastTable.Cell(5, 2).Range.InsertAfter(dateRegBox.Text);
				lastTable.Cell(6, 2).Range.InsertAfter(dateTestBox.Text);
			}
			catch (Exception)
			{
				GenFault(1);
			}
		}
	}
}
