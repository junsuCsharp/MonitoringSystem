using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MonitoringSystem.Forms
{
    public partial class PageSub : Form
    {
        public PageSub()
        {
            InitializeComponent();

        }

        List<Label> PageSubLabel = new List<Label>();
        const int iGridCount = 14;
        string[] dataName = new string[] { "박스 크기", "박스 무게", "팔레트 크기", "작업 속도", "리프트 높이", "적재 방향" ,"간지 사용", "박스 정렬 실린더 사용" , "안전 라이다 센서 사용", "라벨 정렬 사용" };
        string Direction;//적재 방향 정보

        public void Sub_Display()
        {
            Init_Grid();
        }

        public void PageSub_Size()
        {
            ClientSize = new Size(Convert.ToInt32(ClientSize.Width * FormMain.X_Scale), Convert.ToInt32(ClientSize.Height * FormMain.Y_Scale));


            for (int i = 0; i < PageSubLabel.Count; i++)
            {
                PageSubLabel[i].Size = new Size(Convert.ToInt32(PageSubLabel[i].Width * FormMain.X_Scale), Convert.ToInt32(PageSubLabel[i].Height * FormMain.Y_Scale));
                PageSubLabel[i].Location = new Point(Convert.ToInt32(PageSubLabel[i].Location.X * FormMain.X_Scale), Convert.ToInt32(PageSubLabel[i].Location.Y * FormMain.Y_Scale));
                PageSubLabel[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(PageSubLabel[i].Font.Size * FormMain.min_Scale));
            }

            dataGridView1.Size = new Size(Convert.ToInt32(dataGridView1.Width * FormMain.X_Scale), Convert.ToInt32(dataGridView1.Height * FormMain.Y_Scale));
            dataGridView1.Location = new Point(Convert.ToInt32(dataGridView1.Location.X * FormMain.X_Scale), Convert.ToInt32(dataGridView1.Location.Y * FormMain.Y_Scale));
            dataGridView1.Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(dataGridView1.Font.Size * FormMain.min_Scale*1.5));
            dataGridView1.ColumnHeadersHeight = Convert.ToInt32((double)85 * FormMain.Y_Scale);
            dataGridView1.RowTemplate.Height = Convert.ToInt32((dataGridView1.Size.Height - dataGridView1.ColumnHeadersHeight) / iGridCount);
        }

        void Init_Grid()
        {
            var box_x = Externs.Robot_Modbus_Table.lstModbusData[7];//박스 X 길이
            var box_y = Externs.Robot_Modbus_Table.lstModbusData[8];//박스 Y 길이
            var box_z = Externs.Robot_Modbus_Table.lstModbusData[9];//박스 Z 길이
            var box_weight = Externs.Robot_Modbus_Table.lstModbusData[10];//박스 무게
            var pallete_x = Externs.Robot_Modbus_Table.lstModbusData[11];//팔레트 X 길이
            var pallete_y = Externs.Robot_Modbus_Table.lstModbusData[12];//팔레트 Y 길이
            var pallete_z = Externs.Robot_Modbus_Table.lstModbusData[13];//팔레트 Z 길이
            var between_paper = Externs.Robot_Modbus_Table.lstModbusData[18];//간지 사용 유무
            var lift_height = Externs.Robot_Modbus_Table.lstModbusData[19];//리프트 높이
            var load_direction = Externs.Robot_Modbus_Table.lstModbusData[20];//적재방향
            var robot_speed = Externs.Robot_Modbus_Table.lstModbusData[21];//로보트 스피드 설정
            var box_sort_cylinder = Externs.Robot_Modbus_Table.lstModbusData[22];//BOX SORT CYLINDER USE 
            var safety_ladar_sensor = Externs.Robot_Modbus_Table.lstModbusData[23];//SAFETY LADAR SENSOR USE	
            var label_aline = Externs.Robot_Modbus_Table.lstModbusData[24];//LABEL ALINE USE

            DataGridView dgv = dataGridView1;

            switch (load_direction.iCurrData)
            {
                case 0:
                    Direction = "-";
                    break;

                case 1:
                    Direction = "Left";
                    break;

                case 2:
                    Direction = "Right";
                    break;

                case 3:
                    Direction = "Left -> Right";
                    break;

                case 4:
                    Direction = "Right -> Left";
                    break;
            }

            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // row 로 선택하기
            //dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.Fill; //row size 막기
            dgv.AllowUserToResizeRows = false; //row size 막기
            dgv.AllowUserToResizeColumns = false; //column size 막기
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = 15;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToAddRows = true;
            //dgv.RowTemplate.Height = 77;

            //dgv.ColumnHeadersHeight = 79;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;            

            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            int iColWidth =Convert.ToInt32( (double)120 * FormMain.X_Scale);

            string[] header = new string[] { };
            dgv.RowCount = iGridCount;

            header = new string[] { "구분", "항목", "현재 상태 값", "단위" };
            dgv.ColumnCount = header.Length;
            dgv.Columns[0].Width = iColWidth;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[0].HeaderText = header[0];
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ClearSelection();
            for (int ix = 0; ix < dgv.ColumnCount; ix++)
            {
                if (ix >= 1)
                {
                    dgv.Columns[ix].HeaderText = $"{header[ix]}";
                    dgv.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv.Columns[ix].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgv.Columns[ix].Resizable = DataGridViewTriState.False;
                dgv.Columns[ix].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int ux = 0; ux < dataName.Length; ux++)
            {
                dgv.Rows[ux].Cells[0].Value = ux+1;
            }

            for (int ux = 0; ux < dataName.Length; ux++)
            {
                dgv.Rows[ux].Cells[1].Value = dataName[ux];
            }
            //현재 값 순서 변경 하면 안됨
            dgv.Rows[0].Cells[2].Value = box_x.iCurrData + " X " + box_y.iCurrData + " X " + box_z.iCurrData;
            dgv.Rows[1].Cells[2].Value = box_weight.iCurrData;
            dgv.Rows[2].Cells[2].Value = pallete_x.iCurrData + " X " + pallete_y.iCurrData + " X " + pallete_z.iCurrData;
            //dgv.Rows[3].Cells[2].Value = robot_default_speed* robot_speed.iCurrData/100 + " ( "+robot_speed.iCurrData+"% )";
            dgv.Rows[3].Cells[2].Value = robot_speed.iCurrData;
            dgv.Rows[4].Cells[2].Value = lift_height.iCurrData;
            dgv.Rows[5].Cells[2].Value = Direction;
            dgv.Rows[6].Cells[2].Value = UseUnuse(between_paper.iCurrData);
            dgv.Rows[7].Cells[2].Value = UseUnuse(box_sort_cylinder.iCurrData);
            dgv.Rows[8].Cells[2].Value = UseUnuse(safety_ladar_sensor.iCurrData);
            dgv.Rows[9].Cells[2].Value = UseUnuse(label_aline.iCurrData);

            dgv.Rows[0].Cells[3].Value = "가로 X 세로 X 높이 (mm)";
            dgv.Rows[1].Cells[3].Value = "kg";
            dgv.Rows[2].Cells[3].Value = "가로 X 세로 X 높이 (mm)";
            //dgv.Rows[3].Cells[3].Value = "m/s";
            dgv.Rows[3].Cells[3].Value = "%";
            dgv.Rows[4].Cells[3].Value = "mm";
            dgv.Rows[5].Cells[3].Value = "Left  /  Right  /  Left -> Right  /  Right -> Left";
            dgv.Rows[6].Cells[3].Value = "사용  /  미사용";
            dgv.Rows[7].Cells[3].Value = "사용  /  미사용";
            dgv.Rows[8].Cells[3].Value = "사용  /  미사용";
            dgv.Rows[9].Cells[3].Value = "사용  /  미사용";

        }

        private void PageSub_Load(object sender, EventArgs e)
        {
            Init_Grid();

            //int before = 15;
            //string binary0 = Convert.ToString(before, 2);
            //Console.WriteLine(binary0);

            //#region 예제
            ////int after = Set_BIt(before, setbitlist_Off);//특정 비트 반전
            ////string binary = Convert.ToString(Convert.ToInt32(Convert.ToString(after), 10), 2);
            ////Console.WriteLine(binary);

            ////int after1 = Set_BIt1(before, setbitlist_Off);//특정 비트 0
            ////string binary1 = Convert.ToString(Convert.ToInt32(Convert.ToString( after1), 10), 2);
            ////Console.WriteLine(binary1);
            //#endregion

            //int after2 = Set_Bit2(before, setbitlist_Off, setbitlist_On);//특정 비트는 0 또다른 특정 비트는 1
            ////Console.WriteLine(after2);
            //string binary2 = Convert.ToString(after2, 2);
            //Console.WriteLine(binary2);

            //int after3 = Set_Bit3(before,setbitlist_number, setbitlist_onoff);
            //string binary3 = Convert.ToString(after3, 2);
            //Console.WriteLine(binary3);
        }

        //List<int> setbitlist_Off = new List<int>() { 0, 3 };
        //List<int> setbitlist_On = new List<int>() { 1, 2 };

        //List<int> setbitlist_number = new List<int>() { 0, 1, 3 };
        //List<int> setbitlist_onoff = new List<int>() { 0, 1, 1 };

        //#region 예제
        ////int Set_BIt(int a, List<int> setlist)
        ////{
        ////    for (int i=0; i< setbitlist_Off.Count; i++)
        ////    {
        ////        a  ^= 1 << setlist[i];
        ////    }

        ////    return a;
        ////}

        ////int Set_BIt1(int a1,List<int> setlist)
        ////{

        ////    for (int i = 0; i < setbitlist_Off.Count; i++)
        ////    {
        ////        a1 &= ~(1 << setlist[i]);
        ////    }

        ////    return a1;
        ////}
        //#endregion

        //int Set_Bit2(int a2, List<int>setList, List<int>setListon)
        //{
        //    //off
        //    for (int i = 0; i < setbitlist_Off.Count; i++)
        //    {
        //        a2 &= ~(1 << setList[i]);
        //    }

        //    //on
        //    for (int i = 0; i < setbitlist_On.Count; i++)
        //    {
        //        a2 |= 1 << setListon[i];
        //    }

        //    return a2;
        //}
        //int Set_Bit3(int a, List<int>num,List<int>onoff)
        //{
        //    int setbit = a;

        //    for(int i=0; i<num.Count; i++)
        //    {
        //        if(onoff[i]==1)
        //        {
        //            setbit |= 1 << num[i];
        //        }
        //        else
        //        {
        //            setbit &= ~(1 << num[i]);
        //        }
        //    }
        //    return setbit;
        //}

        string UseUnuse(int data)
        {
            string a;

            if (data == 0 && Cores.Core_Robot.IsConneted == true)
            {
                a = "미사용";
            }
            else if (data != 0)
            {
                a = "사용";
            }
            else
            {
                a = "-";
            }

            return a;
        }

    }
}
