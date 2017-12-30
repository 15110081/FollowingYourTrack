using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Resources;
using FollowingYourTrack.Properties;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;
using System.Net.Mail;

namespace FollowingYourTrack
{
    public partial class page_home : UserControl
    {
        public static int temp = 1;
        public page_home()
        {
            InitializeComponent();
            bunifuImageButton6.Tag = true;
        }
        public page_home(bool t)
        {
            InitializeComponent();
            int id = Properties.Settings.Default.idProcessKey;
            Bitmap bm = new Bitmap(Resources.play_button);
            bunifuImageButton6.Image = bm;
            bunifuImageButton6.Tag = true;
            label7.Text = "Start";
            Application.Restart();
            Process processtoclose = Process.GetProcessById(id);
            processtoclose.Kill();


        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            CPU form = new CPU();
            form.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "You have to entire your QR", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LoginQR form = new LoginQR();
            form.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
         @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
            {
                objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
                Bitmap bm = new Bitmap(Resources.icon);
                bunifuImageButton2.Image = bm;
                label1.Text = "Lock";
            }
            else
            {
                objRegistryKey.DeleteValue("DisableTaskMgr");
                Bitmap bm = new Bitmap(Resources.open);
                bunifuImageButton2.Image = bm;
                label1.Text = "Open";
                objRegistryKey.Close();
            }
        }
        formOption form = null;
        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if ((bool)bunifuImageButton6.Tag)
            {
                Bitmap bm = new Bitmap(Resources.stop);
                bunifuImageButton6.Image = bm;
                label7.Text = "Stop";
                bunifuImageButton6.Tag = false;
                //Properties.Settings.Default.Save();

                form = new formOption();
                form.Show();
            }
            else
            {
                LoginQRStop form = new LoginQRStop();
                form.Show();
            }
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            Process p = Process.Start("LockFolder.exe");
            Thread.Sleep(500);
            p.WaitForInputIdle();
            //   SetParent(p.MainWindowHandle, this.Handle);
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            //TestQRCodeDLL.Form1 form = new TestQRCodeDLL.Form1();
            //form.Show();
            QRCodeDLL form = new QRCodeDLL();
            form.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            formOption form = new formOption();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formOption.cam.Stop();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {

            formOption.cam.Stop();
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
