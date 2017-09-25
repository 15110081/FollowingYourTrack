using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;
namespace Login_QR_code
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            
            //timer1.Enabled = true;
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //throw new NotImplementedException();
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pictureBox1.Image);
            try
            {
                string decoded = result.ToString().Trim();

                if (decoded != "")
                {
                    timer1.Stop();
                    MessageBox.Show(decoded);
                    Form2 form = new Form2();
                    form.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //khi nhấn nút login thì bắt đầu chạy timer để kiểm tra QR code có đúng với "laptrinhvb.net" không
            timer1.Enabled = true;
            timer1.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }
    }
}
