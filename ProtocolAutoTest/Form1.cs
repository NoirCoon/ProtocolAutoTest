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
		private int numOfProtocol;

		private Object trueObj = true;// Обертка значения TRUE в объект
		private Object falseObj = false;// Обертка значения FALSE в объект
		private Object missingObj = System.Reflection.Missing.Value;// Чтото вроде NULL как объект

		private bool GeneralFault = false;//важная переменная на случай некой Генеральной ошибки, если TRUE ошибка имеет место быть
		private bool SavePathSelected; //Проверка что путь сохранения выбран, Если TRUE значит выбран.

		//
		//Список шаблонов
		//
		private TemplateTables tmpBufferTemplates;//пустой шаблон
		private readonly TemplateTables cbLineTemplate = new TemplateTables
		{
			tables = new Table[4],
			index = new int[4] { 1, 2, 3, 4 }
		};
		private readonly TemplateTables engineTemplate = new TemplateTables
		{
			tables = new Table[6],
			index = new int[6] { 5, 6, 7, 8, 9, 10 }
		};

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
			
			//cablLinePage.Parent = null;
			//enginePage.Parent = null;
		}

		private void Create_Click(object sender, EventArgs e)//нажатие кнопки Создать
		{
			
			if (EmptyTest() == true && SavePathSelected == true)//проверка на заполненость полей и выбор пути сохранения
			{
				create.Enabled = false;
				numOfProtocol = 1;
				wordapp = new Word.Application {Visible = true};
				for(int i = 0; i < protListBox.Items.Count; i++)
                {
					if(protListBox.GetItemChecked(i) == true)
                    {
						CreateTemplate();
						ChangeTemplate(i+1);
                    }

					numOfProtocol++;
				}
			}
			else //Иначе сообщение об ошибке
			{ 
				GenFault(20); 
			} 
			create.Enabled = true;
		}
		//
		//Функция определяющая заполненность полей (На данном этапе проверяет только главную вкладку)
		//

		private bool EmptyTest()
		{
			var listTextBox = mainTab.Controls.OfType<TextBox>().ToList();
			bool empty = true;
			bool emptyBox = false;
			foreach (var txtB in listTextBox)
			{
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
			for (int i = 0; i < protListBox.Items.Count; i++)
			{
				if (protListBox.GetItemChecked(i) == true)
				{
					emptyBox = true;
				}
			}
			if (emptyBox == false)
			{
				protListBox.BackColor = Color.MistyRose;
			}
			else
			{
				protListBox.BackColor = Color.White;
			}
			return empty&&emptyBox;
		}

		//
		//Функция открытия документа - шаблона
		//
		private void CreateTemplate()
		{
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

		private void ChangeTemplate(int method)
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
				worddocument.Select();
				findText = "п00-0-0-0000";
				replaceText = protNumBox.Text + "-" + numOfProtocol.ToString() + "-" + DateTime.Now.Year.ToString();
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
					table3.Cell(1, 1).Range.InsertAfter(protNumBox.Text + "-" + numOfProtocol.ToString() + "-" + DateTime.Now.Year.ToString());
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
				ChangeBody(method);
			}
			catch (Exception)
			{
				GenFault(1);
			}
		}

		//
		//Функция форматирования @body
		//

		private void ChangeBody(int method)
		{
            try
			{
				Object findText;
				Object replaceText;

				//
				//выбор SaveName, наименование протокола, шаблона
				//

				switch (method)
				{
					case 1:
						SaveName = "Кабельные линии";
						replaceText = "контрольных кабельных линий.";
						tmpBufferTemplates = cbLineTemplate;//скопирован шаблон cbLine
						break;
					case 2:
						SaveName = "Электродвигатели";
						replaceText = "электродвигателей переменного тока.";
						tmpBufferTemplates = engineTemplate;
						break;
					default:
						replaceText = "Ошибочка! GenFault(3)";
						GenFault(3);
						break;
				}
				findText = "@test";
				worddocument.Select(); //Выбор основного документа
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText);
				wordapp.Selection.Collapse(0);

				//
				//цикл записи в шаблон соответствующих таблиц согласно данным в массиве index
				//

				worddocument2.Select();
				for (int i = 0; i < tmpBufferTemplates.index.Length; i++)
				{
					tmpBufferTemplates.tables[i] = worddocument2.Tables[tmpBufferTemplates.index[i]];
				}
				tmpBufferTemplates.tables = ChangeTable(tmpBufferTemplates.tables, method);//редактирование таблиц согласно методу

				//
				//Вставка таблиц в основной документ
				//
				foreach (Table tempTable in tmpBufferTemplates.tables)
				{
					tempTable.Range.Copy();
					worddocument.Select(); //Выбор основного документа
					findText = "@body"; //Поиск @body
					wordapp.Selection.Find.Execute(ref findText); //Поиск @body и его выделение
					wordapp.Selection.Collapse(WdCollapseDirection.wdCollapseStart); //убирает выделение в начало слова @body
					wordapp.Selection.Paste(); //Вставка в выделенный фрагмент после поиска
					//wordapp.Selection.InsertParagraphAfter();//Вставка параграфа после таблицы чтобы они не слиплись при добавлении следующей
				}
				worddocument.Select(); //Выбор основного документа
				findText = "@body"; //Поиск @body
				replaceText = "";
				wordapp.Selection.Find.Execute(ref findText, ReplaceWith: ref replaceText); //Поиск @body и его замена
				//Save();
			}
			catch (Exception)
			{
				GenFault(4);
			}
		}

		//
		//Функция для переноса из датагридвью в таблицу
		//

		private Table[] ChangeTable(Table[] tables, int method)//Работает частично, пока не найден способ добавить новую строку, вставка работает норм
		{
			Random rnd = new Random();
			//rnd.Next(19, 31);
			try
            {
				switch (method)
				{
					//
					// Придумать как оптимизировать, частично оптимизировал, читабельность... ну, кто-то сможет прочитать, а кто-то ты
					//
					case 1://случай для шаблона кабельные линии таблица
						for (int i = 0; i < cablLineGrid.Rows.Count; i++)//перебирает строчки гридвью
						{
							if(cablLineGrid.Rows[i].Cells[1].Value != null)//условие, если ячейка с номером строки не пустая
							{
								for (int j = 0; j < 3; j++)//перебирает столбцы грид вью 1 и 2
								{
									tables[1].Cell(i + 1, j + 1).Range.InsertAfter(cablLineGrid.Rows[i].Cells[j].Value.ToString());//Вставляются все остальные, точнее первая и вторая ячейка на соответствующие места
								}
								tables[1].Cell(i + 1, 3).Range.InsertAfter(" " + cablLineGrid.Rows[i].Cells[3].Value.ToString());
								tables[1].Cell(i + 1, 3).Range.InsertAfter("X" + cablLineGrid.Rows[i].Cells[4].Value.ToString());//присоединяется к ячейке с маркой и кол-вом жил
								tables[1].Cell(i + 1, 4).Range.InsertAfter(cablLineGrid.Rows[i].Cells[5].Value.ToString());//вставляется в соответствующую ячейку, нужно, потому что есть смещение на две ячейки от шаблонной таблицы
								//
								//Авто заполнение второй части таблицы с указанием сопротивления жил кабеля
								tables[1].Cell(i + 1, 5).Range.InsertAfter("Соответствует");//думаю всё понятно
								for (int j = 6; j < 14; j++)//перебирает столбцы ячеек сопротивления жил кабеля с 6 по 13
								{
									if((j-5) <= Convert.ToInt32(cablLineGrid.Rows[i].Cells[3].Value.ToString()))//берёт значения в ячейки кол-во жил, переводит в строку, переводит в число. Адрес ячейки переводится в номер жилы (j-5). Сравниваются
                                    {
										tables[1].Cell(i + 1, j).Range.InsertAfter((rnd.Next(19, 31)*100).ToString());//записывает случайное значение сопротивления
									}
									else
									{
										tables[1].Cell(i + 1, j).Range.InsertAfter("—");//записывает прочерк, если кол-во жил меньше номера жилы в таблице
									}
								}
								if (i < (cablLineGrid.Rows.Count - 2))//проверка, есть ли дальше ещё строки или нет
									tables[1].Rows.Add();//вставляет новую строку если есть
							}
						}
						break;
					//
					// Придумать как оптимизировать
					//
					case 2:
						for(int i = 0; i < engineGrid.Rows.Count; i++)//Ну тут понятно
                        {
							if (engineGrid.Rows[i].Cells[1].Value != null)//уже было в кабллайн
							{
								for (int j = 0; j < engineGrid.Rows.Count; j++)//уже было в кабллайн
								{
									tables[1].Cell(i + 1, j + 1).Range.InsertAfter(engineGrid.Rows[i].Cells[j].Value.ToString());//переносит все данные в первую таблицу
									tables[3].Cell(i + 1, j + 1).Range.InsertAfter(engineGrid.Rows[i].Cells[j].Value.ToString());
								}
										tables[3].Cell(i + 1, 3).Range.InsertAfter((rnd.Next(19, 31) * 100).ToString());
										tables[3].Cell(i + 1, 4).Range.InsertAfter("1,0");
										tables[3].Cell(i + 1, 5).Range.InsertAfter("> 1,3");
										tables[3].Cell(i + 1, 6).Range.InsertAfter("выдержал");
										tables[3].Cell(i + 1, 7).Range.InsertAfter("Соответствует");
								if (i < (engineGrid.Rows.Count - 2))
								{
									tables[1].Rows.Add();
									tables[3].Rows.Add();
								}
							}
                        }
						break;
				}
			}
			catch (Exception)
			{
				GenFault(3);
			}
			return tables;
		}


		//
		//Функция сохранения готового протокола
		//

		private void Save()//wordapp всё еще открыт
		{
			Object fileName = SavePath + @"\" + protNumBox.Text + "-" + numOfProtocol.ToString() + "-" + DateTime.Now.Year.ToString() + " " + SaveName + ".docx";//заменить "ЗАМЕНИТЬ" на порядковый номер протокола (формируется из чекбокса)
			Object fileFormat = WdSaveFormat.wdFormatDocumentDefault;//формат сохраняемого документа
			worddocument2.Content.Font.Size = 11;//устанавливает размер шрфита всего документа
			worddocument.SaveAs2(ref fileName, ref fileFormat);//сохранить как
			worddocument.Close(ref falseObj, ref missingObj, ref missingObj);//закрытие документа
			worddocument = null;//очистка переменной
			worddocument2.Close(ref falseObj, ref missingObj, ref missingObj);//закрытие документа2
			worddocument2 = null;//очистка переменной2
			wordapp = null;
		}

		//
		//Вызов окна выбора папки для сохранения и получении пути.
		//

		private void SaveBtn_Click(object sender, EventArgs e) 
		{
			folderBrowserDialog1.ShowDialog(); //Открыть диалоговое окно с выбором папки
			SavePath = folderBrowserDialog1.SelectedPath; //Получить путь
			if (SavePath == null) { SavePathSelected = false; } //Проверки на то что путь выбран
			else if (SavePath == "") { SavePathSelected = false; } //Проверки на то что путь выбран
			else { SavePathSelected = true; } //Путь выбран заебись
		}


		//
		//Функция для вывода сообщения ошибки или предупреждения с 0 по 19 зарезервированы номера ошибок с 20 предупреждений
		//

		private void GenFault(int numOfError)
		{
			string txtOfError;
			string txtOfHead = "Ошибка!";
			System.Windows.Forms.MessageBoxButtons MBB = MessageBoxButtons.OK;
			System.Windows.Forms.MessageBoxIcon MBI = MessageBoxIcon.Error;
			switch (numOfError)
			{
				//
				//Ошибки
				//
				case 0:
					txtOfError = "Произошла ошибка при открытии документа 1!\nError in CreateTemplate()";
					break;
				case 1:
					txtOfError = "Произошла ошибка при генерации основного формата!\nError in ChangeTemplate()";
					break;
				case 2:
					txtOfError = "Произошла ошибка при открытии документа 2!\nError in CreateTemplate()";
					break;
				case 3:
					txtOfError = "Произошла ошибка при редактировании тела шаблона!\nError in ChangeTable()";
					break;
				case 4:
					txtOfError = "Произошла ошибка при генерации тела шаблона! \nError in ChangeBody();";
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
			if (numOfError <= 19)
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
			/*
			for (int i = 0; i < protListBox.Items.Count; i++)
			{
				if (protListBox.GetItemChecked(i) == true)
				{
					cablLinePage.Parent = tabControlPanel; //Показать
				}
				else if (protListBox.GetItemChecked(i) == false)
				{
					cablLinePage.Parent = null; //Скрыть
				}
			}
			*/
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
		//Функция нумерация строк при создании новой строки, строки только для чтения, по ним определяется можно ли строку перенисти в таблицу или нет
		//

		private void cablLineGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)//при создании новой строчки
		{
			for (int i = 0; i < cablLineGrid.Rows.Count - 1; i++)//перебирает все строчки
			{
				cablLineGrid.Rows[i].Cells[0].Value = i + 1;
			}
		}

        private void engineGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
			for (int i = 0; i < engineGrid.Rows.Count - 1; i++)//перебирает все строчки
			{
				engineGrid.Rows[i].Cells[0].Value = i + 1;
			}
		}
    }
}
