using System.Windows.Forms;

namespace FloatingStickyNotes.Views
{
  public partial class ConfigPanel : Form
  {
    public ConfigPanel()
    {
      InitializeComponent();
    }

    public Panel GetPanel()
    {
      return viewPanel;
    }
  }
}
