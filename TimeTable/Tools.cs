using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceGrid;

namespace TimeTable.Tools
{
    public static class Methods
    {
        public static SourceGrid.Cells.Editors.TextBox getTeachersEditor(ds_db.TeachersDataTable Teachers)
        {
            SourceGrid.Cells.Editors.TextBox teachersEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            teachersEditor.Control.AutoCompleteMode = AutoCompleteMode.Suggest;
            teachersEditor.Control.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            var teachers_db = from row in Teachers
                              select row.LastName + ' ' + row.FirstName + ' ' + row.Patronymic;
            source.AddRange(teachers_db.ToArray());
            teachersEditor.Control.AutoCompleteCustomSource = source;
            return teachersEditor;
        }

        public static SourceGrid.Cells.Editors.TextBox getLessonsEditor(ds_db.LessonsDataTable Lessons)
        {
            SourceGrid.Cells.Editors.TextBox lessonsEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            {
                lessonsEditor.Control.AutoCompleteMode = AutoCompleteMode.Suggest;
                lessonsEditor.Control.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                var lessons_db = from row in Lessons
                                 select row.Title;
                source.AddRange(lessons_db.ToArray());
                lessonsEditor.Control.AutoCompleteCustomSource = source;
                return lessonsEditor;
            }
        }

        public static SourceGrid.Cells.Editors.TextBox getAuditor(ds_db.ft_timetableDataTable table)
        {
            SourceGrid.Cells.Editors.TextBox lessonsEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            {
                lessonsEditor.Control.AutoCompleteMode = AutoCompleteMode.Suggest;
                lessonsEditor.Control.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                source.AddRange(table.Select(t=> t.AudienceNumber).Distinct().ToArray());
                lessonsEditor.Control.AutoCompleteCustomSource = source;
                return lessonsEditor;
            }
        }
        public static int numbersOfSubGroups(int key)
        {
            int ans = 22;
            while ((key & (1 << --ans)) == 0) ;
            return ans;
        }

        public static bool isWillLesson(int key, int week, int subgroup, int subgroups)
        {
            switch (week)
            {
                case 1:
                    return (key & (1 << subgroup - 1)) != 0;
                case 2:
                    return (key & (1 << (subgroups + subgroup - 1))) != 0;
                default:
                    return false;
            }
        }

        public static bool isLessonEveryWeek(int key, int subgroups)
        {
            return key == ((1 << subgroups * 2 + 1) - 1);
        }

        public static String LessonString(ds_db.ft_timetableRow row, int maxLength)
        {
            if (row.LessonsRow.Title.Length <= maxLength)
                return string.Format("{0}\n{1} {2}.{3}.",
                row.LessonsRow.Title,
                row.TeachersRow.LastName,
                row.TeachersRow.FirstName[0],
                row.TeachersRow.Patronymic[0]);
            else
                return string.Format("{0}\n{1} {2}.{3}.",
                row.LessonsRow.Abbreviation,
                row.TeachersRow.LastName,
                row.TeachersRow.FirstName[0],
                row.TeachersRow.Patronymic[0]);
        }

        public static String LessonString(ds_db.pt_timetableRow row, int maxLength)
        {
            if (row.LessonsRow.Title.Length <= maxLength)
                return string.Format("{0}\n{1} {2}.{3}.",
                row.LessonsRow.Title,
                row.TeachersRow.LastName,
                row.TeachersRow.FirstName[0],
                row.TeachersRow.Patronymic[0]);
            else
                return string.Format("{0}\n{1} {2}.{3}.",
                row.LessonsRow.Abbreviation,
                row.TeachersRow.LastName,
                row.TeachersRow.FirstName[0],
                row.TeachersRow.Patronymic[0]);
        }

        public static void deleteDayOfGroup(int dayNumber, int groupNumber, ds_db.ft_timetableDataTable db)
        {
            var dayTimeTable = from row in db
                               where row.Day == dayNumber && row.GroupNumber == groupNumber
                               select row;
            foreach (var row in dayTimeTable)
                row.Delete();
        }

        public static void deleteDayOfGroup(int dayNumber, int groupNumber, ds_db.pt_timetableDataTable db)
        {
            var dayTimeTable = from row in db
                               where row.Day == dayNumber && row.GroupNumber == groupNumber
                               select row;
            foreach (var row in dayTimeTable)
                row.Delete();
        }

