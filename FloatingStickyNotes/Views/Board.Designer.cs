namespace FloatingStickyNotes
{
  partial class Board
  {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
      this.topBar = new System.Windows.Forms.Panel();
      this.configPanel = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mostrarTableroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.menuBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.winBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.closeBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.topBar.SuspendLayout();
      this.configPanel.SuspendLayout();
      this.notifyIconMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // topBar
      // 
      this.topBar.BackColor = System.Drawing.Color.Gray;
      this.topBar.Controls.Add(this.menuBtn);
      this.topBar.Controls.Add(this.winBtn);
      this.topBar.Controls.Add(this.closeBtn);
      this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.topBar.Location = new System.Drawing.Point(0, 0);
      this.topBar.Name = "topBar";
      this.topBar.Size = new System.Drawing.Size(600, 30);
      this.topBar.TabIndex = 0;
      this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
      // 
      // configPanel
      // 
      this.configPanel.Controls.Add(this.button1);
      this.configPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.configPanel.Location = new System.Drawing.Point(0, 30);
      this.configPanel.Name = "configPanel";
      this.configPanel.Size = new System.Drawing.Size(100, 370);
      this.configPanel.TabIndex = 1;
      this.configPanel.Visible = false;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(22, 16);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.notifyIcon1.BalloonTipText = "Crea notas flotantes";
      this.notifyIcon1.BalloonTipTitle = "Float Sticky Notes";
      this.notifyIcon1.ContextMenuStrip = this.notifyIconMenu;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "Float Sticky Notes";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // notifyIconMenu
      // 
      this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarTableroToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
      this.notifyIconMenu.Name = "notifyIconMenu";
      this.notifyIconMenu.Size = new System.Drawing.Size(157, 54);
      // 
      // mostrarTableroToolStripMenuItem
      // 
      this.mostrarTableroToolStripMenuItem.Name = "mostrarTableroToolStripMenuItem";
      this.mostrarTableroToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.mostrarTableroToolStripMenuItem.Text = "Mostrar Tablero";
      this.mostrarTableroToolStripMenuItem.Click += new System.EventHandler(this.mostrarTableroToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
      // 
      // salirToolStripMenuItem
      // 
      this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
      this.salirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.salirToolStripMenuItem.Text = "Salir";
      this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
      // 
      // addBtn
      // 
      this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.addBtn.BackColor = System.Drawing.SystemColors.Control;
      this.addBtn.BackgroundImage = global::FloatingStickyNotes.Properties.Resources.BoardBackgroundCenter;
      this.addBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.addBtn.Image = global::FloatingStickyNotes.Properties.Resources.agregar;
      this.addBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.addBtn.Location = new System.Drawing.Point(536, 340);
      this.addBtn.Name = "addBtn";
      this.addBtn.Size = new System.Drawing.Size(48, 48);
      this.addBtn.TabIndex = 2;
      this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
      // 
      // menuBtn
      // 
      this.menuBtn.BackColor = System.Drawing.Color.Gray;
      this.menuBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.menuBtn.Image = global::FloatingStickyNotes.Properties.Resources.PanelMenuOpen;
      this.menuBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.menuBtn.Location = new System.Drawing.Point(8, 2);
      this.menuBtn.Name = "menuBtn";
      this.menuBtn.Size = new System.Drawing.Size(26, 26);
      this.menuBtn.TabIndex = 3;
      this.menuBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
      // 
      // winBtn
      // 
      this.winBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.winBtn.BackColor = System.Drawing.Color.Gray;
      this.winBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.winBtn.Image = global::FloatingStickyNotes.Properties.Resources.Maximizar;
      this.winBtn.ImagePadding = new System.Windows.Forms.Padding(3);
      this.winBtn.Location = new System.Drawing.Point(536, 2);
      this.winBtn.Name = "winBtn";
      this.winBtn.Size = new System.Drawing.Size(26, 26);
      this.winBtn.TabIndex = 2;
      this.winBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.winBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
      // 
      // closeBtn
      // 
      this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.closeBtn.BackColor = System.Drawing.Color.Gray;
      this.closeBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.closeBtn.Image = global::FloatingStickyNotes.Properties.Resources.Cerrar;
      this.closeBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.closeBtn.Location = new System.Drawing.Point(566, 2);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(26, 26);
      this.closeBtn.TabIndex = 1;
      this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
      // 
      // Board
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.ClientSize = new System.Drawing.Size(600, 400);
      this.Controls.Add(this.addBtn);
      this.Controls.Add(this.configPanel);
      this.Controls.Add(this.topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Board";
      this.ShowInTaskbar = false;
      this.Text = "Form1";
      this.TopMost = true;
      this.topBar.ResumeLayout(false);
      this.configPanel.ResumeLayout(false);
      this.notifyIconMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel topBar;
    private Controls.FSNButton winBtn;
    private Controls.FSNButton closeBtn;
    private Controls.FSNButton menuBtn;
    private System.Windows.Forms.Panel configPanel;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
    private System.Windows.Forms.ToolStripMenuItem mostrarTableroToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    private Controls.FSNButton addBtn;
  }
}

