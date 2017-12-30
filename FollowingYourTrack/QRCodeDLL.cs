using QRCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;

namespace FollowingYourTrack
{
    public partial class QRCodeDLL : Form
    {
        public QRCodeDLL()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        QRCodeSB qRCode = new QRCodeSB();
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = qRCode.GenerateQR_CodeSB(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = qRCode.DecodeQR_CodeSB(pictureBox1.Image);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            qRCode.Save_QRCodeSB(pictureBox1.Image);
        }
    }
}
