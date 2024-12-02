using FloatingStickyNotes.Core;
using FloatingStickyNotes.Patterns.Command.Interfaces;
using FloatingStickyNotes.Patterns.Statse.BoardStates;

namespace FloatingStickyNotes.Patterns.Command.Commands.BoardCommands
{
  internal class BoardHideCommand : ICommand
  {

    private Board _board;
    public BoardHideCommand(Board board)
    {
      _board = board;
    }

    public void Execute()
    {
      Helper.BoardStateHandler.SetState(new BoardRestoredState(_board));
      Helper.BoardStateHandler.SetState(new BoardHideState(_board));
    }
  }
}
