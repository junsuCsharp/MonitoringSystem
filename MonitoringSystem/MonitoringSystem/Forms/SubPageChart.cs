using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartDirector;
using System.Threading;
using System.Globalization;

namespace MonitoringSystem.Forms
{
    public partial class SubPageChart : Form
    {
        public SubPageChart()
        {
            InitializeComponent();
        }


        public SubPageChart(Unit id)
        {
            InitializeComponent();

            myUnitId = id;
        }

        DataBase dataBase = new DataBase();

        public enum Unit
        {
            Hour, Day, Week, Month, Max
        }

        enum EChart
        {
            Bar, Line
        }

        private Unit myUnitId;
        private Random random = new Random();

        string Title;

        List<Size> szViewer = new List<Size>();

        string[] strMonthLabels = { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" };
        string[] strWeekLabels = { "일", "월", "화", "수", "목", "금", "토" };

        Color colorHigh = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
        Color colorLow = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));

        int iColorHigh = 32 << 16 | 56 << 8 | 100;
        int iColorLow = 51 << 16 | 102 << 8 | 255;

        int WhatDay;
        int WhatYear;

        private void SubPageChart_Load(object sender, EventArgs e)
        {
            WhatDay = DateTime.Today.Day;
            WhatYear = DateTime.Today.Year;

            comboBox1.SelectedIndex = 0;

            dataBase.Connect();
            dataBase.Create_Table();

            dataBase.Delete_Row();//필요없는 연도 정보 삭제

            dataBase.test_data();//년,월,주 정보 로드
            dataBase.prevYearData_1 = dataBase.prevDataLoad((WhatYear - 1));
            dataBase.prevYearData_2 = dataBase.prevDataLoad((WhatYear - 2));
            dataBase.prevYearData_3 = dataBase.prevDataLoad((WhatYear - 3));

            //1~3년 전 정보 받아오기
            dataBase.yearData((WhatYear - 1), dataBase.prevYearData_1, out MonitoringSystem.DataBase.prevYearOK_1, out MonitoringSystem.DataBase.prevYearNG_1);
            dataBase.yearData((WhatYear - 2), dataBase.prevYearData_2, out MonitoringSystem.DataBase.prevYearOK_2, out MonitoringSystem.DataBase.prevYearNG_2);
            dataBase.yearData((WhatYear - 3), dataBase.prevYearData_3, out MonitoringSystem.DataBase.prevYearOK_3, out MonitoringSystem.DataBase.prevYearNG_3);

            dataBase.test_month_dataLoad();
            dataBase.test_week_dataLoad();
            dataBase.test_year_dataLoad();

            dataBase.test_day_data();//시간별 정보 로드

            szViewer.Add(winChartViewer1.Size);

            CreateChart(winChartViewer1);

            subPageCahrt_Size();

            dataBase.start_data();

            //data update를 위한 쓰레드
            //Thread myThread = new Thread(data_update);
            
            //myThread.Start();

            timer1.Start();
        }

        void data_update()
        {
            if (WhatDay != DateTime.Today.Day)
            {
                dataBase.test_data();

                dataBase.test_month_dataLoad();
                dataBase.test_week_dataLoad();
                dataBase.test_year_dataLoad();
                dataBase.test_day_data();

                WhatDay = DateTime.Today.Day;
            }
            if(WhatYear!=DateTime.Today.Year)
            {
                dataBase.Delete_Row();

                WhatYear = DateTime.Today.Year;
            }

            dataBase.month_data();
            dataBase.week_data();
            dataBase.year_data();
            dataBase.test_day_data();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            data_update();

            CreateChart(winChartViewer1);
        }

