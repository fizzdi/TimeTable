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
    }
}
