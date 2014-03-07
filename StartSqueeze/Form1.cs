using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;



namespace StartSqueeze
{
    public partial class Form1 : Form
    {


        private Process p = new Process();
        private bool isRunning = false;
        public Form1()
        {
            InitializeComponent();


        }

        private string getsqname()
        {
            String myPath = System.IO.Path.GetDirectoryName(
                 System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            String cmd1 = myPath + "\\squeezelite-win.exe";
            return cmd1;
        }

        private void populateAudioSwitcher()
        {
            deviceSelector.Items.Clear();
            String sqlite = getsqname();
            if (File.Exists(sqlite))
            {
                ProcessStartInfo info = new ProcessStartInfo(sqlite);
                info.Arguments = ("-l");
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = false;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.StandardOutputEncoding = Encoding.UTF8;
                Process qp = new Process();
                qp.StartInfo = info;
                qp.Start();
                String rt = qp.StandardOutput.ReadToEnd();
                char[] buffer = rt.ToCharArray();
                qp.WaitForExit();
                foreach (string line in rt.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(line, "^ *[0-9]+ *-"))
                    {
                        deviceSelector.Items.Add(line);
                    }
                }

            }
            if (deviceSelector.Items.Count < 1)
            {
                deviceSelector.Visible = false;
            }
            else
            {
                int defaultidx= (int)Properties.Settings.Default["Device"];
                if (defaultidx >= 0 && defaultidx < deviceSelector.Items.Count)
                    deviceSelector.SelectedIndex = defaultidx;
                else
                    deviceSelector.SelectedIndex = 0;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tfName.Text = (String)Properties.Settings.Default["Name"];
            tfServer.Text = (String)Properties.Settings.Default["Server"];
            cbAuto.Checked = (Boolean)Properties.Settings.Default["Autostart"];
            int width = (int)Properties.Settings.Default["Width"];
            int height = (int)Properties.Settings.Default["Height"];
            if (width > 0 && height > 0)
            {
                this.Width = width;
                this.Height = height;
            }
            populateAudioSwitcher();
            if (cbAuto.Checked)
            {
                btStart.PerformClick();
            }


        }
        private void startPlayer()
        {
            if (isRunning) return;
            string cmd1 = getsqname();
            if (tfName.Text == "" || tfServer.Text == "")
            {
                MessageBox.Show("please fill Name and Server");
                return;
            }

            if (!File.Exists(cmd1))
            {
                MessageBox.Show("command not found:" + cmd1 + " - unable to execute");
                //webBrowser1.DocumentText = "<h1><center>Loading...</center></h1>";
                //timer1.Start();
                //timer2.Start();
                return;
            }
            ProcessStartInfo info = new ProcessStartInfo(cmd1);
            String args = "-s " + tfServer.Text + " -n " + tfName.Text;
            if (deviceSelector.Items.Count > 0)
            {
                Regex regex = new Regex(" *- *");
                String sel = deviceSelector.SelectedItem.ToString();
                String[] sela = regex.Split(sel);
                args += " -o " + sela[0];
            }
            info.Arguments = args;
            //MessageBox.Show("starting: " + args);
            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = false;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            p.StartInfo = info;
            p.Start();
            isRunning = true;
            lbPlayer.Visible = true;
            timer2.Start();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            startPlayer();   
            timer1.Start();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning && playerRunning())
            {
                p.Kill();
            }
            this.Close();
        }

        private void tfServer_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Server"] = tfServer.Text;
            Properties.Settings.Default.Save();
        }

        private void tfName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Name"] = tfName.Text;
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            String url = "http://" + tfServer.Text + ":9002?player=" + tfName.Text;
            this.webBrowser1.Navigate(url);

        }

        private void cbAuto_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Autostart"] = cbAuto.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning && playerRunning())
            {
                p.Kill();
            }

        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            Properties.Settings.Default["Width"] = this.Width;
            Properties.Settings.Default["Height"] = this.Height;
            Properties.Settings.Default.Save();
        }

        private bool playerRunning()
        {
            try
            {
                return !p.HasExited;
            }
            catch (Exception i) { }
            return false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bool prunning = playerRunning();
            if (isRunning && prunning)
            {
                if (!lbPlayerOn.Visible)
                {
                    lbPlayerOn.Visible = true;
                    lbPlayer.Visible = false;
                }
                btStop.Enabled = true;
            }
            else
            {
                if (isRunning)
                {
                    isRunning = false;
                }
                if (!lbPlayer.Visible)
                {
                    lbPlayerOn.Visible = false;
                    lbPlayer.Visible = true;
                }
                btStop.Enabled = false;
                timer2.Stop();
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRunning && playerRunning())
                {
                    p.Kill();
                }
            }
            catch (Exception i) { }
        }

        private void deviceSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Device"] = deviceSelector.SelectedIndex;
            Properties.Settings.Default.Save();
            if (isRunning && playerRunning())
            {
                p.Kill();
                isRunning = false;
                startPlayer();
            }
        }
    }
}
