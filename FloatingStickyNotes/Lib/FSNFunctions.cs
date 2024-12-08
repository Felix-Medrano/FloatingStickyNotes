using FloatingStickyNotes.Core;

using System.Drawing;

namespace FloatingStickyNotes.Lib
{
  public class FSNFunctions
  {
    public int GetIconIndex(Image icon)
    {
      for (int i = 0; i < Helper.FSNConsts.NOTE_ICONS.Count; i++)
      {
        if (Helper.FSNConsts.NOTE_ICONS[i] == icon)
        {
          return i;
        }
      }
      return -1;
    }

  }
}
