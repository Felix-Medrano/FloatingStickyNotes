using FloatingStickyNotes.Lib;
using FloatingStickyNotes.Patterns.Statse;
using FloatingStickyNotes.Patterns.Statse.BoardStates;

namespace FloatingStickyNotes.Core
{
  public static class Helper
  {
    public static FSNConsts FSNConsts = new FSNConsts();
    public static FSNColors FSNColors = new FSNColors();
    public static FSNFunctions FSNFunctions = new FSNFunctions();
    public static StateHandler BoardStateHandler = new StateHandler(new BoardHideState());
  }
}
