using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;

namespace Tower_defense
{
  public partial class GameForm : Form
  {
    private TGame Game = null;

    public GameForm()
    {
      InitializeComponent();
    }

    private void MenuNewGame_Click(object sender, EventArgs e)
    {
      GameConfSelector SelectorForm = new GameConfSelector();
      if (SelectorForm.ShowDialog() == DialogResult.OK)
      {
        if (Game != null)
        {
          Game.GetFreedomToTimer();
          Game = null;
        }
        Game = TGame.Factory(PBGame, GameTimer, SelectorForm.ReturnConfigName());
        if (Game == null)
        {
          Environment.Exit(1);
        }
        else
          MessageBox.Show("Game conf loaded successeful");
      }
    }

    private void PBGame_MouseUp(object sender, MouseEventArgs e)
    {
      if (Game != null)
      {
        Game.MouseUp(e);
      }
    }

    private void PBGame_MouseMove(object sender, MouseEventArgs e)
    {
      if (Game != null)
      {
        Game.MouseMove(e);
      }
    }

    private void MenuScaling0d2_Click(object sender, EventArgs e)
    {
      if (Game != null)
      {
        Game.Scaling = Convert.ToSingle((sender as ToolStripMenuItem).Text);
      }
    }

  }
}
