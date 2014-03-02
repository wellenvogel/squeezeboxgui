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

        private void Form1_Load(object sender, EventArgs e)
        {
            tfName.Text = (String)Properties.Settings.Default["Name"];
            tfServer.Text = (String)Properties.Settings.Default["Server"];
            cbAuto.Checked = (Boolean)Properties.Settings.Default["Autostart"];
            if (cbAuto.Checked)
            {
                btStart.PerformClick();
            }

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            String myPath = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            String cmd1 = myPath + "\\squeezelite-win.exe";
            if (tfName.Text == "" || tfServer.Text == "")
            {
                MessageBox.Show("please fill Name and Server");
                return;
            }
           
            if (! File.Exists(cmd1))
            {
                MessageBox.Show("command not found:" + cmd1  + " - unable to execute");
                return;
            }
            
            ProcessStartInfo info = new ProcessStartInfo(cmd1);
            String args = "-s " + tfServer.Text + " -n " + tfName.Text;
            info.Arguments = args;
            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = false;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            p.StartInfo = info;
            p.Start();
            isRunning = true;
            lbPlayer.Visible = true;
            this.lbPlayer.Text = "Player running with pid " + p.Id;
            timer1.Start();     

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning && !p.HasExited)
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
            Process.Start(url);

        }

        private void cbAuto_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Autostart"] = cbAuto.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning && !p.HasExited)
            {
                p.Kill();
            }

        }
    }
}
