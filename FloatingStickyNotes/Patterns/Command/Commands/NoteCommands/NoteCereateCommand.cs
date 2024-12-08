using FloatingStickyNotes.Core;
using FloatingStickyNotes.Patterns.Command.Interfaces;
using FloatingStickyNotes.Patterns.Statse.NoteState;

namespace FloatingStickyNotes.Patterns.Command.Commands.NoteCommands
{
  public class NoteCereateCommand : ICommand
  {
    private readonly Board _board;

    public NoteCereateCommand(Board board)
    {
      _board = board;
    }

    public void Execute()
    {
      Helper.BoardStateHandler.SetState(new NoteCreateState(_board));
      Helper.BoardStateHandler.ApplyState(_board);
    }
  }
}