        void CreateChart(WinChartViewer viewer)
        {
            //sample data
            double[] data0 = { 100, 125, 156, 147, 87, 124, 178, 109, 140, 106, 192, 122 };
            double[] data1 = { 122, 156, 179, 211, 198, 177, 160, 220, 190, 188, 220, 270 };
            //double[] data2 = { 167, 190, 213, 267, 250, 320, 212, 199, 245, 267, 240, 310 };
            string[] labels = Chart_X_String(myUnitId);

            // The data for the bar chart
            //double[] data0 = { 100, 115, 165, 107, 67 };
            //double[] data1 = { 85, 106, 129, 161, 123 };
            //double[] data2 = { 67, 87, 86, 167, 157 };

            data0 = Chart_SampleData_ng(myUnitId);
            data1 = Chart_SampleData_ok(myUnitId);

            // The labels for the bar chart
            //string[] labels = { "Mon", "Tue", "Wed", "Thu", "Fri" };

            // Create a XYChart object of size 600 x 360 pixels
            XYChart c = new XYChart(szViewer[(int)EChart.Bar].Width,szViewer[(int)EChart.Bar].Height + 20);
            //XYChart c = new XYChart(Convert.ToInt32(((double)(szViewer[(int)EChart.Bar].Width)) * FormMain.X_Scale), Convert.ToInt32(((double)(szViewer[(int)EChart.Bar].Height) + 20) * FormMain.Y_Scale));

            c.addTitle(Title, null, 20);

            // Set default text color to dark grey (0x333333)
            c.setColor(Chart.TextColor, 0x333333);

            // Set the plotarea at (70, 20) and of size 400 x 300 pixels, with transparent
            // background and border and light grey (0xcccccc) horizontal grid lines
            //c.setPlotArea(70, 20, 400, 300, Chart.Transparent, -1, Chart.Transparent, 0xcccccc);
            int offsetWidth =Convert.ToInt32(85);
            int offsetHeight =Convert.ToInt32(45);
            c.setPlotArea(offsetWidth, offsetHeight, szViewer[(int)EChart.Bar].Width - offsetWidth - 20, szViewer[(int)EChart.Bar].Height - 60, 0xf8f8f8, 0xffffff);
            //c.setPlotArea(offsetWidth, offsetHeight,Convert.ToInt32 ((double)(szViewer[(int)EChart.Bar].Width - offsetWidth - 10)*FormMain.X_Scale),Convert.ToInt32 ((double)(szViewer[(int)EChart.Bar].Height - 60)*FormMain.Y_Scale), 0xf8f8f8, 0xffffff);

            // Add a legend box at (480, 20) using vertical layout and 12pt Arial font. Set
            // background and border to transparent and key icon border to the same as the fill
            // color.
            LegendBox b = c.addLegend(1300, 5, false, "Arial", 8 * FormMain.min_Scale);
            b.setBackground(Chart.Transparent, Chart.Transparent);
            b.setKeyBorder(Chart.SameAsMainColor);

            // Set the x and y axis stems to transparent and the label font to 12pt Arial
            c.xAxis().setColors(Chart.Transparent);
            c.yAxis().setColors(Chart.Transparent);
            c.xAxis().setLabelStyle("Arial", 12);
            c.yAxis().setLabelStyle("Arial", 12);

            // Add a stacked bar layer
            BarLayer layer = c.addBarLayer2(Chart.Stack);

            // Add the three data sets to the bar layer
            //layer.addDataSet(data0, 0xaaccee, "Server # 1");
            //layer.addDataSet(data0, iColorLow, "불량수량");
            layer.addDataSet(data1, iColorHigh, "생산수량");
            //layer.addDataSet(data2, 0xeeaa66, "Server # 3");

            // Set the bar border to transparent
            layer.setBorderColor(Chart.Transparent);

            // Enable labelling for the entire bar and use 12pt Arial font
            layer.setAggregateLabelStyle("Arial", 12);

            // Enable labelling for the bar segments and use 12pt Arial font with center alignment
            layer.setDataLabelStyle("Arial", 10, 16777215).setAlignment(Chart.Center);

            // For a vertical stacked bar with positive data, the first data set is at the bottom.
            // For the legend box, by default, the first entry at the top. We can reverse the legend
            // order to make the legend box consistent with the stacked bar.
            layer.setLegendOrder(Chart.ReverseLegend);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            //c.xAxis().setTickDensity(5);

            // For the automatic y-axis labels, set the minimum spacing to 40 pixels.
            c.yAxis().setTickDensity(40);

            // Add a title to the y axis using dark grey (0x555555) 14pt Arial Bold font
            c.yAxis().setTitle("수량 [ 횟수 ]", "Arial Bold", 10 * FormMain.min_Scale, 0x555555);

            // Output the chart
            viewer.Chart = c;

            //include tool tip for the chart
            //viewer.ImageMap = c.getHTMLImageMap("clickable", "", "title='{dataSetName} {xLabel}: {value}'");
        }

