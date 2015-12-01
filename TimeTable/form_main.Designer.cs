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
            this.dgv_maintable = new System.Windows.Forms.DataGridView();
            this.col_Monday_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Monday_Lesson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Monday_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_subgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Monday_WeekOne = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Monday_WeekTwo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Monday_Audit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_groups = new System.Windows.Forms.ComboBox();
            this.cb_days = new System.Windows.Forms.ComboBox();
            this.but_prevDay = new System.Windows.Forms.Button();
            this.but_nextDay = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_maintable)).BeginInit();
            this.ms_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_maintable
            // 
            this.dgv_maintable.AllowUserToResizeRows = false;
            this.dgv_maintable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_maintable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_maintable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Monday_Number,
            this.col_Monday_Lesson,
            this.col_Monday_Teacher,
            this.col_subgroup,
            this.col_Monday_WeekOne,
            this.col_Monday_WeekTwo,
            this.col_Monday_Audit});
            this.dgv_maintable.Location = new System.Drawing.Point(12, 108);
            this.dgv_maintable.Name = "dgv_maintable";
            this.dgv_maintable.RowHeadersVisible = false;
            this.dgv_maintable.Size = new System.Drawing.Size(533, 234);
            this.dgv_maintable.TabIndex = 0;
            this.dgv_maintable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_maintable_CellBeginEdit);
            this.dgv_maintable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_maintable_CellEndEdit);
            this.dgv_maintable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_maintable_CellValueChanged);
            this.dgv_maintable.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_maintable_EditingControlShowing);
            // 
            // col_Monday_Number
            // 
            this.col_Monday_Number.HeaderText = "№";
            this.col_Monday_Number.Name = "col_Monday_Number";
            this.col_Monday_Number.Width = 30;
            // 
            // col_Monday_Lesson
            // 
            this.col_Monday_Lesson.HeaderText = "Предмет";
            this.col_Monday_Lesson.Name = "col_Monday_Lesson";
            // 
            // col_Monday_Teacher
            // 
            this.col_Monday_Teacher.HeaderText = "Преподаватель";
            this.col_Monday_Teacher.Name = "col_Monday_Teacher";
            // 
            // col_subgroup
            // 
            this.col_subgroup.HeaderText = "Подгруппа";
            this.col_subgroup.Name = "col_subgroup";
            // 
            // col_Monday_WeekOne
            // 
            this.col_Monday_WeekOne.HeaderText = "Первая неделя";
            this.col_Monday_WeekOne.Name = "col_Monday_WeekOne";
            this.col_Monday_WeekOne.Width = 50;
            // 
            // col_Monday_WeekTwo
            // 
            this.col_Monday_WeekTwo.HeaderText = "Вторая неделя";
            this.col_Monday_WeekTwo.Name = "col_Monday_WeekTwo";
            this.col_Monday_WeekTwo.Width = 50;
            // 
            // col_Monday_Audit
            // 
            this.col_Monday_Audit.HeaderText = "№ аудитории";
            this.col_Monday_Audit.Name = "col_Monday_Audit";
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
            // but_prevDay
            // 
            this.but_prevDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_prevDay.Location = new System.Drawing.Point(12, 348);
            this.but_prevDay.Name = "but_prevDay";
            this.but_prevDay.Size = new System.Drawing.Size(75, 23);
            this.but_prevDay.TabIndex = 4;
            this.but_prevDay.Text = "<<";
            this.but_prevDay.UseVisualStyleBackColor = true;
            this.but_prevDay.Click += new System.EventHandler(this.but_prevDay_Click);
            // 
            // but_nextDay
            // 
            this.but_nextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_nextDay.Location = new System.Drawing.Point(470, 348);
            this.but_nextDay.Name = "but_nextDay";
            this.but_nextDay.Size = new System.Drawing.Size(75, 23);
            this.but_nextDay.TabIndex = 5;
            this.but_nextDay.Text = ">>";
            this.but_nextDay.UseVisualStyleBackColor = true;
            this.but_nextDay.Click += new System.EventHandler(this.but_nextDay_Click);
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
            this.ms_menu.Size = new System.Drawing.Size(557, 24);
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
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 381);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_nextDay);
            this.Controls.Add(this.but_prevDay);
            this.Controls.Add(this.dgv_maintable);
            this.Controls.Add(this.ms_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_menu;
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "form_main";
            this.Text = "Расписание занятий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.Load += new System.EventHandler(this.form_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_maintable)).EndInit();
            this.ms_menu.ResumeLayout(false);
            this.ms_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_maintable;
        private System.Windows.Forms.ComboBox cb_groups;
        private System.Windows.Forms.ComboBox cb_days;
        private System.Windows.Forms.Button but_prevDay;
        private System.Windows.Forms.Button but_nextDay;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Lesson;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_subgroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Monday_WeekOne;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Monday_WeekTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Audit;
    }
}

