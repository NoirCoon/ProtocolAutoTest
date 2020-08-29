namespace ProtocolAuto
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label8 = new System.Windows.Forms.Label();
            this.protListBox = new System.Windows.Forms.CheckedListBox();
            this.testPersBox3 = new System.Windows.Forms.TextBox();
            this.testPersBox2 = new System.Windows.Forms.TextBox();
            this.testPersBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.protNumBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fioBox4 = new System.Windows.Forms.TextBox();
            this.creat = new System.Windows.Forms.Button();
            this.auditBox = new System.Windows.Forms.TextBox();
            this.audit = new System.Windows.Forms.Label();
            this.fioBox3 = new System.Windows.Forms.TextBox();
            this.fioBox2 = new System.Windows.Forms.TextBox();
            this.fioBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.testPers = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cablLine = new System.Windows.Forms.TabPage();
            this.TableOfCableLine = new System.Windows.Forms.DataGridView();
            this.контрольныеКабелиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableDBDataSet = new ProtocolAutoTest.TableDBDataSet();
            this.dateRegBox = new System.Windows.Forms.TextBox();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.saveBtn = new System.Windows.Forms.Button();
            this.dateReg = new System.Windows.Forms.Label();
            this.dateTestBox = new System.Windows.Forms.TextBox();
            this.dateTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wetBox = new System.Windows.Forms.TextBox();
            this.wet = new System.Windows.Forms.Label();
            this.pressBox = new System.Windows.Forms.TextBox();
            this.press = new System.Windows.Forms.Label();
            this.tempBox = new System.Windows.Forms.TextBox();
            this.temp = new System.Windows.Forms.Label();
            this.objAddBox = new System.Windows.Forms.TextBox();
            this.objAdd = new System.Windows.Forms.Label();
            this.agency = new System.Windows.Forms.Label();
            this.agencyBox = new System.Windows.Forms.TextBox();
            this.objctBox = new System.Windows.Forms.TextBox();
            this.objct = new System.Windows.Forms.Label();
            this.costumerBox = new System.Windows.Forms.TextBox();
            this.customer = new System.Windows.Forms.Label();
            this.tabControlPanel = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.контрольные_кабелиTableAdapter = new ProtocolAutoTest.TableDBDataSetTableAdapters.Контрольные_кабелиTableAdapter();
            this.NumOfRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objAddCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkOfCableCell = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sechXjilCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cablLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableOfCableLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.контрольныеКабелиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDBDataSet)).BeginInit();
            this.mainTab.SuspendLayout();
            this.tabControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(815, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Виды протоколов";
            // 
            // protListBox
            // 
            this.protListBox.CheckOnClick = true;
            this.protListBox.FormattingEnabled = true;
            this.protListBox.Items.AddRange(new object[] {
            "Испытание кабельных линий",
            "Вторичная коммутация",
            "Металлосвязь",
            "Электродвигатели",
            "Параметрирование ПЛК",
            "Испытание контрольных кабельных линий"});
            this.protListBox.Location = new System.Drawing.Point(756, 58);
            this.protListBox.Name = "protListBox";
            this.protListBox.Size = new System.Drawing.Size(243, 94);
            this.protListBox.TabIndex = 19;
            this.protListBox.SelectedIndexChanged += new System.EventHandler(this.ProtListBox_SelectedIndexChanged);
            // 
            // testPersBox3
            // 
            this.testPersBox3.Location = new System.Drawing.Point(162, 309);
            this.testPersBox3.Name = "testPersBox3";
            this.testPersBox3.Size = new System.Drawing.Size(239, 20);
            this.testPersBox3.TabIndex = 13;
            // 
            // testPersBox2
            // 
            this.testPersBox2.Location = new System.Drawing.Point(162, 282);
            this.testPersBox2.Name = "testPersBox2";
            this.testPersBox2.Size = new System.Drawing.Size(239, 20);
            this.testPersBox2.TabIndex = 11;
            // 
            // testPersBox1
            // 
            this.testPersBox1.Location = new System.Drawing.Point(162, 255);
            this.testPersBox1.Name = "testPersBox1";
            this.testPersBox1.Size = new System.Drawing.Size(239, 20);
            this.testPersBox1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Номер протокола:";
            // 
            // protNumBox
            // 
            this.protNumBox.Location = new System.Drawing.Point(162, 203);
            this.protNumBox.Name = "protNumBox";
            this.protNumBox.Size = new System.Drawing.Size(239, 20);
            this.protNumBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "ФИО";
            // 
            // fioBox4
            // 
            this.fioBox4.Location = new System.Drawing.Point(446, 335);
            this.fioBox4.Name = "fioBox4";
            this.fioBox4.Size = new System.Drawing.Size(168, 20);
            this.fioBox4.TabIndex = 16;
            // 
            // creat
            // 
            this.creat.Location = new System.Drawing.Point(868, 495);
            this.creat.Name = "creat";
            this.creat.Size = new System.Drawing.Size(122, 35);
            this.creat.TabIndex = 20;
            this.creat.Text = "Создать";
            this.creat.UseVisualStyleBackColor = true;
            this.creat.Click += new System.EventHandler(this.Create_Click);
            // 
            // auditBox
            // 
            this.auditBox.Location = new System.Drawing.Point(162, 336);
            this.auditBox.Name = "auditBox";
            this.auditBox.Size = new System.Drawing.Size(239, 20);
            this.auditBox.TabIndex = 15;
            // 
            // audit
            // 
            this.audit.AutoSize = true;
            this.audit.Location = new System.Drawing.Point(35, 339);
            this.audit.Name = "audit";
            this.audit.Size = new System.Drawing.Size(121, 13);
            this.audit.TabIndex = 32;
            this.audit.Text = "Результаты проверил:";
            // 
            // fioBox3
            // 
            this.fioBox3.Location = new System.Drawing.Point(446, 309);
            this.fioBox3.Name = "fioBox3";
            this.fioBox3.Size = new System.Drawing.Size(168, 20);
            this.fioBox3.TabIndex = 14;
            // 
            // fioBox2
            // 
            this.fioBox2.Location = new System.Drawing.Point(446, 282);
            this.fioBox2.Name = "fioBox2";
            this.fioBox2.Size = new System.Drawing.Size(168, 20);
            this.fioBox2.TabIndex = 12;
            // 
            // fioBox1
            // 
            this.fioBox1.Location = new System.Drawing.Point(446, 256);
            this.fioBox1.Name = "fioBox1";
            this.fioBox1.Size = new System.Drawing.Size(168, 20);
            this.fioBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "ФИО";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "ФИО";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "ФИО";
            // 
            // testPers
            // 
            this.testPers.AutoSize = true;
            this.testPers.Location = new System.Drawing.Point(32, 258);
            this.testPers.Name = "testPers";
            this.testPers.Size = new System.Drawing.Size(124, 13);
            this.testPers.TabIndex = 22;
            this.testPers.Text = "Испытания произвели:";
            // 
            // cablLine
            // 
            this.cablLine.Controls.Add(this.TableOfCableLine);
            this.cablLine.Location = new System.Drawing.Point(4, 22);
            this.cablLine.Name = "cablLine";
            this.cablLine.Padding = new System.Windows.Forms.Padding(3);
            this.cablLine.Size = new System.Drawing.Size(1025, 555);
            this.cablLine.TabIndex = 1;
            this.cablLine.Text = "Кабельные линии";
            this.cablLine.UseVisualStyleBackColor = true;
            // 
            // TableOfCableLine
            // 
            this.TableOfCableLine.BackgroundColor = System.Drawing.SystemColors.Window;
            this.TableOfCableLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableOfCableLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumOfRow,
            this.objAddCell,
            this.MarkOfCableCell,
            this.sechXjilCell,
            this.lengthCell});
            this.TableOfCableLine.Location = new System.Drawing.Point(6, 6);
            this.TableOfCableLine.Name = "TableOfCableLine";
            this.TableOfCableLine.Size = new System.Drawing.Size(1013, 543);
            this.TableOfCableLine.TabIndex = 0;
            this.TableOfCableLine.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.TableOfCableLine_UserAddedRow);
            // 
            // контрольныеКабелиBindingSource
            // 
            this.контрольныеКабелиBindingSource.DataMember = "Контрольные кабели";
            this.контрольныеКабелиBindingSource.DataSource = this.tableDBDataSet;
            // 
            // tableDBDataSet
            // 
            this.tableDBDataSet.DataSetName = "TableDBDataSet";
            this.tableDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateRegBox
            // 
            this.dateRegBox.Location = new System.Drawing.Point(162, 439);
            this.dateRegBox.Name = "dateRegBox";
            this.dateRegBox.Size = new System.Drawing.Size(123, 20);
            this.dateRegBox.TabIndex = 18;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.saveBtn);
            this.mainTab.Controls.Add(this.label8);
            this.mainTab.Controls.Add(this.protListBox);
            this.mainTab.Controls.Add(this.testPersBox3);
            this.mainTab.Controls.Add(this.testPersBox2);
            this.mainTab.Controls.Add(this.testPersBox1);
            this.mainTab.Controls.Add(this.label7);
            this.mainTab.Controls.Add(this.protNumBox);
            this.mainTab.Controls.Add(this.label6);
            this.mainTab.Controls.Add(this.fioBox4);
            this.mainTab.Controls.Add(this.creat);
            this.mainTab.Controls.Add(this.auditBox);
            this.mainTab.Controls.Add(this.audit);
            this.mainTab.Controls.Add(this.fioBox3);
            this.mainTab.Controls.Add(this.fioBox2);
            this.mainTab.Controls.Add(this.fioBox1);
            this.mainTab.Controls.Add(this.label5);
            this.mainTab.Controls.Add(this.label4);
            this.mainTab.Controls.Add(this.label3);
            this.mainTab.Controls.Add(this.testPers);
            this.mainTab.Controls.Add(this.dateRegBox);
            this.mainTab.Controls.Add(this.dateReg);
            this.mainTab.Controls.Add(this.dateTestBox);
            this.mainTab.Controls.Add(this.dateTest);
            this.mainTab.Controls.Add(this.label2);
            this.mainTab.Controls.Add(this.label1);
            this.mainTab.Controls.Add(this.wetBox);
            this.mainTab.Controls.Add(this.wet);
            this.mainTab.Controls.Add(this.pressBox);
            this.mainTab.Controls.Add(this.press);
            this.mainTab.Controls.Add(this.tempBox);
            this.mainTab.Controls.Add(this.temp);
            this.mainTab.Controls.Add(this.objAddBox);
            this.mainTab.Controls.Add(this.objAdd);
            this.mainTab.Controls.Add(this.agency);
            this.mainTab.Controls.Add(this.agencyBox);
            this.mainTab.Controls.Add(this.objctBox);
            this.mainTab.Controls.Add(this.objct);
            this.mainTab.Controls.Add(this.costumerBox);
            this.mainTab.Controls.Add(this.customer);
            this.mainTab.Location = new System.Drawing.Point(4, 22);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(1025, 555);
            this.mainTab.TabIndex = 0;
            this.mainTab.Text = "Основные данные";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(868, 442);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(122, 32);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "Место сохранения";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // dateReg
            // 
            this.dateReg.AutoSize = true;
            this.dateReg.Location = new System.Drawing.Point(53, 442);
            this.dateReg.Name = "dateReg";
            this.dateReg.Size = new System.Drawing.Size(103, 13);
            this.dateReg.TabIndex = 20;
            this.dateReg.Text = "Дата регистрации:";
            // 
            // dateTestBox
            // 
            this.dateTestBox.Location = new System.Drawing.Point(162, 413);
            this.dateTestBox.Name = "dateTestBox";
            this.dateTestBox.Size = new System.Drawing.Size(123, 20);
            this.dateTestBox.TabIndex = 17;
            // 
            // dateTest
            // 
            this.dateTest.AutoSize = true;
            this.dateTest.Location = new System.Drawing.Point(62, 416);
            this.dateTest.Name = "dateTest";
            this.dateTest.Size = new System.Drawing.Size(94, 13);
            this.dateTest.TabIndex = 18;
            this.dateTest.Text = "Дата испытания:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(214, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Данные протокола";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(567, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Параметры среды";
            // 
            // wetBox
            // 
            this.wetBox.Location = new System.Drawing.Point(551, 111);
            this.wetBox.Name = "wetBox";
            this.wetBox.Size = new System.Drawing.Size(168, 20);
            this.wetBox.TabIndex = 8;
            this.wetBox.Text = "65";
            // 
            // wet
            // 
            this.wet.AutoSize = true;
            this.wet.Location = new System.Drawing.Point(482, 114);
            this.wet.Name = "wet";
            this.wet.Size = new System.Drawing.Size(66, 13);
            this.wet.TabIndex = 12;
            this.wet.Text = "Влажность:";
            // 
            // pressBox
            // 
            this.pressBox.Location = new System.Drawing.Point(551, 85);
            this.pressBox.Name = "pressBox";
            this.pressBox.Size = new System.Drawing.Size(168, 20);
            this.pressBox.TabIndex = 7;
            this.pressBox.Text = "760";
            // 
            // press
            // 
            this.press.AutoSize = true;
            this.press.Location = new System.Drawing.Point(417, 88);
            this.press.Name = "press";
            this.press.Size = new System.Drawing.Size(131, 13);
            this.press.TabIndex = 10;
            this.press.Text = "Атмосферное давление:";
            // 
            // tempBox
            // 
            this.tempBox.Location = new System.Drawing.Point(551, 59);
            this.tempBox.Name = "tempBox";
            this.tempBox.Size = new System.Drawing.Size(168, 20);
            this.tempBox.TabIndex = 6;
            this.tempBox.Text = "22";
            // 
            // temp
            // 
            this.temp.AutoSize = true;
            this.temp.Location = new System.Drawing.Point(471, 62);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(77, 13);
            this.temp.TabIndex = 8;
            this.temp.Text = "Температура:";
            // 
            // objAddBox
            // 
            this.objAddBox.Location = new System.Drawing.Point(162, 177);
            this.objAddBox.Name = "objAddBox";
            this.objAddBox.Size = new System.Drawing.Size(239, 20);
            this.objAddBox.TabIndex = 4;
            // 
            // objAdd
            // 
            this.objAdd.AutoSize = true;
            this.objAdd.Location = new System.Drawing.Point(66, 180);
            this.objAdd.Name = "objAdd";
            this.objAdd.Size = new System.Drawing.Size(90, 13);
            this.objAdd.TabIndex = 6;
            this.objAdd.Text = "Присоединение:";
            // 
            // agency
            // 
            this.agency.AutoSize = true;
            this.agency.Location = new System.Drawing.Point(15, 154);
            this.agency.Name = "agency";
            this.agency.Size = new System.Drawing.Size(141, 13);
            this.agency.TabIndex = 5;
            this.agency.Text = "Пусконаладочная орг-ция:";
            // 
            // agencyBox
            // 
            this.agencyBox.Location = new System.Drawing.Point(162, 151);
            this.agencyBox.Name = "agencyBox";
            this.agencyBox.Size = new System.Drawing.Size(239, 20);
            this.agencyBox.TabIndex = 3;
            this.agencyBox.Text = "ООО «ВСТ-И»";
            // 
            // objctBox
            // 
            this.objctBox.BackColor = System.Drawing.SystemColors.Window;
            this.objctBox.Location = new System.Drawing.Point(162, 85);
            this.objctBox.Multiline = true;
            this.objctBox.Name = "objctBox";
            this.objctBox.Size = new System.Drawing.Size(239, 60);
            this.objctBox.TabIndex = 2;
            // 
            // objct
            // 
            this.objct.AutoSize = true;
            this.objct.Location = new System.Drawing.Point(108, 88);
            this.objct.Name = "objct";
            this.objct.Size = new System.Drawing.Size(48, 13);
            this.objct.TabIndex = 2;
            this.objct.Text = "Объект:";
            // 
            // costumerBox
            // 
            this.costumerBox.Location = new System.Drawing.Point(162, 59);
            this.costumerBox.Name = "costumerBox";
            this.costumerBox.Size = new System.Drawing.Size(239, 20);
            this.costumerBox.TabIndex = 1;
            this.costumerBox.Text = "АО «Полюс Магадан»";
            // 
            // customer
            // 
            this.customer.AutoSize = true;
            this.customer.Location = new System.Drawing.Point(98, 62);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(58, 13);
            this.customer.TabIndex = 0;
            this.customer.Text = "Заказчик:";
            // 
            // tabControlPanel
            // 
            this.tabControlPanel.Controls.Add(this.mainTab);
            this.tabControlPanel.Controls.Add(this.cablLine);
            this.tabControlPanel.Location = new System.Drawing.Point(12, 12);
            this.tabControlPanel.Name = "tabControlPanel";
            this.tabControlPanel.SelectedIndex = 0;
            this.tabControlPanel.Size = new System.Drawing.Size(1033, 581);
            this.tabControlPanel.TabIndex = 1;
            // 
            // контрольные_кабелиTableAdapter
            // 
            this.контрольные_кабелиTableAdapter.ClearBeforeFill = true;
            // 
            // NumOfRow
            // 
            this.NumOfRow.HeaderText = "№";
            this.NumOfRow.Name = "NumOfRow";
            this.NumOfRow.ReadOnly = true;
            // 
            // objAddCell
            // 
            this.objAddCell.HeaderText = "Присоединение";
            this.objAddCell.Name = "objAddCell";
            // 
            // MarkOfCableCell
            // 
            this.MarkOfCableCell.AutoComplete = false;
            this.MarkOfCableCell.DataSource = this.контрольныеКабелиBindingSource;
            this.MarkOfCableCell.DisplayMember = "Марка";
            this.MarkOfCableCell.HeaderText = "Марка";
            this.MarkOfCableCell.Name = "MarkOfCableCell";
            // 
            // sechXjilCell
            // 
            this.sechXjilCell.HeaderText = "Сечение х Число жил";
            this.sechXjilCell.Name = "sechXjilCell";
            // 
            // lengthCell
            // 
            this.lengthCell.HeaderText = "Длина, м";
            this.lengthCell.Name = "lengthCell";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 598);
            this.Controls.Add(this.tabControlPanel);
            this.Name = "mainForm";
            this.Text = "ProtocolAuto";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.cablLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableOfCableLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.контрольныеКабелиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDBDataSet)).EndInit();
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.tabControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox protListBox;
        private System.Windows.Forms.TextBox testPersBox3;
        private System.Windows.Forms.TextBox testPersBox2;
        private System.Windows.Forms.TextBox testPersBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox protNumBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fioBox4;
        private System.Windows.Forms.Button creat;
        private System.Windows.Forms.TextBox auditBox;
        private System.Windows.Forms.Label audit;
        private System.Windows.Forms.TextBox fioBox3;
        private System.Windows.Forms.TextBox fioBox2;
        private System.Windows.Forms.TextBox fioBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label testPers;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabPage cablLine;
        private System.Windows.Forms.TextBox dateRegBox;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.Label dateReg;
        private System.Windows.Forms.TextBox dateTestBox;
        private System.Windows.Forms.Label dateTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wetBox;
        private System.Windows.Forms.Label wet;
        private System.Windows.Forms.TextBox pressBox;
        private System.Windows.Forms.Label press;
        private System.Windows.Forms.TextBox tempBox;
        private System.Windows.Forms.Label temp;
        private System.Windows.Forms.TextBox objAddBox;
        private System.Windows.Forms.Label objAdd;
        private System.Windows.Forms.Label agency;
        private System.Windows.Forms.TextBox agencyBox;
        private System.Windows.Forms.TextBox objctBox;
        private System.Windows.Forms.Label objct;
        private System.Windows.Forms.TextBox costumerBox;
        private System.Windows.Forms.Label customer;
        private System.Windows.Forms.TabControl tabControlPanel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView TableOfCableLine;
        private ProtocolAutoTest.TableDBDataSet tableDBDataSet;
        private System.Windows.Forms.BindingSource контрольныеКабелиBindingSource;
        private ProtocolAutoTest.TableDBDataSetTableAdapters.Контрольные_кабелиTableAdapter контрольные_кабелиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn objAddCell;
        private System.Windows.Forms.DataGridViewComboBoxColumn MarkOfCableCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn sechXjilCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthCell;
    }
}

