using FloatingStickyNotes.Core;
using FloatingStickyNotes.CustomControls;
using FloatingStickyNotes.Patterns.Statse.BoardStates;
using FloatingStickyNotes.Properties;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes
{
  public partial class Board : Form
  {
    private Rectangle primaryScreen = Screen.PrimaryScreen.WorkingArea;
    private bool isMaximized = false;

    public Board()
    {
      InitializeComponent();
      this.DoubleBuffered = true;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      Helper.BoardStateHandler.ApplyState(this);

      topBar.BackColor = Color.FromArgb(180, Color.Gray);
    }

    private void topBar_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (!isMaximized)
        {
          Win32.ReleaseCapture();
          Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
        }
      }
    }

    private void fsnButton1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void maximizeBtn_Click(object sender, EventArgs e)
    {
      var btn = sender as FSNButton;

      Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

      if (isMaximized)
      {
        Helper.BoardStateHandler.SetState(new BoardRestoredState());
        isMaximized = false;
        btn.ImageToDraw = Resources.Maximizar;
      }
      else
      {
        Helper.BoardStateHandler.SetState(new BoardMaximizedState());
        isMaximized = true;
        btn.ImageToDraw = Resources.Minimizar;
      }

      Helper.BoardStateHandler.ApplyState(this);
      Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
      Invalidate();

      //closeBtn
      //maximizeBtn
      int space = 5;
      closeBtn.Left = this.Width - (closeBtn.Width + space);
      maximizeBtn.Left = closeBtn.Left - (maximizeBtn.Width + space);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

      if (isMaximized)
      {
        Helper.BoardStateHandler.SetState(new BoardRestoredState());
        isMaximized = false;
        maximizeBtn.ImageToDraw = Resources.Maximizar;
      }
      else
      {
        Helper.BoardStateHandler.SetState(new BoardMaximizedState());
        isMaximized = true;
        maximizeBtn.ImageToDraw = Resources.Minimizar;
      }

      Helper.BoardStateHandler.ApplyState(this);
      Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
      Invalidate();

      //closeBtn
      //maximizeBtn
      int space = 5;
      closeBtn.Left = this.Width - (closeBtn.Width + space);
      maximizeBtn.Left = closeBtn.Left - (maximizeBtn.Width + space);
    }
  }
}
