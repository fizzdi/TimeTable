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
            this.dgv_ftMonday = new System.Windows.Forms.DataGridView();
            this.col_Monday_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Monday_Lesson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Monday_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Monday_WeekOne = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Monday_WeekTwo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Monday_Audit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_groups = new System.Windows.Forms.ComboBox();
            this.ds_timetable = new TimeTable.ds_db();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.but_nextDay = new System.Windows.Forms.Button();
            this.but_prevDay = new System.Windows.Forms.Button();
            this.cb_days = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ft_timetableTableAdapter = new TimeTable.ds_dbTableAdapters.ft_timetableTableAdapter();
            this.tam_db = new TimeTable.ds_dbTableAdapters.TableAdapterManager();
            this.lessonsTableAdapter = new TimeTable.ds_dbTableAdapters.LessonsTableAdapter();
            this.pt_timetableTableAdapter = new TimeTable.ds_dbTableAdapters.pt_timetableTableAdapter();
            this.teachersTableAdapter = new TimeTable.ds_dbTableAdapters.TeachersTableAdapter();
            this.getGroupsFTTableAdapter = new TimeTable.ds_dbTableAdapters.getGroupsFTTableAdapter();
            this.getGroupsPTTableAdapter = new TimeTable.ds_dbTableAdapters.getGroupsPTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ftMonday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ftMonday
            // 
            this.dgv_ftMonday.AllowUserToResizeRows = false;
            this.dgv_ftMonday.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ftMonday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ftMonday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Monday_Number,
            this.col_Monday_Lesson,
            this.col_Monday_Teacher,
            this.col_Monday_WeekOne,
            this.col_Monday_WeekTwo,
            this.col_Monday_Audit});
            this.dgv_ftMonday.Location = new System.Drawing.Point(6, 79);
            this.dgv_ftMonday.Name = "dgv_ftMonday";
            this.dgv_ftMonday.RowHeadersVisible = false;
            this.dgv_ftMonday.Size = new System.Drawing.Size(548, 229);
            this.dgv_ftMonday.TabIndex = 0;
            this.dgv_ftMonday.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_ftMonday_CellBeginEdit);
            this.dgv_ftMonday.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ftMonday_CellEndEdit);
            this.dgv_ftMonday.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_ftMonday_EditingControlShowing);
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
            // col_Monday_WeekOne
            // 
            this.col_Monday_WeekOne.HeaderText = "Первая неделя";
            this.col_Monday_WeekOne.Name = "col_Monday_WeekOne";
            // 
            // col_Monday_WeekTwo
            // 
            this.col_Monday_WeekTwo.HeaderText = "Вторая неделя";
            this.col_Monday_WeekTwo.Name = "col_Monday_WeekTwo";
            // 
            // col_Monday_Audit
            // 
            this.col_Monday_Audit.HeaderText = "№ аудитории";
            this.col_Monday_Audit.Name = "col_Monday_Audit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_groups
            // 
            this.cb_groups.DataSource = this.ds_timetable;
            this.cb_groups.DisplayMember = "getGroupsFT.GroupNumber";
            this.cb_groups.FormattingEnabled = true;
            this.cb_groups.Location = new System.Drawing.Point(43, 3);
            this.cb_groups.Name = "cb_groups";
            this.cb_groups.Size = new System.Drawing.Size(121, 21);
            this.cb_groups.TabIndex = 2;
            this.cb_groups.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // ds_timetable
            // 
            this.ds_timetable.DataSetName = "ds_db";
            this.ds_timetable.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 369);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.but_nextDay);
            this.tabPage1.Controls.Add(this.but_prevDay);
            this.tabPage1.Controls.Add(this.cb_days);
            this.tabPage1.Controls.Add(this.cb_groups);
            this.tabPage1.Controls.Add(this.dgv_ftMonday);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // but_nextDay
            // 
            this.but_nextDay.Location = new System.Drawing.Point(479, 314);
            this.but_nextDay.Name = "but_nextDay";
            this.but_nextDay.Size = new System.Drawing.Size(75, 23);
            this.but_nextDay.TabIndex = 5;
            this.but_nextDay.Text = ">>";
            this.but_nextDay.UseVisualStyleBackColor = true;
            this.but_nextDay.Click += new System.EventHandler(this.but_nextDay_Click);
            // 
            // but_prevDay
            // 
            this.but_prevDay.Location = new System.Drawing.Point(6, 314);
            this.but_prevDay.Name = "but_prevDay";
            this.but_prevDay.Size = new System.Drawing.Size(75, 23);
            this.but_prevDay.TabIndex = 4;
            this.but_prevDay.Text = "<<";
            this.but_prevDay.UseVisualStyleBackColor = true;
            this.but_prevDay.Click += new System.EventHandler(this.but_prevDay_Click);
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
            this.cb_days.Location = new System.Drawing.Point(193, 3);
            this.cb_days.Name = "cb_days";
            this.cb_days.Size = new System.Drawing.Size(121, 21);
            this.cb_days.TabIndex = 3;
            this.cb_days.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(596, 459);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "form_main";
            this.Text = "Расписание занятий";
            this.Load += new System.EventHandler(this.form_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ftMonday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_timetable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ftMonday;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_groups;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cb_days;
        private System.Windows.Forms.TabPage tabPage2;
        private ds_db ds_timetable;
        private ds_dbTableAdapters.ft_timetableTableAdapter ft_timetableTableAdapter;
        private ds_dbTableAdapters.TableAdapterManager tam_db;
        private ds_dbTableAdapters.LessonsTableAdapter lessonsTableAdapter;
        private ds_dbTableAdapters.pt_timetableTableAdapter pt_timetableTableAdapter;
        private ds_dbTableAdapters.TeachersTableAdapter teachersTableAdapter;
        private ds_dbTableAdapters.getGroupsFTTableAdapter getGroupsFTTableAdapter;
        private ds_dbTableAdapters.getGroupsPTTableAdapter getGroupsPTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Lesson;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Teacher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Monday_WeekOne;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Monday_WeekTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Monday_Audit;
        private System.Windows.Forms.Button but_nextDay;
        private System.Windows.Forms.Button but_prevDay;
    }
}

