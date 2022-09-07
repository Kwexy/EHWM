using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EHWM {
    public partial class EHWMForm : Form {

        public HardwareInfoHandler hardwareInfoHandler;

        public EHWMForm() {
            hardwareInfoHandler = new HardwareInfoHandler(this);
            InitializeComponent();
            this.aboutText.Text = "v." + Application.ProductVersion.ToString() + "\n\n" +
            "A Simple Hardware Monitor That Lives In The Taskbar\n\n" +
            "Created by: Kyran Gibson";
        }

        public void Form_Load(object sender, EventArgs e) {
            Console.WriteLine("Program Started Successfully!");
        }

        public void Timer1_Tick(object sender, EventArgs e) {
            hardwareInfoHandler.getPerc();
            hardwareInfoHandler.update();
        }

        private void EHWMForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
            this.MinimizeBox = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/Kwexy/EHWM");
        }
    }
}
