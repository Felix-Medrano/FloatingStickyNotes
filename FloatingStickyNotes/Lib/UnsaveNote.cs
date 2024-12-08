using System.Drawing;

namespace FloatingStickyNotes.Lib
{
  public class UnsaveNote
  {
    private Image icon;
    private Color color;
    private string noteText;

    public Image Icon { get => icon; }
    public Color Color { get => color; }
    public string NoteText { get => noteText; }

    public UnsaveNote(Image icon, Color color, string noteText)
    {
      this.icon = icon;
      this.color = color;
      this.noteText = noteText;
    }
  }
}
