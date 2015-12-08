using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTable
{
    public partial class formLessons : Form
    {
        bool error = false;
        public formLessons()
        {
            InitializeComponent();
        }

        private void formLessons_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ds_db.Lessons' table. You can move, or remove it, as needed.
            this.lessonsTableAdapter.Fill(this.ds_db.Lessons);
        }

        private void formLessons_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (error)
            {
                MessageBox.Show("Данные введены не полностью!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            lessonsBindingSource.EndEdit();
            lessonsTableAdapter.Update(ds_db.Lessons);
        }

        private void dgv_lessons_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            error = false;
            if (dgv_lessons[0, e.RowIndex].Value == DBNull.Value)
            {
                error = true;
                MessageBox.Show("Введите полное название предмета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgv_lessons[1, e.RowIndex].Value == DBNull.Value)
            {
                error = true;
                MessageBox.Show("Введите сокращенное название предмета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
