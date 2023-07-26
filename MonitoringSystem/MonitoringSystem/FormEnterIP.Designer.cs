
namespace MonitoringSystem
{
    partial class FormEnterIP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.my_ip_adress = new System.Windows.Forms.TextBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button_Re = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP 설정";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(640, 77);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(120, 60);
            this.button_Connect.TabIndex = 16;
            this.button_Connect.Text = "연결";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "내 IP 주소";
            // 
            // my_ip_adress
            // 
            this.my_ip_adress.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.my_ip_adress.Location = new System.Drawing.Point(63, 92);
            this.my_ip_adress.Name = "my_ip_adress";
            this.my_ip_adress.ReadOnly = true;
            this.my_ip_adress.Size = new System.Drawing.Size(442, 44);
            this.my_ip_adress.TabIndex = 19;
            this.my_ip_adress.Text = "-";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(640, 562);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(120, 120);
            this.button_Exit.TabIndex = 20;
            this.button_Exit.Text = "종료";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(640, 210);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(120, 60);
            this.button_Search.TabIndex = 22;
            this.button_Search.Text = "검색";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(640, 276);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(120, 60);
            this.button_Apply.TabIndex = 24;
            this.button_Apply.Text = "적용";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(63, 210);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(508, 472);
            this.checkedListBox1.TabIndex = 29;
            // 
            // button_Re
            // 
            this.button_Re.Location = new System.Drawing.Point(511, 77);
            this.button_Re.Name = "button_Re";
            this.button_Re.Size = new System.Drawing.Size(60, 60);
            this.button_Re.TabIndex = 30;
            this.button_Re.Text = "다시";
            this.button_Re.UseVisualStyleBackColor = true;
            this.button_Re.Click += new System.EventHandler(this.button_Re_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "연결 가능한 IP 주소";
            // 
            // FormEnterIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Re);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.my_ip_adress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormEnterIP";
            this.Text = "FormIP";
            this.Load += new System.EventHandler(this.FormEnterIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox my_ip_adress;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button_Re;
        private System.Windows.Forms.Label label2;
    }
}