        public static void deleteGroup(int groupNumber, ds_db.pt_timetableDataTable db)
        {
            var dayTimeTable = from row in db
                               where row.GroupNumber == groupNumber
                               select row;
            foreach (var row in dayTimeTable)
                row.Delete();
        }

        public static void deleteGroup(int groupNumber, ds_db.ft_timetableDataTable db)
        {
            var dayTimeTable = from row in db
                               where row.GroupNumber == groupNumber
                               select row;
            foreach (var row in dayTimeTable)
                row.Delete();
        }

    }

    //Contoller for cells with lessons's info
    class LessonCellContollerFT : SourceGrid.Cells.Controllers.ControllerBase

    {
        ds_db.ft_timetableDataTable db_table;
        ds_db.LessonsDataTable lessons;
        ds_db.TeachersDataTable teachers;
        private ComboBox days;
        private ComboBox groups;
        private string oldValue;

        public LessonCellContollerFT(ref ComboBox days, ref ComboBox groups,
            ds_db.ft_timetableDataTable ft_table, ds_db.LessonsDataTable lessons, ds_db.TeachersDataTable teachers)
        {
            this.days = days;
            this.groups = groups;
            this.db_table = ft_table;
            this.lessons = lessons;
            this.teachers = teachers;
        }
        public override void OnFocusEntered(CellContext sender, EventArgs e)
        {
            base.OnFocusEntered(sender, e);
            oldValue = (string)sender.Value;
            sender.Cell.Editor = Methods.getLessonsEditor(lessons);
        }

