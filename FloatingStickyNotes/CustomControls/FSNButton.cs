using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes.CustomControls
{
  public class FSNButton : Button
  {
    private bool isPressed = false;
    private Point originalLocation;
    private Padding imagePadding;
    private Image imageToDraw;

    public Padding ImagePadding
    {
      get { return imagePadding; }
      set
      {
        imagePadding = value;
        Invalidate(); // Redraw the control when padding changes
      }
    }

    public Image ImageToDraw
    {
      get { return imageToDraw; }
      set
      {
        imageToDraw = value;
        Invalidate(); // Redraw the control when the image changes
      }
    }

    public FSNButton()
    {
      FlatStyle = FlatStyle.Flat;
      FlatAppearance.BorderSize = 0;
      Text = "";
      BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
      base.OnPaint(pevent);
      if (imageToDraw != null)
      {
        Rectangle imageRect = new Rectangle(
                imagePadding.Left,
                imagePadding.Top,
                ClientRectangle.Width - imagePadding.Horizontal,
                ClientRectangle.Height - imagePadding.Vertical
            );

        // Desplazar la imagen si el botón está presionado
        if (isPressed)
        {
          imageRect.Offset(1, 1);
        }

        pevent.Graphics.DrawImage(imageToDraw, imageRect);
      }
      if (isPressed)
      {
        using (Pen pen = new Pen(Color.Gray, 2))
        {
          pevent.Graphics.DrawLine(pen, 0, 0, Width, 0); // Top border
          pevent.Graphics.DrawLine(pen, 0, 0, 0, Height); // Left border
        }
      }
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
      if (mevent.Button == MouseButtons.Left)
      {
        isPressed = true;
        Invalidate();
      }
      base.OnMouseDown(mevent);
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
      if (mevent.Button == MouseButtons.Left)
      {
        ResetButtonState();
      }
      base.OnMouseUp(mevent);
    }

    protected override void OnMouseEnter(EventArgs eventargs)
    {
      BackColor = Color.FromArgb(20, Color.Gray);
      base.OnMouseEnter(eventargs);
    }

    protected override void OnMouseLeave(EventArgs eventargs)
    {
      if (!ClientRectangle.Contains(PointToClient(Control.MousePosition)))
      {
        ResetButtonState();
      }
      base.OnMouseLeave(eventargs);
    }

    private void ResetButtonState()
    {
      isPressed = false;
      BackColor = Color.Transparent;
      Invalidate();
    }
  }
}