using FloatingStickyNotes.Controls;
using FloatingStickyNotes.Core;
using FloatingStickyNotes.Patterns.Command.Interfaces;
using FloatingStickyNotes.Patterns.Statse.BoardStates;
using FloatingStickyNotes.Properties;

using System;

namespace FloatingStickyNotes.Patterns.Command.Commands.BoardCommands
{
  public class BoardMaximizeCommand : ICommand
  {
    private Board _board;
    private readonly FSNButton _button;

    public BoardMaximizeCommand(Board board, FSNButton button)
    {
      _board = board;
      _button = button;
    }

    public void Execute()
    {
      Win32.SendMessage(_board.Handle, Win32.WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

      if (_board.IsBoardMaximized)
      {
        Helper.BoardStateHandler.SetState(new BoardRestoredState());
        _board.IsBoardMaximized = false;
        _button.Image = Resources.Maximizar;
      }
      else
      {
        Helper.BoardStateHandler.SetState(new BoardMaximizedState());
        _board.IsBoardMaximized = true;
        _button.Image = Resources.Minimizar;
      }

      Helper.BoardStateHandler.ApplyState(_board);
      Win32.SendMessage(_board.Handle, Win32.WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
      _board.ConfigPanel.Height = _board.Height - _board.TopBar.Height;
      _board.Invalidate();
      _board.ConfigPanel.Refresh();
    }
  }
}
