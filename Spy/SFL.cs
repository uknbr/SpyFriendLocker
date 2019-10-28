using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.IO;
using System.Text;

namespace Spy
{
    public partial class frmPrincipal : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool LockWorkStation();

        [DllImport("kernel32", SetLastError = true)]
        private static extern int GetPrivateProfileString(string section, string key, 
            string def, StringBuilder retVal, int size, string filePath);  

        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private bool folder = true;
        private String[] P;
        private String pathSave;
        private String[] files = { "config.ini", "proc.dat", "AForge.Video.DirectShow.dll", "AForge.Video.dll" };
        private String format;

        public frmPrincipal()
        {
            /* check */
            checkFiles();
            
            /* settings from file (.dat & .ini) */
            InitializeComponent();
            P = denyProcess();

            try
            {
                timer.Interval = Convert.ToInt16(getConfigFromINI("time"));

                format = getConfigFromINI("img");
                if (String.IsNullOrEmpty(format))
                {
                    format = "bmp";
                    errorMessageINI("img", format);
                }
                
                pathSave = getConfigFromINI("path");
                if (String.IsNullOrEmpty(pathSave))
                {
                    pathSave = @"C:\Spy\";
                    errorMessageINI("path", pathSave);
                }
            }
            catch
            {
                timer.Interval = 1000;
                errorMessageINI("time", "1000");
            }

            /* start */
            getCamList();
            createFolder();
            statusDevices();
        }

        /* check if file exists */
        public void checkFiles()
        {
            foreach (string f in files)
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + @"/" + f))
                {
                    MessageBox.Show("File not found: " + f, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
            }
        }

        public void errorMessageINI(String f, String d)
        {
            MessageBox.Show("The field [" + f + "] does not exists.\n" +
                            "Please, check file: config.ini\n" + 
                            "Default value is: " + d, 
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /* read parameters from ini */
        public String getConfigFromINI(string field)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString("Configuration", field, "", temp, 255, Directory.GetCurrentDirectory() + @"\config.ini");
            return temp.ToString();         
        } 

        /* create folder to save shots */
        public void createFolder()
        {
            DirectoryInfo dir = new DirectoryInfo(pathSave);

            if (!dir.Exists)
            {
                try
                {
                    dir.Create();
                    folder = true;
                }
                catch (IOException e)
                {
                    folder = false;
                    MessageBox.Show(@"Directory '" + pathSave + "' cannot be created then imagens wont be saved.\n" +
                                    @"To solve this, create dir manually\nDescription: " + e.Message, @"Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /* status device */
        private void statusDevices()
        {
            if (DeviceExist)
                status.Items[0].Text = @"Status: Ready to Start!";
            else
                status.Items[0].Text = @"Status: No Device detected!";
        }

        /* lock windows */
        private void lockWin()
        {
            bool result = LockWorkStation();

            if (result == false)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }  

        // just kill before start
        private void KillOnly()
        {
            Process[] processos = Process.GetProcesses();
            
            foreach (Process processo in processos)
            {
                foreach (String line in P)
                {
                    if (line == processo.ProcessName)
                    {
                        processo.Kill();
                    }
                }
            }
        }

        // kill target process
        private void Kill()
        {
            bool killed = false;
            Process[] processos = Process.GetProcesses();
            
            foreach (Process processo in processos)
            {
                foreach (String line in P)
                {
                    if (line == processo.ProcessName)
                    {
                        processo.Kill();
                        killed = true;
                    }
                }
            }

            if (killed)
            {
                this.Visible = true;
                btnStart.PerformClick();
                lockWin();
            }
        }

        /* Read deny process specified by user from dat file */
        public String[] denyProcess()
        {
            string[] deny = new string[100];
            string line;
            int count = 0;

            try
            {
                StreamReader file = new StreamReader(Directory.GetCurrentDirectory() + @"\proc.dat");

                while ((line = file.ReadLine()) != null)
                {
                    deny[count] = line;
                    count++;
                }

                file.Close();
                return deny;
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Please create 'proc.dat' in current directory of application\n" + 
                                "with process (line by line) to kill when start program", "File not found", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            return null;
        }
        
        // get the devices name
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cmbDevices.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    cmbDevices.Items.Add(device.Name);
                }
                cmbDevices.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cmbDevices.Items.Add("No capture device on your system"); 
                cmbDevices.SelectedIndex = 0; //make dafault to first cam
            }
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            String date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_";
            String hour = DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            String save = pathSave + "webcam_" + date + hour + "." + format;
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();

            if (folder)
            {
                    switch (format)
                    {
                        case "bmp":
                            img.Save(save, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case "png":
                            img.Save(save, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        case "gif":
                            img.Save(save, System.Drawing.Imaging.ImageFormat.Gif);
                            break;

                        case "jpeg":
                            img.Save(save, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case "jpg":
                            img.Save(save, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        /* default is BMP */
                        default:
                            img.Save(save, System.Drawing.Imaging.ImageFormat.Bmp);
                            //MessageBox.Show("The especified format [" + format + "] is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }                
            }
            imgCam.Image = img;
        }

        //close the device safely
        private void CloseVideoSource()
        {
            if (videoSource != null)
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lockWin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KillOnly();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getCamList();
            statusDevices();
            imgCam.Image = null;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            /* start */
            if (btnStart.Text == @"Start")
            {
                if (DeviceExist)
                {
                    if (chkHide.Checked)
                        this.Visible = false;

                    // start timer
                    timer.Enabled = true;

                    // capture
                    videoSource = new VideoCaptureDevice(videoDevices[cmbDevices.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    CloseVideoSource();
                    videoSource.DesiredFrameSize = new Size(160, 120);
                    videoSource.Start();

                    // buttons & status
                    status.Items[0].Text = @"Status: Device running...";
                    btnStart.Text = @"Stop";
                    btnStart.Image = images.Images[0];
                }
                else
                {
                    status.Items[0].Text = @"Status: Error, No Device selected.";
                }
            }
            /* stop */
            else
            {
                if (videoSource.IsRunning)
                {
                    CloseVideoSource();
                    status.Items[0].Text = @"Status: Device stopped.";
                    btnStart.Text = @"Start";
                    btnStart.Image = images.Images[1];
                }
            }
        }

        /* on close */
        private void SFL_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }

        /* tick timer */
        private void timer_Tick(object sender, EventArgs e)
        {
            Kill();
        }
    }
}
