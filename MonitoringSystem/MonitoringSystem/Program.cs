using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringSystem
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ChartDirector.Chart.setLicenseCode("DEVP-2M4Y-J2K9-HZ5F-75E7-197C");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormEnterIP());
            Application.Run(new FormMain());
        }
    }
}
