using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Diagnostics;

namespace MonitoringSystem.Forms
{
    public partial class PageMain : System.Windows.Forms.Form
    {
        public PageMain()
        {
            InitializeComponent();

        }

        List<Label> PageMainLabel = new List<Label>();
        List<Panel> PageMainPanel = new List<Panel>();
        List<TableLayoutPanel> PageMainTableLayoutPanel = new List<TableLayoutPanel>();

        List<Button> lstButtons = new List<Button>();
        List<SubPageChart> lstFormChart = new List<SubPageChart>();
        List<Button> lstManuButtons = new List<Button>();

        Forms.SubPageChart subPageChart = new Forms.SubPageChart();

        DateTime today = DateTime.Today;
        List<Button> PageQuantityButton = new List<Button>();
        const float chart_title_fontsize = 27.75f;
        public string chart_name = "day";
        public static int alarmCnt = 0;
        public int PrevDay;//알람 횟수 초기화를 위한 날짜 비교
        public static int TotalTime;
        public static int GripCount;
        const double targetOperateTime = 5;

        //public enum ESrt
        //{
        //    None, Count, Product, Lift
        //}

        //public enum ProgramSrc
        //{
        //    Pallect, chiken, mechine
        //}

        List<string> alarm_list = new List<string> { "Master_On", "Xaxis_Power", "Yaxis_Power", "Zaxis_Power", "Xaxis_Left_Limit", "Xaxis_Right_Limit", "Yaxis_Fore_Limit", "Yaxis_Back_Limit", "Zaxis_Up_Limit", "Zaxis_Down_Limit",
            "Xaxis_Ready", "Xaxis_Home", "Xaxis_Error", "Servo_Comm", "Yaxis_Ready", "Yaxis_Home", "Yaxis_Error", "Zaxis_Ready", "Zaxis_Home", "Zaxis_Error", "Estop_Panel", "Estop_OpBox1", "Estop_OpBox2", "Estop_OpBox3", "Estop_Cobot",
            "ServoOn_Cobot", "Air_Pressure", "SSU1_Error", "SSU2_Error", "Conveyor_AirPressure" };

        //List<string> alarm_comment = new List<string> { "장비 마스터 On키가 꺼져있습니다.", "LH X축 서보 파워 차단되었습니다.\r\n 마스터 ON 키를 눌러주세요 ", "LH Y축 서보 파워 차단되었습니다.\r\n 마스터 ON 키를 눌러주세요 ",
        //    "LH Z축 서보 파워 차단되었습니다.\r\n 마스터 ON 키를 눌러주세요 ", "LH X축 왼쪽 리밋 감지되었습니다.", "LH X축 오른쪽 리밋 감지되었습니다.", "LH Y축 전진 리밋 감지되었습니다.", "LH Y축 후진 리밋 감지되었습니다.",
        //    "LH Z축 상승 리밋 감지되었습니다.", "LH Z축 하강 리밋 감지되었습니다.", "LH X축 서보가 예기치 못하게 Ready 신호가 OFF되었습니다.\r\n 리셋 해주세요.", "LH X축 원점이 맞지 않습니다.\r\n 원점복귀 버튼을 눌러주세요.",
        //    "LH X축 서보에러_리셋 후\r\n 원점 복귀버튼을 눌러주세요.", "서보통신에러_\r\n장비 상태를 점검해주세요.", "LH Y축 서보가 예기치 못하게 Ready 신호가 OFF되었습니다.\r\n 리셋 해주세요.", "LH Y축 원점이 맞지 않습니다.\r\n 원점복귀 버튼을 눌러주세요.",
        //    "LH Y축 서보에러_리셋 후\r\n 원점 복귀버튼을 눌러주세요.", "LH Z축 서보가 예기치 못하게 Ready 신호가 OFF되었습니다.\r\n 리셋 해주세요.", "LH Z축 원점이 맞지 않습니다.\r\n 원점복귀 버튼을 눌러주세요.",
        //    "LH Z축 서보에러_리셋 후\r\n 원점 복귀버튼을 눌러주세요.", "메인판넬 비상정지가 눌러졌습니다.", "작업자버튼박스1 비상정지가 눌러졌습니다.", "작업자버튼박스2 비상정지가 눌러졌습니다.", "작업자버튼박스3 비상정지가 눌러졌습니다.",
        //    "코봇 비상정지가 눌러졌습니다.", "코봇 서보온이 꺼졌습니다.", "메인공압이 정상이 아닙니다.", "진공 흡기가 정상이 아닙니다.", "개별2 공압이 정상이 아닙니다.", "컨베어 메인공압이 정상이 아닙니다." };

