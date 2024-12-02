using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.Interfaces
{
  public interface IState
  {
    void Action(Control control);
  }
}
