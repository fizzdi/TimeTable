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
    public partial class form_main : Form
    {
        private string last_lesson;
        private string last_teacher;
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

             //if (cb_groups.SelectedIndex != -1 && cb_days.SelectedIndex != -1)
             //    TimeTableTools.fillGridOfDay_Group(cb_days.SelectedIndex + 1, int.Parse(cb_groups.Text), ref dgv_maintable, ref ds_timetable);
         }

         /*private void dgv_maintable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
         {
             int curday = cb_days.SelectedIndex + 1;
             int curgroup = int.Parse(cb_groups.Text);
             int curnumber = (int)dgv_maintable[0, e.RowIndex].Value;
             var table = from rowtt in ds_timetable.ft_timetable
                         where rowtt.Day == curday 
                         && rowtt.GroupNumber == curgroup 
                         && rowtt.Number == curnumber
                         && rowtt.LessonsRow.Title == (string)dgv_maintable[1, e.RowIndex].Value
                         select rowtt;

             if (table.Count() == 0 && e.ColumnIndex != 4 && e.ColumnIndex != 5)
                 ds_timetable.ft_timetable.Addft_timetableRow(curday, (int)dgv_maintable[0, e.RowIndex].Value, curgroup, ds_timetable.Lessons[0], ds_timetable.Teachers[0], false, false, "", 0);

             switch (e.ColumnIndex)
             {
                 case 1:
                     {
                         if ((string)dgv_maintable[1, e.RowIndex].Value == null)
                         {
                             DialogResult result = MessageBox.Show("Удалить занятие?", "Удаление занятия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (result == System.Windows.Forms.DialogResult.Yes)
                             {
                                 foreach (var row in table)
                                 {
                                     if (row.LessonsRow.Title == last_lesson)
                                     {
                                         row.Delete();
                                         break;
                                     }
                                 }
                                 dgv_maintable[1, e.RowIndex].Value = dgv_maintable[2, e.RowIndex].Value = dgv_maintable[6, e.RowIndex].Value = null;
                                 dgv_maintable[4, e.RowIndex].Value = dgv_maintable[5, e.RowIndex].Value = true;
                                 return;
                             }
                         }

                         var lessons = from row in ds_timetable.Lessons
                                       where row.Title == (string)dgv_maintable[1, e.RowIndex].Value
                                       select row;
                         if (lessons.Count() == 0)
                         {
                             DialogResult result = MessageBox.Show(this, "Вы хотите добавить новый предмет?", "Новый предмет", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (result == System.Windows.Forms.DialogResult.No)
                             {
                                 dgv_maintable[1, e.RowIndex].Value = last_lesson;
                                 return;
                             }

                             form_newLesson frm = new form_newLesson((string)dgv_maintable[1, e.RowIndex].Value);
                             frm.Owner = this;
                             frm.ShowDialog();
                             ds_timetable.Lessons.AddLessonsRow(frm.FullName, frm.ShortName);

                         }

                         foreach (var row in table)
                             row.LessonID = lessons.First().LessonID;
                     }
                     break;

                 case 2:
                     {
                         var teacherInfo = ((string)dgv_maintable[2, e.RowIndex].Value).Split(' ').ToArray();
                         if (teacherInfo.Length != 3)
                         {
                             MessageBox.Show("Введите ФИО преподавателя!", "Некорректные ФИО преподователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             dgv_maintable[2, e.RowIndex].Value = last_teacher;
                             return;
                         }

                         var teachers = from row in ds_timetable.Teachers
                                        where row.LastName == teacherInfo[0] &&
                                              row.FirstName == teacherInfo[1] &&
                                              row.Patronymic == teacherInfo[2]
                                        select row.TeacherID;

                         if (teachers.Count() == 0)
                         {
                             DialogResult result = MessageBox.Show(this, "Вы хотите добавить нового преподавателя?", "Новый преподаватель", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (result == System.Windows.Forms.DialogResult.No)
                             {
                                 dgv_maintable[2, e.RowIndex].Value = last_teacher;
                                 return;
                             }
                             else
                             {
                                 ds_timetable.Teachers.AddTeachersRow(teacherInfo[0], teacherInfo[1], teacherInfo[2]);
                                 //tam_db.UpdateAll(ds_timetable);
                             }
                         }

                             foreach (var row in table)
                                 row.TeacherID = teachers.First();
                     }
                     break;
                 default:
                     {

                         foreach (var row in table)
                         {
                             row.AudienceNumber = (string)dgv_maintable[6, e.RowIndex].Value;
                             row.WeekOne = (bool)dgv_maintable[4, e.RowIndex].Value;
                             row.WeekTwo = (bool)dgv_maintable[5, e.RowIndex].Value;
                         }
                     }
                     break;
             }
             //tam_db.UpdateAll(ds_timetable);
         }

         private void dgv_maintable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
         {
             last_lesson = (string)dgv_maintable[1, e.RowIndex].Value;
             last_teacher = (string)dgv_maintable[2, e.RowIndex].Value;
         }

         private void dgv_maintable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
         {
             switch (dgv_maintable.CurrentCell.ColumnIndex)
             {
                 case 1:
                     {
                         TextBox autoText = e.Control as TextBox;
                         if (autoText != null)
                         {
                             autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                             autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                             AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                             var lessons = from row in ds_timetable.Lessons
                                           select row.Title;
                             source.AddRange(lessons.ToArray());
                             autoText.AutoCompleteCustomSource = source;
                         }
                     }
                     break;

                 case 2:
                     {
                         TextBox autoText = e.Control as TextBox;
                         if (autoText != null)
                         {
                             autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                             autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                             AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                             var teachers = from row in ds_timetable.Teachers
                                            select row.LastName + ' ' + row.FirstName + ' ' + row.Patronymic;
                             source.AddRange(teachers.ToArray());
                             autoText.AutoCompleteCustomSource = source;
                         }
                     }
                     break;
             }
         }

         private void dgv_maintable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
             //if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                 //tam_db.UpdateAll(ds_timetable);
         }*/

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
            cb_groups.SelectedIndex = cb_groups.Items.Add(cb_groups.Text);
            //TimeTableTools.fillGridOfDay_Group(cb_days.SelectedIndex + 1, int.Parse(cb_groups.Text), ref dgv_maintable, ref ds_timetable);

        }

        private void form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            tam_db.UpdateAll(ds_timetable);
        }

        private void ms_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Расписание занятий v.{0}\nКузнецов Дмитрий\ne-mail: kuznetsov.da@list.ru", "1.01a"), "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class TimeTableTools
    {
        public static void fillGridOfDay_Group(int dayNumber, int groupNumber, ref DataGridView grid,
            ref ds_db db, bool partTime = false)
        {
            grid.Columns[0].ValueType = typeof(int);
            grid.Sort(grid.Columns[0], ListSortDirection.Ascending);
            grid.Rows.Clear();

            for (int i = 0; i < 8; ++i)
            {
                grid.Rows.Add();
                grid[0, i].Value = i + 1;
                grid[4, i].Value = grid[5, i].Value = false;
            }

            if (partTime)
            {
                var dayTimeTable = from row in db.pt_timetable
                                   where row.Day == dayNumber && row.GroupNumber == groupNumber
                                   orderby row.Number
                                   select row;

                foreach (var curRow in dayTimeTable)
                {
                    int newrow = (int)curRow["Number"];
                    if (curRow[2] == DBNull.Value)
                        continue;
                    foreach (var row in dayTimeTable)
                    {
                        int indOfrow = (int)row["Number"] - 1;
                        if (row[3] == DBNull.Value)
                            continue;
                        grid[1, indOfrow].Value = row.LessonsRow.Title;
                        grid[2, indOfrow].Value = String.Format("{0} {1} {2}",
                        row.TeachersRow.LastName, row.TeachersRow.FirstName, row.TeachersRow.Patronymic);
                        grid[4, indOfrow].Value = (bool)row[5];
                        grid[5, indOfrow].Value = (bool)row[6];
                        grid[6, indOfrow].Value = row[7];
                    }
                }
            }
            else
            {
                var dayTimeTable = from row in db.ft_timetable
                                   where row.Day == dayNumber && row.GroupNumber == groupNumber
                                   orderby row.Number
                                   select row;

                foreach (var row in dayTimeTable)
                {
                    int indOfrow = (int)row["Number"] - 1;
                    if (row[3] == DBNull.Value)
                        continue;
                    grid[1, indOfrow].Value = row.LessonsRow.Title;
                    grid[2, indOfrow].Value = String.Format("{0} {1} {2}",
                    row.TeachersRow.LastName, row.TeachersRow.FirstName, row.TeachersRow.Patronymic);
                    grid[4, indOfrow].Value = (bool)row[5];
                    grid[5, indOfrow].Value = (bool)row[6];
                    grid[6, indOfrow].Value = row[7];
                }
            }
        }
    }
}