        List<string> alarm_comment = new List<string> { "장비 마스터 On키 꺼짐", "LH X축 서보 파워 차단", "LH Y축 서보 파워 차단", "LH Z축 서보 파워 차단", "LH X축 왼쪽 리밋 감지", "LH X축 오른쪽 리밋 감지", "LH Y축 전진 리밋 감지",
            "LH Y축 후진 리밋 감지", "LH Z축 상승 리밋 감지", "LH Z축 하강 리밋 감지", "LH X축 서보 Ready 신호 OFF", "LH X축 원점 벗어남", "LH X축 서보에러", "서보통신에러", "LH Y축 서보 Ready 신호 OFF", "LH Y축 원점 벗어남",
            "LH Y축 서보에러", "LH Z축 서보 Ready 신호 OFF", "LH Z축 원점 벗어남", "LH Z축 서보에러", "메인판넬 비상정지 상태", "작업자버튼박스1 비상정지 상태", "작업자버튼박스2 비상정지 상태", "작업자버튼박스3 비상정지 상태",
            "코봇 비상정지 상태", "코봇 서보온 꺼짐", "메인공압 비정상", "진공 흡기 비정상", "개별2 공압 비정상", "컨베어 메인공압 비정상" };

        Stopwatch swCompleteTime = new Stopwatch();
        long Time = 0;

