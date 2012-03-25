using System;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;

namespace Tower_defense
{
  public partial class GameForm : Form
  {
    private Game _game;

    public GameForm()
    {
      InitializeComponent();
    }

    private void MenuNewGame_Click(object sender, EventArgs e)
    {
      GameConfSelector selectorForm = new GameConfSelector();
      if (selectorForm.ShowDialog() == DialogResult.OK)
      {
        if (_game != null)
        {
          GameTimer.Stop();
          _game = null;
        }
        _game = Game.Factory(PBGame, selectorForm.ReturnConfigName());
        if (_game == null)
        {
          Environment.Exit(1);
        }
        else
        {
          GameTimer.Interval = 30;//1;
          GameTimer.Start();
          MessageBox.Show("Game conf loaded successeful");
        }
      }
    }

    private void PBGame_MouseUp(object sender, MouseEventArgs e)
    {
      if (_game != null)
      {
        _game.MouseUp(e);
      }
    }

    private void PBGame_MouseMove(object sender, MouseEventArgs e)
    {
      if (_game != null)
      {
        _game.MouseMove(e);
      }
    }

    private void MenuScaling0d2_Click(object sender, EventArgs e)
    {
      if (_game != null)
      {
        var toolStripMenuItem = sender as ToolStripMenuItem;
        if (toolStripMenuItem != null) _game.Scaling = Convert.ToSingle(toolStripMenuItem.Text);
      }
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
      _game.Tick();
      _game.Render();
    }
  }
}