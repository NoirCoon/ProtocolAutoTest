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

namespace ProtocolAuto
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
			//tabControlPanel.TabPages.Remove(cablLine); //убрать 
			
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
			else { MessageBox.Show("Не выбрано место сохранения или не заполнены все поля"); } //Иначе сообщение об ошибке
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
		//Функция для создания протоколов параметр method указывает на вид протокола. существует проблема, при создании второго документа неизвестно как переключаться между открытыми документами
		//
		private void GenFormat(int method)
		{
			//Объявление всякой хрени
			Object findText;
			Object replaceText;
			Object newTemplate = false;
			Object documentType = WdNewDocumentType.wdNewBlankDocument;
			Object visible = true;
			pathToFile = "Example.docx";

			Table table1; //Таблица замены обьекта и присоединения
			Table table2; //Таблица для переопределения. Переменная для записи таблиц из второго документа и вставки в первый. Даже имя совпадает таблица 2 документ 2)
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
				MessageBox.Show("Произошла ошибка при открытии документа 1");
				GenFaultActive();
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
            catch (Exception) {
				MessageBox.Show("Произошла ошибка при генерации основного формата");
				GenFaultActive();
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
				MessageBox.Show("Произошла ошибка при открытии документа 2");
				GenFaultActive();
			} 

			switch (method)//Переброс таблиц из 1 документа в 2 (Будет наверно очень нагружен вариантами, тут надо подумать как сделать) 
			{
				case 1:
					table2 = worddocument2.Tables[1]; //Обращение к таблице по индексу 1 во втором документе
					table2.Range.Copy(); //Копирование таблицы
					worddocument.Select(); //Выбор основного документа
					findText = "@body"; //Поиск @body
					wordapp.Selection.Find.Execute(ref findText); //Поиск @body и его выделение
					wordapp.Selection.Collapse(WdCollapseDirection.wdCollapseStart); //убирает выделение в начало слова @body
					wordapp.Selection.Paste(); //Вставка в выделенный фрагмент после поиска
					wordapp.Selection.InsertParagraphAfter();//Вставка параграфа после таблицы чтобы они не слиплись при добавлении следующей

					worddocument2.Select(); //Выбор документа 2
					wordapp.Selection.Collapse(0); //Сброс выделения предыдущей таблицы. Нужно для устранения каких либо ошибок, скорее всего в моем мозгу. Пусть будет
                    table2 = worddocument2.Tables[2]; //Обращение к таблице по индексу 2 во втором документе
					table2.Range.Copy(); //Копирование таблицы
					worddocument.Select(); //Выбор основного документа
					findText = "@body"; //Поиск @body
					wordapp.Selection.Find.Execute(ref findText); //Поиск @body и его выделение
					wordapp.Selection.Paste(); //Вставка в выделенный фрагмент после поиска с выпиливание @body нахер

					SaveName = "Кабельные линии";
					break;
				default:
					GenFaultActive();
					break;
			} 

			Save();
		}

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

		private void Save()//функция сохранения готового протокола
		{
			Object fileName = SavePath + @"\" + protNumBox.Text + "-" + "ЗАМЕНИТЬ" + "-" + DateTime.Now.Year.ToString() + " " + SaveName + ".docx";//адрес сохранения заменить курентдиректори на SavePath !ЗАМЕНЕНО
			Object fileFormat = WdSaveFormat.wdFormatDocumentDefault;//формат сохраняемого документа
			worddocument.SaveAs2(ref fileName, ref fileFormat);//сохранить как
			worddocument.Close(ref falseObj, ref missingObj, ref missingObj);//закрытие документа
			worddocument = null;//очистка переменной
		}

		private void GenFaultActive()
		{
			wordapp.Quit(ref falseObj, ref missingObj, ref missingObj);
			worddocument = null;
			worddocument2 = null;
			wordapp = null;
			GeneralFault = true;
		}

		private void ProtListBox_SelectedIndexChanged(object sender, EventArgs e)//если выбранный чекизменён
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
    }
}