        /// <summary>
        /// 2023.05.?? 김준수 작성
        /// 2323.06.22 알람 내역 상세화
        /// 화면 표시
        /// </summary>
        public void PageMain_Display()
        {
            double BarValue;
            double completeTime = 0;

            var operate_rate = Externs.Robot_Modbus_Table.lstModbusData[0];//가동률
            var total_quantity = Externs.Robot_Modbus_Table.lstModbusData[2];//작업전체수량
            var progress_quantity = Externs.Robot_Modbus_Table.lstModbusData[3];//작업진행수량
            var production_cnt = Externs.Robot_Modbus_Table.lstModbusData[4];//생산수량
            var error_cnt = Externs.Robot_Modbus_Table.lstModbusData[5];//불량수량
            var alarm_code = Externs.Robot_Modbus_Table.lstModbusData[6];//알람코드
            var total_box_cnt = Externs.Robot_Modbus_Table.lstModbusData[14];//레이어 박스 총 수량
            var total_layer_cnt = Externs.Robot_Modbus_Table.lstModbusData[15];//팔레트 레이어 총 수량
            var cur_box_cnt = Externs.Robot_Modbus_Table.lstModbusData[16];//레이어 박스 진행 수량
            var cur_layer_cnt = Externs.Robot_Modbus_Table.lstModbusData[17];//팔레트 레이어 진행 수량
            var work_state = Externs.Robot_Modbus_Table.lstModbusData[32];//작업 상태
            var box_time = Externs.Robot_Modbus_Table.lstModbusData[33];//박스 작업 시간
            var total_time = Externs.Robot_Modbus_Table.lstModbusData[34];//팔레트 작업 시간
            var load_direction = Externs.Robot_Modbus_Table.lstModbusData[20];//적재방향


            //가동률
            labelPPM.Text = ((double)operate_rate.iCurrData / targetOperateTime * 100).ToString();

            //시간당 생산량
            labelPPH.Text = Convert.ToString(operate_rate.iCurrData * 60);

            //작업 완료 예상 소요 시간 
            if (load_direction.iCurrData == 3 || load_direction.iCurrData == 4)
            {
                completeTime = (double)(total_quantity.iCurrData) / targetOperateTime * 2 * 60;
            }
            else
            {
                completeTime = (double)(total_quantity.iCurrData) / targetOperateTime * 60;
            }

            double[] copleteTime_ = Time_Hour_Min_Sec(completeTime);
            labelCompleteTime.Text = copleteTime_[1].ToString("00") + " : " + copleteTime_[2].ToString("00");

            //실제 소요 시간
            if (FormMain.workState == "Start")
            {
                swCompleteTime.Start();
                Time = swCompleteTime.ElapsedMilliseconds;
            }
            else if (FormMain.workState == "Pause")
            {
                swCompleteTime.Stop();
                Time = swCompleteTime.ElapsedMilliseconds;
            }
            else if(FormMain.workState== "Cancel")
            {
                swCompleteTime.Reset();
            }
            else if (FormMain.workState == "Wait")
            {
                swCompleteTime.Reset();
            }
            else
            {
                Time = swCompleteTime.ElapsedMilliseconds;
            }

            double[] arrCompletTime = Time_Hour_Min_Sec((double)Time / 1000);
            labelCompleteTimeSpan.Text = arrCompletTime[1].ToString("00") + " : " + arrCompletTime[2].ToString("00");

            //박스 당 소요 시간
            double[] arrTimeBox = Time_Hour_Min_Sec((double)box_time.iPrevData);
            labelBoxRunTime.Text = arrTimeBox[0].ToString("00") + " : " + arrTimeBox[1].ToString("00") + " : " + arrTimeBox[2].ToString("00");

            //팔레트 당 소요 시간(현재 작업 시간)
            double[] arrTimeNow = Time_Hour_Min_Sec((double)total_time.iPrevData);
            labelRunTimeNow.Text = arrTimeNow[0].ToString("00") + " : " + arrTimeNow[1].ToString("00") + " : " + arrTimeNow[2].ToString("00");

            //그리퍼 사용횟수(누적)
            if (production_cnt.iPrevData != 0 && production_cnt.iPrevData < production_cnt.iCurrData)
            {
                GripCount += (production_cnt.iCurrData - production_cnt.iPrevData);
            }

            labelGripperCount.Text = GripCount.ToString();

            //전체 가동 시간(누적)
            if (total_time.iPrevData != 0 && total_time.iPrevData < total_time.iCurrData)
            {
                TotalTime += (total_time.iCurrData - total_time.iPrevData);
            }

            double[] arrTimeTotal = Time_Hour_Min_Sec((double)TotalTime);

            labelRunTimeTotal.Text = arrTimeTotal[0].ToString("00") + " : " + arrTimeTotal[1].ToString("00") + " : " + arrTimeTotal[2].ToString("00");


            //팔레트 기준 달성률
            if (total_quantity.iCurrData != 0)
            {
                BarValue = Convert.ToDouble(progress_quantity.iCurrData) / Convert.ToDouble(total_quantity.iCurrData) * 100;

                label2.Text = BarValue.ToString("0");
            }
            else
            {
                label2.Text = "0";
            }
            labelTotalProgress.Text = progress_quantity.iCurrData + "  /  " + total_quantity.iCurrData;

            //레이어 기준 달성률
            labelLayerProgress.Text = cur_layer_cnt.iCurrData + "  /  " + total_layer_cnt.iCurrData;

            //박스 기준 달성률
            labelBoxProgress.Text = cur_box_cnt.iCurrData + "  /  " + total_box_cnt.iCurrData;

            //생산수량
            labelOKProduct.Text = Convert.ToString(production_cnt.iCurrData);

            //불량수량
            labelNGProduct.Text = Convert.ToString(error_cnt.iCurrData);

            //전체수량
            int total_cnt = production_cnt.iCurrData + error_cnt.iCurrData;
            labelTotalProduct.Text = Convert.ToString(total_cnt);

            //불량률
            double defectRate;
            if (error_cnt.iCurrData + production_cnt.iCurrData != 0)
            {
                defectRate = (double)error_cnt.iCurrData / (double)total_cnt * 100;

                labelNGRate.Text = defectRate.ToString("0.00");
            }
            else
            {
                defectRate = 0;

                labelNGRate.Text = Convert.ToString(defectRate);
            }


            //알람상태,내용
            if (alarm_code.iCurrData != 0)
            {
                labelAlarmCode.Text = alarm_code.iCurrData + " : " + alarm_list[alarm_code.iCurrData];
                labelAlarmComment.Text = Convert.ToString(alarm_comment[alarm_code.iCurrData]);
                panel4.BackColor = Color.Red;

                switch (alarm_code.iCurrData)
                {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 11:
                    case 13:
                    case 15:
                    case 18:
                        labelAlarmLevel.Text = "Error";
                        break;

                    default:
                        labelAlarmLevel.Text = "Fatal";
                        break;
                }
            }
            else if (Cores.Core_Robot.IsConneted == false)
            {
                labelAlarmCode.Text = "50 : DisConnect";
                labelAlarmComment.Text = "Robot 통신 실패";
                panel4.BackColor = Color.Red;
                labelAlarmLevel.Text = "Warning";

            }
            else
            {
                labelAlarmCode.Text = "-";
                labelAlarmComment.Text = "-";
                panel4.BackColor = Color.FromArgb(255, 157, 102);
                tableLayoutPanel6.ForeColor = System.Drawing.SystemColors.ControlText;
                labelAlarmLevel.Text = "-";

            }


            //알람 횟수 - 현재데이터가 0이 아니고 이전데이터와 다른 경우에 cnt++, 날짜가 변경되면 cnt=0, 데이터베이스에 알람 횟수 같이 저장했다가 페이지 로드할때 당일 최대cnt읽어오기
            if (alarm_code.iCurrData != 0 && (alarm_code.iCurrData != alarm_code.iPrevData))
            {
                alarmCnt++;
            }
            label3.Text = Convert.ToString(alarmCnt);
        }

