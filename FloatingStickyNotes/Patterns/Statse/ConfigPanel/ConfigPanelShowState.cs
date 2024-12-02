using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.ConfigPanel
{
  internal class ConfigPanelShowState : IState
  {
    public async void Action(Control control)
    {
      var configPanel = control as Panel;
      configPanel.Visible = true;
      Board parent = configPanel.Parent as Board;
      int targetWidth = 100;
      int step = 5;

      while (configPanel.Width < targetWidth)
      {
        configPanel.Width += step;
        await Task.Delay(5);
      }

      parent.IsConfigPanelOpen = true;
      parent.IsTransitioning = false;

      configPanel.Width = targetWidth;

    }
  }
}
