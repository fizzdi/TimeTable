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
            this.ds_db = new TimeTable.ds_db();
            this.groupBox1.SuspendLayout();
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
            this.but_ok.Location = new System.Drawing.Point(105, 96);
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
            // ds_db
            // 
            this.ds_db.DataSetName = "ds_db";
            this.ds_db.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // form_newLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 126);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_newLesson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый предмет";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private ds_db ds_db;
    }
}