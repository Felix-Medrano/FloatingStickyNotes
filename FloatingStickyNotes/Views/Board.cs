using FloatingStickyNotes.Core;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes
{
  public partial class Board : Form
  {
    public Board()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

      int x = workingArea.Right - this.Width;
      int y = workingArea.Bottom - this.Height;

      this.Location = new Point(x, y);
    }

    private void topBar_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Win32.ReleaseCapture();
        Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
    }
  }
}
