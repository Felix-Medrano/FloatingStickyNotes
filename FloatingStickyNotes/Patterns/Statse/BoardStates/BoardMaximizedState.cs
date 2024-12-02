using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.BoardStates
{
  public class BoardMaximizedState : IState
  {
    public void Action(Control control)
    {
      var form = control as Form;
      form.Bounds = Screen.FromControl(form).WorkingArea;
      form.Location = Point.Empty;
      Console.WriteLine("Formulario maximizado.");
    }
  }
}
