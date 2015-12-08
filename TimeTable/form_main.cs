using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TimeTable
{
    public partial class form_main : Form
    {
        public form_main()
        {
            InitializeComponent();
            ds_timetable.Lessons.LessonIDColumn.AutoIncrementSeed = 1;
            ds_timetable.Lessons.LessonIDColumn.AutoIncrementStep = 1;
            ds_timetable.Teachers.TeacherIDColumn.AutoIncrementSeed = 1;
            ds_timetable.Teachers.TeacherIDColumn.AutoIncrementStep = 1;
            //but_prevDay.Enabled = but_nextDay.Enabled = false;
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timetabledbDataSet.ft_timetable' table. You can move, or remove it, as needed.
            this.ft_timetableTableAdapter.Fill(this.ds_timetable.ft_timetable);
            this.teachersTableAdapter.Fill(this.ds_timetable.Teachers);
            this.pt_timetableTableAdapter.Fill(this.ds_timetable.pt_timetable);
            this.lessonsTableAdapter.Fill(this.ds_timetable.Lessons);
            this.ft_timetableTableAdapter.Fill(this.ds_timetable.ft_timetable);
            this.getGroupsFTTableAdapter.Fill(this.ds_timetable.getGroupsFT);
            this.getGroupsPTTableAdapter.Fill(this.ds_timetable.getGroupsPT);
            cb_groups.SelectedIndex = -1;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            var groups = ds_timetable.getGroupsFT.Select(t => t.GroupNumber.ToString()).ToArray();
            source.AddRange(groups);
            cb_groups.AutoCompleteCustomSource = source;
            cb_groups.Items.AddRange(groups);



            //TimeTableTools.fillGridOfDay_Group(1, 341, 2, this);
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cb_days.SelectedIndex == 0)
                but_prevDay.Enabled = false;
            else but_prevDay.Enabled = true;

            if (cb_days.SelectedIndex == 5)
                but_nextDay.Enabled = false;
            else but_nextDay.Enabled = true;*/

            if (cb_groups.SelectedIndex != -1 && cb_days.SelectedIndex == -1)
            {
                cb_days.SelectedIndex = 0;
            }

            if (cb_groups.SelectedIndex != -1 && cb_days.SelectedIndex != -1)
                fillGridOfDay_Group(cb_days.SelectedIndex + 1, int.Parse(cb_groups.Text), 2);
        }

        private void but_prevDay_Click(object sender, EventArgs e)
        {
            cb_days.SelectedIndex--;
        }

        private void but_nextDay_Click(object sender, EventArgs e)
        {
            cb_days.SelectedIndex++;
        }

        private void ms_refresh_Click(object sender, EventArgs e)
        {
            tam_db.UpdateAll(ds_timetable);
            //TimeTableTools.fillGridOfDay_Group(cb_days.SelectedIndex + 1, int.Parse(cb_groups.Text), ref dgv_maintable, ref ds_timetable);
        }

        private void ms_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void b_addgroup_Click(object sender, EventArgs e)
        {
            int gr;
            if (!int.TryParse(cb_groups.Text, out gr))
            {
                MessageBox.Show("Введите номер группы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_groups.Text = "";
            }
            else cb_groups.SelectedIndex = cb_groups.Items.Add(cb_groups.Text);
            //TimeTableTools.fillGridOfDay_Group(cb_days.SelectedIndex + 1, int.Parse(cb_groups.Text), ref dgv_maintable, ref ds_timetable);

        }

        private void form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            tam_db.UpdateAll(ds_timetable);
            Tools.ToExcel.ExcelClose();
        }

        private void ms_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Расписание занятий v.{0}\nКузнецов Дмитрий\ne-mail: kuznetsov.da@list.ru", "1.01a"), "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tools.ToExcel.CreateBooks(ref ds_timetable);
        }

        public void fillGridOfDay_Group(int dayNumber, int groupNumber, int subgroup, bool partTime = false)
        {
            string[] roman_numbers = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
            const int lessons = 8;
            int header_span = subgroup == 1 ? 1 : 2;
            grid.Rows.Clear();
            grid.ClipboardMode = SourceGrid.ClipboardMode.Delete | SourceGrid.ClipboardMode.Copy;
            grid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid.Selection.EnableMultiSelection = false;


            //Editors
            SourceGrid.Cells.Editors.TextBox lessonsEditor = TimeTable.Tools.Methods.getLessonsEditor(ref ds_timetable);
            SourceGrid.Cells.Editors.TextBox teacherEditor = TimeTable.Tools.Methods.getTeachersEditor(ref ds_timetable);

            //Views
            SourceGrid.Cells.Views.Cell viewEvenLessons = new SourceGrid.Cells.Views.Cell();
            viewEvenLessons.BackColor = System.Drawing.SystemColors.ControlLight;
            viewEvenLessons.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;


            //Size of grid
            grid.Redim(header_span + lessons * 3, 1 + 2 * subgroup);

            //Column Number of lesson
            grid.Columns[0].Width = 30;
            grid[0, 0] = new SourceGrid.Cells.Cell("№");
            grid[0, 0].RowSpan = 2;
            grid[0, 0].View = viewEvenLessons;
            //grid[0,0].Controller


            //Column first week
            grid[0, 1] = new SourceGrid.Cells.Cell("Первая неделя");
            grid[0, 1].ColumnSpan = subgroup;
            grid[0, 1].View = viewEvenLessons;

            //Column second week
            grid[0, 1 + subgroup] = new SourceGrid.Cells.Cell("Вторая неделя");
            grid[0, 1 + subgroup].ColumnSpan = subgroup;
            grid[0, 1 + subgroup].View = viewEvenLessons;

            //subColumns of week
            for (int i = 0; i < subgroup; ++i)
            {
                grid.Columns[1 + i].Width = grid.Columns[1 + subgroup + i].Width = 150;
                grid[1, 1 + i] = new SourceGrid.Cells.Cell(roman_numbers[i]);
                grid[1, 1 + subgroup + i] = new SourceGrid.Cells.Cell(roman_numbers[i]);
                grid[1, 1 + i].View = viewEvenLessons;
                grid[1, 1 + subgroup + i].View = viewEvenLessons;
            }



            //Initialization cells
            for (int i = header_span; i < grid.RowsCount; ++i)
            {
                //Indices
                if ((i - header_span) % 3 == 0)
                {
                    grid[i, 0] = new SourceGrid.Cells.Cell((i - header_span) / 3 + 1);
                    grid[i, 0].RowSpan = 3;
                    if ((i - header_span) % 6 >= 3)
                        grid[i, 0].View = viewEvenLessons;
                    grid[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                }


                for (int j = 1; j < grid.ColumnsCount; ++j)
                {
                    grid[i, j] = new SourceGrid.Cells.Cell();

                    if ((i - header_span) % 6 >= 3)
                        grid[i, j].View = viewEvenLessons;

                    //Set lessons editors
                    if ((i - header_span) % 3 == 0)
                    {
                        grid[i, j].Editor = lessonsEditor;
                        grid[i, j].AddController(new Tools.LessonCellContoller(ref cb_days, ref cb_groups, ref ds_timetable));
                    }
                    //Teacher row
                    else if ((i - header_span) % 3 == 1)
                    {
                        grid[i, j].AddController(new Tools.TeacherCellContoller(ref cb_days, ref cb_groups, ref ds_timetable));
                    }
                    else //Audience row
                        grid[i, j].AddController(new Tools.AudienceCellContoller(ref cb_days, ref cb_groups, ref ds_timetable));

                }
            }


            if (partTime)
            {
                var dayTimeTable = from row in ds_timetable.pt_timetable
                                   where row.Day == dayNumber && row.GroupNumber == groupNumber
                                   orderby row.Number
                                   select row;

                foreach (var row in dayTimeTable)
                {
                    int indOfrow = ((int)row.Number - 1) * 3 + header_span;
                    for (int i = 0; i < subgroup; ++i)
                    {
                        //First week
                        if ((row.WeekSubGroup & (1 << i)) != 0)
                        {

                            grid[indOfrow, 1 + i].Value = row.LessonsRow.Title;

                            grid[indOfrow + 1, 1 + i].Value = String.Format("{0} {1} {2}",
                            row.TeachersRow.LastName, row.TeachersRow.FirstName, row.TeachersRow.Patronymic);
                            grid[indOfrow + 1, 1 + i].Editor = teacherEditor;

                            grid[indOfrow + 2, 1 + i].Value = row.AudienceNumber;
                            grid[indOfrow + 2, 1 + i].Editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
                        }

                        //Second week
                        if ((row.WeekSubGroup & (1 << (subgroup + i))) != 0)
                        {
                            grid[indOfrow, 1 + subgroup + i].Value = row.LessonsRow.Title;

                            grid[indOfrow + 1, 1 + subgroup + i].Value = String.Format("{0} {1} {2}",
                            row.TeachersRow.LastName, row.TeachersRow.FirstName, row.TeachersRow.Patronymic);
                            grid[indOfrow + 1, 1 + subgroup + i].Editor = teacherEditor;

                            grid[indOfrow + 2, 1 + subgroup + i].Value = row.AudienceNumber;
                            grid[indOfrow + 2, 1 + subgroup + i].Editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
                        }
                    }
                }
            }
            else
            {
                var dayTimeTable = from row in ds_timetable.ft_timetable
                                   where row.Day == dayNumber && row.GroupNumber == groupNumber
                                   orderby row.Number
                                   select row;

                foreach (var row in dayTimeTable)
                {
                    int indOfrow = ((int)row.Number - 1) * 3 + header_span;
                    for (int i = 0; i < subgroup; ++i)
                    {
                        //First week
                        if ((row.WeekSubGroup & (1 << i)) != 0)
                        {
                            grid[indOfrow, 1 + i].Value = row.LessonsRow.Title;

                            grid[indOfrow + 1, 1 + i].Value = String.Format("{0} {1} {2}",
                            row.TeachersRow.LastName, row.TeachersRow.FirstName, row.TeachersRow.Patronymic);
                            grid[indOfrow + 1, 1 + i].Editor = teacherEditor;

                            grid[indOfrow + 2, 1 + i].Value = row.AudienceNumber;
                            grid[indOfrow + 2, 1 + i].Editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
                        }

                        //Second week
                        if ((row.WeekSubGroup & (1 << (subgroup + i))) != 0)
                        {
                            grid[indOfrow, 1 + subgroup + i].Value = row.LessonsRow.Title;

                            grid[indOfrow + 1, 1 + subgroup + i].Value = String.Format("{0} {1} {2}",
                            row.TeachersRow.LastName, row.TeachersRow.FirstName, row.TeachersRow.Patronymic);
                            grid[indOfrow + 1, 1 + subgroup + i].Editor = teacherEditor;

                            grid[indOfrow + 2, 1 + subgroup + i].Value = row.AudienceNumber;
                            grid[indOfrow + 2, 1 + subgroup + i].Editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
                        }
                    }
                }
            }

        } // end fillGridOfDay_Group

        private void ms_settings_Click(object sender, EventArgs e)
        {
            SettingsForm sfrm = new SettingsForm();
            sfrm.Owner = this;
            sfrm.ShowDialog();
        }
    }
}
