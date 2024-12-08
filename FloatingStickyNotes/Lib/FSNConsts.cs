using FloatingStickyNotes.Properties;

using System.Collections.Generic;
using System.Drawing;

namespace FloatingStickyNotes.Lib
{
  public class FSNConsts
  {
    //Board
    public readonly Size BOARD_NORMAL_SIZE = new Size(600,400);

    //ConfigPanel
    public readonly int CONFIG_PANEL_WIDTH = 100;

    //Note
    public readonly Size MINIMIZED_NOTE = new Size(36,36);

    public readonly List<Image> NOTE_ICONS = new List<Image>
    {
      Resources.Clip,
      Resources.Codigo,
      Resources.Contacto,
      Resources.Corazon,
      Resources.Correo,
      Resources.Favorito,
      Resources.Idea,
      Resources.Importante,
      Resources.Informacion,
      Resources.Mando,
      Resources.Musica,
      Resources.Reloj,
      Resources.Trabajo
    };
  }
}