        //List<string> q_data_log = new List<string>();
        //DateTime nowDate_qlog_data;

        //public void qlog_data_save()
        //{
        //    //List 크기나 여유 있는 타이밍 조건 걸어서 로그 저장 실행
        //    Common.ClsLogFile.Write_Data_Queue($"{nowDate_qlog_data:yyyy-MM-dd_}Data.log", q_data_log);

        //}

        public void PageMain_Size()
        {
            ClientSize = new Size(Convert.ToInt32(ClientSize.Width * FormMain.X_Scale), Convert.ToInt32(ClientSize.Height * FormMain.Y_Scale));

            PageMainPanel.Add(panel1);
            PageMainPanel.Add(panel2);

            for(int i=0; i<PageMainPanel.Count; i++)
            {
                PageMainPanel[i].Size = new Size(Convert.ToInt32( PageMainPanel[i].Width*FormMain.X_Scale),Convert.ToInt32( PageMainPanel[i].Height*FormMain.Y_Scale));
                PageMainPanel[i].Location = new Point(Convert.ToInt32(PageMainPanel[i].Location.X * FormMain.X_Scale), Convert.ToInt32(PageMainPanel[i].Location.Y * FormMain.Y_Scale));
            }

            #region labellist 목록
            PageMainLabel.Add(label1);
            PageMainLabel.Add(label25);
            PageMainLabel.Add(label26);
            PageMainLabel.Add(label27);
            PageMainLabel.Add(labelProduct);
            PageMainLabel.Add(labelTotalProduct);
            PageMainLabel.Add(labelOKProduct);
            PageMainLabel.Add(labelNGProduct);
            PageMainLabel.Add(label36);
            PageMainLabel.Add(label37);
            PageMainLabel.Add(label38);
            PageMainLabel.Add(labelNGRate);
            PageMainLabel.Add(labelProductRate);
            PageMainLabel.Add(label22);
            PageMainLabel.Add(label6);
            PageMainLabel.Add(labelCompleteTime);
            PageMainLabel.Add(label40);
            PageMainLabel.Add(label39);
            PageMainLabel.Add(label41);
            PageMainLabel.Add(labelPPM);
            PageMainLabel.Add(labelPPH);
            PageMainLabel.Add(labelDriveTime);
            PageMainLabel.Add(label19);
            PageMainLabel.Add(label20);
            PageMainLabel.Add(label21);
            PageMainLabel.Add(labelBoxRunTime);
            PageMainLabel.Add(labelRunTimeNow);
            PageMainLabel.Add(labelRunTimeTotal);
            PageMainLabel.Add(label42);
            PageMainLabel.Add(label43);
            PageMainLabel.Add(label44);
            PageMainLabel.Add(labelWorkProgress);
            PageMainLabel.Add(label10);
            PageMainLabel.Add(label17);
            PageMainLabel.Add(label18);
            PageMainLabel.Add(label45);
            PageMainLabel.Add(label46);
            PageMainLabel.Add(label47);
            PageMainLabel.Add(label2);
            PageMainLabel.Add(labelTotalProgress);
            PageMainLabel.Add(labelLayerProgress);
            PageMainLabel.Add(labelBoxProgress);
            PageMainLabel.Add(labelAlarm);
            PageMainLabel.Add(labelAlarmCode);
            PageMainLabel.Add(labelAlarmComment);
            PageMainLabel.Add(label3);
            PageMainLabel.Add(label7);
            PageMainLabel.Add(label8);
            PageMainLabel.Add(label4);
            PageMainLabel.Add(label5);
            PageMainLabel.Add(label9);
            PageMainLabel.Add(label11);
            PageMainLabel.Add(label12);
            PageMainLabel.Add(label13);
            PageMainLabel.Add(labelAlarmLevel);
            PageMainLabel.Add(label28);
            PageMainLabel.Add(label16);
            PageMainLabel.Add(labelCompleteTimeSpan);
            PageMainLabel.Add(label24);
            PageMainLabel.Add(label14);
            PageMainLabel.Add(label15);
            PageMainLabel.Add(labelGripperCount);

            #endregion

            for (int i = 0; i < PageMainLabel.Count; i++)
            {
                PageMainLabel[i].Size = new Size(Convert.ToInt32(PageMainLabel[i].Width * FormMain.X_Scale), Convert.ToInt32(PageMainLabel[i].Height * FormMain.Y_Scale));
                PageMainLabel[i].Location = new Point(Convert.ToInt32(PageMainLabel[i].Location.X * FormMain.X_Scale), Convert.ToInt32(PageMainLabel[i].Location.Y * FormMain.Y_Scale));
                PageMainLabel[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(PageMainLabel[i].Font.Size * FormMain.min_Scale));
            }

            PageMainTableLayoutPanel.Add(tableLayoutPanel1);
            PageMainTableLayoutPanel.Add(tableLayoutPanel2);
            PageMainTableLayoutPanel.Add(tableLayoutPanel3);
            PageMainTableLayoutPanel.Add(tableLayoutPanel4);
            PageMainTableLayoutPanel.Add(tableLayoutPanel5);
            PageMainTableLayoutPanel.Add(tableLayoutPanel6);

            for(int i=0; i< PageMainTableLayoutPanel.Count; i++)
            {
                PageMainTableLayoutPanel[i].Size = new Size(Convert.ToInt32(PageMainTableLayoutPanel[i].Width * FormMain.X_Scale), Convert.ToInt32(PageMainTableLayoutPanel[i].Height * FormMain.Y_Scale));
                //PageMainTableLayoutPanel[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(PageMainTableLayoutPanel[i].Font.Size * FormMain.min_Scale));
            }

            lstButtons.Add(button1);
            lstButtons.Add(button2);
            lstButtons.Add(button3);
            lstButtons.Add(button4);

            for (int i=0; i< lstButtons.Count; i++)
            {
                lstButtons[i].Size = new Size(Convert.ToInt32(lstButtons[i].Width * FormMain.X_Scale), Convert.ToInt32(lstButtons[i].Height * FormMain.Y_Scale));
                lstButtons[i].Location = new Point(Convert.ToInt32(lstButtons[i].Location.X * FormMain.X_Scale), Convert.ToInt32(lstButtons[i].Location.Y * FormMain.Y_Scale));
                lstButtons[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(lstButtons[i].Font.Size * FormMain.min_Scale));
            }
        }
        private void PageMain_Load(object sender, EventArgs e)
        {
            lstButtons.Add(button1);
            lstButtons.Add(button2);
            lstButtons.Add(button3);
            lstButtons.Add(button4);

            panel1.Controls.Clear();

            subPageChart.TopLevel = false;
            //panel1.Controls.Add(subPageChart);
            subPageChart.Show();

            lstFormChart.Add(new SubPageChart(SubPageChart.Unit.Hour));
            lstFormChart.Add(new SubPageChart(SubPageChart.Unit.Day));
            lstFormChart.Add(new SubPageChart(SubPageChart.Unit.Week));
            lstFormChart.Add(new SubPageChart(SubPageChart.Unit.Month));

            foreach (SubPageChart frm in lstFormChart)
            {
                frm.TopLevel = false;
                panel1.Controls.Add(frm);
            }

            foreach (Control frm in panel1.Controls)
            {
                frm.Show();
                frm.Hide();
            }

            lstManuButtons.Add(button1);
            lstManuButtons.Add(button2);
            lstManuButtons.Add(button3);
            lstManuButtons.Add(button4);

            foreach (Button b in lstManuButtons)
            {
                b.Click += B_Click;
            }

            B_Click(lstManuButtons[(int)SubPageChart.Unit.Hour], null);

        }

