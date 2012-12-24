namespace Tower_defense
{
  partial class GameForm
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
      this.PBGame = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PBGame)).BeginInit();
      this.SuspendLayout();
      // 
      // PBGame
      // 
      this.PBGame.Image = ((System.Drawing.Image)(resources.GetObject("PBGame.Image")));
      this.PBGame.Location = new System.Drawing.Point(0, 0);
      this.PBGame.Name = "PBGame";
      this.PBGame.Size = new System.Drawing.Size(730, 600);
      this.PBGame.TabIndex = 0;
      this.PBGame.TabStop = false;
      this.PBGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBGame_MouseMove);
      this.PBGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBGame_MouseUp);
      // 
      // GameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(730, 602);
      this.Controls.Add(this.PBGame);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.MaximizeBox = false;
      this.Name = "GameForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Tag = "0";
      this.Text = "Tower defense pre-alpha";
      ((System.ComponentModel.ISupportInitialize)(this.PBGame)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox PBGame;
  }
}

