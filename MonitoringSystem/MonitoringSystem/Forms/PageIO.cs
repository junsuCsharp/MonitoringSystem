using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringSystem.Forms
{
    public partial class PageIO : Form
    {
        public PageIO()
        {
            InitializeComponent();

        }

        //List<string> DI_name_list = new List<string>() { "판넬 비상정지", "조작박스1 비상정지", "조작박스2 비상정지", "조작박스3 비상정지", "자동모드", "단동모드", "시작버튼", "일시정지버튼", "모터리셋버튼", "원점복귀버튼", "코봇 서보 온버튼", "공압정상", "코봇 높이 요청(DO9)", "코봇 진공 흡기(DO10)", "코봇 진공 배기(DO11)", "전원인가온"
        //                                                ," - ", "팔렛 감지_좌", "팔렛 감지_우", "Z축 상승 리밋", "Z축 홈", "Z축 하강 리밋", "코봇 홈(DO1)", "코봇 진행중(DO2)", "코봇 서보온(DO3)", "코봇 비상정지(DO13)", "코봇 작업정지(DO15)", "컨베어 박스1 감지", "컨베어 박스2 감지", " - ", "컨베어 실린더 후진", "컨베어 공압 정상"
        //                                                ,"레이더 감지", "레이더 Aux1", "레이더 Aux2", " - ", "진공센서 P1", "진공센서 P2", "온로봇 진공흡착완료", "온로봇 스페어"};
        List<string> DI_name_list = new List<string>() { "판넬 비상정지 버튼 눌림", "조작박스1 비상정지 버튼 눌림", "조작박스2 비상정지 버튼 눌림", "조작박스3 비상정지 버튼 눌림", "자동모드 상태", "단동모드 상태", "시작 버튼 눌림", "일시정지 버튼 눌림", "모터 리셋 버튼 눌림", "원점 복귀 버튼 눌림", "코봇 서보 온 버튼 눌림", "공압정상 상태", "코봇 높이 요청 상태", "코봇 진공 흡기 상태", "코봇 진공 배기 상태", "전원 인가 온 상태"
                                                        ," - ", "좌측 팔레트 감지 상태", "우측 팔레트 감지 상태", "Z축 상승 한계 감지 상태", "Z축 홈 감지 상태", "Z축 하강 한계 감지 상태", "코봇 홈 감지 상태", "코봇 진행중 상태", "코봇 서보 온 상태", "코봇 비상정지 상태", "코봇 작업정지 상태", "컨베이어 박스1 감지 상태", "컨베이어 박스2 감지 상태", " - ", "컨베이어 실린더 후진 감지", "컨베이어 공압 정상 상태"
                                                        ,"레이더 감지 상태", "레이더 Aux1 감지 상태", "레이더 Aux2 감지 상태", " - ", "진공센서1 감지 상태", "진공센서2 감지 상태", "그리퍼 진공흡착 완료 상태", "그리퍼 스페어"};

        List<string> DI_number_list = new List<string>() { "IX00", "IX01", "IX02", "IX03", "IX04", "IX05", "IX06", "IX07", "IX10", "IX11", "IX12", "IX13", "IX14", "IX15", "IX16", "IX17"
                                                          ,"IX20", "IX21", "IX22", "IX23", "IX24", "IX25", "IX26", "IX27", "IX30", "IX31", "IX32", "IX33", "IX34", "IX35", "IX36", "IX37"
                                                          ,"MIOX00", "MIOX01", "MIOX02", "MIOX03", "MIOX10", "MIOX11", "MIOX12", "MIOX13"};

        //List<string> DO_name_list = new List<string>() { "원점복귀완료 램프", "온로봇 진공 온", "온로봇 진공 오프", "부저", " - ", "코봇 일시정지(DI3)", "코봇 원격(DI13)", "코봇 리셋", "적색 LED", "녹색 LED", "청색 LED", "코봇 서보온(DI9)", "코봇 시작(DI10)", "코봇 높이 완료(DI1)", "코봇 취소(DI2)", "코봇 옐로우존(DI5)"
        //                                               , "진공 흡기", "진공 배기", " - ", "초기원점 설정", "코봇 재시작(DI4)", " - ", " - ", "뮤팅 그룹1", "뮤팅 그룹2", " - ", "Z축 브레이크 해제", "컨베어 실린더 전진", "컨베어 실린더 후진", "코봇 박스 투입 허가", "코봇 진공흡착완료", "컨베어 온"};
        List<string> DO_name_list = new List<string>() { "원점복귀 완료 램프 온", "그리퍼 진공 온", "그리퍼 진공 오프", "부저 울림", " - ", "코봇 일시정지 명령", "코봇 원격 명령", "코봇 리셋 명령", "적색 LED 온", "녹색 LED 온", "청색 LED 온", "코봇 서보 온", "코봇 시작 명령", "코봇 높이 완료 명령", "코봇 취소 명령", "코봇 옐로우존"
                                                       , "진공 흡기 명령", "진공 배기 명령", " - ", "초기원점 설정 명령", "코봇 재시작 명령", " - ", " - ", "뮤팅 그룹1", "뮤팅 그룹2", " - ", "Z축 브레이크 해제 명령", "컨베이어 실린더 전진 명령", "컨베이어 실린더 후진 명령", "코봇 박스 투입 허가 명령", "코봇 진공흡착 완료 명령", "컨베이어 온"};

        List<string> DO_number_list = new List<string>() { "OX00", "OX01", "OX02", "OX03", "OX04", "OX05", "OX06", "OX07", "OX10", "OX11", "OX12", "OX13", "OX14", "OX15", "OX16", "OX17"
                                                          ,"OX20", "OX21", "OX22", "OX23", "OX24", "OX25", "OX26", "OX27", "OX30", "OX31", "OX32", "OX33", "OX34", "OX35", "OX36", "OX37"};

        string DI_1 = "0000000000000000", DI_2 = "0000000000000000", DI_3 = "00000000", DO_1 = "0000000000000000", DO_2 = "0000000000000000";

        char[] DI_1_Array = new char[16];
        char[] DI_2_Array = new char[16];
        char[] DI_3_Array = new char[8];
        char[] DO_1_Array = new char[16];
        char[] DO_2_Array = new char[16];

        public char[] DI_Total_Array = new char[40];
        public char[] DO_Total_Array = new char[32];

        List<TableLayoutPanel> PageIOTableLayoutPanel = new List<TableLayoutPanel>();
        List<Label> PageIOLabel = new List<Label>();
        List<Label> DI_name_List = new List<Label>();
        List<Label> DI_number_List = new List<Label>();
        List<Label> DO_name_List = new List<Label>();
        List<Label> DO_number_List = new List<Label>();
        List<Button> DIO_button = new List<Button>();

        int di_cnt;
        int do_cnt;
        public void IO_Display()
        {
            for(int i=0; i<16; i++)
            {
                Controls.Find("DI_name_" + (i + 1), true)[0].Text = DI_name_list[i + di_cnt];
                Controls.Find("DI_number_" + (i + 1), true)[0].Text = DI_number_list[i + di_cnt];

                if(DI_Total_Array[i + di_cnt]==48)//off
                {
                    Controls.Find("DI_label_" + (i + 1), true)[0].BackColor=Color.Gray;
                    Controls.Find("DI_label_" + (i + 1), true)[0].Text = "off";
                }
                else if(DI_Total_Array[i + di_cnt] == 49)//on
                {
                    Controls.Find("DI_label_" + (i + 1), true)[0].BackColor = Color.Lime;
                    Controls.Find("DI_label_" + (i + 1), true)[0].Text = "on";

                }
            }

            for (int i = 0; i < 16; i++)
            {
                Controls.Find("DO_name_" + (i + 1), true)[0].Text = DO_name_list[i + do_cnt];
                Controls.Find("DO_number_" + (i + 1), true)[0].Text = DO_number_list[i + do_cnt];

                if (DO_Total_Array[i + do_cnt] == 48)
                {
                    Controls.Find("DO_label_" + (i + 1), true)[0].BackColor = Color.Gray;
                    Controls.Find("DO_label_" + (i + 1), true)[0].Text = "off";
                }
                else if (DO_Total_Array[i + do_cnt] == 49)
                {
                    Controls.Find("DO_label_" + (i + 1), true)[0].BackColor = Color.Lime;
                    Controls.Find("DO_label_" + (i + 1), true)[0].Text = "on";
                }
            }
        }
        private void B_Click(object sender, EventArgs e)
        {
            try
            {
                //throw new NotImplementedException();

                Button button = sender as Button;
                for (int idx = 0; idx < DIO_button.Count; idx++)
                {
                    if (button == DIO_button[idx])
                    {
                        DataBaseLoad(idx);
                    }
                    else
                    {

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
                    case 0://Input up(1)                 
                        if (di_cnt != 0)
                        {
                            di_cnt--;
                            IO_Display();
                        }
                        break;

                    case 1://Input down(1)
                        if (di_cnt< DI_name_list.Count-16)
                        {
                            di_cnt++;
                            IO_Display();
                        }
                        break;

                    case 2://Input up(16)
                        if (di_cnt > 16)
                        {
                            di_cnt -= 16;
                            IO_Display();
                        }
                        else
                        {
                            di_cnt =0;
                            IO_Display();

                        }
                        break;

                    case 3://Input down(16)
                        if (di_cnt < DI_name_list.Count - 32)
                        {
                            di_cnt += 16;
                            IO_Display();
                        }
                        else
                        {
                            di_cnt = DI_name_list.Count - 16;
                            IO_Display();
                        }
                        break;
                    case 4://Output up(1)                 
                        if (do_cnt != 0)
                        {
                            do_cnt--;
                            IO_Display();
                        }
                        break;

                    case 5://Output down(1)
                        if (do_cnt < DO_name_list.Count - 16)
                        {
                            do_cnt++;
                            IO_Display();
                        }
                        break;

                    case 6://Output up(16)
                        if (do_cnt > 16)
                        {
                            do_cnt -= 16;
                            IO_Display();
                        }
                        else
                        {
                            do_cnt = 0;
                            IO_Display();

                        }
                        break;

                    case 7://Output down(16)
                        if (do_cnt < DO_name_list.Count - 32)
                        {
                            do_cnt += 16;
                            IO_Display();
                        }
                        else
                        {
                            do_cnt = DO_name_list.Count - 16;
                            IO_Display();
                        }
                        break;
                }
            }
            catch { }

        }

        void IO_PrevData_Save()
        {
            for (int i = 25; i < 30; i++)
            {
                Externs.Robot_Modbus_Table.lstModbusData[i].iPrevData = Externs.Robot_Modbus_Table.lstModbusData[i].iCurrData;
            }
        }

        //void Log_IO_data()
        //{
        //    DateTime nowDate = DateTime.Now;

        //    string log = $"| {nowDate:yyyy-MM-dd HH:mm:ss} | {DI_1} | {DI_2} | {DI_3} | {DO_1} | {DO_2} |";

        //    Common.ClsLogFile.Write_IO_Data($"{nowDate:yyyy-MM-dd_}IO_Data.log", log);

        //}

        void IO_Data_Sort()
        {
            var di_1 = Externs.Robot_Modbus_Table.lstModbusData[27];//BOX SORT CYLINDER USE 
            var di_2 = Externs.Robot_Modbus_Table.lstModbusData[28];//SAFETY LADAR SENSOR USE	
            var di_3 = Externs.Robot_Modbus_Table.lstModbusData[29];//LABEL ALINE USE
            var do_1 = Externs.Robot_Modbus_Table.lstModbusData[30];//Robot State
            var do_2 = Externs.Robot_Modbus_Table.lstModbusData[31];//Servo On Robot

            DI_1 = new string(Convert.ToString(di_1.iCurrData, 2).PadLeft(16, '0').Reverse().ToArray()).Substring(0, 16);
            DI_2 = new string(Convert.ToString(di_2.iCurrData, 2).PadLeft(16, '0').Reverse().ToArray()).Substring(0, 16);
            DI_3 = new string(Convert.ToString(di_3.iCurrData, 2).PadLeft(16, '0').Reverse().ToArray()).Substring(0, 8);
            DO_1 = new string(Convert.ToString(do_1.iCurrData, 2).PadLeft(16, '0').Reverse().ToArray()).Substring(0, 16);
            DO_2 = new string(Convert.ToString(do_2.iCurrData, 2).PadLeft(16, '0').Reverse().ToArray()).Substring(0, 16);

            DI_1_Array = DI_1.ToCharArray();
            DI_2_Array = DI_2.ToCharArray();
            DI_3_Array = DI_3.ToCharArray();
            DO_1_Array = DO_1.ToCharArray();
            DO_2_Array = DO_2.ToCharArray();

            DI_Total_Array = DI_1_Array.Concat(DI_2_Array).Concat(DI_3_Array).ToArray();
            DO_Total_Array = DO_1_Array.Concat(DO_2_Array).ToArray();
        }

        public void IO_Display_Update()
        {
            IO_Data_Sort();

            IO_Display();

            //Log_IO_data();

            IO_PrevData_Save();
        }

        public void PageIO_Size()
        {
            ClientSize = new Size(Convert.ToInt32(ClientSize.Width * FormMain.X_Scale), Convert.ToInt32(ClientSize.Height * FormMain.Y_Scale));

            PageIOLabel.Add(label1);
            PageIOLabel.Add(label2);

            int pageIOLabelFontSize;

            for (int i = 0; i < PageIOLabel.Count; i++)
            {
                if(i==0||i==1)
                {
                    pageIOLabelFontSize = 20;
                }
                else
                {
                    pageIOLabelFontSize = 8;
                }
                PageIOLabel[i].Size = new Size(Convert.ToInt32(PageIOLabel[i].Width * FormMain.X_Scale), Convert.ToInt32(PageIOLabel[i].Height * FormMain.Y_Scale));
                PageIOLabel[i].Location = new Point(Convert.ToInt32(PageIOLabel[i].Location.X * FormMain.X_Scale), Convert.ToInt32(PageIOLabel[i].Location.Y * FormMain.Y_Scale));
                PageIOLabel[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(pageIOLabelFontSize * FormMain.min_Scale));
            }

            //라벨 위치, 크기, 폰트 조정
            #region IO Label
            DI_name_List.Add(DI_number_1);
            DI_name_List.Add(DI_name_1);
            DI_name_List.Add(DI_number_2);
            DI_name_List.Add(DI_name_2);
            DI_name_List.Add(DI_number_3);
            DI_name_List.Add(DI_name_3);
            DI_name_List.Add(DI_number_4);
            DI_name_List.Add(DI_name_4);
            DI_name_List.Add(DI_number_5);
            DI_name_List.Add(DI_name_5);
            DI_name_List.Add(DI_number_6);
            DI_name_List.Add(DI_name_6);
            DI_name_List.Add(DI_number_7);
            DI_name_List.Add(DI_name_7);
            DI_name_List.Add(DI_number_8);
            DI_name_List.Add(DI_name_8);
            DI_name_List.Add(DI_number_9);
            DI_name_List.Add(DI_name_9);
            DI_name_List.Add(DI_number_10);
            DI_name_List.Add(DI_name_10);
            DI_name_List.Add(DI_number_11);
            DI_name_List.Add(DI_name_11);
            DI_name_List.Add(DI_number_12);
            DI_name_List.Add(DI_name_12);
            DI_name_List.Add(DI_number_13);
            DI_name_List.Add(DI_name_13);
            DI_name_List.Add(DI_number_14);
            DI_name_List.Add(DI_name_14);
            DI_name_List.Add(DI_number_15);
            DI_name_List.Add(DI_name_15);
            DI_name_List.Add(DI_number_16);
            DI_name_List.Add(DI_name_16);
            DI_name_List.Add(DO_name_1);
            DI_name_List.Add(DO_number_1);
            DI_name_List.Add(DO_name_2);
            DI_name_List.Add(DO_number_2);
            DI_name_List.Add(DO_name_3);
            DI_name_List.Add(DO_number_3);
            DI_name_List.Add(DO_name_4);
            DI_name_List.Add(DO_number_4);
            DI_name_List.Add(DO_name_5);
            DI_name_List.Add(DO_number_5);
            DI_name_List.Add(DO_name_6);
            DI_name_List.Add(DO_number_6);
            DI_name_List.Add(DO_name_7);
            DI_name_List.Add(DO_number_7);
            DI_name_List.Add(DO_name_8);
            DI_name_List.Add(DO_number_8);
            DI_name_List.Add(DO_name_9);
            DI_name_List.Add(DO_number_9);
            DI_name_List.Add(DO_name_10);
            DI_name_List.Add(DO_number_10);
            DI_name_List.Add(DO_name_11);
            DI_name_List.Add(DO_number_11);
            DI_name_List.Add(DO_name_12);
            DI_name_List.Add(DO_number_12);
            DI_name_List.Add(DO_name_13);
            DI_name_List.Add(DO_number_13);
            DI_name_List.Add(DO_name_14);
            DI_name_List.Add(DO_number_14);
            DI_name_List.Add(DO_name_15);
            DI_name_List.Add(DO_number_15);
            DI_name_List.Add(DO_name_16);
            DI_name_List.Add(DO_number_16);
            DI_name_List.Add(DI_label_1);
            DI_name_List.Add(DI_label_2);
            DI_name_List.Add(DI_label_3);
            DI_name_List.Add(DI_label_4);
            DI_name_List.Add(DI_label_5);
            DI_name_List.Add(DI_label_6);
            DI_name_List.Add(DI_label_7);
            DI_name_List.Add(DI_label_8);
            DI_name_List.Add(DI_label_9);
            DI_name_List.Add(DI_label_10);
            DI_name_List.Add(DI_label_11);
            DI_name_List.Add(DI_label_12);
            DI_name_List.Add(DI_label_13);
            DI_name_List.Add(DI_label_14);
            DI_name_List.Add(DI_label_15);
            DI_name_List.Add(DI_label_16);
            DI_name_List.Add(DO_label_1);
            DI_name_List.Add(DO_label_2);
            DI_name_List.Add(DO_label_3);
            DI_name_List.Add(DO_label_4);
            DI_name_List.Add(DO_label_5);
            DI_name_List.Add(DO_label_6);
            DI_name_List.Add(DO_label_7);
            DI_name_List.Add(DO_label_8);
            DI_name_List.Add(DO_label_9);
            DI_name_List.Add(DO_label_10);
            DI_name_List.Add(DO_label_11);
            DI_name_List.Add(DO_label_12);
            DI_name_List.Add(DO_label_13);
            DI_name_List.Add(DO_label_14);
            DI_name_List.Add(DO_label_15);
            DI_name_List.Add(DO_label_16);

            #endregion

            for (int i = 0; i< DI_name_List.Count; i++)
            {
                DI_name_List[i].Size = new Size(Convert.ToInt32(DI_name_List[i].Width * FormMain.X_Scale), Convert.ToInt32(DI_name_List[i].Height * FormMain.Y_Scale));
                DI_name_List[i].Location = new Point(Convert.ToInt32(DI_name_List[i].Location.X * FormMain.X_Scale), Convert.ToInt32(DI_name_List[i].Location.Y * FormMain.Y_Scale));
                DI_name_List[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(DI_name_List[i].Font.Size * FormMain.min_Scale));
            }

            //버튼 위치 , 크기 조정
            DIO_button.Add(button1);
            DIO_button.Add(button2);
            DIO_button.Add(button3);
            DIO_button.Add(button4);
            DIO_button.Add(button5);
            DIO_button.Add(button6);
            DIO_button.Add(button7);
            DIO_button.Add(button8);

            for (int i = 0; i < DIO_button.Count; i++)
            {
                DIO_button[i].Size = new Size(Convert.ToInt32(DIO_button[i].Width * FormMain.X_Scale), Convert.ToInt32(DIO_button[i].Height * FormMain.Y_Scale));
                DIO_button[i].Location = new Point(Convert.ToInt32(DIO_button[i].Location.X * FormMain.X_Scale), Convert.ToInt32(DIO_button[i].Location.Y * FormMain.Y_Scale));
            }

        }

        private void PageIO_Load_1(object sender, EventArgs e)
        {
            foreach (Button b in DIO_button)
            {
                b.Click += B_Click;
            }

            IO_Data_Sort();

            IO_Display();
        }
    }
}
