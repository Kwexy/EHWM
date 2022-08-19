using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace EHWM {
    public partial class EHWMForm : Form {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EHWMForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.titleText = new System.Windows.Forms.Label();
            this.aboutText = new System.Windows.Forms.Label();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // titleText
            // 
            this.titleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.White;
            this.titleText.Location = new System.Drawing.Point(0, 0);
            this.titleText.Margin = new System.Windows.Forms.Padding(0);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(380, 257);
            this.titleText.TabIndex = 0;
            this.titleText.Text = "EHWM";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutText
            // 
            this.aboutText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutText.ForeColor = System.Drawing.Color.White;
            this.aboutText.Location = new System.Drawing.Point(0, 139);
            this.aboutText.Name = "aboutText";
            this.aboutText.Size = new System.Drawing.Size(380, 70);
            this.aboutText.TabIndex = 1;
            this.aboutText.Text = "";
            this.aboutText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.ActiveLinkColor = System.Drawing.Color.Purple;
            this.githubLinkLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.githubLinkLabel.LinkColor = System.Drawing.Color.Teal;
            this.githubLinkLabel.Location = new System.Drawing.Point(0, 233);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(380, 24);
            this.githubLinkLabel.TabIndex = 2;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "Github";
            this.githubLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLinkLabel_LinkClicked);
            // 
            // EHWMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(380, 257);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.aboutText);
            this.Controls.Add(this.titleText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EHWMForm";
            this.ShowInTaskbar = false;
            this.Text = "About EHWM";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EHWMForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timer1;
        private Label titleText;
        private Label aboutText;
        private LinkLabel githubLinkLabel;
    }
}

