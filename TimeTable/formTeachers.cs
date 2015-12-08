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
    public partial class formTeachers : Form
    {
        bool error = false;
        ds_db db;
        public formTeachers()
        {
            InitializeComponent();
        }

        private void formTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ds_db.Teachers' table. You can move, or remove it, as needed.
            this.teachersTableAdapter.Fill(this.ds_db.Teachers);
        }

        private void formTeachers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (error)
            {
                MessageBox.Show("Данные введены не полностью!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            teachersBindingSource.EndEdit();
            teachersTableAdapter.Update(ds_db.Teachers);
        }

        private void dgv_teachers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            error = false;
            if (dgv_teachers[0, e.RowIndex].Value == DBNull.Value)
            {
                error = true;
                MessageBox.Show("Введите фамилию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgv_teachers[1, e.RowIndex].Value == DBNull.Value)
            {
                error = true;
                MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgv_teachers[2, e.RowIndex].Value == DBNull.Value)
            {
                error = true;
                MessageBox.Show("Введите отчество!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
