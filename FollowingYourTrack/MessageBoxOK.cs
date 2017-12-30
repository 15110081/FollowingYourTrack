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
    public partial class MessageBoxOK : MetroFramework.Forms.MetroForm
    {
        public MessageBoxOK()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            LoginQR form = new LoginQR();
            form.Show();
            this.Hide();
        }
    }
}
