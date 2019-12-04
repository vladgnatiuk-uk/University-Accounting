namespace UniversityAccounting
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.cbChange = new System.Windows.Forms.ComboBox();
            this.rbEmp = new System.Windows.Forms.RadioButton();
            this.rbStud = new System.Windows.Forms.RadioButton();
            this.lblCalc = new System.Windows.Forms.Label();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.dateTasks = new System.Windows.Forms.DateTimePicker();
            this.txtCalc1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbCalcChoose = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cbViewPage = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.cbAdd = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.unAccountingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unAccountingDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 374);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(639, 348);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Головна";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(640, 349);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.button2);
            this.tabPage5.Controls.Add(this.cbCalcChoose);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(632, 323);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Обчислення";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbEdit);
            this.groupBox1.Controls.Add(this.lblCalc);
            this.groupBox1.Controls.Add(this.dgvTasks);
            this.groupBox1.Controls.Add(this.dateTasks);
            this.groupBox1.Controls.Add(this.txtCalc1);
            this.groupBox1.Location = new System.Drawing.Point(21, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 245);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результат";
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.btnChange);
            this.gbEdit.Controls.Add(this.cbChange);
            this.gbEdit.Controls.Add(this.rbEmp);
            this.gbEdit.Controls.Add(this.rbStud);
            this.gbEdit.Location = new System.Drawing.Point(27, 94);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(327, 145);
            this.gbEdit.TabIndex = 3;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Вибір людини";
            this.gbEdit.Visible = false;
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(18, 100);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(156, 32);
            this.btnChange.TabIndex = 5;
            this.btnChange.Text = "Показати інформацію";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // cbChange
            // 
            this.cbChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChange.FormattingEnabled = true;
            this.cbChange.Location = new System.Drawing.Point(144, 27);
            this.cbChange.Name = "cbChange";
            this.cbChange.Size = new System.Drawing.Size(155, 21);
            this.cbChange.TabIndex = 4;
            // 
            // rbEmp
            // 
            this.rbEmp.AutoSize = true;
            this.rbEmp.Location = new System.Drawing.Point(18, 51);
            this.rbEmp.Name = "rbEmp";
            this.rbEmp.Size = new System.Drawing.Size(89, 17);
            this.rbEmp.TabIndex = 3;
            this.rbEmp.Text = "Співробітник";
            this.rbEmp.UseVisualStyleBackColor = true;
            this.rbEmp.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbStud
            // 
            this.rbStud.AutoSize = true;
            this.rbStud.Location = new System.Drawing.Point(18, 27);
            this.rbStud.Name = "rbStud";
            this.rbStud.Size = new System.Drawing.Size(65, 17);
            this.rbStud.TabIndex = 2;
            this.rbStud.Text = "Студент";
            this.rbStud.UseVisualStyleBackColor = true;
            this.rbStud.CheckedChanged += new System.EventHandler(this.rbStud_CheckedChanged);
            // 
            // lblCalc
            // 
            this.lblCalc.AutoSize = true;
            this.lblCalc.Location = new System.Drawing.Point(24, 36);
            this.lblCalc.Name = "lblCalc";
            this.lblCalc.Size = new System.Drawing.Size(535, 13);
            this.lblCalc.TabIndex = 0;
            this.lblCalc.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---------------";
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(0, 0);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.Size = new System.Drawing.Size(603, 249);
            this.dgvTasks.TabIndex = 4;
            this.dgvTasks.Visible = false;
            // 
            // dateTasks
            // 
            this.dateTasks.Location = new System.Drawing.Point(27, 52);
            this.dateTasks.Name = "dateTasks";
            this.dateTasks.Size = new System.Drawing.Size(131, 20);
            this.dateTasks.TabIndex = 5;
            this.dateTasks.Visible = false;
            this.dateTasks.ValueChanged += new System.EventHandler(this.dateTasks_ValueChanged);
            // 
            // txtCalc1
            // 
            this.txtCalc1.Location = new System.Drawing.Point(27, 52);
            this.txtCalc1.Name = "txtCalc1";
            this.txtCalc1.ReadOnly = true;
            this.txtCalc1.Size = new System.Drawing.Size(131, 20);
            this.txtCalc1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Виконати";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbCalcChoose
            // 
            this.cbCalcChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalcChoose.FormattingEnabled = true;
            this.cbCalcChoose.Items.AddRange(new object[] {
            "Затрати університету",
            "Затрати на співробітників(Підрахунок)",
            "Затрати на студентів(Підрахунок)",
            "Кількість студентів",
            "Кількість співробітників",
            "Загальна кількість людей",
            "Інформація про співробітника/студента",
            "Затрати на співробітників",
            "Затрати на студентів",
            "Підрахунок оплат",
            "Показати людей с вказаної дати народження"});
            this.cbCalcChoose.Location = new System.Drawing.Point(21, 25);
            this.cbCalcChoose.Name = "cbCalcChoose";
            this.cbCalcChoose.Size = new System.Drawing.Size(215, 21);
            this.cbCalcChoose.TabIndex = 0;
            this.cbCalcChoose.SelectedIndexChanged += new System.EventHandler(this.cbCalcChoose_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.cbViewPage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(639, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Відображення";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(25, 75);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(594, 251);
            this.dataGridView.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Показати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbViewPage
            // 
            this.cbViewPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViewPage.FormattingEnabled = true;
            this.cbViewPage.Items.AddRange(new object[] {
            "Співробітники",
            "Персональна інформація співробітників",
            "Посади",
            "Студенти",
            "Персональна інформація студентів",
            "Оплати"});
            this.cbViewPage.Location = new System.Drawing.Point(285, 37);
            this.cbViewPage.Name = "cbViewPage";
            this.cbViewPage.Size = new System.Drawing.Size(229, 21);
            this.cbViewPage.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.cbAdd);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(639, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Введення даних";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 41);
            this.button3.TabIndex = 9;
            this.button3.Text = "Додати";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbAdd
            // 
            this.cbAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdd.FormattingEnabled = true;
            this.cbAdd.Items.AddRange(new object[] {
            "Співробітник",
            "Студент"});
            this.cbAdd.Location = new System.Drawing.Point(186, 244);
            this.cbAdd.Name = "cbAdd";
            this.cbAdd.Size = new System.Drawing.Size(402, 21);
            this.cbAdd.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(186, 180);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(402, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 116);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(402, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(402, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Виберіть статус : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Введіть ім\'я по батькові : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введіть прізвище : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введіть ім\'я :";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 372);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Бухгалтерия университета";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEdit.ResumeLayout(false);
            this.gbEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unAccountingDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.BindingSource unAccountingDataSetBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbViewPage;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox cbCalcChoose;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbAdd;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCalc1;
        private System.Windows.Forms.Label lblCalc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.RadioButton rbEmp;
        private System.Windows.Forms.RadioButton rbStud;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox cbChange;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DateTimePicker dateTasks;
    }
}

