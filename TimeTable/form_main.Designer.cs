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
            this.ms_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_bd = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_del = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_delday = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_delall = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_library = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_teachers = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_lections = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Day = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_day_next = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_day_back = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_about = new System.Windows.Forms.ToolStripMenuItem();
            this.b_addgroup = new System.Windows.Forms.Button();
            this.nud_sem = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_subgroups = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_parttime = new System.Windows.Forms.RadioButton();
            this.rb_fulltime = new System.Windows.Forms.RadioButton();
            this.grid = new SourceGrid.Grid();
            this.validatorTypeConverter1 = new DevAge.ComponentModel.Validator.ValidatorTypeConverter();
            this.ds_timetable = new TimeTable.ds_db();
            this.ft_timetableTableAdapter = new TimeTable.ds_dbTableAdapters.ft_timetableTableAdapter();
            this.tam_db = new TimeTable.ds_dbTableAdapters.TableAdapterManager();
            this.lessonsTableAdapter = new TimeTable.ds_dbTableAdapters.LessonsTableAdapter();
            this.pt_timetableTableAdapter = new TimeTable.ds_dbTableAdapters.pt_timetableTableAdapter();
            this.teachersTableAdapter = new TimeTable.ds_dbTableAdapters.TeachersTableAdapter();
            this.getGroupsFTTableAdapter = new TimeTable.ds_dbTableAdapters.getGroupsFTTableAdapter();
            this.getGroupsPTTableAdapter = new TimeTable.ds_dbTableAdapters.getGroupsPTTableAdapter();
            this.but_prevDay = new System.Windows.Forms.Button();
            this.but_nextDay = new System.Windows.Forms.Button();
            this.ms_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sem)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_subgroups)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).BeginInit();
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
            this.ms_bd,
            this.ms_settings,
            this.ms_about});
            this.ms_menu.Location = new System.Drawing.Point(0, 0);
            this.ms_menu.Name = "ms_menu";
            this.ms_menu.Size = new System.Drawing.Size(540, 24);
            this.ms_menu.TabIndex = 6;
            this.ms_menu.Text = "menuStrip1";
            // 
            // ms_file
            // 
            this.ms_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_saveas,
            this.ms_exit});
            this.ms_file.Name = "ms_file";
            this.ms_file.Size = new System.Drawing.Size(48, 20);
            this.ms_file.Text = "Файл";
            // 
            // ms_saveas
            // 
            this.ms_saveas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_saveas_xls});
            this.ms_saveas.Name = "ms_saveas";
            this.ms_saveas.Size = new System.Drawing.Size(119, 22);
            this.ms_saveas.Text = "Экспорт";
            // 
            // ms_saveas_xls
            // 
            this.ms_saveas_xls.Name = "ms_saveas_xls";
            this.ms_saveas_xls.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.ms_saveas_xls.Size = new System.Drawing.Size(149, 22);
            this.ms_saveas_xls.Text = "в Excel";
            this.ms_saveas_xls.Click += new System.EventHandler(this.ms_saveas_xls_Click);
            // 
            // ms_exit
            // 
            this.ms_exit.Name = "ms_exit";
            this.ms_exit.Size = new System.Drawing.Size(119, 22);
            this.ms_exit.Text = "Выйти";
            this.ms_exit.Click += new System.EventHandler(this.ms_exit_Click);
            // 
            // ms_bd
            // 
            this.ms_bd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_refresh,
            this.ms_del,
            this.ms_library,
            this.ms_Day});
            this.ms_bd.Name = "ms_bd";
            this.ms_bd.Size = new System.Drawing.Size(88, 20);
            this.ms_bd.Text = "База Данных";
            // 
            // ms_refresh
            // 
            this.ms_refresh.Name = "ms_refresh";
            this.ms_refresh.ShortcutKeyDisplayString = "";
            this.ms_refresh.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ms_refresh.Size = new System.Drawing.Size(169, 22);
            this.ms_refresh.Text = "Обновить";
            this.ms_refresh.Click += new System.EventHandler(this.ms_refresh_Click);
            // 
            // ms_del
            // 
            this.ms_del.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_delday,
            this.ms_delall});
            this.ms_del.Name = "ms_del";
            this.ms_del.Size = new System.Drawing.Size(169, 22);
            this.ms_del.Text = "Удалить пары...";
            // 
            // ms_delday
            // 
            this.ms_delday.Name = "ms_delday";
            this.ms_delday.Size = new System.Drawing.Size(166, 22);
            this.ms_delday.Text = "за день у группы";
            this.ms_delday.Click += new System.EventHandler(this.ms_delday_Click);
            // 
            // ms_delall
            // 
            this.ms_delall.Name = "ms_delall";
            this.ms_delall.Size = new System.Drawing.Size(166, 22);
            this.ms_delall.Text = "у всей группы";
            this.ms_delall.Click += new System.EventHandler(this.ms_delall_Click);
            // 
            // ms_library
            // 
            this.ms_library.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_teachers,
            this.ms_lections});
            this.ms_library.Name = "ms_library";
            this.ms_library.Size = new System.Drawing.Size(169, 22);
            this.ms_library.Text = "Справочники";
            // 
            // ms_teachers
            // 
            this.ms_teachers.Name = "ms_teachers";
            this.ms_teachers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.ms_teachers.Size = new System.Drawing.Size(200, 22);
            this.ms_teachers.Text = "Преподаватели";
            this.ms_teachers.Click += new System.EventHandler(this.ms_teachers_Click);
            // 
            // ms_lections
            // 
            this.ms_lections.Name = "ms_lections";
            this.ms_lections.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.ms_lections.Size = new System.Drawing.Size(200, 22);
            this.ms_lections.Text = "Занятия";
            this.ms_lections.Click += new System.EventHandler(this.ms_lections_Click);
            // 
            // ms_Day
            // 
            this.ms_Day.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_day_next,
            this.ms_day_back});
            this.ms_Day.Name = "ms_Day";
            this.ms_Day.Size = new System.Drawing.Size(169, 22);
            this.ms_Day.Text = "День";
            // 
            // ms_day_next
            // 
            this.ms_day_next.Name = "ms_day_next";
            this.ms_day_next.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ms_day_next.Size = new System.Drawing.Size(189, 22);
            this.ms_day_next.Text = "Следущий";
            this.ms_day_next.Click += new System.EventHandler(this.ms_day_next_Click);
            // 
            // ms_day_back
            // 
            this.ms_day_back.Name = "ms_day_back";
            this.ms_day_back.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.ms_day_back.Size = new System.Drawing.Size(189, 22);
            this.ms_day_back.Text = "Предыдущий";
            this.ms_day_back.Click += new System.EventHandler(this.ms_day_back_Click);
            // 
            // ms_settings
            // 
            this.ms_settings.Name = "ms_settings";
            this.ms_settings.Size = new System.Drawing.Size(79, 20);
            this.ms_settings.Text = "Настройки";
            this.ms_settings.Click += new System.EventHandler(this.ms_settings_Click);
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nud_subgroups);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Подгрупп:";
            // 
            // nud_subgroups
            // 
            this.nud_subgroups.Location = new System.Drawing.Point(320, 14);
            this.nud_subgroups.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_subgroups.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_subgroups.Name = "nud_subgroups";
            this.nud_subgroups.Size = new System.Drawing.Size(58, 20);
            this.nud_subgroups.TabIndex = 13;
            this.nud_subgroups.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.rb_parttime.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
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
            this.rb_fulltime.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.EnableSort = true;
            this.grid.Location = new System.Drawing.Point(12, 107);
            this.grid.Name = "grid";
            this.grid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid.Size = new System.Drawing.Size(516, 330);
            this.grid.TabIndex = 13;
            this.grid.TabStop = true;
            this.grid.ToolTipText = "";
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
            // but_prevDay
            // 
            this.but_prevDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_prevDay.Location = new System.Drawing.Point(12, 445);
            this.but_prevDay.Name = "but_prevDay";
            this.but_prevDay.Size = new System.Drawing.Size(75, 23);
            this.but_prevDay.TabIndex = 15;
            this.but_prevDay.Text = "<<";
            this.but_prevDay.UseVisualStyleBackColor = true;
            this.but_prevDay.Click += new System.EventHandler(this.but_prevDay_Click);
            // 
            // but_nextDay
            // 
            this.but_nextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_nextDay.Location = new System.Drawing.Point(453, 445);
            this.but_nextDay.Name = "but_nextDay";
            this.but_nextDay.Size = new System.Drawing.Size(75, 23);
            this.but_nextDay.TabIndex = 16;
            this.but_nextDay.Text = ">>";
            this.but_nextDay.UseVisualStyleBackColor = true;
            this.but_nextDay.Click += new System.EventHandler(this.but_nextDay_Click);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 480);
            this.Controls.Add(this.but_nextDay);
            this.Controls.Add(this.but_prevDay);
            this.Controls.Add(this.grid);
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
            ((System.ComponentModel.ISupportInitialize)(this.nud_subgroups)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ds_dbTableAdapters.ft_timetableTableAdapter ft_timetableTableAdapter;
        private ds_dbTableAdapters.TableAdapterManager tam_db;
        private ds_dbTableAdapters.LessonsTableAdapter lessonsTableAdapter;
        private ds_dbTableAdapters.pt_timetableTableAdapter pt_timetableTableAdapter;
        private ds_dbTableAdapters.TeachersTableAdapter teachersTableAdapter;
        private ds_dbTableAdapters.getGroupsFTTableAdapter getGroupsFTTableAdapter;
        private ds_dbTableAdapters.getGroupsPTTableAdapter getGroupsPTTableAdapter;
        private System.Windows.Forms.MenuStrip ms_menu;
        private System.Windows.Forms.ToolStripMenuItem ms_file;
        private System.Windows.Forms.ToolStripMenuItem ms_saveas;
        private System.Windows.Forms.ToolStripMenuItem ms_saveas_xls;
        private System.Windows.Forms.ToolStripMenuItem ms_exit;
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
        private DevAge.ComponentModel.Validator.ValidatorTypeConverter validatorTypeConverter1;
        public System.Windows.Forms.ComboBox cb_groups;
        public System.Windows.Forms.ComboBox cb_days;
        public ds_db ds_timetable;
        public SourceGrid.Grid grid;
        private System.Windows.Forms.ToolStripMenuItem ms_settings;
        private System.Windows.Forms.Button but_prevDay;
        private System.Windows.Forms.Button but_nextDay;
        private System.Windows.Forms.NumericUpDown nud_subgroups;
        private System.Windows.Forms.ToolStripMenuItem ms_bd;
        private System.Windows.Forms.ToolStripMenuItem ms_refresh;
        private System.Windows.Forms.ToolStripMenuItem ms_del;
        private System.Windows.Forms.ToolStripMenuItem ms_delday;
        private System.Windows.Forms.ToolStripMenuItem ms_delall;
        private System.Windows.Forms.ToolStripMenuItem ms_library;
        private System.Windows.Forms.ToolStripMenuItem ms_teachers;
        private System.Windows.Forms.ToolStripMenuItem ms_lections;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem ms_Day;
        private System.Windows.Forms.ToolStripMenuItem ms_day_next;
        private System.Windows.Forms.ToolStripMenuItem ms_day_back;
    }
}

