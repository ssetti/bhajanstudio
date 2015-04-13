using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bhajans
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            //Find the window
            Utility utility = new Utility();
            int hWnd = utility.IsAppRunning("Bhajans");
            if (hWnd > 0)
            {
                utility.ActivateApp(hWnd);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
                BhajansForm.style = args[0];
            else
                BhajansForm.style = "Regular";
            Application.Run(new BhajansForm());
        }
    }
}
