using System;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;
using GameCoClassLibrary.Enums;
using GameCoClassLibrary.Forms;
using GameCoClassLibrary.Interfaces;
using Button = GameCoClassLibrary.Enums.Button;
using MainMenu = GameCoClassLibrary.Classes.MainMenu;
using Menu = GameCoClassLibrary.Classes.Menu;

namespace Tower_defense
{
  public partial class GameForm : Form
  {
    private Menu _gameMenu;
    private Game _game;
    private readonly IGraphic _graphObject;
    private readonly Timer _timer;
    private float _currentScale;

    public GameForm()
    {
      InitializeComponent();
      _graphObject = new WinFormsGraphic(null);
      _currentScale = 1.0f;
      GameResize(1.0f);
      _gameMenu = new MainMenu(_graphObject);
      _timer = new Timer();
      _timer.Tick += TimerTick;
      _timer.Interval = 30;
      _timer.Start();
    }

    private void GameResize(float scaling)
    {
      _currentScale = scaling;
      _graphObject.Resize(0, 0, scaling, PBGame);
      if (_gameMenu != null)
      {
        _gameMenu.Scaling = scaling;
      }
      if (_game != null)
      {
        _game.Scaling = scaling;
      }
    }

    private void CreateNewGame(FormType formType)
    {
      FormForSelection selectorForm = new FormForSelection(formType);
      if (selectorForm.ShowDialog() == DialogResult.OK)
      {
        if (_game != null)
        {
          if (_timer != null)
            _timer.Stop();
          _game = null;
        }
        try
        {
          _game = Game.Factory(selectorForm.ReturnFileName(),
                               formType == FormType.GameConfiguration ? FactoryAct.Create : FactoryAct.Load,
                               _graphObject);
        }
        catch
        {
          _game = null;
        }
        if (_game != null)
        {
          _game.Scaling = _currentScale;
          _gameMenu = null;
          MessageBox.Show("Game conf loaded successeful");
        }
        if (_timer != null)
          _timer.Start();
      }
    }

    private void TimerTick(object obj, EventArgs e)
    {
      if (_gameMenu != null)
      {
        _gameMenu.Show();
      }
      if (_game != null)
      {
        _game.Tick(PBGame.PointToClient(Control.MousePosition));
        _game.Render();
      }
      _graphObject.Render();
    }

    private void PBGame_MouseUp(object sender, MouseEventArgs e)
    {
      Button result = Button.Empty;
      if (_gameMenu != null)
      {
        result = _gameMenu.MouseUp(e);
        //MessageBox.Show(result.ToString());
      }
      if (_game != null)
      {
        result = _game.MouseUp(e);
      }
      switch (result)
      {
        case Button.Empty:
          break;
        case Button.BigScale:
          GameResize(2.0f);
          break;
        case Button.NormalScale:
          GameResize(1.0f);
          break;
        case Button.SmallScale:
          GameResize(0.8125f);
          break;
        case Button.Exit:
          Environment.Exit(0);
          break;
        case Button.LoadGame:
          CreateNewGame(FormType.Load);
          break;
        case Button.NewGame:
          CreateNewGame(FormType.GameConfiguration);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void PBGame_MouseMove(object sender, MouseEventArgs e)
    {
      if (_game != null)
      {
        _game.MouseMove(e);
      }
    }

  }
}
