using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.BoardStates
{
  public class BoardHideState : IState
  {
    public void Action(Form form)
    {
      form.WindowState = FormWindowState.Minimized;
      form.Hide();
      Console.WriteLine("Formulario escondido.");
    }
  }
}
