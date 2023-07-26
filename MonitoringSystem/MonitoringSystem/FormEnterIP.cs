using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.DirectoryServices;
using System.Diagnostics;

namespace MonitoringSystem
{
    public partial class FormEnterIP : Form
    {
        public FormEnterIP()
        {
            InitializeComponent();
        }

        public static string SetIP_Robot_1;
        public static string SetIP_Robot_2;
        public static string SetIP_Robot_3;
        bool ip_ = false;

        List<string> iplist = new List<string>();

        /// <summary>
        /// ip 형식이 올바른지 확인
        /// 내가 ip를 지정하는게 아닌 유효한 ip를 찾아가는 방식으로 바꿀예정이라 필요 없음
        /// </summary>
        /// <param name="ip_text"></param>
        void ip_check(string ip_text)
        {
            string ip_Split = ip_text;
            string[] words = ip_Split.Split('.');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length <= 3)
                {
                    int j = 0;

                    bool result = int.TryParse(words[i], out j);

                    if (result == false)
                    {
                        ip_ = false;

                        break;
                    }
                }
                else
                {
                    ip_ = false;

                    break;
                }

                ip_ = true;
            }
        }

        string myipAdress;

        /// <summary>
        /// 내 로컬 IP 가져오기
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string LocalIP = string.Empty;

            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIP = host.AddressList[i].ToString();
                    break;
                }
            }
            return LocalIP;
        }

        private void FormEnterIP_Load(object sender, EventArgs e)
        {
            myipAdress = GetLocalIP();
            my_ip_adress.Text = myipAdress;

        }

        /// <summary>
        /// 핑 체크
        /// </summary>
        void PingCheck()
        {
            string str = check_ip(myipAdress);


            for (int i = 2; i < 256; i++)
            {
                //string ip = $"172.16.0.{i}";
                string ip = str + i;
                if (ip == my_ip_adress.Text)
                {
                    continue;
                }
                Networks.NetAsyncPing.PingCheckAsync(ip, false);
            }


            Console.WriteLine("aaaa");
            timer1.Interval = 1000;
            timer1.Start();

            Console.WriteLine($"{DateTime.Now}  IP Serch Start");

        }

        string check_ip(string ip)
        {
            string ip_;

            string[] split_ip = ip.Split('.');

            ip_ = split_ip[0] + "." + split_ip[1] + "." + split_ip[2] + ".";

            return ip_;
        }

        /// <summary>
        /// 연결 가능한 IP checkListBox에 출력
        /// </summary>
        int icount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            icount++;

            Console.WriteLine($"{DateTime.Now} IP COUNT ::: { Networks.NetAsyncPing.dicReConnectIps.Count}");

            if (icount > 2)
            {

                if (Networks.NetAsyncPing.dicReConnectIps.Count != 0)
                {
                    foreach (KeyValuePair<string, bool> item in Networks.NetAsyncPing.dicReConnectIps)
                    {
                        //listBox1.Items.Add($"{item.Key} :: {item.Value}");
                        //checkedListBox1.Items.Add($"IP : {item.Key} \t State : {item.Value}");
                        checkedListBox1.Items.Add($"IP : {item.Key}");
                    }

                }
                else
                {
                    //listBox1.Items.Add($"None");
                    checkedListBox1.Items.Add($"None");
                }


                timer1.Stop();
            }
        }

        /// <summary>
        /// 선택된 IP listBox로 이동
        /// </summary>
        void ip_list()
        {
            iplist.Clear();

            System.Collections.IEnumerator ie;
            ie = checkedListBox1.CheckedIndices.GetEnumerator();
            while (ie.MoveNext())
            {
                //MessageBox.Show(checkedListBox1.Items[(int)ie.Current].ToString());
                iplist.Add(checkedListBox1.Items[(int)ie.Current].ToString().Substring(5));
            }

        }

        private void button_Re_Click(object sender, EventArgs e)
        {
            myipAdress = GetLocalIP();
            my_ip_adress.Text = myipAdress;

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            SetIP_Robot_1 = my_ip_adress.Text;

            ip_check(SetIP_Robot_1);

            if (ip_ == true)
            {

                Close();

            }
            else if (ip_ == false)
            {
                MessageBox.Show("IP 주소를 확인해주세요.");
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            Networks.NetAsyncPing.dicReConnectIps.Clear();

            PingCheck();
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                ip_list();

                SetIP_Robot_1 = iplist[0];

                ip_check(SetIP_Robot_1);

                if (ip_ == true)
                {

                    Close();

                }
                else if (ip_ == false)
                {
                    MessageBox.Show("IP 주소를 확인해주세요.");
                }
            }
            catch 
            {
                MessageBox.Show("IP 주소를 선택해주세요.");
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
