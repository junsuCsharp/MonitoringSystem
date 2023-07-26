using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Externs
{
    public class Robot_Modbus_Table
    {
        public static string strRobot_Version = null;

        public static List<Data> lstModbusData = new List<Data>() {
            //모드버스 주소, 형태, 레지스터 종류, 설명, 자리수, 
            new Data(128, Type.Read , Func.Holding_Register, "operate_rate             ", new Point(10, 0), "가동률                     ", true), //modbus_Data_List[00]
            new Data(129, Type.Read , Func.Holding_Register, "model_info               ", new Point(10, 0), "모델정보                   ", true), //modbus_Data_List[01]
            new Data(130, Type.Read , Func.Holding_Register, "total_quantity           ", new Point(10, 0), "작업전체수량               ", true), //modbus_Data_List[02]
            new Data(131, Type.Read , Func.Holding_Register, "progress_quantity        ", new Point(10, 0), "작업진행수량      	   	    ", true), //modbus_Data_List[03]
            new Data(132, Type.Read , Func.Holding_Register, "production_cnt           ", new Point(10, 0), "생산수량     		   	    ", true), //modbus_Data_List[04]
            new Data(133, Type.Read , Func.Holding_Register, "error_cnt                ", new Point(10, 0), "불량수량    		   	    ", true), //modbus_Data_List[05]
            new Data(140, Type.Read , Func.Holding_Register, "alarm_code               ", new Point(10, 0), "알람코드			   	    ", true), //modbus_Data_List[06]
            new Data(141, Type.Read , Func.Holding_Register, "box_x                    ", new Point(10, 0), "박스 X 길이			   	", true), //modbus_Data_List[07]
            new Data(142, Type.Read , Func.Holding_Register, "box_y                    ", new Point(10, 0), "박스 Y 길이			   	", true), //modbus_Data_List[08]
            new Data(143, Type.Read , Func.Holding_Register, "box_z                    ", new Point(10, 0), "박스 Z 길이			   	", true), //modbus_Data_List[09]
            new Data(144, Type.Read , Func.Holding_Register, "box_weight               ", new Point(10, 0), "박스 무게			   	    ", true), //modbus_Data_List[10]
            new Data(145, Type.Read , Func.Holding_Register, "pallete_x                ", new Point(10, 0), "팔레트 X 길이		   	    ", true), //modbus_Data_List[11]
            new Data(146, Type.Read , Func.Holding_Register, "pallete_y                ", new Point(10, 0), "팔레트 Y 길이		   	    ", true), //modbus_Data_List[12]
            new Data(147, Type.Read , Func.Holding_Register, "pallete_z                ", new Point(10, 0), "팔레트 Z 길이		   	    ", true), //modbus_Data_List[13]
            new Data(148, Type.Read , Func.Holding_Register, "total_box_cnt            ", new Point(10, 0), "박스 패턴 박스 수	   	    ", true), //modbus_Data_List[14]
            new Data(149, Type.Read , Func.Holding_Register, "total_layer_cnt          ", new Point(10, 0), "박스 패턴 레이어 수	   	", true), //modbus_Data_List[15]
            new Data(150, Type.Read , Func.Holding_Register, "cur_box_cnt              ", new Point(10, 0), "현재 박스 수		   	    ", true), //modbus_Data_List[16]
            new Data(151, Type.Read , Func.Holding_Register, "cur_layer_cnt            ", new Point(10, 0), "현재 레이어 수		   	    ", true), //modbus_Data_List[17]
            new Data(152, Type.Read , Func.Holding_Register, "between_paper            ", new Point(10, 0), "간지 사용 유무		   	    ", true), //modbus_Data_List[18]
            new Data(153, Type.Read , Func.Holding_Register, "lift_height              ", new Point(10, 0), "리프트 높이			   	", true), //modbus_Data_List[19]
            new Data(154, Type.Read , Func.Holding_Register, "load_direction           ", new Point(10, 0), "적재방향			   	    ", true), //modbus_Data_List[20]
            new Data(155, Type.Read , Func.Holding_Register, "robot_speed              ", new Point(10, 0), "로보트 스피드 설정	   	    ", true), //modbus_Data_List[21]
            new Data(156, Type.Read , Func.Holding_Register, "box_sort_cylinder        ", new Point(10, 0), "BOX SORT CYLINDER USE  	", true), //modbus_Data_List[22]
            new Data(157, Type.Read , Func.Holding_Register, "safety_ladar_sensor      ", new Point(10, 0), "SAFETY LADAR SENSOR USE	", true), //modbus_Data_List[23]
            new Data(158, Type.Read , Func.Holding_Register, "label_aline              ", new Point(10, 0), "LABEL ALINE USE		   	", true), //modbus_Data_List[24]
                                                                                                                                                                  
            new Data(259, Type.Read , Func.Holding_Register, "robot_state              ", new Point(10, 0), "Robot State			   	", true), //modbus_Data_List[25]                   
            new Data(260, Type.Read , Func.Holding_Register, "servo_on_robot           ", new Point(10, 0), "Servo On Robot		   	    ", true), //modbus_Data_List[26]
                                                                                       
            new Data(160, Type.Read , Func.Holding_Register, "di_1                     ", new Point(10, 0), "PC IO 상태 (DI #1)	   	    ", true), //modbus_Data_List[27]
            new Data(161, Type.Read , Func.Holding_Register, "di_2                     ", new Point(10, 0), "PC IO 상태 (DI #2)	   	    ", true), //modbus_Data_List[28]
            new Data(162, Type.Read , Func.Holding_Register, "di_3                     ", new Point(10, 0), "PC IO 상태 (DI #3)	   	    ", true), //modbus_Data_List[29]
            new Data(163, Type.Read , Func.Holding_Register, "do_1                     ", new Point(10, 0), "PC IO 상태 (DO #1)	   	    ", true), //modbus_Data_List[30]
            new Data(164, Type.Read , Func.Holding_Register, "do_2                     ", new Point(10, 0), "PC IO 상태 (DO #2)	   	    ", true), //modbus_Data_List[31]

            //2023.07.19 modbus 추가
            new Data(134, Type.Read , Func.Holding_Register, "work_state               ", new Point(10, 0), "작업 상태 0:작업x 1:작업0  ", true), //modbus_Data_List[32]
            new Data(135, Type.Read , Func.Holding_Register, "box_time                 ", new Point(10, 0), "박스 소요 시간  	   	    ", true), //modbus_Data_List[33]
            new Data(136, Type.Read , Func.Holding_Register, "total_time               ", new Point(10, 0), "전체 소요 시간  	   	    ", true), //modbus_Data_List[34]


            //로봇 버전 확인용
            //new Data(256, Type.Read , Func.Holding_Register, "Controller_Major_Version ", new Point(10, 0), "               	   	    ", true), 
            //new Data(257, Type.Read , Func.Holding_Register, "Controller Minor Version ", new Point(10, 0), "               	   	    ", true), 
            //new Data(258, Type.Read , Func.Holding_Register, "Controller Patch Version ", new Point(10, 0), "               	   	    ", true), 

             };

        public static byte SetBit(int dat)
        {
            if (dat == 1)
            {
                return 0xff;
            }
            return 0;
        }

        public partial class Data
        {
            /// <summary>
            /// 최초 생성자
            /// </summary>
            /// <param name="addr"></param>
            /// <param name="rw"></param>
            /// <param name="resistor"></param>
            /// <param name="desc"></param>
            /// <param name="pt"></param>
            /// <param name="comment"></param>
            public Data(int addr, Type rw, Func resistor, string desc, Point pt, string comment, bool use)
            {
                Address = addr;
                type = rw;
                func = resistor;
                strDesc = desc;
                ptDecimal = pt;
                strComment = comment;
                IsUsed = use;
            }

            public Data(int addr, int data)
            {
                Address = addr;
                iData = data;
            }

            public bool IsUsed;
            public int Address;            
            public Type type;
            public Func func;
            public int iData;
            public string strData;
            public string strDesc;
            public Point ptDecimal;
            public string strComment;

            //이전 데이터 업데이트 변경시에만 하기위하여 사용한다.
            public int iPrevData;
               
            public bool IsFirst = false;

            public int iCurrData;
        }

        public enum Type
        { 
            Read, Write, Both
        }

        public enum Func
        {
            Read_Coil= 0x01, Holding_Register=0x03, Write_Coil=0x05, Write_Register = 0x06,
        }

        public enum Robot_Write
        {
            GPIO, TOOL_IO, REGISTER
        }

        public enum RobotState_Ver_1_0
        {
            INITIALIZING = 0,
            STANDBY = 1,
            OPERATING = 2,
            SAFE_OFF = 3,
            TECHING = 4,
            SAFE_STOP = 5,
            EMERGENCY_STOP = 6,
            HOMING = 7,
            RECOVERY = 8,
            SAFE_STOP_2 = 9,
            SAFE_OFF2 = 10,                        
            NOT_READY = 15,            
        }

        public enum RobotState_Ver_1_1
        {
            BACKDRIVE_HOLD = 0,
            BACKDRIVE_RELEASE = 1,
            BACKDRIVE_RELEASE_BY_COCKPIT = 2,
            SAFE_OFF = 3,
            INITIALIZING = 4,
            INTERRUPTED = 5,
            EMERGENCY_STOP = 6,
            AUTO_MEASURE = 7,
            RECOVERY_STANDBY = 8,
            RECOVERY_JOGGING = 9,
            RECOVERY_HANDGUIDING = 10,
            MANUAL_STANDBY = 11,
            MANUAL_JOGGING = 12,
            MANUAL_HANDGUIDING = 13,
            HIGH_PRIORITY_RUNNING = 14,
            STANDALONE_STANDBY = 15,
            STANDALONE_RUNNING = 16,
            COLLABORATIVE_STANDBY = 17,
            COLLABORATIVE_RUNNING = 18,
            HANDGUIDING_CONTROL_STANDBY = 19,
            HANDGUIDING_CONTROL_RUNNING = 20,
        }

    }
}
