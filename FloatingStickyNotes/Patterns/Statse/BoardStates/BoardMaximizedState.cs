using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.BoardStates
{
  public class BoardMaximizedState : IState
  {
    public void Action(Form form)
    {
      form.Bounds = Screen.FromControl(form).WorkingArea;
      form.Location = Point.Empty;
      form.BringToFront();
      Console.WriteLine("Formulario maximizado.");
    }
  }
}
