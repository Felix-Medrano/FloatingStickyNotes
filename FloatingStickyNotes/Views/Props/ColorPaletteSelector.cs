using FloatingStickyNotes.Lib;
using FloatingStickyNotes.Properties;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes.Views.Props
{
  public class ColorPaletteSelector : Form
  {
    public event EventHandler<Color> ColorSelected;

    private Color selectedColor;

    private FSNColors.NoteColors noteColors;

    private int colorSize = 40;
    private int spacing = 8;
    private int margin = 8;
    private int rows = 2;
    private int columns;

    public int Spacing
    {
      get => spacing;
      set
      {
        spacing = value;
        UpdateSize();
        Invalidate();
      }
    }

    public int ColorSize
    {
      get => colorSize;
      set
      {
        colorSize = value;
        UpdateSize();
        Invalidate();
      }
    }

    public new int Margin
    {
      get => margin;
      set
      {
        margin = value;
        UpdateSize();
        Invalidate();
      }
    }

    public Color InitialColor
    {
      get => selectedColor;
      set
      {
        selectedColor = value;
        Invalidate();
      }
    }

    public ColorPaletteSelector()
    {
      noteColors = new FSNColors().Notes;
      this.DoubleBuffered = true;
      this.ShowInTaskbar = false;
      this.FormBorderStyle = FormBorderStyle.None;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Color Selector";
      this.BackgroundImage = Resources.BoardBackgroundCenter;
      this.AutoSize = true;
      this.Visible = true;
      this.TopMost = true;
      UpdateSize();
    }

    private void UpdateSize()
    {
      var properties = typeof(FSNColors.NoteColors).GetProperties();
      columns = (int)Math.Ceiling((double)properties.Length / rows);

      int totalWidth = (colorSize + spacing) * columns - spacing + (margin * 2);
      int totalHeight = (colorSize + spacing) * rows - spacing + (margin * 2);
      this.Size = new Size(totalWidth, totalHeight);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics g = e.Graphics;

      var properties = typeof(FSNColors.NoteColors).GetProperties();
      columns = (int)Math.Ceiling((double)properties.Length / rows);

      for (int i = 0; i < properties.Length; i++)
      {
        Color color = (Color)properties[i].GetValue(noteColors);
        int row = i / columns;
        int col = i % columns;
        int x = margin + col * (colorSize + spacing);
        int y = margin + row * (colorSize + spacing);

        using (SolidBrush brush = new SolidBrush(color))
        {
          g.FillRectangle(brush, x, y, colorSize, colorSize);
        }

        if (color == selectedColor)
        {
          using (Pen pen = new Pen(Color.Black, 2))
          {
            g.DrawRectangle(pen, x, y, colorSize, colorSize);
          }
        }
      }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);

      int col = (e.X - margin) / (colorSize + spacing);
      int row = (e.Y - margin) / (colorSize + spacing);
      int index = row * 4 + col;

      if (col >= 0 && col < 4 && row >= 0 && row < 2 &&
          index >= 0 && index < typeof(FSNColors.NoteColors).GetProperties().Length)
      {
        var prop = typeof(FSNColors.NoteColors).GetProperties()[index];
        selectedColor = (Color)prop.GetValue(noteColors);
        ColorSelected?.Invoke(this, selectedColor);
        Invalidate();
      }
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);
      this.Dispose();
      this.Close();
    }

    public void AdjustPosition(Point location)
    {
      Rectangle screenBounds = Screen.FromPoint(this.Location).Bounds;


      if (this.Right > screenBounds.Right)
      {
        location.X = screenBounds.Right - this.Width;
      }
      else if (this.Left < screenBounds.Left)
      {
        location.X = screenBounds.Left;
      }

      if (this.Bottom > screenBounds.Bottom)
      {
        location.Y = screenBounds.Bottom - this.Height;
      }
      else if (this.Top < screenBounds.Top)
      {
        location.Y = screenBounds.Top;
      }

      this.Location = location;
    }
  }
}
