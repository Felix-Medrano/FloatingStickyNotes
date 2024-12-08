using FloatingStickyNotes.Controls;
using FloatingStickyNotes.Core;
using FloatingStickyNotes.Patterns.Command.Commands.BoardCommands;
using FloatingStickyNotes.Patterns.Command.Commands.ConfigPanelCommands;
using FloatingStickyNotes.Patterns.Command.Commands.NoteCommands;
using FloatingStickyNotes.Patterns.Command.Interfaces;
using FloatingStickyNotes.Views;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FloatingStickyNotes
{
  public partial class Board : Form
  {
    private Rectangle primaryScreen = Screen.PrimaryScreen.WorkingArea;
    private Stack<ICommand> commandEscStack = new Stack<ICommand>();
    private Dictionary<Guid, Note> notesDictionary= new Dictionary<Guid, Note>();
    private bool isBoardMaximized = false;
    private bool isBoardShowned = true;
    private bool isConfigPanelOpen = false;
    private bool isTransitioning = false;

    private ConfigPanelHideCommand configPanelHideCommand;
    private ConfigPanelShowCommand configPanelShowCommand;
    private BoardHideCommand boardHideCommand;
    private BoardMaximizeCommand boardMaximizeCommand;
    private NoteCereateCommand noteCereateCommand;

    public Panel TopBar { get { return topBar; } }
    public Panel ConfigPanel { get { return configPanel; } }

    public Stack<ICommand> CommandEscStack { get => commandEscStack; }
    public bool IsBoardMaximized { get => isBoardMaximized; set => isBoardMaximized = value; }
    public bool IsConfigPanelOpen { get => isConfigPanelOpen; set => isConfigPanelOpen = value; }
    public bool IsTransitioning { get => isTransitioning; set => isTransitioning = value; }
    public bool IsBoardShowned { get => isBoardShowned; set => isBoardShowned = value; }

    public Board()
    {
      InitializeComponent();
      this.DoubleBuffered = true;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      boardHideCommand = new BoardHideCommand(this);
      boardMaximizeCommand = new BoardMaximizeCommand(this, winBtn);

      configPanelHideCommand = new ConfigPanelHideCommand(configPanel, menuBtn);
      configPanelShowCommand = new ConfigPanelShowCommand(configPanel, menuBtn);
      noteCereateCommand = new NoteCereateCommand(this);

#if DEBUG
      commandEscStack.Push(new BoardHideCommand(this));
      isBoardMaximized = true;
      boardMaximizeCommand.Execute();
#else
      boardHideCommand.Execute();
#endif

      configPanel.Width = Helper.FSNConsts.CONFIG_PANEL_WIDTH;
      configPanel.Controls.Add(new ConfigPanel().GetPanel());
      configPanel.Height = this.Height - topBar.Height;

      configPanelHideCommand.Execute();

      topBar.BackColor = Color.FromArgb(180, Color.Gray);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.C: //Open ConfigPanel
          if (!isConfigPanelOpen)
          {
            configPanelShowCommand.Execute();
            commandEscStack.Push(configPanelHideCommand);
          }
          break;

#if DEBUG
        case (Keys.Control | Keys.C):
          this.Close();
          break;
#endif

        case Keys.Escape: //Ocultar panel(es)
          if (commandEscStack.Count > 0)
          {
            var command = commandEscStack.Pop();
            command.Execute();
          }
          break;

        case Keys.M: //Maximizar o Restaurar ventana
          boardMaximizeCommand.Execute();
          break;

        case Keys.N: //Crear nueva nota
          noteCereateCommand.Execute();
          break;

      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void topBar_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (!isBoardMaximized)
        {
          Win32.ReleaseCapture();
          Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
        }
      }
    }

    private void closeBtn_Click(object sender, EventArgs e)
    {
      isBoardMaximized = true; //Necesario para que se muestre desde notifyIcon
      commandEscStack.Clear();
      configPanelHideCommand.Execute();
      boardHideCommand.Execute();
    }

    private void maximizeBtn_Click(object sender, EventArgs e)
    {
      boardMaximizeCommand.Execute();
      addBtn.Refresh();
    }

    private void menuBtn_Click(object sender, EventArgs e)
    {
      var btn = sender as FSNButton;

      if (!isTransitioning)
      {
        if (isConfigPanelOpen)
        {
          configPanelHideCommand.Execute();
          commandEscStack.Pop();
        }
        else
        {
          configPanelShowCommand.Execute();
          commandEscStack.Push(configPanelHideCommand);
        }
      }

      Helper.BoardStateHandler.ApplyState(configPanel);
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      WindowStateCommand();
    }

    private void salirToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void mostrarTableroToolStripMenuItem_Click(object sender, EventArgs e)
    {
      WindowStateCommand();
    }

    private void WindowStateCommand()
    {
      if (!isBoardShowned)
      {
        this.Show();
        boardMaximizeCommand.Execute();
        commandEscStack.Push(new BoardHideCommand(this));
      }
    }

    private void addBtn_Click(object sender, EventArgs e)
    {
      noteCereateCommand.Execute();
    }
  }
}
