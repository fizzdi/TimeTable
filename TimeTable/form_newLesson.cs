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
    public partial class form_newLesson : Form
    {
        public String ShortName { get { return tb_short.Text; } }
        public String FullName { get { return tb_full.Text; } }
        public form_newLesson(string fullname)
        {
            InitializeComponent();
            tb_full.Text = fullname;
            var strs = fullname.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (strs.Length == 1)
            {
                tb_short.Text = strs[0];
            }
            else
            {
                foreach (string s in strs)
                {
                    if (tb_short.Text.Length != 0)
                        tb_short.Text += ' ';
                    tb_short.Text += subString(s);
                }
            }

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            var teachers = from row in ds_db.Teachers
                           select row.LastName;
            var teachers_array = teachers.ToArray();
            cb_LastName.Items.AddRange(teachers_array);
            source.AddRange(teachers_array);
            cb_LastName.AutoCompleteCustomSource = source;
        }

        private string subString(string s)
        {
            string result;
            if (s.Length > 5)
                result = s.Substring(0, 5);
            else
                return s;

            int i = result.Length-1;
            while (i < s.Length && isVowel(result.Last()))
                result += s[++i];
            while (result.Length > 3 && isVowel(result.Last()))
                result.Remove(result.Length);

            return result + '.';
        }

        private bool isVowel(Char c)
        {
            string Vowels = "ауоыиэяюёеaeiouy";
            return Vowels.IndexOf(Char.ToLower(c)) != -1;
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_newLesson_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cb_LastName.Text == "" || tb_Patr.Text == "" || tb_Name.Text == "")
            {
                MessageBox.Show("Заполненны не все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
        }

        private void cb_LastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Name.Text = (string)ds_db.Teachers.FindByTeacherID((int)cb_LastName.SelectedValue)["FirstName"];
            tb_Patr.Text = (string)ds_db.Teachers.FindByTeacherID((int)cb_LastName.SelectedValue)["Patronymic"];
        }

        private void but_newTeacher_Click(object sender, EventArgs e)
        {
            ds_db.Teachers.AddTeachersRow(cb_LastName.Text, tb_Name.Text, tb_Patr.Text);
            var teachers = from row in ds_db.Teachers
                           select row.LastName;
            cb_LastName.Items.Clear();
            cb_LastName.Items.AddRange(teachers.ToArray());
        }
    }
}
