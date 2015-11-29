namespace TimeTable
{
    partial class form_newLesson
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
            this.tb_short = new System.Windows.Forms.TextBox();
            this.tb_full = new System.Windows.Forms.TextBox();
            this.l_fullname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.but_ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_LastName = new System.Windows.Forms.ComboBox();
            this.tb_Patr = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.but_newTeacher = new System.Windows.Forms.Button();
            this.ds_db = new TimeTable.ds_db();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_db)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_short
            // 
            this.tb_short.Location = new System.Drawing.Point(145, 45);
            this.tb_short.Name = "tb_short";
            this.tb_short.Size = new System.Drawing.Size(171, 20);
            this.tb_short.TabIndex = 0;
            // 
            // tb_full
            // 
            this.tb_full.Location = new System.Drawing.Point(113, 19);
            this.tb_full.Name = "tb_full";
            this.tb_full.Size = new System.Drawing.Size(203, 20);
            this.tb_full.TabIndex = 1;
            // 
            // l_fullname
            // 
            this.l_fullname.AutoSize = true;
            this.l_fullname.Location = new System.Drawing.Point(8, 22);
            this.l_fullname.Name = "l_fullname";
            this.l_fullname.Size = new System.Drawing.Size(99, 13);
            this.l_fullname.TabIndex = 2;
            this.l_fullname.Text = "Полное название:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сокращенное название:";
            // 
            // but_ok
            // 
            this.but_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_ok.Location = new System.Drawing.Point(104, 198);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(143, 23);
            this.but_ok.TabIndex = 3;
            this.but_ok.Text = "OK";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_full);
            this.groupBox1.Controls.Add(this.tb_short);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.l_fullname);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 78);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Предмет";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_LastName);
            this.groupBox2.Controls.Add(this.tb_Patr);
            this.groupBox2.Controls.Add(this.tb_Name);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 95);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Преподаватель";
            // 
            // cb_LastName
            // 
            this.cb_LastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_LastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cb_LastName.FormattingEnabled = true;
            this.cb_LastName.Location = new System.Drawing.Point(76, 17);
            this.cb_LastName.Name = "cb_LastName";
            this.cb_LastName.Size = new System.Drawing.Size(184, 21);
            this.cb_LastName.TabIndex = 6;
            this.cb_LastName.SelectedIndexChanged += new System.EventHandler(this.cb_LastName_SelectedIndexChanged);
            // 
            // tb_Patr
            // 
            this.tb_Patr.Location = new System.Drawing.Point(76, 64);
            this.tb_Patr.Name = "tb_Patr";
            this.tb_Patr.Size = new System.Drawing.Size(184, 20);
            this.tb_Patr.TabIndex = 5;
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(76, 41);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(184, 20);
            this.tb_Name.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Отчество:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фамилия:";
            // 
            // but_newTeacher
            // 
            this.but_newTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_newTeacher.Location = new System.Drawing.Point(287, 97);
            this.but_newTeacher.Name = "but_newTeacher";
            this.but_newTeacher.Size = new System.Drawing.Size(47, 95);
            this.but_newTeacher.TabIndex = 6;
            this.but_newTeacher.Text = "Новый преподаватель";
            this.but_newTeacher.UseVisualStyleBackColor = true;
            this.but_newTeacher.Click += new System.EventHandler(this.but_newTeacher_Click);
            // 
            // ds_db
            // 
            this.ds_db.DataSetName = "ds_db";
            this.ds_db.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // form_newLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 228);
            this.Controls.Add(this.but_newTeacher);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_newLesson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый предмет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_newLesson_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_db)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_short;
        private System.Windows.Forms.TextBox tb_full;
        private System.Windows.Forms.Label l_fullname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_Patr;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ds_db ds_db;
        private System.Windows.Forms.ComboBox cb_LastName;
        private System.Windows.Forms.Button but_newTeacher;
    }
}