        public void Insert_Row()
        {
            subPageChart.Insert_Row();
        }

        private void B_Click(object sender, EventArgs e)
        {
            try
            {
                //throw new NotImplementedException();

                Button button = sender as Button;
                for (int idx = 0; idx < (int)SubPageChart.Unit.Max; idx++)
                {
                    if (button == lstManuButtons[idx])
                    {
                        //클릭o
                        panel1.Controls[idx].Show();
                        lstManuButtons[idx].BackColor = Color.FromArgb(223, 226, 229);
                        lstManuButtons[idx].ForeColor = Color.Black;
                        DataBaseLoad(idx);
                    }
                    else
                    {
                        //클릭x
                        panel1.Controls[idx].Hide();
                        lstManuButtons[idx].BackColor = Color.FromArgb(236, 245, 252);
                        lstManuButtons[idx].ForeColor = Color.Black;
                    }
                }
            }
            catch { }

        }

        void DataBaseLoad(int idx)
        {
            try
            {
                switch (idx)
                {
                    case 0://hour                 
                           //lstFormChart[idx].UpdateChart(dat);
                        break;

                    case 1://day
                           //lstFormChart[idx].UpdateChart(dayCount);
                        break;

                    case 2://week
                           //lstFormChart[idx].UpdateChart(weekCount);
                        break;

                    case 3://month
                           //lstFormChart[idx].UpdateChart(monthCount);
                        break;
                }
            }
            catch { }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Common.FormMessageBox msg = new Common.FormMessageBox("알람 횟수를 초기화 하시겠습니까?");
            if (msg.ShowDialog() == DialogResult.OK)
            {
                alarmCnt = 0;
            }
            else
            {

            }
        }

        private void labelRunTimeTotal_Click(object sender, EventArgs e)
        {
            Common.FormMessageBox msg = new Common.FormMessageBox("전체 작업 시간을 초기화 하시겠습니까?");
            if (msg.ShowDialog() == DialogResult.OK)
            {
                TotalTime = 0;
            }
            else
            {

            }
        }

        private void labelGripperCount_Click(object sender, EventArgs e)
        {
            Common.FormMessageBox msg = new Common.FormMessageBox("그리퍼 사용 횟수를 초기화 하시겠습니까?");
            if (msg.ShowDialog() == DialogResult.OK)
            {
                GripCount = 0;
            }
            else
            {

            }
        }

        //초를 시,분,초로 쪼개는 함수
        double[] Time_Hour_Min_Sec(double sec)
        {
            double Hour_ = System.Math.Truncate((double)sec / 3600);
            double Hour = Hour_;
            double Min_ = System.Math.Truncate(((double)sec % 3600) / 60);
            double Min = Min_;
            double Sec = ((double)sec % 3600) % 60;

            double[] Hour_Min_Sec = new double[] { Hour, Min, Sec };

            return Hour_Min_Sec;
        }
    }
}
