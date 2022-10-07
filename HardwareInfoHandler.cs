using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EHWM {
        public class HardwareInfoHandler {

        /*CREATES PERFORMANCE COUNTER OBJECTS*/

        private PerformanceCounter CPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private PerformanceCounter MEM = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        private PerformanceCounter GPU = new PerformanceCounter("GPU Engine", "Utilization Percentage");

        private PerformanceCounter DSK = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");


        private enum EMonitor { eCPU, eMEM, eGPU, eDSK };
        private EMonitor monitor = EMonitor.eCPU;

        public IconHandler iconHandler;

        public HardwareInfoHandler(Form form) {
            iconHandler = new IconHandler(form);
            iconHandler.SetIcons();
            iconHandler.InitMenuItems();
            iconHandler.SetupMenu();
        }

        public void UpdateMonitor() {
            if (iconHandler.GetMenuItemChecked() == "CPU Usage") {
                monitor = EMonitor.eCPU;
            }
            if (iconHandler.GetMenuItemChecked() == "Memory Used") {
                monitor = EMonitor.eMEM;
            }
            if (iconHandler.GetMenuItemChecked() == "GPU Usage") {
                monitor = EMonitor.eGPU;
            }
            if (iconHandler.GetMenuItemChecked() == "Disk Speed") {
                monitor = EMonitor.eDSK;
            }
        }

        public void GetPerc() {
            if (monitor == EMonitor.eCPU) {
                iconHandler.SetPerc((int)CPU.NextValue());
            }
            if (monitor == EMonitor.eMEM) {
                iconHandler.SetPerc((int)MEM.NextValue());
            }
            if (monitor == EMonitor.eGPU) {
                iconHandler.SetPerc((int)GPU.NextValue());
            }
            if (monitor == EMonitor.eDSK) {
                iconHandler.SetPerc((int)DSK.NextValue());
            }
        }

        public void Update() {
            iconHandler.Update();
            this.UpdateMonitor();
        }
    }
}