        string[] Chart_X_String(Unit unit)
        {
            string[] strXaxis = new string[] { };
            switch (unit)
            {
                case Unit.Hour:
                    comboBox1.Hide();
                    strXaxis = new string[24];
                    for (int idx = 0; idx < strXaxis.Length; idx++)
                    {
                        strXaxis[idx] = $"{idx:0}"+"시";
                    }
                    break;
                case Unit.Day:
                    comboBox1.Hide();
                    strXaxis = new string[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)];
                    for (int idx = 0; idx < strXaxis.Length; idx++)
                    {
                        strXaxis[idx] = $"{idx+1:0}"+"일";
                    }
                    break;
                case Unit.Week:
                    comboBox1.Hide();
                    strXaxis = new string[strWeekLabels.Length];
                    for (int idx = 0; idx < strXaxis.Length; idx++)
                    {
                        strXaxis[idx] = strWeekLabels[idx];
                    }
                    break;
                case Unit.Month:
                    comboBox1.Show();
                    strXaxis = new string[strMonthLabels.Length];
                    for (int idx = 0; idx < strXaxis.Length; idx++)
                    {
                        strXaxis[idx] = strMonthLabels[idx];
                    }
                    break;
            }
            return strXaxis;
        }

        double[] Chart_SampleData_ok(Unit unit)
        {
            double[] dXaxis_ok = new double[] { };
            switch (unit)
            {
                case Unit.Hour:
                    dXaxis_ok = new double[24];
                    for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                    {
                        dXaxis_ok[idx] = DataBase.hour_ok_arr[idx];
                        Title = DateTime.Today.Date.ToString("M월d일");
                    }
                    break;
                case Unit.Day:
                    dXaxis_ok = new double[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)];
                    for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                    {
                        dXaxis_ok[idx] = DataBase.month_ok_arr[idx];
                        Title = DateTime.Today.Month + "월";
                    }
                    break;
                case Unit.Week:
                    dXaxis_ok = new double[7];
                    for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                    {
                        dXaxis_ok[idx] = DataBase.week_ok_arr[idx];
                        Title = DateTime.Today.Year + "년" + dataBase.GetWeekOfYear(DateTime.Now, CultureInfo.CurrentCulture) + "주차";
                    }
                    break;
                case Unit.Month:
                    dXaxis_ok = new double[12];
                    if(comboBox1.SelectedIndex==0)
                    {
                        for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                        {
                            dXaxis_ok[idx] = DataBase.year_ok_arr[idx];
                            Title = DateTime.Today.Year + "년";
                        }
                    }
                    else if(comboBox1.SelectedIndex == 1)
                    {
                        for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                        {
                            dXaxis_ok[idx] = MonitoringSystem.DataBase.prevYearOK_1[idx];
                            Title = DateTime.Today.Year - 1 + "년";
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                        {
                            dXaxis_ok[idx] = MonitoringSystem.DataBase.prevYearOK_2[idx];
                            Title = DateTime.Today.Year - 2 + "년";
                        }
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        for (int idx = 0; idx < dXaxis_ok.Length; idx++)
                        {
                            dXaxis_ok[idx] = MonitoringSystem.DataBase.prevYearOK_3[idx];
                            Title = DateTime.Today.Year - 3 + "년";
                        }
                    }
                    break;
            }

            return dXaxis_ok;
        }
        double[] Chart_SampleData_ng(Unit unit)
        {
            double[] dXaxis = new double[] { };
            switch (unit)
            {
                case Unit.Hour:
                    dXaxis = new double[24];
                    for (int idx = 0; idx < dXaxis.Length; idx++)
                    {
                        dXaxis[idx] = DataBase.hour_ng_arr[idx];
                    }
                    break;
                case Unit.Day:
                    dXaxis = new double[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)];
                    for (int idx = 0; idx < dXaxis.Length; idx++)
                    {
                        dXaxis[idx] = DataBase.month_ng_arr[idx];
                    }
                    break;
                case Unit.Week:
                    dXaxis = new double[7];
                    for (int idx = 0; idx < dXaxis.Length; idx++)
                    {
                        dXaxis[idx] = DataBase.week_ng_arr[idx];
                    }
                    break;
                case Unit.Month:
                    dXaxis = new double[12];
                    if (comboBox1.SelectedIndex == 0)
                    {
                        for (int idx = 0; idx < dXaxis.Length; idx++)
                        {
                            dXaxis[idx] = DataBase.year_ng_arr[idx];
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        for (int idx = 0; idx < dXaxis.Length; idx++)
                        {
                            dXaxis[idx] = MonitoringSystem.DataBase.prevYearNG_1[idx];
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        for (int idx = 0; idx < dXaxis.Length; idx++)
                        {
                            dXaxis[idx] = MonitoringSystem.DataBase.prevYearNG_2[idx];
                        }
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        for (int idx = 0; idx < dXaxis.Length; idx++)
                        {
                            dXaxis[idx] = MonitoringSystem.DataBase.prevYearNG_3[idx];
                        }
                    }
                    break;
            }

            return dXaxis;
        }

        public void Insert_Row()
        {
            dataBase.Insert_Row();
        }

        public void subPageCahrt_Size()
        {
            ClientSize = new Size(Convert.ToInt32(this.Width * FormMain.X_Scale), Convert.ToInt32(this.Height * FormMain.Y_Scale));
            winChartViewer1.Size = new Size(Convert.ToInt32(winChartViewer1.Width * FormMain.X_Scale), Convert.ToInt32(winChartViewer1.Height * FormMain.Y_Scale));

            comboBox1.Size = new Size(Convert.ToInt32(comboBox1.Width * FormMain.X_Scale), Convert.ToInt32(comboBox1.Height * FormMain.Y_Scale));
            comboBox1.Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(comboBox1.Font.Size * FormMain.min_Scale));
            comboBox1.Location = new Point(Convert.ToInt32(comboBox1.Location.X * FormMain.X_Scale), Convert.ToInt32(comboBox1.Location.Y * FormMain.Y_Scale));
        }
    }
}

