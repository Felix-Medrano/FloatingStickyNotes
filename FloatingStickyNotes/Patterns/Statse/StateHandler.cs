using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse
{
  public class StateHandler
  {
    private IState _currentState;

    public StateHandler(IState initialState)
    {
      _currentState = initialState;
    }

    public void SetState(IState newState)
    {
      _currentState = newState;
    }

    public void ApplyState(Control control)
    {
      _currentState.Action(control);
    }
  }
}
