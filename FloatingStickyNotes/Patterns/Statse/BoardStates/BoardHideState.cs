using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.BoardStates
{
  public class BoardHideState : IState
  {
    public BoardHideState() { } //Clean Construct

    public BoardHideState(Control control) => Action(control);

    public void Action(Control control)
    {
      var form = control as Board;
      form.WindowState = FormWindowState.Minimized;
      form.IsBoardMaximized = true; //Don't Remove
      form.IsBoardShowned = false;
      form.Hide();
      Console.WriteLine("Formulario escondido.");
    }
  }
}
