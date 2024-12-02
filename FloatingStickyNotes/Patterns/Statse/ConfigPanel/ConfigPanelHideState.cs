using FloatingStickyNotes.Patterns.Statse.Interfaces;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingStickyNotes.Patterns.Statse.ConfigPanel
{
  internal class ConfigPanelHideState : IState
  {
    public async void Action(Control control)
    {
      var configPanel = control as Panel;
      Board parent = configPanel.Parent as Board;
      int step = 5;

      while (configPanel.Width > 0)
      {
        configPanel.Width -= step;
        await Task.Delay(5); // Adjust delay for smoother or faster animation
      }
      parent.IsConfigPanelOpen = false;
      parent.IsTransitioning = false;

      configPanel.Width = 0;

      configPanel.Visible = false;
    }
  }
}
