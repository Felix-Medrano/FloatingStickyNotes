using FloatingStickyNotes.Core;
using FloatingStickyNotes.Lib;
using FloatingStickyNotes.Patterns.Command.Interfaces;
using FloatingStickyNotes.Patterns.Statse.Interfaces;
using FloatingStickyNotes.Patterns.Statse.NoteState;
using FloatingStickyNotes.Views.Props;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FloatingStickyNotes.Views
{
  public partial class Note : Form
  {
    //Clase Auxiliar
    private class AuxNoteState
    {
      public IState edit = new NoteEditState();
      public IState read = new NoteReadState();
    }

    private IState noteState;
    private AuxNoteState state = new AuxNoteState();
    private UnsaveNote unsaveNote;

    private Stack<ICommand> commandEscStack = new Stack<ICommand>();
    private Timer clickDelay = new Timer();
    private Point lastLocation;
    private Point lastNoteLocation;
    private bool isMenuOpen = false;
    private bool isMaximized = true;
    private bool isMouseDown = false;
    private bool hasMoved = false;

    private const int MovementThreshold = 5;
    private const int MinimumTextBoxHeight = 30;
    private const int MaximumTextBoxHeight = 300;

    public Note()
    {
      InitializeComponent();
    }

    public Note(IState state)
    {
      InitializeComponent();

      if (state is NoteEditState)
      {
        noteState = this.state.edit;
      }
      else if (state is NoteReadState)
      {
        noteState = this.state.read;
      }
      else
      {
        // Manejar el caso en que el estado inicial no sea reconocido
        throw new ArgumentException("Estado inicial no reconocido", nameof(state));
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Escape:
          if (unsaveNote != null)
            if (unsaveNote.Icon != this.iconBtn.Image ||
                unsaveNote.Color != this.BackColor ||
                unsaveNote.NoteText != this.noteText.Text)
            {
              iconBtn.Image = unsaveNote.Icon;
              noteText.Text = unsaveNote.NoteText;
              noteText.BackColor =
              this.BackColor = unsaveNote.Color;

              unsaveNote = null;
              UpdateControlsState();
              Invalidate();
            }
          break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      noteText.BackColor = this.BackColor = Helper.FSNColors.Notes.Yellow;
      iconBtn.Image = Helper.FSNConsts.NOTE_ICONS[0];

      noteText.BackColor = this.BackColor = new FSNColors.NoteColors().Yellow;
      noteText.GotFocus += noteText_GotFocus;

      unsaveNote = new UnsaveNote(
        iconBtn.Image,
        BackColor,
        noteText.Text);

      UpdateControlsState();
    }

    private void noteText_GotFocus(object sender, EventArgs e)
    {
      noteText.SelectionStart = noteText.TextLength;
      noteText.ScrollToCaret();
    }

    private void UpdateControlsState()
    {
      bool isEditMode = noteState == state.edit;
      colorSelectBtn.Visible = isEditMode;
      saveBtn.Visible = isEditMode;
      noteText.ReadOnly = !isEditMode;
      ReorganizeControls();
    }

    private void ReorganizeControls()
    {
      int spacing = 2;
      int nextLocationY = 2;
      this.Width = 0;

      foreach (Control control in this.Controls)
      {
        if (control.Visible)
        {
          this.Width += control.Width + spacing;
          control.Left = nextLocationY;
          control.Top = 2;
          nextLocationY = control.Right + spacing;
        }
      }
    }

    private void noteText_Click(object sender, EventArgs e)
    {
      if (unsaveNote == null)
        unsaveNote = new UnsaveNote(
        iconBtn.Image,
        BackColor,
        noteText.Text);

      if (noteState == state.read)
      {
        noteText.ReadOnly = false;
        noteText.Focus();
        noteText.SelectionStart = noteText.TextLength;
        noteText.ScrollToCaret();
        noteState = state.edit;
        UpdateControlsState();
        MaximizeRightPosition();
      }
    }

    private void colorSelectBtn_Click(object sender, EventArgs e)
    {
      var colorSelector = new ColorPaletteSelector()
      {
        InitialColor = this.BackColor
      };
      colorSelector.ColorSelected += ColorPaletteSelector_ColorSelected;
      Point location = new Point(this.Left + colorSelectBtn.Right, this.Top + colorSelectBtn.Bottom);
      colorSelector.AdjustPosition(location);
    }

    private void ColorPaletteSelector_ColorSelected(object sender, Color e)
    {
      this.BackColor = noteText.BackColor = e;
      Refresh();
    }

    private void iconBtn_Click(object sender, EventArgs e)
    {
      if (noteState == state.edit)
      {
        ShowIconSelector();
      }
      else if (noteState == state.read)
      {
        ToggleMaximizeState();
      }
    }

    private void IconSelector_IconSelected(object sender, Image e)
    {
      iconBtn.Image = e;
      Refresh();
    }

    private void MaximizeRightPosition()
    {
      Screen currentScreen = Screen.FromControl(this);
      Rectangle workingArea = currentScreen.WorkingArea;
      if (this.Right > workingArea.Right)
      {
        this.Left = workingArea.Right - this.Width;
      }
    }

    private void ShowIconSelector()
    {
      var iconSelector = new IconSelector
      {
        InitialIconIndex = Helper.FSNFunctions.GetIconIndex(iconBtn.Image) // Set the initial icon index
      };

      iconSelector.IconSelected += IconSelector_IconSelected;
      Point location = new Point(this.Left + iconBtn.Left, this.Top + iconBtn.Bottom);
      iconSelector.AdjustPosition(location);
    }

    private void ToggleMaximizeState()
    {
      Screen currentScreen = Screen.FromControl(this);
      Rectangle workingArea = currentScreen.WorkingArea;

      if (isMaximized)
      {
        lastNoteLocation = this.Location;
        this.Size = Helper.FSNConsts.MINIMIZED_NOTE;
        isMaximized = false;
        SnapToEdge(workingArea);
      }
      else
      {
        UpdateControlsState();
        this.Height = noteText.Height + 4;
        isMaximized = true;
        this.Location = new Point(lastNoteLocation.X, Top);
      }
    }

    private void SnapToEdge(Rectangle workingArea)
    {
      int centerX = this.Left + this.Width / 2;
      this.Left = centerX < workingArea.Left + workingArea.Width / 2
        ? workingArea.Left
        : workingArea.Right - this.Width;
    }

    private void noteText_ContentsResized(object sender, ContentsResizedEventArgs e)
    {
      AdjustRichTextBoxHeight(e.NewRectangle.Height);
    }

    private void AdjustRichTextBoxHeight(int contentHeight)
    {
      int newHeight = Math.Max(MinimumTextBoxHeight, Math.Min(contentHeight, MaximumTextBoxHeight));
      if (noteText.Height != newHeight)
      {
        noteText.Height = newHeight;
        this.Height = noteText.Bottom + 2;
      }
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      RemoveLastLineIfEmpty();
      noteText.ReadOnly = true;
      noteState = state.read;
      UpdateControlsState();
      this.ActiveControl = null;
      unsaveNote = null;
    }

    private void RemoveLastLineIfEmpty()
    {
      string[] lines = noteText.Lines;
      if (lines.Length > 0 && string.IsNullOrWhiteSpace(lines[lines.Length - 1]))
      {
        noteText.Lines = lines.Take(lines.Length - 1).ToArray();
      }
    }

    private void iconBtn_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        isMouseDown = true;
        lastLocation = e.Location;
        hasMoved = false;
      }
    }

    private void iconBtn_MouseUp(object sender, MouseEventArgs e)
    {
      isMouseDown = false;
      this.Cursor = Cursors.Default;

      if (!hasMoved)
      {
        iconBtn_Click(sender, e);
      }

      hasMoved = false;
    }

    private void iconBtn_MouseMove(object sender, MouseEventArgs e)
    {
      if (isMouseDown)
      {
        HandleMouseMove(e);
      }
    }

    private void HandleMouseMove(MouseEventArgs e)
    {
      int deltaX = e.X - lastLocation.X;
      int deltaY = e.Y - lastLocation.Y;

      // Define a movement threshold
      int movementThreshold = 1;

      if (Math.Abs(deltaX) > movementThreshold || Math.Abs(deltaY) > movementThreshold)
      {
        Screen currentScreen = Screen.FromControl(this);
        Rectangle workingArea = currentScreen.WorkingArea;

        if (isMaximized)
        {
          this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
        }
        else
        {
          MoveMinimizedNoteY(deltaY, workingArea);
          SnapToScreenEdge(currentScreen, workingArea);
        }

        hasMoved = true;
        this.Cursor = Cursors.SizeAll;
      }
    }

    private void MoveMinimizedNoteY(int deltaY, Rectangle workingArea)
    {
      int newY = this.Location.Y + deltaY;
      newY = Math.Max(workingArea.Top, Math.Min(newY, workingArea.Bottom - this.Height));
      this.Location = new Point(this.Location.X, newY);
    }

    private void SnapToScreenEdge(Screen currentScreen, Rectangle workingArea)
    {
      Screen newScreen = Screen.FromPoint(Cursor.Position);
      if (newScreen != currentScreen)
      {
        currentScreen = newScreen;
        workingArea = currentScreen.WorkingArea;
      }

      int cursorX = Cursor.Position.X;
      int distanceToLeft = Math.Abs(cursorX - workingArea.Left);
      int distanceToRight = Math.Abs(cursorX - workingArea.Right);

      this.Left = distanceToLeft < distanceToRight ? workingArea.Left : workingArea.Right - this.Width;
    }

    private void AdjustFormPosition()
    {
      Screen currentScreen = Screen.FromControl(this);
      Rectangle workingArea = currentScreen.WorkingArea;

      int x = Math.Max(workingArea.Left, Math.Min(this.Left, workingArea.Right - this.Width));
      int y = Math.Max(workingArea.Top, Math.Min(this.Top, workingArea.Bottom - this.Height));

      this.Location = new Point(x, y);
    }

    private void closeBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
