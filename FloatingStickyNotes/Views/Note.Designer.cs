namespace FloatingStickyNotes.Views
{
  partial class Note
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.iconBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.colorSelectBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.noteText = new System.Windows.Forms.RichTextBox();
      this.saveBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.menuBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.closeBtn = new FloatingStickyNotes.Controls.FSNButton();
      this.SuspendLayout();
      // 
      // iconBtn
      // 
      this.iconBtn.BackColor = System.Drawing.SystemColors.Control;
      this.iconBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.iconBtn.Image = global::FloatingStickyNotes.Properties.Resources.Clip;
      this.iconBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.iconBtn.Location = new System.Drawing.Point(0, 0);
      this.iconBtn.Name = "iconBtn";
      this.iconBtn.Size = new System.Drawing.Size(32, 32);
      this.iconBtn.TabIndex = 0;
      this.iconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.iconBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iconBtn_MouseDown);
      this.iconBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.iconBtn_MouseMove);
      this.iconBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.iconBtn_MouseUp);
      // 
      // colorSelectBtn
      // 
      this.colorSelectBtn.BackColor = System.Drawing.SystemColors.Control;
      this.colorSelectBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.colorSelectBtn.Image = global::FloatingStickyNotes.Properties.Resources.PaletaColores;
      this.colorSelectBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.colorSelectBtn.Location = new System.Drawing.Point(33, 0);
      this.colorSelectBtn.Name = "colorSelectBtn";
      this.colorSelectBtn.Size = new System.Drawing.Size(32, 32);
      this.colorSelectBtn.TabIndex = 1;
      this.colorSelectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.colorSelectBtn.Click += new System.EventHandler(this.colorSelectBtn_Click);
      // 
      // noteText
      // 
      this.noteText.BackColor = System.Drawing.SystemColors.Control;
      this.noteText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.noteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
      this.noteText.Location = new System.Drawing.Point(66, 0);
      this.noteText.Name = "noteText";
      this.noteText.Size = new System.Drawing.Size(370, 32);
      this.noteText.TabIndex = 2;
      this.noteText.Text = "";
      this.noteText.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.noteText_ContentsResized);
      this.noteText.Click += new System.EventHandler(this.noteText_Click);
      // 
      // saveBtn
      // 
      this.saveBtn.BackColor = System.Drawing.SystemColors.Control;
      this.saveBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.saveBtn.Image = global::FloatingStickyNotes.Properties.Resources.Ok;
      this.saveBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.saveBtn.Location = new System.Drawing.Point(442, 0);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(32, 32);
      this.saveBtn.TabIndex = 3;
      this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // menuBtn
      // 
      this.menuBtn.BackColor = System.Drawing.SystemColors.Control;
      this.menuBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.menuBtn.Image = global::FloatingStickyNotes.Properties.Resources.PanelMenuOpen;
      this.menuBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.menuBtn.Location = new System.Drawing.Point(480, 0);
      this.menuBtn.Name = "menuBtn";
      this.menuBtn.Size = new System.Drawing.Size(32, 32);
      this.menuBtn.TabIndex = 4;
      this.menuBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // closeBtn
      // 
      this.closeBtn.BackColor = System.Drawing.SystemColors.Control;
      this.closeBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
      this.closeBtn.Image = global::FloatingStickyNotes.Properties.Resources.Cerrar;
      this.closeBtn.ImagePadding = new System.Windows.Forms.Padding(0);
      this.closeBtn.Location = new System.Drawing.Point(518, 0);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(32, 32);
      this.closeBtn.TabIndex = 5;
      this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
      // 
      // Note
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(550, 39);
      this.Controls.Add(this.iconBtn);
      this.Controls.Add(this.colorSelectBtn);
      this.Controls.Add(this.noteText);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.menuBtn);
      this.Controls.Add(this.closeBtn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Note";
      this.Text = "Note";
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.FSNButton iconBtn;
    private Controls.FSNButton colorSelectBtn;
    private System.Windows.Forms.RichTextBox noteText;
    private Controls.FSNButton saveBtn;
    private Controls.FSNButton menuBtn;
    private Controls.FSNButton closeBtn;
  }
}