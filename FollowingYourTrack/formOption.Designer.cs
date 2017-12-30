namespace FollowingYourTrack
{
    partial class formOption
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
            this.chkFW = new System.Windows.Forms.CheckBox();
            this.chkPic = new System.Windows.Forms.CheckBox();
            this.chkKey = new System.Windows.Forms.CheckBox();
            this.chkMail = new System.Windows.Forms.CheckBox();
            this.chkProcess = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tmPortrait = new System.Windows.Forms.Timer(this.components);
            this.chkPortrait = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPortrait = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.chkStartWithOS = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tmMail = new System.Windows.Forms.Timer(this.components);
            this.tmCapture = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFW
            // 
            this.chkFW.AutoSize = true;
            this.chkFW.Location = new System.Drawing.Point(63, 34);
            this.chkFW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkFW.Name = "chkFW";
            this.chkFW.Size = new System.Drawing.Size(105, 21);
            this.chkFW.TabIndex = 0;
            this.chkFW.Text = "FileWatcher";
            this.chkFW.UseVisualStyleBackColor = true;
            // 
            // chkPic
            // 
            this.chkPic.AutoSize = true;
            this.chkPic.Location = new System.Drawing.Point(63, 82);
            this.chkPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkPic.Name = "chkPic";
            this.chkPic.Size = new System.Drawing.Size(110, 21);
            this.chkPic.TabIndex = 1;
            this.chkPic.Text = "Take Picture";
            this.chkPic.UseVisualStyleBackColor = true;
            // 
            // chkKey
            // 
            this.chkKey.AutoSize = true;
            this.chkKey.Location = new System.Drawing.Point(63, 132);
            this.chkKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkKey.Name = "chkKey";
            this.chkKey.Size = new System.Drawing.Size(132, 21);
            this.chkKey.TabIndex = 2;
            this.chkKey.Text = "Catch KeyBoard";
            this.chkKey.UseVisualStyleBackColor = true;
            // 
            // chkMail
            // 
            this.chkMail.AutoSize = true;
            this.chkMail.Location = new System.Drawing.Point(63, 183);
            this.chkMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMail.Name = "chkMail";
            this.chkMail.Size = new System.Drawing.Size(92, 21);
            this.chkMail.TabIndex = 3;
            this.chkMail.Text = "Send Mail";
            this.chkMail.UseVisualStyleBackColor = true;
            // 
            // chkProcess
            // 
            this.chkProcess.AutoSize = true;
            this.chkProcess.Location = new System.Drawing.Point(63, 231);
            this.chkProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkProcess.Name = "chkProcess";
            this.chkProcess.Size = new System.Drawing.Size(251, 21);
            this.chkProcess.TabIndex = 4;
            this.chkProcess.Text = "Process and Imformation Computer";
            this.chkProcess.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(221, 346);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmPortrait
            // 
            this.tmPortrait.Interval = 50000;
            this.tmPortrait.Tick += new System.EventHandler(this.tmPortrait_Tick);
            // 
            // chkPortrait
            // 
            this.chkPortrait.AutoSize = true;
            this.chkPortrait.Location = new System.Drawing.Point(63, 277);
            this.chkPortrait.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkPortrait.Name = "chkPortrait";
            this.chkPortrait.Size = new System.Drawing.Size(76, 21);
            this.chkPortrait.TabIndex = 6;
            this.chkPortrait.Text = "Portrait";
            this.chkPortrait.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(144, 5);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(477, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 402);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPic);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPortrait);
            this.panel1.Controls.Add(this.btnPath);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.chkStartWithOS);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chkPortrait);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 402);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "millisecond";
            // 
            // txtPic
            // 
            this.txtPic.Location = new System.Drawing.Point(188, 83);
            this.txtPic.Name = "txtPic";
            this.txtPic.Size = new System.Drawing.Size(66, 22);
            this.txtPic.TabIndex = 18;
            this.txtPic.Text = "5";
            this.txtPic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "millisecond";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(177, 181);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(66, 22);
            this.txtMail.TabIndex = 16;
            this.txtMail.Text = "5";
            this.txtMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "millisecond";
            // 
            // txtPortrait
            // 
            this.txtPortrait.Location = new System.Drawing.Point(177, 276);
            this.txtPortrait.Name = "txtPortrait";
            this.txtPortrait.Size = new System.Drawing.Size(66, 22);
            this.txtPortrait.TabIndex = 14;
            this.txtPortrait.Text = "5";
            this.txtPortrait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(320, 34);
            this.btnPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(33, 23);
            this.btnPath.TabIndex = 13;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(177, 34);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(137, 22);
            this.txtPath.TabIndex = 12;
            // 
            // chkStartWithOS
            // 
            this.chkStartWithOS.AutoSize = true;
            this.chkStartWithOS.Location = new System.Drawing.Point(63, 316);
            this.chkStartWithOS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkStartWithOS.Name = "chkStartWithOS";
            this.chkStartWithOS.Size = new System.Drawing.Size(116, 21);
            this.chkStartWithOS.TabIndex = 11;
            this.chkStartWithOS.Text = "Start With OS";
            this.chkStartWithOS.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 402);
            this.panel2.TabIndex = 0;
            // 
            // tmMail
            // 
            this.tmMail.Interval = 50000;
            this.tmMail.Tick += new System.EventHandler(this.tmMail_Tick);
            // 
            // tmCapture
            // 
            this.tmCapture.Interval = 50000;
            this.tmCapture.Tick += new System.EventHandler(this.tmCapture_Tick);
            // 
            // formOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkProcess);
            this.Controls.Add(this.chkMail);
            this.Controls.Add(this.chkKey);
            this.Controls.Add(this.chkPic);
            this.Controls.Add(this.chkFW);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formOption_FormClosing);
            this.Load += new System.EventHandler(this.formOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFW;
        private System.Windows.Forms.CheckBox chkPic;
        private System.Windows.Forms.CheckBox chkKey;
        private System.Windows.Forms.CheckBox chkMail;
        private System.Windows.Forms.CheckBox chkProcess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmPortrait;
        private System.Windows.Forms.CheckBox chkPortrait;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkStartWithOS;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortrait;
        private System.Windows.Forms.Timer tmMail;
        private System.Windows.Forms.Timer tmCapture;
    }
}