using FloatingStickyNotes.Core;

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FloatingStickyNotes
{
  internal static class Program
  {
    /// <summary>
    /// Punto de entrada principal para la aplicación.
    /// </summary>
    [STAThread]
    static void Main()
    {
      var currentProcess = Process.GetCurrentProcess();
      var existingProcess = Process.GetProcessesByName(currentProcess.ProcessName)
                                         .FirstOrDefault(p => p.Id != currentProcess.Id);
      if (existingProcess != null)
      {
        IntPtr handle = existingProcess.MainWindowHandle;
        if (handle != IntPtr.Zero)
        {
          Win32.SwitchToThisWindow(handle);
        }
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Board());
    }
  }
}
