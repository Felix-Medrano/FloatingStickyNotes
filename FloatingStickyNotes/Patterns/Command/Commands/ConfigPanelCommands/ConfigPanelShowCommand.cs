using FloatingStickyNotes.Controls;
using FloatingStickyNotes.Core;
using FloatingStickyNotes.Patterns.Command.Interfaces;
using FloatingStickyNotes.Patterns.Statse.ConfigPanel;
using FloatingStickyNotes.Properties;

using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Command.Commands.ConfigPanelCommands
{
  public class ConfigPanelShowCommand : ICommand
  {
    private readonly Panel _panel;
    private readonly FSNButton _btn;

    public ConfigPanelShowCommand(Panel panel, FSNButton btn)
    {
      _panel = panel;
      _btn = btn;
    }

    public void Execute()
    {
      Helper.BoardStateHandler.SetState(new ConfigPanelShowState());
      Helper.BoardStateHandler.ApplyState(_panel);
      _btn.Image = Resources.PanelMenuClose;
    }
  }
}
