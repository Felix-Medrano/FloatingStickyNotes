using FloatingStickyNotes.Core;

using System.Drawing;

namespace FloatingStickyNotes.Models
{
  public class NoteModel
  {
    public int Id { get; set; }
    public int IconId { get; set; }
    public string Text { get; set; }
    public Color Color { get; set; }
    public Point Location { get; set; }
    public Point LastLocation { get; set; }
    public Size Size { get; set; }

    public override string ToString()
    {
      return this.PropertiesToString();
    }
  }
}
