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
    public partial class password : MetroFramework.Forms.MetroForm
    {
        private string captchaText;
        public password()
        {
            InitializeComponent();
        }

        public String randomString()
        {
            Random rnd = new Random();
            int number = rnd.Next(10000, 99999);
            string text = md5(number.ToString());
            text = text.ToUpper();
            text = text.Substring(0, 6);
            return text;

        }
        public static byte[] encryptData(String data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(String data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        private Bitmap drawImage(string txt, int w, int h)
        {
            Bitmap bt = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bt);
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, bt.Width, bt.Height);
            System.Drawing.Font font = new System.Drawing.Font("Tahoma", 30);
            sb = new SolidBrush(Color.Blue);
            g.DrawString(txt, font, sb, bt.Width / 2 - (txt.Length / 2) * font.Size, (bt.Height / 2) - font.Size);
            // Tạo hiệu ứng cho captcha
            // vẽ dấu chấm
            int count = 0;
            Random rand = new Random();
            while (count < 1000)
            {
                sb = new SolidBrush(Color.YellowGreen);
                g.FillEllipse(sb, rand.Next(0, bt.Width), rand.Next(0, bt.Height), 4, 2);
                count++;
            }
            count = 0;
            // vẽ đường gạch ngang
            while (count < 25)
            {
                g.DrawLine(new Pen(Color.Pink), rand.Next(0, bt.Width), rand.Next(0, bt.Height), rand.Next(0, bt.Width), rand.Next(0, bt.Height));
                count++;
            }
            // End tạo hiệu ứng
            return bt;
        }
        private void Reset()
        {
            captchaText = this.randomString();
            bunifuCustomTextbox1.Text = "";
            // vẽ captcha lên panel 1
            panel1.BackgroundImage = drawImage(captchaText, panel1.Width, panel1.Height);

        }
        private void bunifuMaterialTextbox1_MouseEnter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "new password")
            {
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox1.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox1_MouseLeave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "new password";
                bunifuMaterialTextbox1.ForeColor = Color.Silver;
            }
        }

        private void bunifuMaterialTextbox2_MouseEnter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "confirm new password")
            {
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox2.ForeColor = Color.Black;
            }
        }

        private void bunifuMaterialTextbox2_MouseLeave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "confirm new password";
                bunifuMaterialTextbox2.ForeColor = Color.Silver;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox1.Text == captchaText)
            {
                MessageBox.Show("Bạn đã nhập chính xác!");
                metroButton2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bạn đã nhập không chính xác!");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void password_Load(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = false;
            Reset();
        }



        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox1.Checked)
            {
                bunifuMaterialTextbox1.isPassword = true;
                bunifuMaterialTextbox2.isPassword = true;
            }
            else
            {
                bunifuMaterialTextbox1.isPassword = false;
                bunifuMaterialTextbox2.isPassword = false;
            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.isPassword = true;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Properties.Settings.Default.PasswordQR = bunifuMaterialTextbox1.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Change password successful!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            }
        }

        private void bunifuMaterialTextbox2_Validating(object sender, CancelEventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != bunifuMaterialTextbox1.Text)
            {
                e.Cancel = true;
                bunifuMaterialTextbox2.Focus();
                errorProvider1.SetError(bunifuMaterialTextbox2, "Your password is not correct");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(bunifuMaterialTextbox2, null);
            }
        }

        private void bunifuCustomTextbox1_Validating(object sender, CancelEventArgs e)
        {
            if (bunifuCustomTextbox1.Text != captchaText)
            {
                e.Cancel = true;
                bunifuCustomTextbox1.Focus();
                errorProvider1.SetError(bunifuCustomTextbox1, "Your captcha is not correct");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(bunifuCustomTextbox1, null);
                MessageBox.Show("Bạn đã nhập không chính xác!");
            }
        }
    }
}