        public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
        {
            base.OnValueChanged(sender, e);

            if ((string)sender.Value == null)
            {
                if (oldValue == null)
                    return;
                int c_row = sender.Position.Row;
                int c_col = sender.Position.Column;
                int c_SubGroupWeek = c_col - 1;
                int c_day = days.SelectedIndex + 1;
                int c_group = int.Parse(groups.Text);
                int c_number = (int)((SourceGrid.Grid)sender.Grid)[c_row, 0].Value;

                var table = from rowtt in db_table
                            where rowtt.Day == c_day
                            && rowtt.GroupNumber == c_group
                            && rowtt.Number == c_number
                            && rowtt.LessonsRow.Title == oldValue
                            && (rowtt.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                            select rowtt;


                DialogResult result = MessageBox.Show("Удалить занятие?", "Удаление занятия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (var row in table)
                    {
                        row.WeekSubGroup &= 0xFFFFFF ^ (1 << c_SubGroupWeek);
                        if (row.WeekSubGroup == (1 << Methods.numbersOfSubGroups(row.WeekSubGroup)))
                            row.Delete();
                        break;
                    }
                    ((SourceGrid.Grid)sender.Grid)[c_row, c_col].Value = ((SourceGrid.Grid)sender.Grid)[c_row + 1, c_col].Value = ((SourceGrid.Grid)sender.Grid)[c_row + 2, c_col].Value = "";
                    ((SourceGrid.Grid)sender.Grid)[c_row + 1, c_col].Editor = ((SourceGrid.Grid)sender.Grid)[c_row + 2, c_col].Editor = null;
                }
                else
                    ((SourceGrid.Grid)sender.Grid)[c_row, c_col].Value = oldValue;
                return;
            }

        }

        public override void OnEditEnded(CellContext sender, EventArgs e)
        {
            base.OnEditEnded(sender, e);

            if (sender.Value == null && oldValue == null)
                return;

            SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
            int c_row = sender.Position.Row;
            int c_col = sender.Position.Column;
            int c_SubGroupWeek = c_col - 1;

            int c_day = days.SelectedIndex + 1;
            if (groups.Text == "")
            {
                grid[c_row + 1, c_col].Editor = grid[c_row + 2, c_col].Editor = null;
                return;
            }
            else
            {
                if (grid[c_row + 1, c_col] != null)
                    grid[c_row + 1, c_col].Editor = Methods.getTeachersEditor(teachers);
                if (grid[c_row + 2, c_col] != null)
                    grid[c_row + 2, c_col].Editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            }

            int c_group = int.Parse(groups.Text);
            int c_number = (int)grid[c_row, 0].Value;

            var table = from rowtt in db_table
                        where rowtt.Day == c_day
                        && rowtt.GroupNumber == c_group
                        && rowtt.Number == c_number
                        && rowtt.LessonsRow.Title == oldValue
                        && (rowtt.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                        select rowtt;

            if (sender.Value == null)
            {
                return;
            }

            var q_les = from row in lessons
                        where row.Title == (string)grid[c_row, c_col].Value
                        select row;
            if (q_les.Count() == 0)
            {
                DialogResult result = MessageBox.Show("Вы хотите добавить новый предмет?", "Новый предмет", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    grid[c_row, c_col].Value = oldValue;
                    grid[c_row + 1, c_col].Editor = grid[c_row + 2, c_col].Editor = null;
                    return;
                }

                form_newLesson frm = new form_newLesson((string)grid[c_row, c_col].Value);
                frm.ShowDialog();
                lessons.AddLessonsRow(frm.FullName, frm.ShortName);

            }

            int newLessonId = q_les.First().LessonID;

            var table2 = from row in db_table
                         where row.Day == c_day
                         && row.GroupNumber == c_group
                         && row.Number == c_number
                         && row.LessonID == newLessonId
                         select row;

            if (table2.Count() == 0)
            {
                if (table.Count() == 0)
                {
                    db_table.Addft_timetableRow(c_day, c_number, c_group, lessons.FindByLessonID(newLessonId), teachers[0], "0", (1 << c_SubGroupWeek) + (1 << grid.ColumnsCount - 1));
                }
                else
                {
                    foreach (var row in table)
                    {
                        //Delete last lesson
                        row.WeekSubGroup &= 0xFFFFFF ^ (1 << c_SubGroupWeek);
                        int newWeekSubGroup = (1 << c_SubGroupWeek) + (1 << grid.ColumnsCount - 1);
                        db_table.Addft_timetableRow(row.Day, row.Number, row.GroupNumber,
                            lessons.FindByLessonID(newLessonId), row.TeachersRow,
                            row.AudienceNumber, newWeekSubGroup);
                        break;
                    }
                }
            }
            else
            {
                foreach (var row in table)
                {
                    //Delete last lesson
                    row.WeekSubGroup &= 0xFFFFFF ^ (1 << c_SubGroupWeek);
                    break;
                }
                foreach (var row in table2)
                {
                    row.WeekSubGroup |= (1 << c_SubGroupWeek);
                }
            }
        }
    }

    //Contoller for cells with teacher's info
    class TeacherCellContollerFT : SourceGrid.Cells.Controllers.ControllerBase
    {
        ds_db.ft_timetableDataTable db_table;
        ds_db.LessonsDataTable lessons;
        ds_db.TeachersDataTable teachers;
        private ComboBox days;
        private ComboBox groups;
        private string oldValue;

        public TeacherCellContollerFT(ref ComboBox days, ref ComboBox groups, ds_db.ft_timetableDataTable ft_table, ds_db.LessonsDataTable lessons, ds_db.TeachersDataTable teachers)
        {
            this.days = days;
            this.groups = groups;
            this.db_table = ft_table;
            this.lessons = lessons;
            this.teachers = teachers;
        }

        public override void OnFocusEntered(CellContext sender, EventArgs e)
        {
            base.OnFocusEntered(sender, e);
            oldValue = (string)sender.Value;
        }

        public override void OnEditEnded(CellContext sender, EventArgs e)
        {
            base.OnEditEnded(sender, e);
            if (sender.Value == null)
                return;

            int c_row = sender.Position.Row;
            int c_col = sender.Position.Column;
            int c_SubGroupWeek = c_col - 1;
            int c_day = days.SelectedIndex + 1;
            int c_group = int.Parse(groups.Text);
            int c_number = (int)((SourceGrid.Grid)sender.Grid)[c_row, 0].Value;
            SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
            var teacherInfo = ((string)grid[c_row, c_col].Value).Split(' ').ToArray();
            if (teacherInfo.Length != 3)
            {
                MessageBox.Show("Введите ФИО преподавателя!", "Некорректные ФИО преподователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid[c_row, c_col].Value = oldValue;
                return;
            }

            var q_teachers = from row in teachers
                             where row.LastName == teacherInfo[0] &&
                                   row.FirstName == teacherInfo[1] &&
                                   row.Patronymic == teacherInfo[2]
                             select row.TeacherID;

            if (q_teachers.Count() == 0)
            {
                DialogResult result = MessageBox.Show("Вы хотите добавить нового преподавателя?", "Новый преподаватель", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    grid[c_row, c_col].Value = oldValue;
                    return;
                }
                else
                {
                    teachers.AddTeachersRow(teacherInfo[0], teacherInfo[1], teacherInfo[2]);
                }
            }

            var table = from rowtt in db_table
                        where rowtt.Day == c_day
                        && rowtt.GroupNumber == c_group
                        && rowtt.Number == c_number
                        && (rowtt.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                        select rowtt;

            foreach (var row in table)
                row.TeacherID = q_teachers.First();


            oldValue = (string)sender.Value;
        }
    }

    class AudienceCellContollerFT : SourceGrid.Cells.Controllers.ControllerBase
    {
        ds_db.ft_timetableDataTable db_table;
        private ComboBox days;
        private ComboBox groups;
        string oldValue;

        public AudienceCellContollerFT(ref ComboBox days, ref ComboBox groups, ds_db.ft_timetableDataTable db_table)
        {
            this.days = days;
            this.groups = groups;
            this.db_table = db_table;
        }

        public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
        {
            base.OnFocusEntering(sender, e);
            oldValue = (string)sender.Value;
            if ((string)(((SourceGrid.Grid)sender.Grid)[sender.Position.Row - 2, sender.Position.Column].Value) != null)
            sender.Cell.Editor = Methods.getAuditor(db_table);
        }
        public override void OnFocusEntered(CellContext sender, EventArgs e)
        {
            base.OnFocusEntered(sender, e);
        }

        public override void OnEditEnded(CellContext sender, EventArgs e)
        {
            base.OnEditEnded(sender, e);

            int c_row = sender.Position.Row;
            int c_col = sender.Position.Column;
            int c_SubGroupWeek = c_col - 1;
            int c_day = days.SelectedIndex + 1;
            int c_group = int.Parse(groups.Text);
            int c_number = (int)((SourceGrid.Grid)sender.Grid)[c_row, 0].Value;
                        string newAudience = (string)sender.Value;

            SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
            char[] separator = {' ', '(', ')', '/', '_'};
            var t = from row in db_table
                    where row.Day == c_day && row.Number == c_number
                    && row.AudienceNumber.Split(separator, StringSplitOptions.RemoveEmptyEntries).SequenceEqual(newAudience.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                    select row;

            foreach(var row in t)
            {
                if (row.GroupNumber == c_group) continue;
                var a = row.AudienceNumber.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var b = newAudience.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if ((row.WeekSubGroup & (1 << c_SubGroupWeek)) != 0)
                {
                    MessageBox.Show("Данная аудитория уже используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sender.Value = oldValue;
                    return;
                }
            }

            var table = from row in db_table
                        where row.Day == c_day
                        && row.GroupNumber == c_group
                        && row.Number == c_number
                        && row.LessonsRow.Title == (string)grid[c_row - 2, c_col].Value
                        && (row.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                        select row;

            if (newAudience == null)
                newAudience = "-1";

            foreach (var row in table)
                row.AudienceNumber = newAudience;
        }
    }

    //Contoller for cells with lessons's info
    class LessonCellContollerPT : SourceGrid.Cells.Controllers.ControllerBase

    {
        ds_db.pt_timetableDataTable db_table;
        ds_db.LessonsDataTable lessons;
        ds_db.TeachersDataTable teachers;
        private ComboBox days;
        private ComboBox groups;
        private string oldValue;

        public LessonCellContollerPT(ref ComboBox days, ref ComboBox groups,
            ds_db.pt_timetableDataTable pt_table, ds_db.LessonsDataTable lessons, ds_db.TeachersDataTable teachers)
        {
            this.days = days;
            this.groups = groups;
            this.db_table = pt_table;
            this.lessons = lessons;
            this.teachers = teachers;
        }
        public override void OnFocusEntered(CellContext sender, EventArgs e)
        {
            base.OnFocusEntered(sender, e);
            oldValue = (string)sender.Value;
            sender.Cell.Editor = Methods.getLessonsEditor(lessons);
        }

        public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
        {
            base.OnValueChanged(sender, e);

            if ((string)sender.Value == null)
            {
                if (oldValue == null)
                    return;
                int c_row = sender.Position.Row;
                int c_col = sender.Position.Column;
                int c_SubGroupWeek = c_col - 1;
                int c_day = days.SelectedIndex + 1;
                int c_group = int.Parse(groups.Text);
                int c_number = (int)((SourceGrid.Grid)sender.Grid)[c_row, 0].Value;

                var table = from rowtt in db_table
                            where rowtt.Day == c_day
                            && rowtt.GroupNumber == c_group
                            && rowtt.Number == c_number
                            && rowtt.LessonsRow.Title == oldValue
                            && (rowtt.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                            select rowtt;


                DialogResult result = MessageBox.Show("Удалить занятие?", "Удаление занятия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (var row in table)
                    {
                        row.WeekSubGroup &= 0xFFFFFF ^ (1 << c_SubGroupWeek);
                        if (row.WeekSubGroup == (1 << Methods.numbersOfSubGroups(row.WeekSubGroup)))
                            row.Delete();
                        break;
                    }
                    ((SourceGrid.Grid)sender.Grid)[c_row, c_col].Value = ((SourceGrid.Grid)sender.Grid)[c_row + 1, c_col].Value = ((SourceGrid.Grid)sender.Grid)[c_row + 2, c_col].Value = "";
                    ((SourceGrid.Grid)sender.Grid)[c_row + 1, c_col].Editor = ((SourceGrid.Grid)sender.Grid)[c_row + 2, c_col].Editor = null;
                }
                else
                    ((SourceGrid.Grid)sender.Grid)[c_row, c_col].Value = oldValue;
                return;
            }

        }

        public override void OnEditEnded(CellContext sender, EventArgs e)
        {
            base.OnEditEnded(sender, e);

            if (sender.Value == null && oldValue == null)
                return;

            SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
            int c_row = sender.Position.Row;
            int c_col = sender.Position.Column;
            int c_SubGroupWeek = c_col - 1;

            int c_day = days.SelectedIndex + 1;
            if (groups.Text == "")
            {
                grid[c_row + 1, c_col].Editor = grid[c_row + 2, c_col].Editor = null;
                return;
            }
            else
            {
                if (grid[c_row + 1, c_col] != null)
                    grid[c_row + 1, c_col].Editor = Methods.getTeachersEditor(teachers);
                if (grid[c_row + 2, c_col] != null)
                    grid[c_row + 2, c_col].Editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            }

            int c_group = int.Parse(groups.Text);
            int c_number = (int)grid[c_row, 0].Value;

            var table = from rowtt in db_table
                        where rowtt.Day == c_day
                        && rowtt.GroupNumber == c_group
                        && rowtt.Number == c_number
                        && rowtt.LessonsRow.Title == oldValue
                        && (rowtt.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                        select rowtt;

            if (sender.Value == null)
            {
                return;
            }

            var q_les = from row in lessons
                        where row.Title == (string)grid[c_row, c_col].Value
                        select row;
            if (q_les.Count() == 0)
            {
                DialogResult result = MessageBox.Show("Вы хотите добавить новый предмет?", "Новый предмет", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    grid[c_row, c_col].Value = oldValue;
                    grid[c_row + 1, c_col].Editor = grid[c_row + 2, c_col].Editor = null;
                    return;
                }

                form_newLesson frm = new form_newLesson((string)grid[c_row, c_col].Value);
                frm.ShowDialog();
                lessons.AddLessonsRow(frm.FullName, frm.ShortName);

            }

            int newLessonId = q_les.First().LessonID;

            var table2 = from row in db_table
                         where row.Day == c_day
                         && row.GroupNumber == c_group
                         && row.Number == c_number
                         && row.LessonID == newLessonId
                         select row;

            if (table2.Count() == 0)
            {
                if (table.Count() == 0)
                {
                    db_table.Addpt_timetableRow(c_day, c_number, c_group, lessons.FindByLessonID(newLessonId), teachers[0], "0", (1 << c_SubGroupWeek) + (1 << grid.ColumnsCount - 1));
                }
                else
                {
                    foreach (var row in table)
                    {
                        //Delete last lesson
                        row.WeekSubGroup &= 0xFFFFFF ^ (1 << c_SubGroupWeek);
                        int newWeekSubGroup = (1 << c_SubGroupWeek) + (1 << grid.ColumnsCount - 1);
                        db_table.Addpt_timetableRow(row.Day, row.Number, row.GroupNumber,
                            lessons.FindByLessonID(newLessonId), row.TeachersRow,
                            row.AudienceNumber, newWeekSubGroup);
                        break;
                    }
                }
            }
            else
            {
                foreach (var row in table)
                {
                    //Delete last lesson
                    row.WeekSubGroup &= 0xFFFFFF ^ (1 << c_SubGroupWeek);
                    break;
                }
                foreach (var row in table2)
                {
                    row.WeekSubGroup |= (1 << c_SubGroupWeek);
                }
            }
        }
    }

    //Contoller for cells with teacher's info
    class TeacherCellContollerPT : SourceGrid.Cells.Controllers.ControllerBase
    {
        ds_db.pt_timetableDataTable db_table;
        ds_db.LessonsDataTable lessons;
        ds_db.TeachersDataTable teachers;
        private ComboBox days;
        private ComboBox groups;
        private string oldValue;

        public TeacherCellContollerPT(ref ComboBox days, ref ComboBox groups, ds_db.pt_timetableDataTable pt_table, ds_db.LessonsDataTable lessons, ds_db.TeachersDataTable teachers)
        {
            this.days = days;
            this.groups = groups;
            this.db_table = pt_table;
            this.lessons = lessons;
            this.teachers = teachers;
        }

        public override void OnFocusEntered(CellContext sender, EventArgs e)
        {
            base.OnFocusEntered(sender, e);
            oldValue = (string)sender.Value;
        }

        public override void OnEditEnded(CellContext sender, EventArgs e)
        {
            base.OnEditEnded(sender, e);
            if (sender.Value == null)
                return;

            int c_row = sender.Position.Row;
            int c_col = sender.Position.Column;
            int c_SubGroupWeek = c_col - 1;
            int c_day = days.SelectedIndex + 1;
            int c_group = int.Parse(groups.Text);
            int c_number = (int)((SourceGrid.Grid)sender.Grid)[c_row, 0].Value;
            SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
            var teacherInfo = ((string)grid[c_row, c_col].Value).Split(' ').ToArray();
            if (teacherInfo.Length != 3)
            {
                MessageBox.Show("Введите ФИО преподавателя!", "Некорректные ФИО преподователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid[c_row, c_col].Value = oldValue;
                return;
            }

            var q_teachers = from row in teachers
                             where row.LastName == teacherInfo[0] &&
                                   row.FirstName == teacherInfo[1] &&
                                   row.Patronymic == teacherInfo[2]
                             select row.TeacherID;

            if (q_teachers.Count() == 0)
            {
                DialogResult result = MessageBox.Show("Вы хотите добавить нового преподавателя?", "Новый преподаватель", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    grid[c_row, c_col].Value = oldValue;
                    return;
                }
                else
                {
                    teachers.AddTeachersRow(teacherInfo[0], teacherInfo[1], teacherInfo[2]);
                }
            }

            var table = from rowtt in db_table
                        where rowtt.Day == c_day
                        && rowtt.GroupNumber == c_group
                        && rowtt.Number == c_number
                        && (rowtt.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                        select rowtt;

            foreach (var row in table)
                row.TeacherID = q_teachers.First();


            oldValue = (string)sender.Value;
        }
    }

    class AudienceCellContollerPT : SourceGrid.Cells.Controllers.ControllerBase
    {
        ds_db.pt_timetableDataTable db_table;
        private ComboBox days;
        private ComboBox groups;

        public AudienceCellContollerPT(ref ComboBox days, ref ComboBox groups, ds_db.pt_timetableDataTable db_table)
        {
            this.days = days;
            this.groups = groups;
            this.db_table = db_table;
        }

        public override void OnFocusEntered(CellContext sender, EventArgs e)
        {
            base.OnFocusEntered(sender, e);
        }

        public override void OnEditEnded(CellContext sender, EventArgs e)
        {
            base.OnEditEnded(sender, e);

            int c_row = sender.Position.Row;
            int c_col = sender.Position.Column;
            int c_SubGroupWeek = c_col - 1;
            int c_day = days.SelectedIndex + 1;
            int c_group = int.Parse(groups.Text);
            int c_number = (int)((SourceGrid.Grid)sender.Grid)[c_row, 0].Value;
            SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;

            var table = from row in db_table
                        where row.Day == c_day
                        && row.GroupNumber == c_group
                        && row.Number == c_number
                        && row.LessonsRow.Title == (string)grid[c_row - 2, c_col].Value
                        && (row.WeekSubGroup & (1 << c_SubGroupWeek)) != 0
                        select row;

            string newAudience = (string)sender.Value;
            if (newAudience == null)
                newAudience = "-1";

            foreach (var row in table)
                row.AudienceNumber = newAudience;
        }
    }

}
