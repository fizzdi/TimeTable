using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace TimeTable.Tools
{
    static class ToExcel
    {
        private static Excel.Application excelapp;

        public static void ExcelClose()
        {
            if (excelapp != null)
                excelapp.Quit();
        }

        public static void CreateBooks(ref ds_db db)
        {
            excelapp = new Excel.Application();

            bool error = false;
            if (File.Exists("app.cfg"))
            {
                using (StreamReader reader = new StreamReader("app.cfg"))
                {
                    if (Console.ReadLine() == null)
                    {
                        error = true;
                    }
                }
            }
            else error = true;

            if (error)
            {
                MessageBox.Show("Перед составлением расписания проверьте настройки!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SettingsForm frm = new SettingsForm();
                frm.ShowDialog();
            }

            //Full time and Part time
            excelapp.SheetsInNewWorkbook = 2;
            excelapp.Workbooks.Add(Type.Missing);

            //Use full time workbook
            Excel.Workbook ft_wb = excelapp.Workbooks[1];
            ft_wb.Activate();
            FillWorkSheet(db.ft_timetable);
            FillWorkSheet(db.pt_timetable);
            excelapp.Visible = true;
        }

        private static void FillWorkSheet(ds_db.ft_timetableDataTable ds)
        {
            string[] roman_numbers = { "I подгруппа", "II подгруппа", "III подгруппа", "IV подгруппа", "V подгруппа", "VI подгруппа", "VII подгруппа", "VIII подгруппа", "IX подгруппа", "X" };
            string[] days_of_week = { "Понедельник", "Вторник", "Среда",
                "Четверг", "Пятница", "Суббота", "VII"};
            //Borders
            const int fatBorder = 3;
            const int solidBorder = 2;
            const int veryfatBorder = 4;
            //Columns
            const int col_days_width = 4;
            const int col_nums_width = 2;
            const int col_weeks_width = 8;
            const int col_lesson_width = 14;
            const int col_audit_width = 5;
            //Rows
            const int row_lesson_height = 24;
            //Font Sizes
            const int fs_nums = 14;
            const int fs_days = 18;
            const int fs_nums_of_week = 8;
            const int fs_lesson_row = 9;
            const int fs_audience_wraped = 8;
            const int fs_header = 36;
            const int fs_subheader = 16;
            //Max length
            const int ml_merged = 35;
            const int ml_non_merged = 15;

            Excel.Workbook ft_wb = excelapp.ActiveWorkbook;
            Excel.Worksheet sht = ft_wb.Sheets[1];
            sht.Name = "Очная форма";
            Excel.Range range;

            int headerEnd = 6;
            int rsideEnd = 4;
            int c_col = rsideEnd;
            int c_row = headerEnd;
            Dictionary<int, int> groups = ds.Select(t => new { GroupNumber = t.GroupNumber, subGroups = Tools.Methods.numbersOfSubGroups(t.WeekSubGroup) / 2 })
                .GroupBy(t => t.GroupNumber)
                .Select(t => new { Group = t.Key, subGroups = t.Max(a => a.subGroups) })
                .OrderBy(t => t.Group)
                .ToDictionary(t => t.Group, t => t.subGroups);

            range = sht.Range[sht.Cells[headerEnd, 1], sht.Cells[headerEnd + 1, 3]];
            range.Merge();
            range.Borders.Weight = fatBorder;

            //Width of days column
            range = sht.Cells[headerEnd, 1];
            range.ColumnWidth = col_days_width;

            //Width of numbers column
            range = sht.Cells[headerEnd, 2];
            range.ColumnWidth = col_nums_width;

            //Width of weeks column
            range = sht.Cells[headerEnd, 3];
            range.ColumnWidth = col_weeks_width;

            //Set font
            ft_wb.Styles["Normal"].Font.Name = "Times New Roman";

            foreach (var cur in groups)
            {
                range = sht.Range[sht.Cells[headerEnd, c_col], sht.Cells[headerEnd, c_col + cur.Value * 2 - 1]];
                range.Merge();
                range.Value = cur.Key;


                range = sht.Range[sht.Cells[headerEnd, c_col], sht.Cells[headerEnd + 1, c_col + cur.Value * 2 - 1]];
                range.Borders.Weight = fatBorder;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = solidBorder;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = solidBorder;


                for (int i = 0; i < cur.Value; ++i)
                {
                    range = sht.Range[sht.Cells[headerEnd + 1, c_col], sht.Cells[headerEnd + 1, c_col + 1]];
                    range.Merge();
                    sht.Cells[headerEnd + 1, c_col] = roman_numbers[i];
                    sht.Cells[headerEnd + 1, c_col].ColumnWidth = col_lesson_width;
                    sht.Cells[headerEnd + 1, c_col + 1].ColumnWidth = col_audit_width;
                    c_col += 2;
                }
            }
            c_row += 2;

            for (int c_day = 1; c_day <= 6; ++c_day)
            {
                var t_day = from row in ds
                            where row.Day == c_day
                            select row;
                if (t_day.Count() == 0) continue;
                int maxLessons = t_day.Max(t => t.Number);
                range = sht.Range[sht.Cells[c_row, 1], sht.Cells[c_row + maxLessons * 2 - 1, 1]];
                range.Merge();
                range.Font.Size = fs_days;
                range.Orientation = Excel.XlOrientation.xlUpward;
                range.Value = days_of_week[c_day - 1];
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = fatBorder;
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = fatBorder;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = veryfatBorder;

                for (int i = 0; i < maxLessons; ++i)
                {
                    range = sht.Range[sht.Cells[c_row + i * 2, 2], sht.Cells[c_row + i * 2 + 1, 2]];
                    sht.Cells[c_row + i * 2, 3].Value = "1 неделя";
                    sht.Cells[c_row + i * 2, 3].Font.Size = fs_nums_of_week;
                    sht.Cells[c_row + i * 2 + 1, 3].Value = "2 неделя";
                    sht.Cells[c_row + i * 2 + 1, 3].Font.Size = fs_nums_of_week;
                    range.Merge();
                    range.Value = i + 1;
                    range.Font.Size = fs_nums;
                    range.RowHeight = row_lesson_height;
                    range = sht.Range[sht.Cells[c_row + i * 2, 2], sht.Cells[c_row + i * 2 + 1, 3]];
                    if (i > 0)
                        range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = fatBorder;
                    range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = fatBorder;
                    range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = fatBorder;
                    range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = veryfatBorder;
                    range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = solidBorder;
                    range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = solidBorder;
                }

                c_col = 4;
                foreach (var c_group in groups)
                {
                    int old_row = c_row;
                    for (int i = 1; i <= maxLessons; ++i)
                    {
                        var cur_les = from row in t_day
                                      where row.GroupNumber == c_group.Key
                                      && row.Number == i
                                      select row;

                        range = sht.Range[sht.Cells[c_row, c_col], sht.Cells[c_row + 1, c_col + 3]];
                        range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = fatBorder;
                        range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = fatBorder;
                        range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = fatBorder;
                        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = solidBorder;
                        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = solidBorder;

                        foreach (var row in cur_les)
                        {
                            //if lessons every week
                            if (Methods.isLessonEveryWeek(row.WeekSubGroup, c_group.Value))
                            {
                                range = sht.Range[sht.Cells[c_row, c_col], sht.Cells[c_row+1, c_col + 2]];
                                range.Merge();
                                range.Value = Methods.LessonString(row, ml_merged);
                                range.Font.Size = fs_lesson_row;
                                range = sht.Range[sht.Cells[c_row, c_col + 3], sht.Cells[c_row + 1, c_col + 3]];
                                range.Merge();
                                range.Value = row.AudienceNumber;
                                if (row.AudienceNumber.Length > 4)
                                    range.Font.Size = fs_audience_wraped;
                            }
                            else
                            {
                                //In first week of the first subgroup
                                if (Methods.isWillLesson(row.WeekSubGroup, 1, 1, c_group.Value))
                                {
                                    //In first week of the whole group
                                    if (Methods.isWillLesson(row.WeekSubGroup, 1, 2, c_group.Value))
                                    {
                                        range = sht.Range[sht.Cells[c_row, c_col], sht.Cells[c_row, c_col + 2]];
                                        range.Merge();
                                        range.Value = Methods.LessonString(row, ml_merged);
                                        range.Font.Size = fs_lesson_row;
                                        sht.Cells[c_row, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                    else
                                    { //In first week of the first subgroup 
                                        sht.Cells[c_row, c_col].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row, c_col].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row, c_col + 1].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row, c_col + 1].Font.Size = fs_audience_wraped;
                                    }
                                }
                                else
                                {
                                    //In first week of the second subgroup
                                    if (Methods.isWillLesson(row.WeekSubGroup, 1, 2, c_group.Value))
                                    {
                                        sht.Cells[c_row, c_col + 2].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row, c_col + 2].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                }

                                //In second week of the first subgroup
                                if (Methods.isWillLesson(row.WeekSubGroup, 2, 1, c_group.Value))
                                {
                                    //In second week of the whole group
                                    if (Methods.isWillLesson(row.WeekSubGroup, 2, 2, c_group.Value))
                                    {
                                        range = sht.Range[sht.Cells[c_row+1, c_col], sht.Cells[c_row+1, c_col + 2]];
                                        range.Merge();
                                        range.Value = Methods.LessonString(row, ml_merged);
                                        range.Font.Size = fs_lesson_row;
                                        sht.Cells[c_row+1, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row + 1, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                    else
                                    { //In second week of the first subgroup 
                                        sht.Cells[c_row+1, c_col].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row+1, c_col].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row+1, c_col + 1].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row + 1, c_col + 1].Font.Size = fs_audience_wraped;
                                    }
                                }
                                else
                                {
                                    //In second week of the second subgroup
                                    if (Methods.isWillLesson(row.WeekSubGroup, 2, 2, c_group.Value))
                                    {
                                        sht.Cells[c_row + 1, c_col + 2].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row + 1, c_col + 2].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row + 1, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row + 1, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                }
                            }
                        }
                        c_row += 2;
                    }
                    c_row = old_row;
                    c_col += c_group.Value * 2;
                }
                c_row += maxLessons * 2;
                range = sht.Range[sht.Cells[c_row, 1], sht.Cells[c_row, c_col - 1]];
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = veryfatBorder;

            }

            range = sht.Range[sht.Cells[2, 1], sht.Cells[2, c_col-1]];
            range.Merge();
            range.Value = "Расписание занятий";
            range.Font.Size = fs_header;
            range.Font.Bold = true;

            range = sht.Range[sht.Cells[3, 1], sht.Cells[3, c_col - 1]];
            range.Merge();
            using (StreamReader reader = new StreamReader("app.cfg"))
            {
                range.Value = "Факультета " + reader.ReadLine();
            }
            range.Font.Size = fs_subheader;
            range.Font.Bold = true;


            //All alignment center
            range = sht.Range[sht.Cells[1, 1], sht.Cells[c_row, c_col]];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.WrapText = true;
        }

        private static void FillWorkSheet(ds_db.pt_timetableDataTable ds)
        {
            string[] roman_numbers = { "I подгруппа", "II подгруппа", "III подгруппа", "IV подгруппа", "V подгруппа", "VI подгруппа", "VII подгруппа", "VIII подгруппа", "IX подгруппа", "X" };
            string[] days_of_week = { "Понедельник", "Вторник", "Среда",
                "Четверг", "Пятница", "Суббота", "VII"};
            //Borders
            const int fatBorder = 3;
            const int solidBorder = 2;
            const int veryfatBorder = 4;
            //Columns
            const int col_days_width = 4;
            const int col_nums_width = 2;
            const int col_weeks_width = 8;
            const int col_lesson_width = 14;
            const int col_audit_width = 5;
            //Rows
            const int row_lesson_height = 24;
            //Font Sizes
            const int fs_nums = 14;
            const int fs_days = 18;
            const int fs_nums_of_week = 8;
            const int fs_lesson_row = 9;
            const int fs_audience_wraped = 8;
            const int fs_header = 36;
            const int fs_subheader = 16;
            //Max length
            const int ml_merged = 35;
            const int ml_non_merged = 15;

            Excel.Workbook pt_wb = excelapp.ActiveWorkbook;
            Excel.Worksheet sht = pt_wb.Sheets[2];
            sht.Name = "Очно-заочная форма";
            Excel.Range range;

            int headerEnd = 6;
            int rsideEnd = 4;
            int c_col = rsideEnd;
            int c_row = headerEnd;
            Dictionary<int, int> groups = ds.Select(t => new { GroupNumber = t.GroupNumber, subGroups = Tools.Methods.numbersOfSubGroups(t.WeekSubGroup) / 2 })
                .GroupBy(t => t.GroupNumber)
                .Select(t => new { Group = t.Key, subGroups = t.Max(a => a.subGroups) })
                .OrderBy(t => t.Group)
                .ToDictionary(t => t.Group, t => t.subGroups);

            range = sht.Range[sht.Cells[headerEnd, 1], sht.Cells[headerEnd + 1, 3]];
            range.Merge();
            range.Borders.Weight = fatBorder;

            //Width of days column
            range = sht.Cells[headerEnd, 1];
            range.ColumnWidth = col_days_width;

            //Width of numbers column
            range = sht.Cells[headerEnd, 2];
            range.ColumnWidth = col_nums_width;

            //Width of weeks column
            range = sht.Cells[headerEnd, 3];
            range.ColumnWidth = col_weeks_width;

            //Set font
            pt_wb.Styles["Normal"].Font.Name = "Times New Roman";

            foreach (var cur in groups)
            {
                range = sht.Range[sht.Cells[headerEnd, c_col], sht.Cells[headerEnd, c_col + cur.Value * 2 - 1]];
                range.Merge();
                range.Value = cur.Key;


                range = sht.Range[sht.Cells[headerEnd, c_col], sht.Cells[headerEnd + 1, c_col + cur.Value * 2 - 1]];
                range.Borders.Weight = fatBorder;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = solidBorder;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = solidBorder;


                for (int i = 0; i < cur.Value; ++i)
                {
                    range = sht.Range[sht.Cells[headerEnd + 1, c_col], sht.Cells[headerEnd + 1, c_col + 1]];
                    range.Merge();
                    sht.Cells[headerEnd + 1, c_col] = roman_numbers[i];
                    sht.Cells[headerEnd + 1, c_col].ColumnWidth = col_lesson_width;
                    sht.Cells[headerEnd + 1, c_col + 1].ColumnWidth = col_audit_width;
                    c_col += 2;
                }
            }
            c_row += 2;

            for (int c_day = 1; c_day <= 6; ++c_day)
            {
                var t_day = from row in ds
                            where row.Day == c_day
                            select row;
                if (t_day.Count() == 0) continue;
                int maxLessons = t_day.Max(t => t.Number);
                range = sht.Range[sht.Cells[c_row, 1], sht.Cells[c_row + maxLessons * 2 - 1, 1]];
                range.Merge();
                range.Font.Size = fs_days;
                range.Orientation = Excel.XlOrientation.xlUpward;
                range.Value = days_of_week[c_day - 1];
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = fatBorder;
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = fatBorder;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = veryfatBorder;

                for (int i = 0; i < maxLessons; ++i)
                {
                    range = sht.Range[sht.Cells[c_row + i * 2, 2], sht.Cells[c_row + i * 2 + 1, 2]];
                    sht.Cells[c_row + i * 2, 3].Value = "1 неделя";
                    sht.Cells[c_row + i * 2, 3].Font.Size = fs_nums_of_week;
                    sht.Cells[c_row + i * 2 + 1, 3].Value = "2 неделя";
                    sht.Cells[c_row + i * 2 + 1, 3].Font.Size = fs_nums_of_week;
                    range.Merge();
                    range.Value = i + 1;
                    range.Font.Size = fs_nums;
                    range.RowHeight = row_lesson_height;
                    range = sht.Range[sht.Cells[c_row + i * 2, 2], sht.Cells[c_row + i * 2 + 1, 3]];
                    if (i > 0)
                        range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = fatBorder;
                    range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = fatBorder;
                    range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = fatBorder;
                    range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = veryfatBorder;
                    range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = solidBorder;
                    range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = solidBorder;
                }

                c_col = 4;
                foreach (var c_group in groups)
                {
                    int old_row = c_row;
                    for (int i = 1; i <= maxLessons; ++i)
                    {
                        var cur_les = from row in t_day
                                      where row.GroupNumber == c_group.Key
                                      && row.Number == i
                                      select row;

                        range = sht.Range[sht.Cells[c_row, c_col], sht.Cells[c_row + 1, c_col + 3]];
                        range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = fatBorder;
                        range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = fatBorder;
                        range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = fatBorder;
                        range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = solidBorder;
                        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = solidBorder;

                        foreach (var row in cur_les)
                        {
                            //if lessons every week
                            if (Methods.isLessonEveryWeek(row.WeekSubGroup, c_group.Value))
                            {
                                range = sht.Range[sht.Cells[c_row, c_col], sht.Cells[c_row + 1, c_col + 2]];
                                range.Merge();
                                range.Value = Methods.LessonString(row, ml_merged);
                                range.Font.Size = fs_lesson_row;
                                range = sht.Range[sht.Cells[c_row, c_col + 3], sht.Cells[c_row + 1, c_col + 3]];
                                range.Merge();
                                range.Value = row.AudienceNumber;
                                if (row.AudienceNumber.Length > 4)
                                    range.Font.Size = fs_audience_wraped;
                            }
                            else
                            {
                                //In first week of the first subgroup
                                if (Methods.isWillLesson(row.WeekSubGroup, 1, 1, c_group.Value))
                                {
                                    //In first week of the whole group
                                    if (Methods.isWillLesson(row.WeekSubGroup, 1, 2, c_group.Value))
                                    {
                                        range = sht.Range[sht.Cells[c_row, c_col], sht.Cells[c_row, c_col + 2]];
                                        range.Merge();
                                        range.Value = Methods.LessonString(row, ml_merged);
                                        range.Font.Size = fs_lesson_row;
                                        sht.Cells[c_row, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                    else
                                    { //In first week of the first subgroup 
                                        sht.Cells[c_row, c_col].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row, c_col].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row, c_col + 1].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row, c_col + 1].Font.Size = fs_audience_wraped;
                                    }
                                }
                                else
                                {
                                    //In first week of the second subgroup
                                    if (Methods.isWillLesson(row.WeekSubGroup, 1, 2, c_group.Value))
                                    {
                                        sht.Cells[c_row, c_col + 2].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row, c_col + 2].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                }

                                //In second week of the first subgroup
                                if (Methods.isWillLesson(row.WeekSubGroup, 2, 1, c_group.Value))
                                {
                                    //In second week of the whole group
                                    if (Methods.isWillLesson(row.WeekSubGroup, 2, 2, c_group.Value))
                                    {
                                        range = sht.Range[sht.Cells[c_row + 1, c_col], sht.Cells[c_row + 1, c_col + 2]];
                                        range.Merge();
                                        range.Value = Methods.LessonString(row, ml_merged);
                                        range.Font.Size = fs_lesson_row;
                                        sht.Cells[c_row + 1, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row + 1, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                    else
                                    { //In second week of the first subgroup 
                                        sht.Cells[c_row + 1, c_col].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row + 1, c_col].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row + 1, c_col + 1].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row + 1, c_col + 1].Font.Size = fs_audience_wraped;
                                    }
                                }
                                else
                                {
                                    //In second week of the second subgroup
                                    if (Methods.isWillLesson(row.WeekSubGroup, 2, 2, c_group.Value))
                                    {
                                        sht.Cells[c_row + 1, c_col + 2].Value = Methods.LessonString(row, ml_non_merged);
                                        sht.Cells[c_row + 1, c_col + 2].Font.Size = fs_lesson_row;
                                        sht.Cells[c_row + 1, c_col + 3].Value = row.AudienceNumber;
                                        if (row.AudienceNumber.Length > 4)
                                            sht.Cells[c_row + 1, c_col + 3].Font.Size = fs_audience_wraped;
                                    }
                                }
                            }
                        }
                        c_row += 2;
                    }
                    c_row = old_row;
                    c_col += c_group.Value * 2;
                }
                c_row += maxLessons * 2;
                range = sht.Range[sht.Cells[c_row, 1], sht.Cells[c_row, c_col - 1]];
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = veryfatBorder;

            }

            range = sht.Range[sht.Cells[2, 1], sht.Cells[2, c_col - 1]];
            range.Merge();
            range.Value = "Расписание занятий";
            range.Font.Size = fs_header;
            range.Font.Bold = true;

            range = sht.Range[sht.Cells[3, 1], sht.Cells[3, c_col - 1]];
            range.Merge();
            using (StreamReader reader = new StreamReader("app.cfg"))
            {
                range.Value = "Факультета " + reader.ReadLine();
            }
            range.Font.Size = fs_subheader;
            range.Font.Bold = true;


            //All alignment center
            range = sht.Range[sht.Cells[1, 1], sht.Cells[c_row, c_col]];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.WrapText = true;
        }

    }
}
