using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FollowingYourTrack
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
            TaoXMLdatabase();
        }

        string filepath = "DataUser.xml";

        private void TaoXMLdatabase()
        {
            if (File.Exists(filepath) != true)
            {
                XmlTextWriter xtw;
                xtw = new XmlTextWriter(filepath, Encoding.UTF8);
                xtw.WriteStartDocument();
                xtw.WriteStartElement("Users");
                xtw.WriteEndElement();
                xtw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void txtRePasswdDK_TextChanged(object sender, EventArgs e)
        {
            if (txtRePasswdDK.Text == "")
                txtError.Text = "";
            else if (txtRePasswdDK.Text != txtPasswdDK.Text)
                txtError.Text = "Incorrect!";
            else
            {
                txtError.Text = "";
            }
        }

        private string EncodeMD5(string pass)       //Hàm mã hóa MD5

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MD5pass = EncodeMD5(txtPasswdDK.Text);
                var xDoc = XDocument.Load(filepath);
                var count = xDoc.Descendants("User").Count();
                var newData = new XElement("User",
                                  new XElement("ID", count + 1),
                                  new XElement("Username", txtUserDK.Text),
                                  new XElement("Password_Encoded", MD5pass),
                                  new XElement("Password",txtPasswdDK.Text),
                                  new XElement("Hint", txtHint.Text));
                xDoc.Root.Add(newData);
                xDoc.Save(filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult result = MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
