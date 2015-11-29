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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* var table = from rowtt in ds_timetable.ft_timetable
                         where rowtt.Day == 1
                         join rowles in ds_timetable.Lessons on rowtt.LessonID equals rowles.LessonID
                         join rowTeach in ds_timetable.Teachers on rowtt.TeacherID equals rowTeach.TeacherID
                         select new { rowtt, rowles, rowTeach }; 
             foreach(var row in table)
             {
                 row.rowtt.GroupNumber = 125;
                 break;
             }
             tam_db.UpdateAll(ds_timetable);*/
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timetabledbDataSet.ft_timetable' table. You can move, or remove it, as needed.
            this.ft_timetableTableAdapter.Fill(this.ds_timetable.ft_timetable);
            this.teacherToLessonsTableAdapter.Fill(this.ds_timetable.TeacherToLessons);
            this.teachersTableAdapter.Fill(this.ds_timetable.Teachers);
            this.pt_timetableTableAdapter.Fill(this.ds_timetable.pt_timetable);
            this.lessonsTableAdapter.Fill(this.ds_timetable.Lessons);
            this.ft_timetableTableAdapter.Fill(this.ds_timetable.ft_timetable);
            this.getGroupsFTTableAdapter.Fill(this.ds_timetable.getGroupsFT);
            this.getGroupsPTTableAdapter.Fill(this.ds_timetable.getGroupsPT);
            cb_groups.SelectedIndex = -1;
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_groups.SelectedIndex < 0 || cb_days.SelectedIndex < 0)
                return;
            TimeTableTools.fillGridOfDay_Group(cb_days.SelectedIndex + 1, (int)((DataRowView)cb_groups.SelectedItem).Row.ItemArray[0], ref dgv_ftMonday, ref ds_timetable);
        }

        private void dgv_ftMonday_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int curday = cb_days.SelectedIndex + 1;
            int curgroup = (int)((DataRowView)cb_groups.SelectedItem).Row.ItemArray[0];
            var table = from rowtt in ds_timetable.ft_timetable
                        where rowtt.Day == 1
                        join rowles in ds_timetable.Lessons on rowtt.LessonID equals rowles.LessonID
                        join rowTeach in ds_timetable.Teachers on rowtt.TeacherID equals rowTeach.TeacherID
                        where rowtt.Day == curday && rowtt.GroupNumber == curgroup
                                  && rowtt.Number == (int)dgv_ftMonday[0, e.RowIndex].Value
                                  && rowles.Title == last_lesson
                        select new { rowtt, rowles, rowTeach };

            switch (e.ColumnIndex)
            {
                case 1:
                    {
                        var lessons = from row in ds_timetable.Lessons
                                          where row.Title == (string)dgv_ftMonday[1, e.RowIndex].Value
                                          select row;
                        int lessonCode = -1;
                        if (lessons.Count() == 0)
                        {
                            DialogResult result = MessageBox.Show(this, "Вы хотите добавить новый предмет?", "Новый предмет", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == System.Windows.Forms.DialogResult.No)
                            {
                                dgv_ftMonday[1, e.RowIndex].Value = last_lesson;
                                return;
                            }

                            form_newLesson frm = new form_newLesson((string)dgv_ftMonday[1, e.RowIndex].Value);
                            frm.Owner = this;
                            frm.ShowDialog();
                            ds_timetable.Lessons.AddLessonsRow(frm.FullName, frm.ShortName);
                            tam_db.UpdateAll(ds_timetable);
                            foreach (var currow in from row in ds_timetable.Lessons where row.Title == frm.FullName select row)
                                lessonCode = currow.LessonID;
                        }
                        else
                        {
                            foreach (var currow in lessons)
                                lessonCode = currow.LessonID;
                        }

                        foreach (var row in table)
                            row.rowtt.LessonID = lessonCode;
                    }
                    break;
                case 2:
                    break;
                default:
                    {
                        foreach (var row in table)
                        {
                            row.rowtt.AudienceNumber = (string)dgv_ftMonday[5, e.RowIndex].Value;
                            row.rowtt.WeekOne = (bool)dgv_ftMonday[3, e.RowIndex].Value;
                            row.rowtt.WeekTwo = (bool)dgv_ftMonday[4, e.RowIndex].Value;
                        }
                    }
                    break;
            }
            tam_db.UpdateAll(ds_timetable);
        }

        private void dgv_ftMonday_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            last_lesson = (string)dgv_ftMonday[1, e.RowIndex].Value;
        }
    }

    public class TimeTableTools
    {
        public static void fillGridOfDay_Group(int dayNumber, int group, ref DataGridView grid,
            ref ds_db db, bool partTime = false)
        {
            grid.Columns[0].ValueType = typeof(int);
            grid.Sort(grid.Columns[0], ListSortDirection.Ascending);
            grid.Rows.Clear();

            for (int i = 0; i < 8; ++i)
            {
                grid.Rows.Add();
                grid[0, i].Value = i + 1;
            }

            if (partTime)
            {
                var dayTimeTable = from row in db.pt_timetable
                                   where row.Day == dayNumber
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
                        grid[1, indOfrow].Value = db.Lessons.FindByLessonID((int)row[3])["Title"];
                        var teacherInfo = db.Teachers.FindByTeacherID((int)row[4]);
                        grid[2, indOfrow].Value = String.Format("{0} {1} {2}",
                        teacherInfo[1], teacherInfo[2], teacherInfo[3]);
                        grid[3, indOfrow].Value = (bool)row[5];
                        grid[4, indOfrow].Value = (bool)row[6];
                        grid[5, indOfrow].Value = row[7];
                    }
                }
            }
            else
            {
                var dayTimeTable = from row in db.ft_timetable
                                   where row.Day == dayNumber
                                   orderby row.Number
                                   select row;

                foreach (var row in dayTimeTable)
                {
                    int indOfrow = (int)row["Number"] - 1;
                    if (row[3] == DBNull.Value)
                        continue;
                    grid[1, indOfrow].Value = db.Lessons.FindByLessonID((int)row[3])["Title"];
                    var teacherInfo = db.Teachers.FindByTeacherID((int)row[4]);
                    grid[2, indOfrow].Value = String.Format("{0} {1} {2}",
                    teacherInfo[1], teacherInfo[2], teacherInfo[3]);
                    grid[3, indOfrow].Value = (bool)row[5];
                    grid[4, indOfrow].Value = (bool)row[6];
                    grid[5, indOfrow].Value = row[7];
                }
            }
        }
    }
}
