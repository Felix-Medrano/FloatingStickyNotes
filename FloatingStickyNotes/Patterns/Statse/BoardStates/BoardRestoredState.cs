using FloatingStickyNotes.Core;
using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.BoardStates
{
  public class BoardRestoredState : IState
  {
    private readonly Size _defaultSize = new Size(600, 400);
    private readonly Point _defaultPosition;

    public BoardRestoredState()
    {
      _defaultPosition = new Point(
          Screen.PrimaryScreen.WorkingArea.Width - _defaultSize.Width,
          Screen.PrimaryScreen.WorkingArea.Height - _defaultSize.Height
      );
    }

    public BoardRestoredState(Control control)
    {
      _defaultPosition = new Point(
          Screen.PrimaryScreen.WorkingArea.Width - _defaultSize.Width,
          Screen.PrimaryScreen.WorkingArea.Height - _defaultSize.Height
      );
      Action(control);
    }

    public void Action(Control control)
    {
      var form = control as Board;
      form.WindowState = FormWindowState.Normal;
      form.IsBoardShowned = true;
      form.Size = _defaultSize;
      form.Location = _defaultPosition;
      Win32.SetForegroundWindow(form.Handle);
      Console.WriteLine("Formulario restaurado a tamaño y posición predeterminados.");
    }
  }
}
