using System;
using System.Runtime.InteropServices;

namespace FloatingStickyNotes.Core
{
  public static class Win32
  {
    public const int HT_CAPTION = 0x2;
    public const int WM_NCLBUTTONDOWN = 0xA1;

    /// <summary>
    /// Muestra la ventana indicada
    /// </summary>
    /// <param name="hWnd">Window Handle</param>
    /// <param name="fUnknow"><see langword="true"/></param>
    [DllImport("user32.dll")]
    public static extern void SwitchToThisWindow(IntPtr hWnd);


    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
  }
}
