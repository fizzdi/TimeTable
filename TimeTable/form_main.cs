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

        }

        private void form_main_Load(object sender, EventArgs e)
        {
            this.teacherToLessonsTableAdapter.Fill(this.ds_db.TeacherToLessons);
            this.teachersTableAdapter.Fill(this.ds_db.Teachers);
            this.pt_timetableTableAdapter.Fill(this.ds_db.pt_timetable);
            this.lessonsTableAdapter.Fill(this.ds_db.Lessons);
            this.ft_timetableTableAdapter.Fill(this.ds_db.ft_timetable);
            this.getGroupsFTTableAdapter.Fill(this.ds_db.getGroupsFT);
            this.getGroupsPTTableAdapter.Fill(this.ds_db.getGroupsPT);
            cb_groups.SelectedIndex = -1;
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_groups.SelectedIndex < 0 || cb_days.SelectedIndex < 0) 
                return;
            TimeTableTools.fillGridOfDay_Group(cb_days.SelectedIndex + 1, (int)((DataRowView)cb_groups.SelectedItem).Row.ItemArray[0], ref dgv_ftMonday, ref ds_db);
        }

        private void dgv_ftMonday_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch(e.ColumnIndex)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    {
                        int curday = cb_days.SelectedIndex + 1;
                        int curgroup = (int)((DataRowView)cb_groups.SelectedItem).Row.ItemArray[0];
                        ds_db.ft_timetable[cb_days]
                    }
        }
    }

    class TimeTableTools
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
