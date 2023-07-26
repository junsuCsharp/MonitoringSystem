using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Globalization;

namespace MonitoringSystem
{
    class DataBase
    {
        public static SQLiteConnection DBConnect;

        DateTime Tomorrow = DateTime.Today.AddDays(1);
        static DateTime today = DateTime.Today;

        static string DB_PATH = $"{Application.StartupPath}\\";
        static string SQLITE_DB = $"Production_Quantity_" + today.ToString("yyyy") + ".db";
        //static string SQLITE_DB = $"Production_Quantity.db";

        public static int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
        public static string[] Month_ok_list = new string[DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)];
        public static string[] Month_ng_list = new string[DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)];

        int OK_cnt;
        int NG_cnt;
        int alarm_cnt;
        int model_num;

        string test_date;
        string test_data1;
        string test_data2;
        string test_data_year;
        string test_data_month;
        string test_data_day;
        string test_data_week;

        const int year_length = 366;
        const int day_length = 24;

        string[,] test_data_arr = new string[7, year_length];

        int[] test_year_ok_arr = new int[12];
        int[] test_year_ng_arr = new int[12];
        public static int[] year_ok_arr = new int[12];
        public static int[] year_ng_arr = new int[12];

        int[] test_month_ok_arr = new int[DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)];
        int[] test_month_ng_arr = new int[DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)];
        public static int[] month_ok_arr = new int[DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)];
        public static int[] month_ng_arr = new int[DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)];

        int[] test_week_ok_arr = new int[7];
        int[] test_week_ng_arr = new int[7];
        public static int[] week_ok_arr = new int[7];
        public static int[] week_ng_arr = new int[7];

        int[] test_hour_ok_arr = new int[day_length];
        int[] test_hour_ng_arr = new int[day_length];
        public static int[] hour_ok_arr = new int[day_length];
        public static int[] hour_ng_arr = new int[day_length];

        int test_cnt = 0;

        public void Connect()//DB파일 생성, 연결
        {
            DBConnect = new SQLiteConnection("Data Source=" + DB_PATH + SQLITE_DB);

            DBConnect.Open();
        }

        /// <summary>
        /// 2023.06.22 김준수
        /// 주간 데이터 선별 조건의 모호함에 따른 database 저장 데이터 추가(week)
        /// </summary>
        public void Create_Table()
        {
            try
            {
                string sql = "create table members (date string, time string, OK int, NG int, year string, month string, day string, hour string, week string, AlarmCount int, RobotDriveTime int)";

                SQLiteCommand command = new SQLiteCommand(sql, DBConnect);
                int result = command.ExecuteNonQuery();

            }

            catch
            {

            }
        }

        public void Insert_Row()
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string time = DateTime.Now.ToString("HH:mm");

            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string hour = DateTime.Now.ToString("HH");
            string week = GetWeekOfYear(DateTime.Now, CultureInfo.CurrentCulture).ToString();
            int robotDriveTime=Forms.PageMain.TotalTime;
            int alarm_cnt = Forms.PageMain.alarmCnt;
            int grip_cnt = Forms.PageMain.GripCount;
            OK_cnt = Externs.Robot_Modbus_Table.lstModbusData[04].iCurrData;
            NG_cnt = Externs.Robot_Modbus_Table.lstModbusData[05].iCurrData;
            model_num = Externs.Robot_Modbus_Table.lstModbusData[01].iCurrData;


            string sql = "insert into members (date, time, OK, NG, year, month, day, hour, week, AlarmCount, RobotDriveTime, GripCount) values " +
                "('" + date + "', '" + time + "', " + OK_cnt + ", " + NG_cnt + ", '" + year + "', '" + month + "', '" + day + "', '" + hour + "', '" + week + "', " + alarm_cnt + ", '" + robotDriveTime + "', ," + grip_cnt + "')";

            SQLiteCommand command = new SQLiteCommand(sql, DBConnect);
            int result = command.ExecuteNonQuery();
        }

        public void close_connection()
        {
            DBConnect.Close();
        }

        public int GetWeekOfYear(DateTime sourceDate, CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;

            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            return cultureInfo.Calendar.GetWeekOfYear(sourceDate, calendarWeekRule, firstDayOfWeek);
        }

        public void test_data()//테스트 데이터(날짜별 최대 OK NG 저장)
        {
            test_cnt = 0;

            //전체 읽어 오는 구문
            //string sql = "select date, max(OK), max(NG), year, month, day, week from members group by date";

            //2023.07.24 김준수 데이터베이스 읽어오는 방식 변경(전체 읽기->today data안 읽고 )
            //Load할 떄, 날짜가 바뀔때 읽기
            //특정일을 제외하고 정보를 읽어오는 구문 -> 날짜를 today로 변경해서 사용
            //select date, max(OK), max(NG), year, month, day, week from members WHERE date NOT in ('2023-07-21') group by date
            string date = DateTime.Now.ToString("yyyy/MM/dd");

            string sql = "select date, max(OK), max(NG), year, month, day, week from members WHERE date NOT in ('" + date + "') group by date";

            //2023.07.24 System.InvalidOperationException: 'Connection was closed, statement was terminated' 에러확인을 위해 임시 삭제
            //SQLiteCommand cmd = new SQLiteCommand(sql, DBConnect);
            //SQLiteDataReader rdr = cmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    test_date = rdr["date"].ToString();
            //    test_data1 = rdr["max(OK)"].ToString();
            //    test_data2 = rdr["max(NG)"].ToString();
            //    test_data_year = rdr["year"].ToString();
            //    test_data_month = rdr["month"].ToString();
            //    test_data_day = rdr["day"].ToString();
            //    test_data_week = rdr["week"].ToString();

            //    test_data_arr[0, test_cnt] = test_date;
            //    test_data_arr[1, test_cnt] = test_data1;
            //    test_data_arr[2, test_cnt] = test_data2;
            //    test_data_arr[3, test_cnt] = test_data_year;
            //    test_data_arr[4, test_cnt] = test_data_month;
            //    test_data_arr[5, test_cnt] = test_data_day;
            //    test_data_arr[6, test_cnt] = test_data_week;

            //    test_cnt++;
            //}

            //2023.07.24 using 사용하여 database read
            using (SQLiteCommand cmd = new SQLiteCommand(sql, DBConnect))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        test_date = rdr["date"].ToString();
                        test_data1 = rdr["max(OK)"].ToString();
                        test_data2 = rdr["max(NG)"].ToString();
                        test_data_year = rdr["year"].ToString();
                        test_data_month = rdr["month"].ToString();
                        test_data_day = rdr["day"].ToString();
                        test_data_week = rdr["week"].ToString();

                        test_data_arr[0, test_cnt] = test_date;
                        test_data_arr[1, test_cnt] = test_data1;
                        test_data_arr[2, test_cnt] = test_data2;
                        test_data_arr[3, test_cnt] = test_data_year;
                        test_data_arr[4, test_cnt] = test_data_month;
                        test_data_arr[5, test_cnt] = test_data_day;
                        test_data_arr[6, test_cnt] = test_data_week;

                        test_cnt++;
                    }
                    rdr.Close();
                }
            }
        }

        //데이터 베이스에서 읽어 온 정보를 월별 데이터로 변환
        public void test_year_dataLoad()
        {
            Array.Clear(test_year_ok_arr, 0, test_year_ok_arr.Length);
            Array.Clear(test_year_ng_arr, 0, test_year_ng_arr.Length);

            for (int i = 0; i < year_length; i++)
            {
                if (test_data_arr[3, i] == today.Year.ToString())
                {
                    test_year_ok_arr[Convert.ToInt32(test_data_arr[4, i]) - 1] += Convert.ToInt32(test_data_arr[1, i]);
                    test_year_ng_arr[Convert.ToInt32(test_data_arr[4, i]) - 1] += Convert.ToInt32(test_data_arr[2, i]);
                }
            }
            //year_data에서 당일 데이터 추가 예정
            //year_ok_arr = test_year_ok_arr;
            //year_ng_arr = test_year_ng_arr;
        }

        //월별 데이터에 당일 데이터 추가
        public void year_data()
        {
            var production_cnt = Externs.Robot_Modbus_Table.lstModbusData[4];
            var error_cnt = Externs.Robot_Modbus_Table.lstModbusData[5];

            int today_month = Convert.ToInt32(DateTime.Now.Month);

            int[] _year_ok_arr = new int[12];
            int[] _year_ng_arr = new int[12];

            //year_ok_arr = test_year_ok_arr;
            _year_ok_arr = (int[])test_year_ok_arr.Clone();
            _year_ng_arr = (int[])test_year_ng_arr.Clone();

            _year_ok_arr[today_month - 1] = test_year_ok_arr[today_month - 1] + production_cnt.iCurrData;
            _year_ng_arr[today_month - 1] = test_year_ng_arr[today_month - 1] + error_cnt.iCurrData;

            year_ok_arr = _year_ok_arr;
            year_ng_arr = _year_ng_arr;
        }

        public void test_month_dataLoad()
        {
            Array.Clear(test_month_ok_arr, 0, test_month_ok_arr.Length);
            Array.Clear(test_month_ng_arr, 0, test_month_ng_arr.Length);

            for (int i = 0; i < year_length; i++)
            {
                if (test_data_arr[3, i] == today.Year.ToString() && test_data_arr[4, i] == today.Month.ToString())
                {
                    test_month_ok_arr[Int32.Parse(test_data_arr[5, i]) - 1] = Int32.Parse(test_data_arr[1, i]);
                    test_month_ng_arr[Int32.Parse(test_data_arr[5, i]) - 1] = Int32.Parse(test_data_arr[2, i]);

                }
            }
            //month_ok_arr = test_month_ok_arr;
            //month_ng_arr = test_month_ng_arr;
        }

        public void month_data()
        {
            var production_cnt = Externs.Robot_Modbus_Table.lstModbusData[4];
            var error_cnt = Externs.Robot_Modbus_Table.lstModbusData[5];

            int today_day = Convert.ToInt32(DateTime.Now.Day);

            int[] _month_ok_arr = new int[test_month_ok_arr.Length];
            int[] _month_ng_arr = new int[test_month_ng_arr.Length];

            _month_ok_arr = (int[])test_month_ok_arr.Clone();
            _month_ng_arr = (int[])test_month_ng_arr.Clone();

            _month_ok_arr[today_day - 1] = test_month_ok_arr[today_day - 1] + production_cnt.iCurrData;
            _month_ng_arr[today_day - 1] = test_month_ng_arr[today_day - 1] + error_cnt.iCurrData;

            month_ok_arr = _month_ok_arr;
            month_ng_arr = _month_ng_arr;
        }

        public void test_week_dataLoad()
        {
            Array.Clear(test_week_ok_arr, 0, test_week_ok_arr.Length);
            Array.Clear(test_week_ng_arr, 0, test_week_ng_arr.Length);

            string today_week;
            string week = GetWeekOfYear(DateTime.Now, CultureInfo.CurrentCulture).ToString();
            today_week = week;

            for (int i = 0; i < year_length; i++)
            {
                if (test_data_arr[3, i] == today.Year.ToString() && test_data_arr[6, i] == week)
                {
                    int week_numver = WhatDay(Convert.ToDateTime(test_data_arr[0, i]));

                    test_week_ok_arr[week_numver - 1] = Int32.Parse(test_data_arr[1, i]);
                    test_week_ng_arr[week_numver - 1] = Int32.Parse(test_data_arr[2, i]);
                }
            }
            //week_ok_arr = test_week_ok_arr;
            //week_ng_arr = test_week_ng_arr;
        }

        public void week_data()
        {
            var production_cnt = Externs.Robot_Modbus_Table.lstModbusData[4];
            var error_cnt = Externs.Robot_Modbus_Table.lstModbusData[5];

            int today_week =Convert.ToInt32(DateTime.Today.DayOfWeek);

            int[] _week_ok_arr = new int[7];
            int[] _week_ng_arr = new int[7];

            _week_ok_arr = (int[])test_week_ok_arr.Clone();
            _week_ng_arr = (int[])test_week_ng_arr.Clone();

            _week_ok_arr[today_week] = test_week_ok_arr[today_week] + production_cnt.iCurrData;
            _week_ng_arr[today_week] = test_week_ng_arr[today_week] + error_cnt.iCurrData;

            week_ok_arr = _week_ok_arr;
            week_ng_arr = _week_ng_arr;
        }

        int WhatDay(DateTime a)
        {
            int ireturn = 0;

            DayOfWeek b = a.DayOfWeek;

            switch (b)
            {
                case DayOfWeek.Sunday:
                    ireturn = 1;
                    break;
                case DayOfWeek.Monday:
                    ireturn = 2;
                    break;
                case DayOfWeek.Tuesday:
                    ireturn = 3;
                    break;
                case DayOfWeek.Wednesday:
                    ireturn = 4;
                    break;
                case DayOfWeek.Thursday:
                    ireturn = 5;
                    break;
                case DayOfWeek.Friday:
                    ireturn = 6;
                    break;
                case DayOfWeek.Saturday:
                    ireturn = 7;
                    break;
            }
            return ireturn;
        }

        public void test_day_data()//당일 데이터
        {
            Array.Clear(test_hour_ok_arr, 0, test_hour_ok_arr.Length);
            Array.Clear(test_hour_ng_arr, 0, test_hour_ng_arr.Length);

            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string sql = "select hour, max(OK), max(NG) from members where date = '" + date + "' GROUP by hour";

            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnect);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                test_data_day = rdr["hour"].ToString();
                test_data1 = rdr["max(OK)"].ToString();
                test_data2 = rdr["max(NG)"].ToString();

                test_hour_ok_arr[Int32.Parse(test_data_day)] = Int32.Parse(test_data1);
                test_hour_ng_arr[Int32.Parse(test_data_day)] = Int32.Parse(test_data2);

            }
            rdr.Close();

            for (int j = 1; j < day_length; j++)
            {
                if (test_hour_ok_arr[j] < test_hour_ok_arr[j - 1])
                {
                    test_hour_ok_arr[j] = test_hour_ok_arr[j - 1];
                    test_hour_ng_arr[j] = test_hour_ng_arr[j - 1];
                }
            }

            for (int j = 1; j < day_length; j++)
            {
                hour_ok_arr[day_length - j] = test_hour_ok_arr[day_length - j] - test_hour_ok_arr[day_length - j - 1];
                hour_ng_arr[day_length - j] = test_hour_ng_arr[day_length - j] - test_hour_ng_arr[day_length - j - 1];
            }

        }

        public void start_data()
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string sql = "select AlarmCount, RobotDriveTime, GripCount from members ORDER BY ROWID DESC LIMIT 1";

            SQLiteCommand cmd = new SQLiteCommand(sql, MonitoringSystem.DataBase.DBConnect);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Forms.PageMain.alarmCnt = Convert.ToInt32( rdr["AlarmCount"]);
                Forms.PageMain.TotalTime = Convert.ToInt32(rdr["RobotDriveTime"]);
                Forms.PageMain.GripCount = Convert.ToInt32(rdr["GripCount"]);
            }
        }
    }
}
