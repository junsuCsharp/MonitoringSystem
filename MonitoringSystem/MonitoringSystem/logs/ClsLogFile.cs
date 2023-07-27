using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Common
{
    public static class ClsLogFile
    {
        private static object LockObj = new object();

        public static void MakeFolder(string path)
        {
            try
            {
                lock (LockObj)
                {
                    //string currentdirectory = Directory.GetCurrentDirectory();
                    //string s_LogFilePath = currentdirectory;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 로그1
        /// </summary>
        /// <param name="file"></param>
        /// <param name="logMsg"></param>
        public static void Write_Data(string file, string logMsg)
        {
            try
            {
                lock (LockObj)
                {
                    string currentdirectory = Directory.GetCurrentDirectory();
                    //string s_LogFilePath = currentdirectory + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                    //string s_LogFilePath = "D:\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                    string s_LogFilePath = $"{Application.StartupPath}\\Data_Logs\\";
                    if (!Directory.Exists(s_LogFilePath))
                    {
                        Directory.CreateDirectory(s_LogFilePath);
                    }

                    string sFile = s_LogFilePath + file;

                    if (!File.Exists(sFile))
                    {
                        using (StreamWriter sw = File.CreateText(sFile))
                        {
                            sw.WriteLine("|      Date Time      | 가동률 | 모델정보 | 작업전체수량 | 작업진행수량 | 생산수량 | 불량수량 | 알람코드 | 박스 X (mm) | 박스 Y (mm) | 박스 Z (mm) " +
                                "| 박스 무게 | 팔레트 X (mm) | 팔레트 Y (mm) | 팔레트 Z (mm) | 박스 패턴 박스 수 | 박스 패턴 레이어 수 | 현재 박스 수 | 현재 레이어 수 | 간지 사용 유무 " +
                                "| 리프트 높이 | 적재방향 | 로봇 속도 | BOX SORT CYLINDER USE | SAFETY LADAR SENSOR USE | LABEL ALINE USE | Robot State | Servo On Robot | DI #1 " +
                                "| DI #2 | DI #3 | DO #1 | DO #2 | 작업 상태 | 박스 소요 시간 | 전체 소요 시간 |");
                        }
                    }
                    using (StreamWriter sw = File.AppendText(sFile))
                    {   
                        sw.WriteLine(logMsg);
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
        }

        //IO분리해서 저장하지 않고 한번에 저장 중
        public static void Write_IO_Data(string file, string logMsg)
        {
            try
            {
                lock (LockObj)
                {
                    string currentdirectory = Directory.GetCurrentDirectory();
                    string s_LogFilePath = $"{Application.StartupPath}\\IO_Logs\\";
                    if (!Directory.Exists(s_LogFilePath))
                    {
                        Directory.CreateDirectory(s_LogFilePath);
                    }

                    string sFile = s_LogFilePath + file;

                    if (!File.Exists(sFile))
                    {
                        using (StreamWriter sw = File.CreateText(sFile))
                        {
                            sw.WriteLine("|      Date Time      |       DI 1       |       DI 2       |   DI 3   |       DO 1       |       DO 2       |");
                        }
                    }
                    using (StreamWriter sw = File.AppendText(sFile))
                    {
                        sw.WriteLine(logMsg);
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
        }

        public static void Write_Data_Queue(string file, List<string> logMsg)
        {
            try
            {
                lock (LockObj)
                {
                    //string currentdirectory = Directory.GetCurrentDirectory();
                    //string s_LogFilePath = currentdirectory + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                    //string s_LogFilePath = file;
                    string path = $"{Application.StartupPath}\\Data_Log\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string sFile = path + file;

                    if (!File.Exists(sFile))
                    {
                        using (StreamWriter sw = File.CreateText(sFile))
                        {
                            sw.WriteLine("        Date Time        | 가동률 | 모델정보 | 생산수량 | 불량수량 | 알람코드 | 작업 진행 상황 | 박스 진행 상황 | 레이어 진행상황 | 박스 정보 | 팔레트 정보 " +
                                "| 간지 사용 유무 | 리프트 높이 | 적재 방향 | 로봇 스피드 | BOX SORT CYLINDER | SAFETY LADAR SENSOR | LABEL ALINE | 작업 상태 | 박스 소요 시간 | 전체 소요 시간 |");

                        }
                    }
                    //else
                    //{
                    //    File.Delete(sFile);
                    //    using (StreamWriter sw = File.CreateText(sFile))
                    //    {
                    //    }
                    //}
                    
                    using (StreamWriter sw = File.AppendText(sFile))
                    {
                        for (int i = 0; i < logMsg.Count; i++)
                        {
                            sw.WriteLine(logMsg[i]);
                        }
                        //logMsg.Clear();
                        sw.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("LOG SAVE :::" + ex.Message);
            }
        }

        public static void Write_IO_Queue(string file, List<string> logMsg)
        {
            try
            {
                lock (LockObj)
                {
                    //string currentdirectory = Directory.GetCurrentDirectory();
                    //string s_LogFilePath = currentdirectory + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                    //string s_LogFilePath = file;
                    string path = $"{Application.StartupPath}\\IO_Logs\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string sFile = path + file;

                    if (!File.Exists(sFile))
                    {
                        using (StreamWriter sw = File.CreateText(sFile))
                        {
                            sw.WriteLine("|      Date Time      |       DI 1       |       DI 2       |   DI 3   |       DO 1       |       DO 2       |");

                        }
                    }
                    //else
                    //{
                    //    File.Delete(sFile);
                    //    using (StreamWriter sw = File.CreateText(sFile))
                    //    {
                    //    }
                    //}

                    using (StreamWriter sw = File.AppendText(sFile))
                    {
                        for (int i = 0; i < logMsg.Count; i++)
                        {
                            sw.WriteLine(logMsg[i]);
                        }
                        //logMsg.Clear();
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LOG SAVE :::" + ex.Message);
            }
        }
        #region READ File
        public static string[] ReadLog(string Url)
        {
            if (!File.Exists(Url))
            {
                return null;
            }
            else
            {
                try
                {
                    string[] strTxtValue = File.ReadAllLines(Url);
                    if (strTxtValue.Length > 0)
                    {
                        return strTxtValue;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(Exception ex)
                {
                    return null;
                }
                
            }
        }
        #endregion

    }
}
