using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

namespace Bhajans
{
    class Utility
    {
        //Import the SetForeground API to activate it
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(int hWnd);

        //Import the SetForeground API to activate it
        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

        public int IsAppRunning(string pProcessName)
        {
            //Find the window
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(pProcessName);
            if (proc.Length > 1)
                for (int i = 0; i < proc.Length; i++)
                    if (proc[i].ProcessName.Equals(pProcessName) && !proc[i].Equals(System.Diagnostics.Process.GetCurrentProcess()))
                        return proc[i].MainWindowHandle.ToInt32();

            return 0;
        }

        public void ActivateApp(int hWnd)
        {
            if (hWnd > 0)
            {
                ShowWindowAsync(hWnd, 9 /* SW_RESTORE */);
                SetForegroundWindow(hWnd);
            }
        }

        public System.Diagnostics.Process[] GetAllApps()
        {
            return System.Diagnostics.Process.GetProcesses();
        }
    }
}
