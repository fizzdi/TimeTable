namespace TimeTable
{
    partial class formLessons
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLessons));
            this.dgv_lessons = new System.Windows.Forms.DataGridView();
            this.ds_db = new TimeTable.ds_db();
            this.lessonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lessonsTableAdapter = new TimeTable.ds_dbTableAdapters.LessonsTableAdapter();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abbreviationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lessons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_db)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessonsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_lessons
            // 
            this.dgv_lessons.AllowUserToDeleteRows = false;
            this.dgv_lessons.AutoGenerateColumns = false;
            this.dgv_lessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lessons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.abbreviationDataGridViewTextBoxColumn});
            this.dgv_lessons.DataSource = this.lessonsBindingSource;
            this.dgv_lessons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_lessons.Location = new System.Drawing.Point(0, 0);
            this.dgv_lessons.Name = "dgv_lessons";
            this.dgv_lessons.RowHeadersVisible = false;
            this.dgv_lessons.Size = new System.Drawing.Size(353, 456);
            this.dgv_lessons.TabIndex = 0;
            this.dgv_lessons.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_lessons_RowValidating);
            // 
            // ds_db
            // 
            this.ds_db.DataSetName = "ds_db";
            this.ds_db.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lessonsBindingSource
            // 
            this.lessonsBindingSource.DataMember = "Lessons";
            this.lessonsBindingSource.DataSource = this.ds_db;
            // 
            // lessonsTableAdapter
            // 
            this.lessonsTableAdapter.ClearBeforeFill = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Полное название";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 150;
            // 
            // abbreviationDataGridViewTextBoxColumn
            // 
            this.abbreviationDataGridViewTextBoxColumn.DataPropertyName = "Abbreviation";
            this.abbreviationDataGridViewTextBoxColumn.HeaderText = "Сокращение";
            this.abbreviationDataGridViewTextBoxColumn.Name = "abbreviationDataGridViewTextBoxColumn";
            this.abbreviationDataGridViewTextBoxColumn.Width = 150;
            // 
            // formLessons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 456);
            this.Controls.Add(this.dgv_lessons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formLessons";
            this.Text = "Занятия";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formLessons_FormClosing);
            this.Load += new System.EventHandler(this.formLessons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lessons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_db)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessonsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lessons;
        private ds_db ds_db;
        private System.Windows.Forms.BindingSource lessonsBindingSource;
        private ds_dbTableAdapters.LessonsTableAdapter lessonsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abbreviationDataGridViewTextBoxColumn;
    }
}