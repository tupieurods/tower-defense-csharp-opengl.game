﻿namespace Tower_defense
{
  partial class GameConfSelector
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
      this.LBGameConf = new System.Windows.Forms.ListBox();
      this.BSelect = new System.Windows.Forms.Button();
      this.BCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // LBGameConf
      // 
      this.LBGameConf.FormattingEnabled = true;
      this.LBGameConf.ItemHeight = 24;
      this.LBGameConf.Location = new System.Drawing.Point(22, 22);
      this.LBGameConf.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.LBGameConf.Name = "LBGameConf";
      this.LBGameConf.Size = new System.Drawing.Size(473, 124);
      this.LBGameConf.TabIndex = 0;
      // 
      // BSelect
      // 
      this.BSelect.Location = new System.Drawing.Point(22, 161);
      this.BSelect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.BSelect.Name = "BSelect";
      this.BSelect.Size = new System.Drawing.Size(138, 42);
      this.BSelect.TabIndex = 1;
      this.BSelect.Text = "Select";
      this.BSelect.UseVisualStyleBackColor = true;
      this.BSelect.Click += new System.EventHandler(this.BSelect_Click);
      // 
      // BCancel
      // 
      this.BCancel.Location = new System.Drawing.Point(361, 161);
      this.BCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.BCancel.Name = "BCancel";
      this.BCancel.Size = new System.Drawing.Size(138, 42);
      this.BCancel.TabIndex = 2;
      this.BCancel.Text = "Cancel";
      this.BCancel.UseVisualStyleBackColor = true;
      this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
      // 
      // GameConfSelector
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(521, 212);
      this.Controls.Add(this.BCancel);
      this.Controls.Add(this.BSelect);
      this.Controls.Add(this.LBGameConf);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.Name = "GameConfSelector";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Game configuration select";
      this.Load += new System.EventHandler(this.GameConfSelector_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox LBGameConf;
    private System.Windows.Forms.Button BSelect;
    private System.Windows.Forms.Button BCancel;
  }
}