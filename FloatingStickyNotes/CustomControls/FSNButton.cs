
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

        Color backgroundColor = isHovered ? Color.FromArgb(200, 116, 116, 116) : Color.FromArgb(0, 224, 224, 224);
        using (SolidBrush brush = new SolidBrush(backgroundColor))
        {
          g.FillPath(brush, path);
        }

        if (isPressed)
        {
          rect.Offset(1, 1);
          using (Pen shadowPen = new Pen(Color.FromArgb(100, 105, 105, 105), 2))
          {
            g.DrawRectangle(shadowPen, rect);
          }
        }

        if (Image != null)
        {
          // Aplicar el padding a la imagen
          Rectangle imageRect = new Rectangle(
            rect.Left + ImagePadding.Left,
            rect.Top + ImagePadding.Top,
            rect.Width - ImagePadding.Horizontal,
            rect.Height - ImagePadding.Vertical
          );
          g.DrawImage(Image, imageRect);
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

      // Disparar el evento Click
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

    // Método protegido para disparar el evento Click
    new protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);

    public void ResetState()
    {
      isPressed = false;
      isHovered = false;
      Invalidate();
    }
  }
}