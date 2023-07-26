using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace MonitoringSystem
{
    public partial class FormMain : Form
    {
        #region 화면 전환 전역 변수
        Forms.PageMain pageMain = new Forms.PageMain();
        Forms.PageSub pageSub = new Forms.PageSub();
        Forms.PageIO pageIO = new Forms.PageIO();
        Forms.ModelInformation modelInformation = new Forms.ModelInformation();
        #endregion

        DateTime nowDate = DateTime.Now;

        List<Button> lstButtons = new List<Button>();//화면 전환을 위한 버튼 리스트
        List<Panel> FormMainPanel = new List<Panel>();//크기 조정을 위한 버튼 리스트
        List<Button> FormMainButton = new List<Button>();//크기 조정을 위한 버튼 리스트
        List<Label> FormMainLabel = new List<Label>();//크기 조정을 위한 버튼 리스트
        List<LBSoft.IndustrialCtrls.Leds.LBLed> Lbled = new List<LBSoft.IndustrialCtrls.Leds.LBLed>();

        public static List<string> modelName = new List<string>() { "", "", "", "", "", "", "", "", "", "" };//모델 이름 정보

        List<string> modbusDataList = new List<string>();

        Queue<List<string>> qlog = new Queue<List<string>>();

        //public static string Device_IP_Adress = "192.168.0.100";
        //null 이면 0.0.0.0을 넣는다.
        public static string Client_IP_Adress = (FormEnterIP.SetIP_Robot_1 != null) ? FormEnterIP.SetIP_Robot_1 : "0.0.0.0";

        public static string workState;

        bool log_ok = false;

        //List<string> Deivce_IP = new List<string>() { "192.168.0.100", "192.168.0.101", "192.168.0.102" };
        //List<string> Deivce_IP = new List<string>() { Device_IP_Adress };

        public FormMain()
        {
            InitializeComponent();
        }

        enum EPages
        {
            main, sub, quantity, io, info, none
        }

        //IP 접속
        Cores.Core_Robot coreRobot = new Cores.Core_Robot("0", Client_IP_Adress);

        const byte DUM = 0;
        const byte LEN = 6;
        const byte SLV = 255;
        const byte DAT = 1;

        double Screen_Width, Screen_Height;//화면 크기
        double Screen_Scale;//화면 배율
        public static double X_Scale;
        public static double Y_Scale;
        public static double min_Scale; //가로 세로 비율이 안맞는 경우 사용하는 작은 배율 값
        //double Prev_X_Scale;
        //double Prev_Y_Scale;

        string[] robot_state_list = new string[] {"BACKDRIVE HOLD", "BACKDRIVE RELEASE", "BACKDRIVE RELEASE by COCKPIT", "SAFE OFF", "INITIALIZING", "INTERRUPTED", "EMERGENCY STOP" , "AUTO MEASURE", "RECOVERY STANDBY",
                "RECOVERY JOGGING", "RECOVERY HANDGUIDING" ,"MANUAL HANDGUIDING","MANUAL JOGGING","MANUAL HANDGUIDING","HIGH PRIORITY RUNNING","STANDALONE STANDBY","STANDALONE RUNNING","COLLABORATIVE STANDBY",
                "COLLABORATIVE RUNNING","HANDGUIDING CONTROL STANDBY","HANDGUIDING CONTROL RUNNING"};

        /// <summary>
        /// 2023.02.10 모드버스 데이터 동기화, ALL
        /// </summary>
        void Modbus_Sender()
        {
            foreach (Externs.Robot_Modbus_Table.Data dat in Externs.Robot_Modbus_Table.lstModbusData.ToList())
            {
                if (dat.IsUsed)
                {
                    byte[] paket = null;

                    paket = new byte[] { (byte)(dat.Address >> 8), (byte)dat.Address, DUM, DUM, DUM, LEN, SLV, (byte)dat.func, (byte)(dat.Address >> 8), (byte)dat.Address, DUM, DAT };

                    if (paket != null)
                    {
                        coreRobot.SendMeassage(paket);
                    }
                }
            }
        }

        /// <summary>
        /// FormMain 각 요소들의 크기 위치 폼 크기에 맞춰 조정
        /// text가 있는 경우 글꼴 글자 크기도 조정
        /// </summary>
        void FormMain_Size()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(Convert.ToInt32(this.Width * X_Scale), Convert.ToInt32(this.Height * Y_Scale));
            this.Location = new Point(0, 0);

            FormMainPanel.Add(panel1);//프로그램 이름, 프로그램 버전, 날짜, 최소화 버튼, 닫기 버튼
            FormMainPanel.Add(panel3);//화면 전환 버튼(공정모니터, 작업정보, 생산량, IO
            FormMainPanel.Add(panel4);//화면표시

            for (int i = 0; i < FormMainPanel.Count; i++)
            {
                FormMainPanel[i].Size = new Size(Convert.ToInt32(FormMainPanel[i].Width * X_Scale), Convert.ToInt32(FormMainPanel[i].Height * Y_Scale));
                FormMainPanel[i].Location = new Point(Convert.ToInt32(FormMainPanel[i].Location.X * X_Scale), Convert.ToInt32(FormMainPanel[i].Location.Y * Y_Scale));
            }

            FormMainButton.Add(button1);
            FormMainButton.Add(button2);
            FormMainButton.Add(button4);
            FormMainButton.Add(button5);
            FormMainButton.Add(exit);

            for (int i = 0; i < FormMainButton.Count; i++)
            {
                FormMainButton[i].Size = new Size(Convert.ToInt32(FormMainButton[i].Width * X_Scale), Convert.ToInt32(FormMainButton[i].Size.Height * Y_Scale));
                FormMainButton[i].Location = new Point(Convert.ToInt32(FormMainButton[i].Location.X * X_Scale), Convert.ToInt32(FormMainButton[i].Location.Y * Y_Scale));
                FormMainButton[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(FormMainButton[i].Font.Size * min_Scale));
            }

            FormMainLabel.Add(label4);
            FormMainLabel.Add(label5);
            FormMainLabel.Add(label6);
            FormMainLabel.Add(label7);
            FormMainLabel.Add(label8);

            for (int i = 0; i < FormMainLabel.Count; i++)
            {
                FormMainLabel[i].Size = new Size(Convert.ToInt32(FormMainLabel[i].Width * X_Scale), Convert.ToInt32(FormMainLabel[i].Height * Y_Scale));
                FormMainLabel[i].Location = new Point(Convert.ToInt32(FormMainLabel[i].Location.X * X_Scale), Convert.ToInt32(FormMainLabel[i].Location.Y * Y_Scale));
                FormMainLabel[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(FormMainLabel[i].Font.Size * min_Scale));
                //FormMainLabel[i].BorderStyle = BorderStyle.FixedSingle;
            }

            FormMainPictureBox.Add(pictureBox1);
            FormMainPictureBox.Add(pictureBox2);

            for(int i=0; i< FormMainPictureBox.Count; i++)
            {
                FormMainPictureBox[i].Size = new Size(Convert.ToInt32(FormMainPictureBox[i].Width * min_Scale), Convert.ToInt32(FormMainPictureBox[i].Height * min_Scale));
                FormMainPictureBox[i].Location = new Point(Convert.ToInt32(FormMainPictureBox[i].Location.X * X_Scale), Convert.ToInt32(FormMainPictureBox[i].Location.Y * Y_Scale));
            }

            Lbled.Add(lbLed1);
            Lbled.Add(lbLed2);
            Lbled.Add(lbLed3);

            for (int i = 0; i < Lbled.Count; i++)
            {
                Lbled[i].Size = new Size(Convert.ToInt32(Lbled[i].Width * X_Scale), Convert.ToInt32(Lbled[i].Height * Y_Scale));
                Lbled[i].LedSize = new Size(Convert.ToInt32(Lbled[i].LedSize.Width * X_Scale), Convert.ToInt32(Lbled[i].LedSize.Height * Y_Scale));
                Lbled[i].Location = new Point(Convert.ToInt32(Lbled[i].Location.X * X_Scale), Convert.ToInt32(Lbled[i].Location.Y * Y_Scale));
                Lbled[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(Lbled[i].Font.Size * min_Scale));
            }
        }

        List<PictureBox> FormMainPictureBox = new List<PictureBox>();

        /// <summary>
        /// 화면 배율 가져오기
        /// </summary>
        void Screen_XY_Scale()
        {
            //화면 배율
            Screen_Scale = GetScreenScalingFactor();

            //화면 크기
            Screen_Width = Screen.FromHandle(this.Handle).WorkingArea.Width;
            Screen_Height = Screen.FromHandle(this.Handle).WorkingArea.Height;

            //적절한 window 화면 배율
            X_Scale = Screen_Width / this.Width;
            Y_Scale = Screen_Height / this.Height;

            if (X_Scale == 0)
            {
                X_Scale = 1;
            }
            if (Y_Scale == 0)
            {
                Y_Scale = 1;
            }

            min_Scale = Math.Min(X_Scale, Y_Scale);
        }

        /// <summary>
        /// 폼 로드 시
        /// 1. 크기 조절
        /// 2. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            pageMain.PrevDay = DateTime.Now.Day;//날짜 비교하려는 거 같은데 변경이 필요해보임

            Screen_XY_Scale();

            FormMain_Size();
            pageIO.PageIO_Size();
            pageMain.PageMain_Size();
            pageSub.PageSub_Size();

            lstButtons.Add(button1);
            lstButtons.Add(button2);
            lstButtons.Add(button4);
            lstButtons.Add(button5);

            panel4.Controls.Clear();

            pageMain.TopLevel = false;
            panel4.Controls.Add(pageMain);
            pageMain.Show();

            pageSub.TopLevel = false;
            panel4.Controls.Add(pageSub);
            pageSub.Show();

            pageIO.TopLevel = false;
            panel4.Controls.Add(pageIO);
            pageIO.Show();

            modelInformation.TopLevel = false;
            panel4.Controls.Add(modelInformation);
            modelInformation.Show();

            button1_Click(button1, null);

            pageMain.PageMain_Display();

            //data, IO 비교를 위한 쓰레스 생성
            Thread myThread = new Thread(Update_Data);

            myThread.Start();

            timer1.Start();

        }

        void test()
        {
            //Log_Data();//qlog 저장 확인 용
        }

        //화면 전환 버튼
        private void button1_Click(object sender, EventArgs e)
        {

            Button selectedButton = sender as Button;

            EPages ePages = EPages.none;

            for (int idx = 0; idx < panel4.Controls.Count; idx++)
            {
                lstButtons[idx].Enabled = true;
                panel4.Controls[idx].Hide();
                lstButtons[idx].BackColor = Color.Transparent;

                if (lstButtons[idx] == selectedButton)
                {
                    ePages = (EPages)idx;
                    lstButtons[idx].BackColor = Color.LightGray;
                }
            }

            if (ePages != EPages.none)
            {
                selectedButton.Enabled = false;
                panel4.Controls[(int)ePages].Show();
            }
        }

        //모드버스 데이터 저장
        void Modbus_Data_Save()
        {
            DateTime TimeNow = DateTime.Now;

            modbusDataList.Clear();
            modbusDataList.Add(TimeNow.ToString());

            for (int i = 0; i < Externs.Robot_Modbus_Table.lstModbusData.Count; i++)
            {
                Externs.Robot_Modbus_Table.lstModbusData[i].iCurrData = Externs.Robot_Modbus_Table.lstModbusData[i].iData;
                
                modbusDataList.Add(Externs.Robot_Modbus_Table.lstModbusData[i].iData.ToString());
            }
        }

        //모드버스 이전 데이터 저장
        void Modbus_PrevData_Save()
        {
            for (int i = 0; i < Externs.Robot_Modbus_Table.lstModbusData.Count; i++)
            {
                Externs.Robot_Modbus_Table.lstModbusData[i].iPrevData = Externs.Robot_Modbus_Table.lstModbusData[i].iCurrData;
            }

        }

        //모드버스 이전 데이터와 비교하여 수행 할 작업
        void Modbus_Data_Compare()
        {
            var production_cnt = Externs.Robot_Modbus_Table.lstModbusData[4];//생산수량
            var error_cnt = Externs.Robot_Modbus_Table.lstModbusData[5];//불량수량

            if (production_cnt.iCurrData > production_cnt.iPrevData || error_cnt.iCurrData > error_cnt.iPrevData)
            {
                pageMain.Insert_Row();
            }

            for (int idx = 0; idx < Externs.Robot_Modbus_Table.lstModbusData.Count; idx++)
            {
                if (Externs.Robot_Modbus_Table.lstModbusData[idx].iCurrData != Externs.Robot_Modbus_Table.lstModbusData[idx].iPrevData)
                {
                    log_ok = false;
                    // queue 로그 데이터 리스트 저장
                    List<string> log = new List<string>();

                    log.Add(string.Join(" | ", modbusDataList.ToArray()));
                    
                    qlog.Enqueue(log);

                    log_ok = true;

                    break;
                }
            }

        }

        /// <summary>
        /// 스레드는 1ms만 sleep
        /// 새로 만든 스레드에서 폼을 건드리면 오류 발생
        /// 
        /// </summary>
        void Update_Data()
        {

            TimeSpan tsSendTime = new TimeSpan(0, 0, 0, 0, 500);

            DateTime dtSendDate = DateTime.Now + tsSendTime;

            Stopwatch swTick = new Stopwatch();
            swTick.Start();

            TimeSpan tsSaveDelay = new TimeSpan(0, 0, 0, 0, 1000);
            Stopwatch swSaveTime = new Stopwatch();
            swSaveTime.Start();

            while (true)
            {
                Thread.Sleep(1);

                if (Cores.Core_Robot.IsConneted == false)
                {
                    coreRobot.ReConnection();

                    continue;
                }

                //날짜 비교 신경 써야 할듯
                if (DateTime.Today.Day != pageMain.PrevDay)
                {
                    pageMain.PrevDay = DateTime.Today.Day;
                }

                //kkk
                if (swSaveTime.ElapsedMilliseconds >= tsSaveDelay.TotalMilliseconds)
                {
                    swSaveTime.Restart();
                    if (qlog.Count > 0 && log_ok == true)
                    {
                        Common.ClsLogFile.Write_Data_Queue($"{nowDate:yyyy-MM-dd_}Data.log", qlog.Dequeue());
                    }
                }

                if (DateTime.Now.Ticks >= dtSendDate.Ticks)
                {
                    dtSendDate = DateTime.Now + tsSendTime;
                    Modbus_Sender();
                }

                if (swTick.ElapsedMilliseconds >= tsSendTime.TotalMilliseconds)
                {
                    swTick.Restart();
                    Modbus_Data_Save();
                }
            }
        }

        /// <summary>
        /// 디스플레이 업데이트는 여기에서 전부 하도록 하자
        /// 스레드에서는 디스플레이 건들이지 않아야 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            FormMain_Display();//FormMain Display Update

            pageMain.PageMain_Display();//PageMain Display Update

            pageSub.Sub_Display();//PageSub Display Update

            pageIO.IO_Display_Update();//PageIO DIsplay Update

            Modbus_Data_Compare();

            Modbus_PrevData_Save();

            //test();
        }

        void FormMain_Display()
        {
            var model_info = Externs.Robot_Modbus_Table.lstModbusData[1];//모델정보
            var alarm_code = Externs.Robot_Modbus_Table.lstModbusData[6];//알람코드
            var robot_state = Externs.Robot_Modbus_Table.lstModbusData[25];//Robot State
            var servo_on_robot = Externs.Robot_Modbus_Table.lstModbusData[26];//Servo On Robot
            var work_state = Externs.Robot_Modbus_Table.lstModbusData[32];

            //현재 시간
            label5.Text = DateTime.Now.ToString("yyyy년 M월 d일  H:mm:ss");

            //모델 정보
            if (model_info.iCurrData == 0)
            {
                label6.Text = "모델 정보 : -";
            }
            else
            {
                label6.Text = "모델 정보 : " + modelName[model_info.iCurrData - 1];
            }
            //로봇 상태
            if (Cores.Core_Robot.IsConneted == true)
            {
                label7.Text = "로봇 상태 : " + robot_state_list[robot_state.iCurrData];
            }
            else
            {
                label7.Text = "로봇 상태 : -";
            }

            //서보 온 로봇
            if (servo_on_robot.iCurrData == 1 && Cores.Core_Robot.IsConneted == true)
            {
                lbLed2.LedColor = Color.Lime;
                if (lbLed2.State != LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink)
                {
                    lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
                }
               
            }
            else
            {
                lbLed2.LedColor = System.Drawing.Color.Red;
                if (lbLed2.State != LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink)
                {
                    lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
                }
            }

            //알람 상태
            if (alarm_code.iCurrData == 0 && Cores.Core_Robot.IsConneted == true)
            {
                lbLed3.LedColor = Color.Lime;
                if (lbLed3.State != LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink)
                {
                    lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
                }
            }
            else
            {
                lbLed3.LedColor = System.Drawing.Color.Red;
                if (lbLed3.State != LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink)
                {
                    lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
                }
            }

            //연결 상태
            if (Cores.Core_Robot.IsConneted == true)
            {
                lbLed1.LedColor = Color.Lime;
                if (lbLed1.State != LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink)
                {
                    lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
                }
            }
            else
            {
                lbLed1.LedColor = System.Drawing.Color.Red;
                if (lbLed1.State != LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink)
                {
                    lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
                }
            }

            //작업상태 - 아직 데이터 없음
            if (work_state.iCurrData == 1 && pageIO.DI_Total_Array[23] == '0' && pageIO.DI_Total_Array[26] == '1')
            {
                label4.Text = "작업 상태 : 진행 중";
                workState = "Start";
            }
            else if (work_state.iCurrData == 1 && pageIO.DI_Total_Array[23] == '1' && pageIO.DI_Total_Array[26] == '0')
            {
                label4.Text = "작업 상태 : 일시 정지";
                workState = "Pause";
            }
            else if (work_state.iCurrData == 0 && pageIO.DI_Total_Array[23] == '1' && pageIO.DI_Total_Array[26] == '0')
            {
                label4.Text = "작업 상태 : 작업 취소";
                workState = "Cancel";
            }
            else if (work_state.iCurrData == 0 && pageIO.DI_Total_Array[23] == '1' && pageIO.DI_Total_Array[26] == '1')
            {
                label4.Text = "작업 상태 : 작업 대기";
                workState = "Wait";
            }
            else
            {
                label4.Text = "작업 상태 : None";
                workState = "None";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 비동기 핑 체크
        /// </summary>
        //void asyncPingCheck()
        //{
        //    DateTime asyncTime = DateTime.Now;

        //    //devJace.Program.LogSave(NLog.LogManager.GetCurrentClassLogger(), devJace.Program.ELogLevel.Info,
        //    //$"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
        //    while (true)
        //    {
        //        Thread.Sleep(1);
        //        //비동기 핑체크
        //        try
        //        {
        //            foreach (string ip in Cores.Core_Object.GetObj_File.Device_IP)
        //            {
        //                Networks.NetAsyncPing.PingCheckAsync(ip);
        //                //devJace.Program.LogSave(NLog.LogManager.GetCurrentClassLogger(), devJace.Program.ELogLevel.Info, $"{System.Reflection.MethodBase.GetCurrentMethod().Name} |" +
        //                //$" IP Address : {ip}");
        //            }

        //            foreach (KeyValuePair<string, bool> lst in Networks.NetAsyncPing.dicReConnectIps)
        //            {
        //                for (int idx = 0; idx < Cores.Core_Object.GetObj_File.Device_IP.Count; idx++)
        //                {
        //                    if (lst.Key == Cores.Core_Object.GetObj_File.Device_IP[idx])
        //                    {

        //                    }
        //                }
        //            }

        //            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //            TimeSpan ts = DateTime.Now - asyncTime;
        //            asyncTime = DateTime.Now;
        //            //devJace.Program.LogSave(NLog.LogManager.GetCurrentClassLogger(), devJace.Program.ELogLevel.Info,
        //            //    $"{System.Reflection.MethodBase.GetCurrentMethod().Name.PadLeft(31)} |" +
        //            //    $" asyncTime {ts.TotalMilliseconds:0000.0000}ms");
        //            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //            if (ts.TotalMilliseconds > 3500)
        //            {
        //                //devJace.Program.LogSave(NLog.LogManager.GetCurrentClassLogger(), devJace.Program.ELogLevel.Warn,
        //                //    $"{System.Reflection.MethodBase.GetCurrentMethod().Name.PadLeft(31)} |" +
        //                //    $" asyncTime {ts.TotalMilliseconds:0000.0000}ms");
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            //devJace.Program.LogSave(NLog.LogManager.GetCurrentClassLogger(), devJace.Program.ELogLevel.Debug,
        //            //    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}" +
        //            //    $" | Async Ping {ex.Message}");
        //        }
        //    }

        //}
        #region 화면 배율 계수 설정하기 - GetScreenScalingFactor()

        /// <summary>
        /// 화면 배율 계수 설정하기
        /// </summary>
        /// <returns>배율 계수</returns>
        public float GetScreenScalingFactor()
        {
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);

            IntPtr deviceHandle = graphics.GetHdc();

            int PhysicalScreenHeight = GetDeviceCaps(deviceHandle, 117);
            int LogicalScreenHeight = GetDeviceCaps(deviceHandle, 10);

            float scalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return scalingFactor; // 1.25 = 125%
        }

        #endregion

        #region 장치 정보 구하기 - GetDeviceCaps(deviceContextHandle, index)

        /// <summary>
        /// 장치 정보 구하기
        /// </summary>
        /// <param name="deviceContextHandle">디바이스 컨텍스트 핸들</param>
        /// <param name="index">인덱스</param>
        /// <returns>장치 정보</returns>
        [DllImport("gdi32")]
        private static extern int GetDeviceCaps(IntPtr deviceContextHandle, int index);


        #endregion

    }
}
