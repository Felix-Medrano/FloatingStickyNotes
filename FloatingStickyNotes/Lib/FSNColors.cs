using System.Drawing;

namespace FloatingStickyNotes.Lib
{
  public class FSNColors
  {
    /// <summary>
    /// Clase interna para colores de notas
    /// </summary>
    public class NoteColors
    {
      public Color Yellow { get; } = ColorTranslator.FromHtml("#FFFF99");
      public Color Blue { get; } = ColorTranslator.FromHtml("#99CCFF");
      public Color Orange { get; } = ColorTranslator.FromHtml("#FFCC99");
      public Color Green { get; } = ColorTranslator.FromHtml("#CCFF99");
      public Color Pink { get; } = ColorTranslator.FromHtml("#FFCCCC");
      public Color Purple { get; } = ColorTranslator.FromHtml("#CC99FF");
      public Color White { get; } = ColorTranslator.FromHtml("#FFFFFF");
      public Color Gray { get; } = ColorTranslator.FromHtml("#CCCCCC");
    }

    // Instancias de los colores de notas y temas
    public NoteColors Notes { get; } = new NoteColors();
  }
}
