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
      this.mSMenuNonGraphical = new System.Windows.Forms.MenuStrip();
      this.MenuMain = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuNewGame = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuPause = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuLoad = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.PBGame)).BeginInit();
      this.mSMenuNonGraphical.SuspendLayout();
      this.SuspendLayout();
      // 
      // PBGame
      // 
      this.PBGame.Image = ((System.Drawing.Image)(resources.GetObject("PBGame.Image")));
      this.PBGame.Location = new System.Drawing.Point(12, 27);
      this.PBGame.Name = "PBGame";
      this.PBGame.Size = new System.Drawing.Size(700, 500);
      this.PBGame.TabIndex = 0;
      this.PBGame.TabStop = false;
      // 
      // mSMenuNonGraphical
      // 
      this.mSMenuNonGraphical.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMain});
      this.mSMenuNonGraphical.Location = new System.Drawing.Point(0, 0);
      this.mSMenuNonGraphical.Name = "mSMenuNonGraphical";
      this.mSMenuNonGraphical.Size = new System.Drawing.Size(725, 24);
      this.mSMenuNonGraphical.TabIndex = 1;
      this.mSMenuNonGraphical.Text = "menuStrip1";
      // 
      // MenuMain
      // 
      this.MenuMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNewGame,
            this.MenuPause,
            this.MenuSave,
            this.MenuLoad,
            this.MenuExit});
      this.MenuMain.Name = "MenuMain";
      this.MenuMain.Size = new System.Drawing.Size(46, 20);
      this.MenuMain.Text = "Main";
      // 
      // MenuNewGame
      // 
      this.MenuNewGame.Name = "MenuNewGame";
      this.MenuNewGame.Size = new System.Drawing.Size(129, 22);
      this.MenuNewGame.Text = "NewGame";
      this.MenuNewGame.Click += new System.EventHandler(this.MenuNewGame_Click);
      // 
      // MenuPause
      // 
      this.MenuPause.Name = "MenuPause";
      this.MenuPause.Size = new System.Drawing.Size(129, 22);
      this.MenuPause.Text = "Pause";
      // 
      // MenuSave
      // 
      this.MenuSave.Name = "MenuSave";
      this.MenuSave.Size = new System.Drawing.Size(129, 22);
      this.MenuSave.Text = "Save";
      // 
      // MenuLoad
      // 
      this.MenuLoad.Name = "MenuLoad";
      this.MenuLoad.Size = new System.Drawing.Size(129, 22);
      this.MenuLoad.Text = "Load";
      // 
      // MenuExit
      // 
      this.MenuExit.Name = "MenuExit";
      this.MenuExit.Size = new System.Drawing.Size(129, 22);
      this.MenuExit.Text = "Exit";
      // 
      // GameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(725, 534);
      this.Controls.Add(this.PBGame);
      this.Controls.Add(this.mSMenuNonGraphical);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MainMenuStrip = this.mSMenuNonGraphical;
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "GameForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Tower defense pre-alpha";
      ((System.ComponentModel.ISupportInitialize)(this.PBGame)).EndInit();
      this.mSMenuNonGraphical.ResumeLayout(false);
      this.mSMenuNonGraphical.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox PBGame;
    private System.Windows.Forms.MenuStrip mSMenuNonGraphical;
    private System.Windows.Forms.ToolStripMenuItem MenuMain;
    private System.Windows.Forms.ToolStripMenuItem MenuNewGame;
    private System.Windows.Forms.ToolStripMenuItem MenuExit;
    private System.Windows.Forms.ToolStripMenuItem MenuPause;
    private System.Windows.Forms.ToolStripMenuItem MenuSave;
    private System.Windows.Forms.ToolStripMenuItem MenuLoad;
  }
}

