using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EHWM {
        public class HardwareInfoHandler {

        private Form mainForm;


        /*CREATES PERFORMANCE COUNTER OBJECTS*/

        private PerformanceCounter CPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private PerformanceCounter MEM = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        private PerformanceCounter GPU = new PerformanceCounter("GPU Engine", "Utilization Percentage", "pid_1200_luid_0x00000000_0x0000CA65_phys_0_eng_0_engtype_3D");

        private PerformanceCounter DSK = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");


        private enum eMonitor { eCPU, eMEM, eGPU, eDSK };
        private eMonitor monitor = eMonitor.eCPU;

        public IconHandler iconHandler;

        public HardwareInfoHandler(Form form) {
            mainForm = form;
            iconHandler = new IconHandler(form);
            iconHandler.setIcons();
            iconHandler.initMenuItems();
            iconHandler.setupMenu();
        }

        public void updateMonitor() {
            if (iconHandler.getMenuItemChecked() == "CPU Speed") {
                monitor = eMonitor.eCPU;
            }
            if (iconHandler.getMenuItemChecked() == "Memory Used") {
                monitor = eMonitor.eMEM;
            }
            if (iconHandler.getMenuItemChecked() == "GPU Speed") {
                monitor = eMonitor.eGPU;
            }
            if (iconHandler.getMenuItemChecked() == "Disk Speed") {
                monitor = eMonitor.eDSK;
            }
        }

        public void getPerc() {
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

        public void update() {
            iconHandler.update();
            this.updateMonitor();
        }
    }
}
