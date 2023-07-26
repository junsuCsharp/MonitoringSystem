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
    public partial class ModelInformation : Form
    {
        List<TextBox> ModelInformationTextBox = new List<TextBox>();
        List<Label> ModelInformationLabel = new List<Label>();
        List<Button> ModelInformationButton = new List<Button>();
        List<Panel> ModelInformationPanel = new List<Panel>();

        public ModelInformation()
        {
            InitializeComponent();
        }

        private void ModelInformation_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(Convert.ToInt32(ClientSize.Width * FormMain.X_Scale), Convert.ToInt32(ClientSize.Height * FormMain.Y_Scale));

            ModelInformationTextBox.Add(Apply_1);
            ModelInformationTextBox.Add(Apply_2);
            ModelInformationTextBox.Add(Apply_3);
            ModelInformationTextBox.Add(Apply_4);
            ModelInformationTextBox.Add(Apply_5);
            ModelInformationTextBox.Add(Apply_6);
            ModelInformationTextBox.Add(Apply_7);
            ModelInformationTextBox.Add(Apply_8);
            ModelInformationTextBox.Add(Apply_9);
            ModelInformationTextBox.Add(Apply_10);
            ModelInformationTextBox.Add(Change_1);
            ModelInformationTextBox.Add(Change_2);
            ModelInformationTextBox.Add(Change_3);
            ModelInformationTextBox.Add(Change_4);
            ModelInformationTextBox.Add(Change_5);
            ModelInformationTextBox.Add(Change_6);
            ModelInformationTextBox.Add(Change_7);
            ModelInformationTextBox.Add(Change_8);
            ModelInformationTextBox.Add(Change_9);
            ModelInformationTextBox.Add(Change_10);

            for (int i=0; i< ModelInformationTextBox.Count; i++)
            {
                ModelInformationTextBox[i].Size = new Size(Convert.ToInt32(ModelInformationTextBox[i].Width*FormMain.X_Scale),Convert.ToInt32(ModelInformationTextBox[i].Height*FormMain.Y_Scale));
                ModelInformationTextBox[i].Location = new Point(Convert.ToInt32(ModelInformationTextBox[i].Location.X * FormMain.X_Scale), Convert.ToInt32(ModelInformationTextBox[i].Location.Y * FormMain.Y_Scale));
                ModelInformationTextBox[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(ModelInformationTextBox[i].Font.Size * FormMain.min_Scale));
            }

            ModelInformationLabel.Add(label1);
            ModelInformationLabel.Add(label2);
            ModelInformationLabel.Add(label3);
            ModelInformationLabel.Add(label4);
            ModelInformationLabel.Add(label5);
            ModelInformationLabel.Add(label6);
            ModelInformationLabel.Add(label7);
            ModelInformationLabel.Add(label8);
            ModelInformationLabel.Add(label9);
            ModelInformationLabel.Add(label10);
            ModelInformationLabel.Add(label11);
            ModelInformationLabel.Add(label13);
            ModelInformationLabel.Add(label15);

            for (int i=0; i<ModelInformationLabel.Count; i++)
            {
                ModelInformationLabel[i].Location = new Point(Convert.ToInt32(ModelInformationLabel[i].Location.X * FormMain.X_Scale), Convert.ToInt32(ModelInformationLabel[i].Location.Y * FormMain.Y_Scale));
                ModelInformationLabel[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(ModelInformationLabel[i].Font.Size * FormMain.min_Scale));
            }

            ModelInformationButton.Add(button2);

            for (int i = 0; i < ModelInformationButton.Count; i++)
            {
                ModelInformationButton[i].Size = new Size(Convert.ToInt32(ModelInformationButton[i].Width * FormMain.X_Scale), Convert.ToInt32(ModelInformationButton[i].Height * FormMain.Y_Scale));
                ModelInformationButton[i].Location = new Point(Convert.ToInt32(ModelInformationButton[i].Location.X * FormMain.X_Scale), Convert.ToInt32(ModelInformationButton[i].Location.Y * FormMain.Y_Scale));
                ModelInformationButton[i].Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32(ModelInformationButton[i].Font.Size * FormMain.min_Scale));
            }

            ModelInformationPanel.Add(panel1);

            for (int i = 0; i < ModelInformationPanel.Count; i++)
            {
                ModelInformationPanel[i].Size = new Size(Convert.ToInt32(ModelInformationPanel[i].Width * FormMain.X_Scale), Convert.ToInt32(ModelInformationPanel[i].Height * FormMain.Y_Scale));
                ModelInformationPanel[i].Location = new Point(Convert.ToInt32(ModelInformationPanel[i].Location.X * FormMain.X_Scale), Convert.ToInt32(ModelInformationPanel[i].Location.Y * FormMain.Y_Scale));
            }

            name_update();

            treeViewInfo.Size = new Size(Convert.ToInt32((double)treeViewInfo.Width * FormMain.X_Scale), Convert.ToInt32((double)treeViewInfo.Height * FormMain.Y_Scale));
            treeViewInfo.Location = new Point(Convert.ToInt32((double)treeViewInfo.Location.X * FormMain.X_Scale), Convert.ToInt32((double)treeViewInfo.Location.Y * FormMain.Y_Scale));
            treeViewInfo.Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32((double)12 * FormMain.min_Scale));

            dataGridViewInfo.Size = new Size(Convert.ToInt32((double)dataGridViewInfo.Width * FormMain.X_Scale), Convert.ToInt32((double)dataGridViewInfo.Height * FormMain.Y_Scale));
            dataGridViewInfo.Location = new Point(Convert.ToInt32((double)dataGridViewInfo.Location.X * FormMain.X_Scale), Convert.ToInt32((double)dataGridViewInfo.Location.Y * FormMain.Y_Scale));
            dataGridViewInfo.Font = new Font(Fonts.FontLibrary.Families[0], Convert.ToInt32((double)12 * FormMain.min_Scale));
            dataGridViewInfo.ColumnHeadersHeight = Convert.ToInt32((double)40 * FormMain.Y_Scale);
            //dataGridViewInfo.RowTemplate.Height=Convert.ToInt32((double)305 * FormMain.Y_Scale);

            Robot_Init_TreeNode();
            Robot_Init_DataGridView(treeViewInfo, ref dataGridViewInfo);
        }



        /// <summary>
        /// 2023.07.14 김준수
        /// 정보창 추가
        /// </summary>
        void name_update()
        {
            for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrWhiteSpace( Controls.Find("Change_" + (i + 1), true)[0].Text))
                {
                    Controls.Find("Apply_" + (i + 1), true)[0].Text = Controls.Find("Change_" + (i + 1), true)[0].Text;
                    Controls.Find("Change_" + (i + 1), true)[0].ResetText();
                }
                FormMain.modelName[i] = Controls.Find("Apply_" + (i + 1), true)[0].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Common.FormMessageBox msg = new Common.FormMessageBox("변경 사항을 저장 하시겠습니까?");

            if (msg.ShowDialog() == DialogResult.OK)
            {
                name_update();
            }
            else
            {

            }
        }

        void Robot_Init_TreeNode()
        {
            TreeNode svrNode = new TreeNode("Palletizing Monitoring System");

            TreeNode opration = new TreeNode("OperatingSystem");
            opration.Nodes.Add("Platform");
            opration.Nodes.Add("ServicePack");
            opration.Nodes.Add("Version");
            opration.Nodes.Add("VersionString");
            opration.Nodes.Add("CLR Version");

            TreeNode robot = new TreeNode("Doosan Robot");
            robot.Nodes.Add("Model");
            robot.Nodes.Add("S/N");

            TreeNode gripper = new TreeNode("Gripper");
            gripper.Nodes.Add("Model");
            gripper.Nodes.Add("Version");

            TreeNode motor = new TreeNode("Z축 리프트");
            motor.Nodes.Add("Model");
            motor.Nodes.Add("S/N");

            TreeNode gpio1 = new TreeNode("DI1, DI2");
            gpio1.Nodes.Add("Model");
            gpio1.Nodes.Add("Art.No.");
            gpio1.Nodes.Add("Version");

            TreeNode gpio2 = new TreeNode("DI3");
            gpio2.Nodes.Add("Model");
            gpio2.Nodes.Add("Art.No.");
            gpio2.Nodes.Add("Version");

            TreeNode gpio3 = new TreeNode("DO1, DO2");
            gpio3.Nodes.Add("Model");
            gpio3.Nodes.Add("Art.No. ");
            gpio3.Nodes.Add("Version");

            svrNode.Nodes.Add(opration);
            svrNode.Nodes.Add(robot);
            svrNode.Nodes.Add(gripper);
            svrNode.Nodes.Add(motor);
            svrNode.Nodes.Add(gpio1);
            svrNode.Nodes.Add(gpio2);
            svrNode.Nodes.Add(gpio3);

            treeViewInfo.Nodes.Add(svrNode);
            treeViewInfo.ExpandAll();

            //Robot_Init_DataGridView(svrNode, ref dataGridViewInfo);
        }

        void Robot_Init_DataGridView(TreeView treeView, ref DataGridView dgv)
        {
            //Console.WriteLine($"DEBUG ::: { treeNode.GetNodeCount(true)} / { treeNode.GetNodeCount(false)}");

            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // row 로 선택하기
            //dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; //row size 막기
            dgv.AllowUserToResizeRows = false; //row size 막기
            dgv.AllowUserToResizeColumns = false; //column size 막기

            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = 15;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToAddRows = true;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.ColumnCount = 2;
            dgv.RowCount = treeView.GetNodeCount(true);
            dgv.ColumnHeadersVisible = true;

            dgv.Columns[0].HeaderText = $"이름";
            dgv.Columns[0].Width = Convert.ToInt32((double)180*FormMain.X_Scale);
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dgv.ColumnHeadersHeight = 50;
            //dgv.AllowUserToResizeColumns = false; //column size 막기

            dgv.Columns[1].HeaderText = $"내용";
            for (int ix = 0; ix < dgv.ColumnCount; ix++)
            {
                if (ix >= 1)
                {
                    //dgv.Columns[ix].HeaderText = $"{ix:00}";
                    dgv.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv.Columns[ix].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                dgv.Columns[ix].Resizable = DataGridViewTriState.False;
                dgv.Columns[ix].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            List<TreeNode> treeNodes = GetAllNodes(treeView);
            string strNodeHeader = null;
            for (int ux = 0; ux < dgv.RowCount; ux++)
            {
                dgv.Rows[ux].Cells[0].Value = treeNodes[ux].Text;
                if (ux == 0)
                {
                    strNodeHeader = treeNodes[ux].Text;
                    dgv.Rows[ux].HeaderCell.Style.BackColor = Color.DarkGray;
                    dgv.Rows[ux].Cells[0].Style.BackColor = Color.Gray;
                }

                if (treeNodes[ux].Parent != null)
                {
                    if (strNodeHeader.Contains(treeNodes[ux].Parent.Text))
                    {
                        dgv.Rows[ux].HeaderCell.Style.BackColor = Color.DarkGray;
                        dgv.Rows[ux].Cells[0].Style.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        //dgv.Rows[ux].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                //Console.WriteLine($"DEBUG ::: {ux} / {treeNodes[ux].Checked} / {treeNodes[ux].Index} / {treeNodes[ux].Text} / {treeNodes[ux].Name} / {treeNodes[ux].Parent}");
            }

            //Operating System
            OperatingSystem os = System.Environment.OSVersion;
            //if(System.Environment.Is64BitOperatingSystem)
            //Console.WriteLine("Platform :" + os.Platform);
            //Console.WriteLine("ServicePack :" + os.ServicePack);
            //Console.WriteLine("Version :" + os.Version);
            //Console.WriteLine("VersionString :" + os.VersionString);
            //Console.WriteLine("CLR Version :" + System.Environment.OSVersion);

            dgv.Rows[2].Cells[1].Value = os.Platform;
            dgv.Rows[3].Cells[1].Value = os.ServicePack;
            dgv.Rows[4].Cells[1].Value = os.Version;
            dgv.Rows[5].Cells[1].Value = os.VersionString;
            dgv.Rows[6].Cells[1].Value = System.Environment.OSVersion;

            dgv.Rows[8].Cells[1].Value = "H2017";
            dgv.Rows[9].Cells[1].Value = "XLD3A8";

            dgv.Rows[11].Cells[1].Value = "MC25C";
            dgv.Rows[12].Cells[1].Value = "MC25CX-N2B60F-U75S5D";

            dgv.Rows[14].Cells[1].Value = "D2T-1023-F-C5";
            dgv.Rows[15].Cells[1].Value = "510P221002390041_A2_141";

            dgv.Rows[17].Cells[1].Value = "CUBE20 DIGITAL INPUT MODULE";
            dgv.Rows[18].Cells[1].Value = "56112";
            dgv.Rows[19].Cells[1].Value = "-";

            dgv.Rows[21].Cells[1].Value = "SYSTEM INTERFACE TO CUBE 67";
            dgv.Rows[22].Cells[1].Value = "564501";
            dgv.Rows[23].Cells[1].Value = "-";

            dgv.Rows[25].Cells[1].Value = "CUBE20 DIGITAL OUTPUT MODULE";
            dgv.Rows[26].Cells[1].Value = "56118";
            dgv.Rows[27].Cells[1].Value = "-";

            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                //dgv.Rows[row].Height = 41;
                dgv.RowTemplate.Height = Convert.ToInt32((dgv.Size.Height - dgv.ColumnHeadersHeight) / dgv.Rows.Count);

                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    //dgv.Rows[row].Cells[col].Style.Font = new Font(Fonts.FontLibrary.Families[0], 12);
                }
            }

            dgv.ClearSelection();
            //Console.WriteLine($"DEBUG :::");
        }

        public static List<TreeNode> GetAllNodes(TreeNode node)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(node);
            foreach (TreeNode child in node.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;

        }

        // 트리뷰의 전체 노드
        public static List<TreeNode> GetAllNodes(TreeView treeView)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in treeView.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }
    }
}
