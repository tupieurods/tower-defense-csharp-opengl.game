using System;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;
using GameCoClassLibrary.Enums;

namespace Tower_defense
{
  public partial class GameForm : Form
  {
    private readonly GameMenu _gameMenu;

    public GameForm()
    {
      InitializeComponent();
      _gameMenu = new GameMenu(GraphicEngineType.WinForms, PBGame);
    }

    private void PBGame_MouseUp(object sender, MouseEventArgs e)
    {
      if (_gameMenu != null)
      {
        _gameMenu.MouseUp(e);
      }
    }

    private void PBGame_MouseMove(object sender, MouseEventArgs e)
    {
      if (_gameMenu != null)
      {
        _gameMenu.MouseMove(e);
      }
    }

  }
}
