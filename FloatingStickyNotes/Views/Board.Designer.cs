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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
      this.topBar = new System.Windows.Forms.Panel();
      this.maximizeBtn = new FloatingStickyNotes.CustomControls.FSNButton();
      this.closeBtn = new FloatingStickyNotes.CustomControls.FSNButton();
      this.menuButton = new FloatingStickyNotes.CustomControls.FSNButton();
      this.topBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // topBar
      // 
      this.topBar.BackColor = System.Drawing.Color.Gray;
      this.topBar.Controls.Add(this.maximizeBtn);
      this.topBar.Controls.Add(this.closeBtn);
      this.topBar.Controls.Add(this.menuButton);
      this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.topBar.Location = new System.Drawing.Point(0, 0);
      this.topBar.Name = "topBar";
      this.topBar.Size = new System.Drawing.Size(600, 30);
      this.topBar.TabIndex = 0;
      this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
      // 
      // maximizeBtn
      // 
      this.maximizeBtn.BackColor = System.Drawing.Color.Transparent;
      this.maximizeBtn.FlatAppearance.BorderSize = 0;
      this.maximizeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.maximizeBtn.ImagePadding = new System.Windows.Forms.Padding(3);
      this.maximizeBtn.ImageToDraw = global::FloatingStickyNotes.Properties.Resources.Maximizar;
      this.maximizeBtn.Location = new System.Drawing.Point(538, 2);
      this.maximizeBtn.Name = "maximizeBtn";
      this.maximizeBtn.Size = new System.Drawing.Size(26, 26);
      this.maximizeBtn.TabIndex = 5;
      this.maximizeBtn.UseVisualStyleBackColor = false;
      this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
      // 
      // closeBtn
      // 
      this.closeBtn.BackColor = System.Drawing.Color.Transparent;
      this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.closeBtn.FlatAppearance.BorderSize = 0;
      this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.closeBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.closeBtn.ImageToDraw = global::FloatingStickyNotes.Properties.Resources.Cerrar;
      this.closeBtn.Location = new System.Drawing.Point(570, 2);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(26, 26);
      this.closeBtn.TabIndex = 2;
      this.closeBtn.UseVisualStyleBackColor = false;
      this.closeBtn.Click += new System.EventHandler(this.fsnButton1_Click);
      // 
      // menuButton
      // 
      this.menuButton.BackColor = System.Drawing.Color.Transparent;
      this.menuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuButton.BackgroundImage")));
      this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.menuButton.FlatAppearance.BorderSize = 0;
      this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.menuButton.ImagePadding = new System.Windows.Forms.Padding(0);
      this.menuButton.ImageToDraw = null;
      this.menuButton.Location = new System.Drawing.Point(8, 2);
      this.menuButton.Name = "menuButton";
      this.menuButton.Size = new System.Drawing.Size(26, 26);
      this.menuButton.TabIndex = 4;
      this.menuButton.UseVisualStyleBackColor = false;
      // 
      // Board
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.ClientSize = new System.Drawing.Size(600, 400);
      this.Controls.Add(this.topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Board";
      this.Text = "Form1";
      this.topBar.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel topBar;
    private CustomControls.FSNButton closeBtn;
    private CustomControls.FSNButton menuButton;
    private CustomControls.FSNButton maximizeBtn;
  }
}

