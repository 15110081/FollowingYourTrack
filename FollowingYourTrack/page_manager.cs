using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace FollowingYourTrack
{
    public partial class page_manager : UserControl
    {
       
        public page_manager()
        {
            InitializeComponent();
            LoadDatatoGridView();
            TaoXMLdatabase();
        }
        string filepath = @"Schedule.xml";
        private void TaoXMLdatabase()
        {
            if (File.Exists(filepath) != true)
            {
                XmlTextWriter xtw;
                xtw = new XmlTextWriter(filepath, Encoding.UTF8);
                xtw.WriteStartDocument();
                xtw.WriteStartElement("Schedule_Track");
                xtw.WriteEndElement();
                xtw.Close();
            }
        }

        private void LoadDatatoGridView()
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(filepath);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception)
            {

            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select Image";
            openFile.Filter = "PNG file (.png)|*.png|(.jpg)|*.jpg";
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    picBoxSP.Image = new Bitmap(openFile.FileName);
                }
            }
            catch (Exception ex){ }
        }
        bool i = false;
        private void ThemSanPham(int text1, string text2, string text3, Image image)
        {        
            if (i == true)
            {
                XmlDocument xmlDocument = new XmlDocument();
                FileStream file = new FileStream(filepath, FileMode.Open);
                xmlDocument.Load(file);
                XmlElement prod = xmlDocument.CreateElement("Schedule");
                XmlElement prodID = xmlDocument.CreateElement("ID");
                string s = text1.ToString();
                XmlText ndID = xmlDocument.CreateTextNode(s);
                XmlElement prodNum = xmlDocument.CreateElement("Number");
                XmlText ndNum = xmlDocument.CreateTextNode(text2);
                XmlElement prodFolder = xmlDocument.CreateElement("Folder");
                XmlText ndFolder = xmlDocument.CreateTextNode(text3);
                XmlElement prodDate = xmlDocument.CreateElement("Date");
                XmlText ndDate = xmlDocument.CreateTextNode(DateTime.Now.ToLongDateString());
                XmlElement prodTime = xmlDocument.CreateElement("Time");
                XmlText ndTime = xmlDocument.CreateTextNode(DateTime.Now.ToLongTimeString());
                string encodeImagestring = ConvertImage(image);
                XmlElement prodHinhAnh = xmlDocument.CreateElement("Image");
                XmlText ndHinhAnh = xmlDocument.CreateTextNode(encodeImagestring);
           
                prodID.AppendChild(ndID);
                prodNum.AppendChild(ndNum);
                prodFolder.AppendChild(ndFolder);
                prodDate.AppendChild(ndDate);
                prodTime.AppendChild(ndTime);
                prodHinhAnh.AppendChild(ndHinhAnh);
           
                prod.AppendChild(prodID);
                prod.AppendChild(prodNum);
                prod.AppendChild(prodFolder);
                prod.AppendChild(prodDate);
                prod.AppendChild(prodTime);
                prod.AppendChild(prodHinhAnh);         
                xmlDocument.DocumentElement.AppendChild(prod);
                file.Close();
                xmlDocument.Save(filepath);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDatatoGridView();
                i = false;
                KhoaButton(btnInsert, false);
            }
            else
            {
                i = true;
                KhoaButton(btnInsert, true);
            }
        }
        private void KhoaButton(Button k, bool i)
        {
            if (k == btnInsert)
            {
                if (i == true)
                {
                    //tbID.Text = "";
                    //tbNumber.Text = "";
                    //tbFolder.Text = "";
                    //picBoxSP.Image = null;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else if (k == btnUpdate)
            {
                if (i == true)
                {
                    btnInsert.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnInsert.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }
        private string ConvertImage(Image image)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));
            string strImage = Convert.ToBase64String((Byte[])converter.ConvertTo(image, typeof(Byte[])));
            return strImage;
        }

        private void btnBNumber_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                     //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    tbNumber.Text = files.Length.ToString();
                    tbFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load(filepath);
            var count = xDoc.Descendants("Schedule").Count();
            //int count = 0;
            ThemSanPham(count, tbNumber.Text, tbFolder.Text, picBoxSP.Image);
            //tbID.Text = "";
            //tbNumber.Text = "";
            //tbFolder.Text = "";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            tbID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbImage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbFolder.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != null)
                {
                    ReadImagefromXml(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch (Exception)
            {
                picBoxSP.Image = null;
            }
        }
        private void ReadImagefromXml(string v)
        {
            Byte[] ImagesByte = Convert.FromBase64String(v);
            MemoryStream MemStr = new MemoryStream(ImagesByte);
            picBoxSP.Image = Image.FromStream(MemStr);
        }
        bool u = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {   
            if (u == true)
            {
                XmlDocument xmlDocument = new XmlDocument();
                FileStream file = new FileStream(filepath, FileMode.Open);
                xmlDocument.Load(file);
                XmlNodeList list = xmlDocument.GetElementsByTagName("Schedule");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement prod = (XmlElement)xmlDocument.GetElementsByTagName("Schedule")[i];
                    XmlElement prodID = (XmlElement)xmlDocument.GetElementsByTagName("ID")[i];               
                    XmlElement prodNumber = (XmlElement)xmlDocument.GetElementsByTagName("Number")[i];
                    XmlElement prodFolder = (XmlElement)xmlDocument.GetElementsByTagName("Folder")[i];
                  
                    XmlElement prodImage = (XmlElement)xmlDocument.GetElementsByTagName("Image")[i];
                    if (prodID.InnerText == tbID.Text)
                    {
                        prodNumber.InnerText = tbNumber.Text;
                        prodFolder.InnerText = tbFolder.Text;
                        prodImage.InnerText = ConvertImage(picBoxSP.Image);
                    }
                }
                file.Close();
                xmlDocument.Save(filepath);
                u = false;
                MessageBox.Show("Update thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhoaButton(btnUpdate, false);
                LoadDatatoGridView();
            }
            else
            {
                u = true;
                KhoaButton(btnUpdate, true);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(filepath, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(file);
            XmlNodeList list = xmlDocument.GetElementsByTagName("Schedule");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement prod = (XmlElement)xmlDocument.GetElementsByTagName("Schedule")[i];
                XmlElement prodID = (XmlElement)xmlDocument.GetElementsByTagName("ID")[i];
                if (prodID.InnerText == tbID.Text)
                {
                    xmlDocument.DocumentElement.RemoveChild(prod);
                }
            }
            file.Close();
            xmlDocument.Save(filepath);

            LoadDatatoGridView();
            MessageBox.Show("Delete thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            string HtmlBody = ExportDatatableToHtml(dt);
            System.IO.File.WriteAllText("ReportHTML.html", HtmlBody);
            MessageBox.Show("Success","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process.Start(tbFolder.Text);
        }
    }

}
