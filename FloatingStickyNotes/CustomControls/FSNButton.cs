
using FloatingStickyNotes.Core;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FloatingStickyNotes.Controls
{
  public class FSNButton : Control
  {
    public new event EventHandler Click;

    private Image _image;
    private Padding _imagePadding = new Padding(0);
    private Color _hoverColor = Color.FromArgb(200, 116, 116, 116);

    private string _text = string.Empty;
    private Font _font = new Font("Arial", 10);
    private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;

    private bool isPressed = false;
    private bool isHovered = false;

    public Image Image
    {
      get { return _image; }
      set
      {
        _image = value;
        Invalidate();
      }
    }

    [Category("Appearance")]
    [Description("Gets or sets the padding for the image inside the button.")]
    public Padding ImagePadding
    {
      get { return _imagePadding; }
      set
      {
        _imagePadding = value;
        Invalidate();
      }
    }

    [Category("Appearance")]
    [Description("Gets or sets the hover color of the button.")]
    public Color HoverColor
    {
      get { return _hoverColor; }
      set
      {
        _hoverColor = value;
        Invalidate();
      }
    }

    [Category("Appearance")]
    [Description("Gets or sets the text displayed on the button.")]
    public override string Text
    {
      get { return _text; }
      set
      {
        _text = value;
        Invalidate();
      }
    }

    [Category("Appearance")]
    [Description("Gets or sets the font of the text displayed on the button.")]
    public override Font Font
    {
      get { return _font; }
      set
      {
        _font = value;
        Invalidate();
      }
    }

    [Category("Appearance")]
    [Description("Gets or sets the alignment of the text on the button.")]
    public ContentAlignment TextAlign
    {
      get { return _textAlign; }
      set
      {
        _textAlign = value;
        Invalidate();
      }
    }

    public FSNButton()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.UserPaint, true);
      Size = new Size(32, 32);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      Graphics g = e.Graphics;
      g.SmoothingMode = SmoothingMode.AntiAlias;

      Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

      this.BackColor = Parent.BackColor;

      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddRoundedRectangle(rect, 5);

        Color backgroundColor = isHovered ? HoverColor : Color.FromArgb(0, 224, 224, 224);
        using (SolidBrush brush = new SolidBrush(backgroundColor))
        {
          g.FillPath(brush, path);
        }

        if (isPressed)
        {
          rect.Offset(1, 1);
          //using (Pen shadowPen = new Pen(Color.FromArgb(100, 105, 105, 105), 2))
          //{
          //  g.DrawRectangle(shadowPen, rect);
          //}
        }

        if (Image != null)
        {
          // Apply padding to the image
          Rectangle imageRect = new Rectangle(
                    rect.Left + ImagePadding.Left,
                    rect.Top + ImagePadding.Top,
                    rect.Width - ImagePadding.Horizontal,
                    rect.Height - ImagePadding.Vertical
                );
          g.DrawImage(Image, imageRect);
        }

        if (!string.IsNullOrEmpty(Text))
        {
          TextRenderer.DrawText(g, Text, Font, rect, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      isPressed = true;
      Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      isPressed = false;
      Invalidate();

      // Trigger the Click event
      if (ClientRectangle.Contains(e.Location))
      {
        OnClick(EventArgs.Empty);
      }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);
      isHovered = true;
      Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      isHovered = false;
      Invalidate();
    }

    // Protected method to trigger the Click event
    new protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);

    public void ResetState()
    {
      isPressed = false;
      isHovered = false;
      Invalidate();
    }
  }
}