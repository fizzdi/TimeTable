namespace TimeTable
{
    partial class form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.cb_groups = new System.Windows.Forms.ComboBox();
            this.cb_days = new System.Windows.Forms.ComboBox();
            this.ms_menu = new System.Windows.Forms.MenuStrip();
            this.ms_file = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_saveas = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_saveas_xls = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_saveas_xlsx = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_config = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_help = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_about = new System.Windows.Forms.ToolStripMenuItem();
            this.b_addgroup = new System.Windows.Forms.Button();
            this.nud_sem = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_parttime = new System.Windows.Forms.RadioButton();
            this.rb_fulltime = new System.Windows.Forms.RadioButton();
            this.ds_timetable = new TimeTable.ds_db();
            this.ft_timetableTableAdapter = new TimeTable.ds_dbTableAdapters.ft_timetableTableAdapter();
            this.tam_db = new TimeTable.ds_dbTableAdapters.TableAdapterManager();
            this.lessonsTableAdapter = new TimeTable.ds_dbTableAdapters.LessonsTableAdapter();
            this.pt_timetableTableAdapter = new TimeTable.ds_dbTableAdapters.pt_timetableTableAdapter();
            this.teachersTableAdapter = new TimeTable.ds_dbTableAdapters.TeachersTableAdapter();
            this.getGroupsFTTableAdapter = new TimeTable.ds_dbTableAdapters.getGroupsFTTableAdapter();
            this.getGroupsPTTableAdapter = new TimeTable.ds_dbTableAdapters.getGroupsPTTableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.ms_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_groups
            // 
            this.cb_groups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_groups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cb_groups.FormattingEnabled = true;
            this.cb_groups.Location = new System.Drawing.Point(69, 40);
            this.cb_groups.Name = "cb_groups";
            this.cb_groups.Size = new System.Drawing.Size(51, 21);
            this.cb_groups.TabIndex = 1;
            this.cb_groups.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // cb_days
            // 
            this.cb_days.FormattingEnabled = true;
            this.cb_days.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота"});
            this.cb_days.Location = new System.Drawing.Point(257, 40);
            this.cb_days.Name = "cb_days";
            this.cb_days.Size = new System.Drawing.Size(121, 21);
            this.cb_days.TabIndex = 2;
            this.cb_days.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // ms_menu
            // 
            this.ms_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_file,
            this.ms_refresh,
            this.ms_help,
            this.ms_about});
            this.ms_menu.Location = new System.Drawing.Point(0, 0);
            this.ms_menu.Name = "ms_menu";
            this.ms_menu.Size = new System.Drawing.Size(619, 24);
            this.ms_menu.TabIndex = 6;
            this.ms_menu.Text = "menuStrip1";
            // 
            // ms_file
            // 
            this.ms_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_saveas,
            this.ms_config,
            this.ms_exit});
            this.ms_file.Name = "ms_file";
            this.ms_file.Size = new System.Drawing.Size(48, 20);
            this.ms_file.Text = "Файл";
            // 
            // ms_saveas
            // 
            this.ms_saveas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_saveas_xls,
            this.ms_saveas_xlsx});
            this.ms_saveas.Name = "ms_saveas";
            this.ms_saveas.Size = new System.Drawing.Size(162, 22);
            this.ms_saveas.Text = "Сохранить как...";
            // 
            // ms_saveas_xls
            // 
            this.ms_saveas_xls.Name = "ms_saveas_xls";
            this.ms_saveas_xls.Size = new System.Drawing.Size(100, 22);
            this.ms_saveas_xls.Text = "XLS";
            // 
            // ms_saveas_xlsx
            // 
            this.ms_saveas_xlsx.Name = "ms_saveas_xlsx";
            this.ms_saveas_xlsx.Size = new System.Drawing.Size(100, 22);
            this.ms_saveas_xlsx.Text = "XLSX";
            // 
            // ms_config
            // 
            this.ms_config.Name = "ms_config";
            this.ms_config.Size = new System.Drawing.Size(162, 22);
            this.ms_config.Text = "Настройки";
            // 
            // ms_exit
            // 
            this.ms_exit.Name = "ms_exit";
            this.ms_exit.Size = new System.Drawing.Size(162, 22);
            this.ms_exit.Text = "Выйти";
            this.ms_exit.Click += new System.EventHandler(this.ms_exit_Click);
            // 
            // ms_refresh
            // 
            this.ms_refresh.Name = "ms_refresh";
            this.ms_refresh.Size = new System.Drawing.Size(73, 20);
            this.ms_refresh.Text = "Обновить";
            this.ms_refresh.Click += new System.EventHandler(this.ms_refresh_Click);
            // 
            // ms_help
            // 
            this.ms_help.Name = "ms_help";
            this.ms_help.Size = new System.Drawing.Size(65, 20);
            this.ms_help.Text = "Справка";
            // 
            // ms_about
            // 
            this.ms_about.Name = "ms_about";
            this.ms_about.Size = new System.Drawing.Size(94, 20);
            this.ms_about.Text = "О программе";
            this.ms_about.Click += new System.EventHandler(this.ms_about_Click);
            // 
            // b_addgroup
            // 
            this.b_addgroup.Location = new System.Drawing.Point(131, 39);
            this.b_addgroup.Name = "b_addgroup";
            this.b_addgroup.Size = new System.Drawing.Size(87, 23);
            this.b_addgroup.TabIndex = 8;
            this.b_addgroup.TabStop = false;
            this.b_addgroup.Text = "&Новая группа";
            this.b_addgroup.UseVisualStyleBackColor = true;
            this.b_addgroup.Click += new System.EventHandler(this.b_addgroup_Click);
            // 
            // nud_sem
            // 
            this.nud_sem.Location = new System.Drawing.Point(69, 14);
            this.nud_sem.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_sem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_sem.Name = "nud_sem";
            this.nud_sem.Size = new System.Drawing.Size(51, 20);
            this.nud_sem.TabIndex = 9;
            this.nud_sem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Семестр:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.b_addgroup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_days);
            this.groupBox1.Controls.Add(this.nud_sem);
            this.groupBox1.Controls.Add(this.cb_groups);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 74);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расписание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "День:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Группа:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_parttime);
            this.groupBox2.Controls.Add(this.rb_fulltime);
            this.groupBox2.Location = new System.Drawing.Point(408, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 74);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Форма обучения:";
            // 
            // rb_parttime
            // 
            this.rb_parttime.AutoSize = true;
            this.rb_parttime.Location = new System.Drawing.Point(12, 43);
            this.rb_parttime.Name = "rb_parttime";
            this.rb_parttime.Size = new System.Drawing.Size(94, 17);
            this.rb_parttime.TabIndex = 1;
            this.rb_parttime.TabStop = true;
            this.rb_parttime.Text = "Очно-заочная";
            this.rb_parttime.UseVisualStyleBackColor = true;
            // 
            // rb_fulltime
            // 
            this.rb_fulltime.AutoSize = true;
            this.rb_fulltime.Checked = true;
            this.rb_fulltime.Location = new System.Drawing.Point(12, 20);
            this.rb_fulltime.Name = "rb_fulltime";
            this.rb_fulltime.Size = new System.Drawing.Size(56, 17);
            this.rb_fulltime.TabIndex = 0;
            this.rb_fulltime.TabStop = true;
            this.rb_fulltime.Text = "Очная";
            this.rb_fulltime.UseVisualStyleBackColor = true;
            // 
            // ds_timetable
            // 
            this.ds_timetable.DataSetName = "ds_db";
            this.ds_timetable.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ft_timetableTableAdapter
            // 
            this.ft_timetableTableAdapter.ClearBeforeFill = true;
            // 
            // tam_db
            // 
            this.tam_db.BackupDataSetBeforeUpdate = false;
            this.tam_db.ft_timetableTableAdapter = this.ft_timetableTableAdapter;
            this.tam_db.LessonsTableAdapter = this.lessonsTableAdapter;
            this.tam_db.pt_timetableTableAdapter = this.pt_timetableTableAdapter;
            this.tam_db.TeachersTableAdapter = this.teachersTableAdapter;
            this.tam_db.UpdateOrder = TimeTable.ds_dbTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lessonsTableAdapter
            // 
            this.lessonsTableAdapter.ClearBeforeFill = true;
            // 
            // pt_timetableTableAdapter
            // 
            this.pt_timetableTableAdapter.ClearBeforeFill = true;
            // 
            // teachersTableAdapter
            // 
            this.teachersTableAdapter.ClearBeforeFill = true;
            // 
            // getGroupsFTTableAdapter
            // 
            this.getGroupsFTTableAdapter.ClearBeforeFill = true;
            // 
            // getGroupsPTTableAdapter
            // 
            this.getGroupsPTTableAdapter.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Items.AddRange(new object[] {
            "1 (нет)",
            "2 (есть)",
            "3 (есть)",
            "4 (есть)",
            "5 (есть)",
            "6 (есть)",
            "7 (нет)",
            "8 (нет)"});
            this.listBox1.Location = new System.Drawing.Point(12, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 274);
            this.listBox1.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 314);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Пары:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(162, 107);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(445, 314);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Информация о выбранной паре:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Location = new System.Drawing.Point(7, 43);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(432, 129);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Первая неделя";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 2;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(8, 74);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(117, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Вторая подгруппа";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Первая подгруппа";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(107, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Есть пара";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Нет пары";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Преподаватель:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(133, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(206, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(133, 98);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(206, 20);
            this.textBox4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Преподаватель:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox10);
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.textBox5);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.textBox6);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.textBox7);
            this.groupBox6.Controls.Add(this.textBox8);
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.checkBox4);
            this.groupBox6.Location = new System.Drawing.Point(7, 178);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(432, 129);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Вторая неделя";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(133, 98);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(206, 20);
            this.textBox5.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Преподаватель:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(133, 46);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(206, 20);
            this.textBox6.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Преподаватель:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(133, 72);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(206, 20);
            this.textBox7.TabIndex = 3;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(133, 20);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(206, 20);
            this.textBox8.TabIndex = 2;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(8, 74);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(117, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Вторая подгруппа";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(8, 22);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(119, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "Первая подгруппа";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox9);
            this.groupBox7.Location = new System.Drawing.Point(346, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(80, 47);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Аудитория:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(7, 20);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(67, 20);
            this.textBox9.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox10);
            this.groupBox8.Location = new System.Drawing.Point(346, 71);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(80, 47);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Аудитория:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(7, 20);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(67, 20);
            this.textBox10.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox11);
            this.groupBox9.Location = new System.Drawing.Point(345, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(80, 47);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Аудитория:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(7, 20);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(67, 20);
            this.textBox11.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox12);
            this.groupBox10.Location = new System.Drawing.Point(346, 72);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(80, 47);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Аудитория:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(7, 20);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(67, 20);
            this.textBox12.TabIndex = 0;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 430);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ms_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_menu;
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "form_main";
            this.Text = "Расписание занятий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.Load += new System.EventHandler(this.form_main_Load);
            this.ms_menu.ResumeLayout(false);
            this.ms_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ds_db ds_timetable;
        private ds_dbTableAdapters.ft_timetableTableAdapter ft_timetableTableAdapter;
        private ds_dbTableAdapters.TableAdapterManager tam_db;
        private ds_dbTableAdapters.LessonsTableAdapter lessonsTableAdapter;
        private ds_dbTableAdapters.pt_timetableTableAdapter pt_timetableTableAdapter;
        private ds_dbTableAdapters.TeachersTableAdapter teachersTableAdapter;
        private ds_dbTableAdapters.getGroupsFTTableAdapter getGroupsFTTableAdapter;
        private ds_dbTableAdapters.getGroupsPTTableAdapter getGroupsPTTableAdapter;
        private System.Windows.Forms.ComboBox cb_groups;
        private System.Windows.Forms.ComboBox cb_days;
        private System.Windows.Forms.MenuStrip ms_menu;
        private System.Windows.Forms.ToolStripMenuItem ms_file;
        private System.Windows.Forms.ToolStripMenuItem ms_saveas;
        private System.Windows.Forms.ToolStripMenuItem ms_saveas_xls;
        private System.Windows.Forms.ToolStripMenuItem ms_saveas_xlsx;
        private System.Windows.Forms.ToolStripMenuItem ms_config;
        private System.Windows.Forms.ToolStripMenuItem ms_exit;
        private System.Windows.Forms.ToolStripMenuItem ms_refresh;
        private System.Windows.Forms.ToolStripMenuItem ms_help;
        private System.Windows.Forms.ToolStripMenuItem ms_about;
        private System.Windows.Forms.Button b_addgroup;
        private System.Windows.Forms.NumericUpDown nud_sem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_parttime;
        private System.Windows.Forms.RadioButton rb_fulltime;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox9;
    }
}

