using System;
using System.Runtime.InteropServices;

namespace FloatingStickyNotes.Core
{
  public static class Win32
  {
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Muestra la ventana indicada
    /// </summary>
    /// <param name="hWnd">Window Handle</param>
    /// <param name="fUnknow"><see langword="true"/></param>
    [DllImport("user32.dll")]
    public static extern void SwitchToThisWindow(IntPtr hWnd);
  }
}
