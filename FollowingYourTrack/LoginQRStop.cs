using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace FollowingYourTrack
{
    public partial class LoginQRStop : MetroFramework.Forms.MetroForm
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        bool t = false;
        public LoginQRStop()
        {
            InitializeComponent();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

    

        private void LoginQRStop_Load_1(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }

        private void LoginQRStop_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            FinalFrame.Stop();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pictureBox1.Image);
            try
            {
                string decoded = result.ToString().Trim();
                if (decoded != "" && decoded == Properties.Settings.Default.PasswordQR)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    MessageBox.Show("Success");
                    t = true;
                    this.Hide();
                    page_home form = new page_home(t);
                    form.Show();
                }
                else
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    MessageBox.Show("your password is not correct");
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
    }
}
