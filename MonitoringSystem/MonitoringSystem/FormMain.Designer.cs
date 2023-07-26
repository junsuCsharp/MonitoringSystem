
namespace MonitoringSystem
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLed3 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed2 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed1 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.sqLiteCommand2 = new System.Data.SQLite.SQLiteCommand();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(153)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lbLed3);
            this.panel1.Controls.Add(this.lbLed2);
            this.panel1.Controls.Add(this.lbLed1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 110);
            this.panel1.TabIndex = 0;
            // 
            // lbLed3
            // 
            this.lbLed3.BackColor = System.Drawing.Color.Transparent;
            this.lbLed3.BlinkInterval = 500;
            this.lbLed3.ForeColor = System.Drawing.Color.White;
            this.lbLed3.Label = "Alarm";
            this.lbLed3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Left;
            this.lbLed3.LedColor = System.Drawing.Color.Lime;
            this.lbLed3.LedSize = new System.Drawing.SizeF(16F, 16F);
            this.lbLed3.Location = new System.Drawing.Point(1600, 80);
            this.lbLed3.Name = "lbLed3";
            this.lbLed3.Renderer = null;
            this.lbLed3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbLed3.Size = new System.Drawing.Size(60, 20);
            this.lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed3.TabIndex = 18;
            // 
            // lbLed2
            // 
            this.lbLed2.BackColor = System.Drawing.Color.Transparent;
            this.lbLed2.BlinkInterval = 500;
            this.lbLed2.ForeColor = System.Drawing.Color.White;
            this.lbLed2.Label = "Robot Servo";
            this.lbLed2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Left;
            this.lbLed2.LedColor = System.Drawing.Color.Lime;
            this.lbLed2.LedSize = new System.Drawing.SizeF(16F, 16F);
            this.lbLed2.Location = new System.Drawing.Point(1670, 80);
            this.lbLed2.Name = "lbLed2";
            this.lbLed2.Renderer = null;
            this.lbLed2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbLed2.Size = new System.Drawing.Size(95, 20);
            this.lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed2.TabIndex = 17;
            // 
            // lbLed1
            // 
            this.lbLed1.BackColor = System.Drawing.Color.Transparent;
            this.lbLed1.BlinkInterval = 500;
            this.lbLed1.ForeColor = System.Drawing.Color.White;
            this.lbLed1.Label = "Robot Connect";
            this.lbLed1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Left;
            this.lbLed1.LedColor = System.Drawing.Color.Lime;
            this.lbLed1.LedSize = new System.Drawing.SizeF(16F, 16F);
            this.lbLed1.Location = new System.Drawing.Point(1775, 80);
            this.lbLed1.Name = "lbLed1";
            this.lbLed1.Renderer = null;
            this.lbLed1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbLed1.Size = new System.Drawing.Size(110, 20);
            this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(208, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(380, 40);
            this.label8.TabIndex = 6;
            this.label8.Text = "물류 적재 모니터링 시스템";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1194, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "로봇 상태 : -";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1330, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 60);
            this.label5.TabIndex = 0;
            this.label5.Text = "현재 시간";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1266, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(442, 40);
            this.label4.TabIndex = 20;
            this.label4.Text = "작업 상태 : -";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1266, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(442, 40);
            this.label6.TabIndex = 3;
            this.label6.Text = "모델 정보 : -";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exit.Location = new System.Drawing.Point(1817, 5);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(98, 88);
            this.exit.TabIndex = 4;
            this.exit.Text = "종료";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(101)))), ((int)(((byte)(223)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.exit);
            this.panel3.Location = new System.Drawing.Point(0, 980);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1920, 100);
            this.panel3.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(950, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(310, 88);
            this.button5.TabIndex = 4;
            this.button5.Text = "설정";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(635, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(310, 88);
            this.button4.TabIndex = 3;
            this.button4.Text = "I.O";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(320, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(310, 88);
            this.button2.TabIndex = 1;
            this.button2.Text = "작업 정보";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 88);
            this.button1.TabIndex = 0;
            this.button1.Text = "공정 모니터";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(0, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1920, 873);
            this.panel4.TabIndex = 3;
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // sqLiteCommand2
            // 
            this.sqLiteCommand2.CommandText = null;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImage = global::MonitoringSystem.Properties.Resources.logo_jd;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(108, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 50);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MonitoringSystem.Properties.Resources.Doosan_Robotics_Partner_logo_lightblue;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(7, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed1;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed3;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

