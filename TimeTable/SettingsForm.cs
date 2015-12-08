using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TimeTable
{
    public partial class SettingsForm : Form
    {
        private const string fileName = "app.cfg";
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    if (!reader.EndOfStream)
                        tb_facul.Text = reader.ReadLine();
                }
            }
            else
            {
                File.Create(fileName);
            }
        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tb_facul.Text == null || tb_facul.Text == "")
            {
                MessageBox.Show("Введите название факультета в родительном падеже!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(tb_facul.Text);
            }
        }
    }
}
