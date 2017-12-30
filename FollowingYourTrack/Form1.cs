using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowingYourTrack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            page_support1.BringToFront();
        }
        Bunifu.Framework.UI.Drag MoveForm=new Bunifu.Framework.UI.Drag();
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm.Grab(this);
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            MoveForm.Release();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm.MoveObject();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;          
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            page_home1.BringToFront();
           
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            page_explorer1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            page_manager1.BringToFront();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState=FormWindowState.Normal;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("HH:mm");
            lblsecond.Text = DateTime.Now.ToString("ss");
            lbldate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblday.Text = DateTime.Now.ToString("dddd");
            lblsecond.Location = new Point(lbltime.Location.X + lbltime.Width , lblsecond.Location.Y);
            lblday.Location = new Point(lbldate.Location.X + lbldate.Width - 3, lblday.Location.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
          Application.Exit();
        }
    }
}
