using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FollowingYourTrack
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string filepath = "DataUser.xml";

        private void button2_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            button3_Click(sender, e);
        }
        private string EncodeMD5(string pass)

        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);

            bs = md5.ComputeHash(bs);

            System.Text.StringBuilder s = new System.Text.StringBuilder();

            foreach (byte b in bs)

            {

                s.Append(b.ToString("x1").ToLower());

            }

            pass = s.ToString();

            return pass;

        }

        int count = 0;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string pass = EncodeMD5(txtPassword.Text);
            XDocument xDocument = XDocument.Load(filepath);
            var data = xDocument.Descendants("User").Select(p => new
            {
                Username = p.Element("Username").Value,
                Password = p.Element("Password_Encoded").Value
            }).ToList();
            foreach (var i in data)
            {
                if (txtUsername.Text == i.Username && pass == i.Password)
                {
                    count = 0;
                    Form1 form1 = new Form1();
                    form1.Show();
                    notifyIcon1.Visible = false;
                    this.Hide();
                    return;
                }
            }
            count++;
            MessageBox.Show("Tài khoản chưa đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (count == 3)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xem hint không", "Gợi ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var Hint = xDocument.Descendants("User").Select(p => new
                    {
                        textHint = p.Element("Hint").Value
                    }).ToList();
                    foreach (var hint in Hint)
                    {
                        MessageBox.Show("Hint của bạn là: " + hint.textHint, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    }
                }
            }
        }

        private void Login_MinimumSizeChanged(object sender, EventArgs e)
        {
           
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.chkStartWithOS)
            {
                ShowIcon = false;
                notifyIcon1.Visible = true;
                WindowState = FormWindowState.Minimized;
                //notifyIcon1.ShowBalloonTip(1000);
            }
        }
    }
}
