using System;
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

        private int hardPerc;

        private Icon graph0;
        private Icon graph1;
        private Icon graph2;
        private Icon graph3;
        private Icon graph4;
        private Icon graph5;
        private Icon graph6;
        private Icon graph7;
        private Icon graph8;
        private Icon graph9;
        private Icon graph10;
        private NotifyIcon toolboxIcon;
        private ContextMenu toolboxMenu;
        private ContextMenu monitorMenu;
        private MenuItem menuItemTitle;
        private MenuItem menuItemSwitch;
        private MenuItem menuItemQuit;
        private MenuItem menuItemCPU;
        private MenuItem menuItemMEM;
        private MenuItem menuItemGPU;
        private MenuItem menuItemDSK;


        //get icons and menu set up NOTE: CHANGE ICON PROGRAMATICALLY (NO HARD CODE)
        public void setIcons() {
            //bind icons to .ico files
            graph0 = new Icon("graph0.ico");
            graph1 = new Icon("graph1.ico");
            graph2 = new Icon("graph2.ico");
            graph3 = new Icon("graph3.ico");
            graph4 = new Icon("graph4.ico");
            graph5 = new Icon("graph5.ico");
            graph6 = new Icon("graph6.ico");
            graph7 = new Icon("graph7.ico");
            graph8 = new Icon("graph8.ico");
            graph9 = new Icon("graph9.ico");
            graph10 = new Icon("graph10.ico");
        }

        public void setPerc(int perc) {
            hardPerc = perc;
        }

        public void setupMenu() {
            toolboxIcon.ContextMenu = toolboxMenu;
        }

        public void initMenuItems() {
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
            toolboxIcon.Icon = graph0;

            menuItemTitle.Text = "EHWM v." + Application.ProductVersion;
            menuItemSwitch.Text = "Switch";
            menuItemQuit.Text = "Quit EHWM";

            menuItemCPU.Text = "CPU";
            menuItemMEM.Text = "Memory";
            menuItemGPU.Text = "GPU";
            menuItemDSK.Text = "Disk";

            menuItemTitle.Click += new EventHandler(menuItemTitle_Click);
            menuItemQuit.Click += new EventHandler(menuItemQuit_Click);

            menuItemCPU.Click += new EventHandler(menuItemCPU_Click);
            menuItemMEM.Click += new EventHandler(menuItemMEM_Click);
            menuItemGPU.Click += new EventHandler(menuItemGPU_Click);
            menuItemDSK.Click += new EventHandler(menuItemDSK_Click);

            toolboxIcon.MouseMove += new MouseEventHandler(toolboxIcon_MouseMove);

            menuItemCPU.Checked = true;
        }

        public void toolboxIcon_MouseMove(object sender, MouseEventArgs e) {
            toolboxIcon.Text = "EHWM," + this.getMenuItemChecked() + " " + hardPerc.ToString() + "%";
        }

        private void menuItemTitle_Click (object sender, EventArgs e) {
            //OPEN GUI
        }

        private void menuItemQuit_Click(object sender, EventArgs e) {
            toolboxIcon.Visible = false;
            Application.Exit();
        }

        private void menuItemCPU_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = true;
            menuItemMEM.Checked = false;
            menuItemGPU.Checked = false;
            menuItemDSK.Checked = false;
            
        }
        private void menuItemMEM_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = false;
            menuItemMEM.Checked = true;
            menuItemGPU.Checked = false;
            menuItemDSK.Checked = false;
        }
        private void menuItemGPU_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = false;
            menuItemMEM.Checked = false;
            menuItemGPU.Checked = true;
            menuItemDSK.Checked = false;
        }
        private void menuItemDSK_Click(object sender, EventArgs e) {
            menuItemCPU.Checked = false;
            menuItemMEM.Checked = false;
            menuItemGPU.Checked = false;
            menuItemDSK.Checked = true;
        }

        public string getMenuItemChecked() {
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

        public void update() {
            toolboxIcon.Text = "EHWM v." + Application.ProductVersion + " - " + getMenuItemChecked();

            if (hardPerc <= 10 && hardPerc > 0) {
                toolboxIcon.Icon = graph0;
            } else if (hardPerc <= 20 && hardPerc > 10) {
                toolboxIcon.Icon = graph1;
            } else if (hardPerc <= 30 && hardPerc > 20) {
                toolboxIcon.Icon = graph2;
            } else if (hardPerc <= 40 && hardPerc > 30) {
                toolboxIcon.Icon = graph3;
            } else if (hardPerc <= 50 && hardPerc > 40) {
                toolboxIcon.Icon = graph4;
            } else if (hardPerc <= 60 && hardPerc > 50) {
                toolboxIcon.Icon = graph5;
            } else if (hardPerc <= 70 && hardPerc > 60) {
                toolboxIcon.Icon = graph6;
            } else if (hardPerc <= 80 && hardPerc > 70) {
                toolboxIcon.Icon = graph7;
            } else if (hardPerc <= 90 && hardPerc > 80) {
                toolboxIcon.Icon = graph8;
            } else if (hardPerc <= 100 && hardPerc > 90) {
                toolboxIcon.Icon = graph9;
            } else if (hardPerc == 100) {
                toolboxIcon.Icon = graph10;
            }
        }
    }
}
