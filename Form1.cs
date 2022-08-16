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

        /*CREATES PERFORMANCE COUNTER OBJECTS*/

        PerformanceCounter CPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        PerformanceCounter MEM = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        PerformanceCounter GPU = new PerformanceCounter("GPU Engine", "Utilization Percentage", "pid_1200_luid_0x00000000_0x0000CA65_phys_0_eng_0_engtype_3D");

        PerformanceCounter DSK = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");

        enum eMonitor { eCPU, eMEM, eGPU, eDSK };
        private eMonitor monitor = eMonitor.eCPU;

        IconHandler iconHandler = new IconHandler();

        public EHWMForm() {
            InitializeComponent();
            iconHandler.initMenuItems();
        }

        public void updateMonitor() {
            if (iconHandler.getMenuItemChecked() == "CPU") {
                monitor = eMonitor.eCPU;
            }
            if (iconHandler.getMenuItemChecked() == "MEM") {
                monitor = eMonitor.eMEM;
            }
            if (iconHandler.getMenuItemChecked() == "GPU") {
                monitor = eMonitor.eGPU;
            }
            if (iconHandler.getMenuItemChecked() == "DSK") {
                monitor = eMonitor.eDSK;
            }
        }

        private void getPerc() {
            if (monitor == eMonitor.eCPU) {
                iconHandler.setPerc((int)CPU.NextValue());
            }
            if (monitor == eMonitor.eMEM) {
                iconHandler.setPerc((int)MEM.NextValue());
            }
            if (monitor == eMonitor.eGPU) {
                iconHandler.setPerc((int)GPU.NextValue());
            }
            if (monitor == eMonitor.eDSK) {
                iconHandler.setPerc((int)DSK.NextValue());
            }
        }

        private void Form_Load(object sender, EventArgs e) {
            iconHandler.setIcons();
            iconHandler.setupMenu();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            getPerc();
            iconHandler.update();
            updateMonitor();
        }
    }
}
