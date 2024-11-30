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
      this.topBar = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // topBar
      // 
      this.topBar.BackColor = System.Drawing.Color.Gray;
      this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.topBar.Location = new System.Drawing.Point(0, 0);
      this.topBar.Name = "topBar";
      this.topBar.Size = new System.Drawing.Size(600, 30);
      this.topBar.TabIndex = 0;
      // 
      // Board
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(600, 400);
      this.Controls.Add(this.topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Board";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel topBar;
  }
}

