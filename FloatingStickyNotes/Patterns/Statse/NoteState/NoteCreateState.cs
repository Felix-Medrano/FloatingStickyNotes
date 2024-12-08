using FloatingStickyNotes.Patterns.Statse.Interfaces;
using FloatingStickyNotes.Views;

using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.NoteState
{
  public class NoteCreateState : IState
  {
    private Board _board;

    public NoteCreateState(Board board)
    {
      _board = board;
    }

    public void Action(Control control)
    {
      Note note = new Note(new NoteEditState());
      note.Show();
    }
  }
}
