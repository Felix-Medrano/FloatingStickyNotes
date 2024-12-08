using FloatingStickyNotes.Core;
using FloatingStickyNotes.Properties;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes.Views.Props
{
  public class IconSelector : Form
  {
    public event EventHandler<Image> IconSelected;

    private int iconSize = 32;
    private int spacing = 8;
    private int margin = 8;
    private int columns = 10;

    private int selectedIndex = -1;
    private int rows;

    public IconSelector()
    {
      UpdateSize();
      this.DoubleBuffered = true;
      this.ShowInTaskbar = false;
      this.FormBorderStyle = FormBorderStyle.None;
      this.StartPosition = FormStartPosition.Manual;
      this.BackgroundImage = Resources.BoardBackgroundCenter;
      this.Text = "Icon Selector";
      this.AutoSize = true;
      this.Visible = true;
    }

    public int Columns
    {
      get => columns;
      set
      {
        columns = value;
        UpdateSize();
        Invalidate();
      }
    }

    public int IconSize
    {
      get => iconSize;
      set
      {
        iconSize = value;
        UpdateSize();
        Invalidate();
      }
    }

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

    public int InitialIconIndex
    {
      set
      {
        selectedIndex = value;
        Invalidate();
      }
    }

    private void UpdateSize()
    {
      rows = (int)Math.Ceiling((double)Helper.FSNConsts.NOTE_ICONS.Count / columns);
      this.Width = margin * 2 + iconSize * columns + spacing * (columns - 1);
      this.Height = margin * 2 + iconSize * rows + spacing * (rows - 1);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      Graphics g = e.Graphics;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      for (int i = 0; i < Helper.FSNConsts.NOTE_ICONS.Count; i++)
      {
        int row = i / columns;
        int col = i % columns;

        int x = margin + col * (iconSize + spacing);
        int y = margin + row * (iconSize + spacing);

        Rectangle iconRect = new Rectangle(x, y, iconSize, iconSize);

        g.DrawImage(Helper.FSNConsts.NOTE_ICONS[i], iconRect);

        if (i == selectedIndex)
        {
          using (Pen pen = new Pen(Color.Blue, 2))
          {
            g.DrawRectangle(pen, iconRect);
          }
        }
      }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);

      int col = (e.X - margin) / (iconSize + spacing);
      int row = (e.Y - margin) / (iconSize + spacing);
      int index = row * columns + col;

      if (col >= 0 && col < columns && row >= 0 && row < rows &&
          index >= 0 && index < Helper.FSNConsts.NOTE_ICONS.Count)
      {
        selectedIndex = index;
        IconSelected?.Invoke(this, Helper.FSNConsts.NOTE_ICONS[index]);
        Invalidate();
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (e.Button == MouseButtons.Left)
      {
        int col = (e.X - margin) / (iconSize + spacing);
        int row = (e.Y - margin) / (iconSize + spacing);
        int index = row * columns + col;

        if (col >= 0 && col < columns && row >= 0 && row < rows &&
            index >= 0 && index < Helper.FSNConsts.NOTE_ICONS.Count)
        {
          DoDragDrop(Helper.FSNConsts.NOTE_ICONS[index], DragDropEffects.Copy);
        }
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
