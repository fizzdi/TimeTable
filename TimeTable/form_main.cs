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
        public form_main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*var table = from rowtt in ds_timetable.ft_timetable
                        where rowtt.Day == 1
                        join rowles in ds_timetable.Lessons on rowtt.LessonID equals rowles.LessonID
                        join rowTeach in ds_timetable.Teachers on rowtt.TeacherID equals rowTeach.TeacherID
                        select new { Number = rowtt.Number, Lesson = rowles.Title, 
                            Teacher = String.Format("{0} {1} {2}", rowTeach.LastName, rowTeach.FirstName, rowTeach.Patronymic),
                            rowtt.WeekOne, rowtt.WeekTwo, rowtt.GroupNumber, rowtt.AudienceNumber};
            dataGridView1.DataSource = table;*/
        }

        private void form_main_Load(object sender, EventArgs e)
        {
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
            switch (e.ColumnIndex)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    {
                        int curday = cb_days.SelectedIndex + 1;
                        int curgroup = (int)((DataRowView)cb_groups.SelectedItem).Row.ItemArray[0];
                        
                    }
                    break;
            }
        }
    }

    public class TimeTableTools
    {
        public static void fillGridOfDay_Group(int dayNumber, int group, ref DataGridView grid,
            ref ds_db db, bool partTime = false)
        {
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
                        grid[5, indOfrow].Value = row[2];
                        grid[6, indOfrow].Value = row[7];
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
                    grid[5, indOfrow].Value = row[2];
                    grid[6, indOfrow].Value = row[7];
                }
            }
        }
    }
}
