﻿using System;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace EHWM {
    public class IconHandler {

        //fields
        private int hardPerc;
        private Form mainForm;
        private Icon[] graphAnim;
        private NotifyIcon toolboxIcon;
        private ContextMenu toolboxMenu;
        private MenuItem menuItemTitle;
        private MenuItem menuItemSwitch;
        private MenuItem menuItemQuit;
        private MenuItem menuItemCPU;
        private MenuItem menuItemMEM;
        private MenuItem menuItemGPU;
        private MenuItem menuItemDSK;

        //bind icons to .ico files
        public void SetIcons() {
            graphAnim = new Icon[11];
            for (int i = 0; i < graphAnim.Length-1; i++) {
                string fileName = @"icons\graph" + i.ToString() + ".ico";
                graphAnim[i] = new Icon(fileName);
            }
        }

        public IconHandler(Form form) {
            mainForm = form;
        }

        //set local hardware value percentage
        public void SetPerc(int perc) {
            hardPerc = perc;
        }

        //setup ContextMenu for NotifyIcon
        public void SetupMenu() {
            toolboxIcon.ContextMenu = toolboxMenu;
        }

        //set menu item values
        public void InitMenuItems() {
            toolboxMenu = new ContextMenu();
            menuItemTitle = new MenuItem();
            menuItemSwitch = new MenuItem();
            menuItemQuit = new MenuItem();
            toolboxMenu.MenuItems.AddRange(new MenuItem[] { menuItemTitle, menuItemSwitch, menuItemQuit });

            menuItemCPU = new MenuItem();
            menuItemMEM = new MenuItem();
            menuItemGPU = new MenuItem();
            menuItemDSK = new MenuItem();
            menuItemSwitch.MenuItems.AddRange(new MenuItem[] { menuItemCPU, menuItemMEM, menuItemGPU, menuItemDSK });

            toolboxIcon = new NotifyIcon();
            toolboxIcon.Visible = true;
            toolboxIcon.Icon = graphAnim[0];

            menuItemTitle.Text = "EHWM v." + Application.ProductVersion;
            menuItemSwitch.Text = "Switch";
            menuItemQuit.Text = "Quit EHWM";

            menuItemCPU.Text = "CPU";
            menuItemMEM.Text = "Memory";
            menuItemGPU.Text = "GPU";
            menuItemDSK.Text = "Disk";

            menuItemTitle.Click += new EventHandler(MenuItemTitle_Click);
            menuItemQuit.Click += new EventHandler(MenuItemQuit_Click);

            menuItemCPU.Click += new EventHandler(MenuItemCPU_Click);
            menuItemMEM.Click += new EventHandler(MenuItemMEM_Click);
            menuItemGPU.Click += new EventHandler(MenuItemGPU_Click);
            menuItemDSK.Click += new EventHandler(MenuItemDSK_Click);

            toolboxIcon.MouseMove += new MouseEventHandler(ToolboxIcon_MouseMove);

            menuItemCPU.Checked = true;
        }

        public void ToolboxIcon_MouseMove(object sender, MouseEventArgs e) {
            toolboxIcon.Text = "EHWM," + this.GetMenuItemChecked() + " " + hardPerc.ToString() + "%";
        }

        private void MenuItemTitle_Click (object sender, EventArgs e) {
            mainForm.Visible = true;
            mainForm.MinimizeBox = false;
            mainForm.ShowInTaskbar = true;
            mainForm.WindowState = FormWindowState.Normal;
            mainForm.Show();
            mainForm.Activate();
            mainForm.TopMost = true;
            mainForm.Focus();
        }
        
        private void MenuItemQuit_Click(object sender, EventArgs e) {
            toolboxIcon.Visible = false;
            Application.Exit();
        }

        private void MenuItemCPU_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = true;
            menuItemMEM.Checked = false;
            menuItemGPU.Checked = false;
            menuItemDSK.Checked = false;
            
        }
        private void MenuItemMEM_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = false;
            menuItemMEM.Checked = true;
            menuItemGPU.Checked = false;
            menuItemDSK.Checked = false;
        }
        private void MenuItemGPU_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = false;
            menuItemMEM.Checked = false;
            menuItemGPU.Checked = true;
            menuItemDSK.Checked = false;
        }
        private void MenuItemDSK_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = false;
            menuItemMEM.Checked = false;
            menuItemGPU.Checked = false;
            menuItemDSK.Checked = true;
        }

        public string GetMenuItemChecked() {
            if (menuItemCPU.Checked) {
                return "CPU Speed";
            } else if (menuItemMEM.Checked) {
                return "Memory Used";
            } else if (menuItemGPU.Checked) {
                return "GPU Speed";
            } else if (menuItemDSK.Checked) {
                return "Disk Speed";
            } else {
                return "NUL";
            }
        }

        public void Update() {
            toolboxIcon.Text = Application.ProductName + "v." + Application.ProductVersion + " - " + GetMenuItemChecked();
            if (hardPerc < 100) {
                toolboxIcon.Icon = graphAnim[(int)Math.Floor(hardPerc/10.0)];
            } else {
                toolboxIcon.Icon = graphAnim[10];
            }
                
        }
    }
}
