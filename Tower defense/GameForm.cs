using System;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;
using GameCoClassLibrary.Forms;
using GameCoClassLibrary.Enums;
using Tower_defense.Properties;

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
      FormForSelection selectorForm = new FormForSelection(FormType.GameConfiguration);
      if (selectorForm.ShowDialog() == DialogResult.OK)
      {
        if (_game != null)
        {
          GameTimer.Stop();
          _game = null;
        }
        _game = Game.Factory(selectorForm.ReturnFileName(), FactoryAct.Create, GraphicEngineType.WinForms, PBGame);
        if (_game == null)
        {
          Environment.Exit(1);
        }
        else
        {
          GameTimer.Interval = 30;//1;
          GameTimer.Start();
          MessageBox.Show(Resources.Game_conf_loaded_successeful);
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
      if (!_game.Paused)
        _game.Tick();
      if (_game.Lose)
      {
        GameTimer.Stop();
        _game = null;
        MessageBox.Show(Resources.Gamer_loose);
        return;
      }
      _game.Render();
    }

    private void MenuPause_Click(object sender, EventArgs e)
    {
      if (_game == null) return;
      _game.Paused = !_game.Paused;
      MenuPause.Text = _game.Paused ? "Unpause" : "Pause";
    }

    private void MenuSave_Click(object sender, EventArgs e)
    {
      if (_game == null) return;
      FormForSave saveNameForm = new FormForSave();
      if (saveNameForm.ShowDialog() == DialogResult.OK)
      {
        MenuPause_Click(sender, e);
        _game.SaveGame(saveNameForm.ReturnSaveFileName());
      }
    }

    //Переписать когда будет сделан класс меню
    private void MenuLoad_Click(object sender, EventArgs e)
    {
      FormForSelection selectorForm = new FormForSelection(FormType.Load);
      if (selectorForm.ShowDialog() == DialogResult.OK)
      {
        if (_game != null)
        {
          GameTimer.Stop();
          _game = null;
        }
        _game = Game.Factory(selectorForm.ReturnFileName(), FactoryAct.Load, GraphicEngineType.WinForms, PBGame);
        if (_game == null)
        {
          Environment.Exit(1);
        }
        else
        {
          GameTimer.Interval = 30;//1;
          GameTimer.Start();
          MessageBox.Show(Resources.Game_loaded_successeful);
        }
      }
    }
  }
}