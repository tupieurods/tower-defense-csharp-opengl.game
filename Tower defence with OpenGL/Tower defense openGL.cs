using System;
using System.Drawing;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;
using GameCoClassLibrary.Enums;
using GameCoClassLibrary.Forms;
using GraphicLib.Interfaces;
using GraphicLib.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Tower_defence_with_OpenGL.Properties;
using GL = OpenTK.Graphics.OpenGL.GL;
using MainMenu = GameCoClassLibrary.Classes.MainMenu;
using Menu = GameCoClassLibrary.Classes.Menu;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Tower_defence_with_OpenGL
{
  public class Program: GameWindow
  {
    public static void Main()
    {
      using(var program = new Program())
      {
        program.Run(60, 120);
      }
    }

    private Menu _gameMenu;
    private Game _game;
    private readonly IGraphic _graphObject;
    private float _currentScale;

    private void GameResize(float scaling)
    {
      _currentScale = scaling;
      _graphObject.Resize(Settings.WindowWidth, Settings.WindowHeight, scaling);
      _graphObject.Clip = new Rectangle(0, 0, Convert.ToInt32(Settings.WindowWidth * scaling),
                                        Convert.ToInt32(Settings.WindowHeight * scaling));
      this.ClientSize = new Size(Convert.ToInt32(Settings.WindowWidth * scaling),
                                 Convert.ToInt32(Settings.WindowHeight * scaling));
      GL.Viewport(this.ClientSize);
      if(_gameMenu != null)
      {
        _gameMenu.Scaling = scaling;
      }
      if(_game != null)
      {
        _game.Scaling = scaling;
      }
    }

    /// <summary>
    /// Creates the new game.
    /// </summary>
    /// <param name="formType">Type of the form.</param>
    private void CreateNewGame(FormType formType)
    {
      FormForSelection selectorForm = new FormForSelection(formType);
      if(selectorForm.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      _game = null;
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
      if(_game == null)
      {
        return;
      }
      _game.Scaling = _currentScale;
      _gameMenu = null;
      _graphObject.ClearCache();
      MessageBox.Show(Resources.Game_created_successeful);
    }

    private MouseEventArgs CreateWinFormsArgsFromOpenTK(MouseButtonEventArgs inValue)
    {
      MouseButtons resultButton;
      switch(inValue.Button)
      {
        case MouseButton.Left:
          resultButton = MouseButtons.Left;
          break;
        case MouseButton.Right:
          resultButton = MouseButtons.Right;
          break;
        default:
          resultButton = MouseButtons.None;
          break;
      }
      MouseEventArgs result = new MouseEventArgs(resultButton, 1, inValue.X, inValue.Y, 0);
      return result;
    }

    private void MouseUp(object sender, MouseButtonEventArgs e)
    {
      GameCoClassLibrary.Enums.Button result = GameCoClassLibrary.Enums.Button.Empty;
      if(_gameMenu != null)
      {
        result = _gameMenu.MouseUp(CreateWinFormsArgsFromOpenTK(e));
      }
      if(_game != null)
      {
        result = _game.MouseUp(CreateWinFormsArgsFromOpenTK(e));
      }
      switch(result)
      {
        case GameCoClassLibrary.Enums.Button.Empty:
          break;
        case GameCoClassLibrary.Enums.Button.BigScale:
          GameResize(1.5f);
          break;
        case GameCoClassLibrary.Enums.Button.NormalScale:
          GameResize(1.0f);
          break;
        case GameCoClassLibrary.Enums.Button.SmallScale:
          GameResize(0.8125f);
          break;
        case GameCoClassLibrary.Enums.Button.Exit:
          Environment.Exit(0);
          break;
        case GameCoClassLibrary.Enums.Button.LoadGame:
          CreateNewGame(FormType.Load);
          break;
        case GameCoClassLibrary.Enums.Button.NewGame:
          CreateNewGame(FormType.GameConfiguration);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void MouseMove(object sender, MouseMoveEventArgs e)
    {
      if(_game != null)
      {
        _game.MouseMove(e.Position);
      }
    }

    private Program()
      : base(
        Settings.WindowWidth, Settings.WindowHeight, new GraphicsMode(color: 32, depth: 0, stencil: 0, samples: 8),
        "Tower defense OpenGl Beta")
    {
      GL.Enable(EnableCap.PolygonSmooth);
      VSync = VSyncMode.On;
      _graphObject = new OpenGLGraphic(this.ClientSize);
      _currentScale = 1.0f;
      _gameMenu = new MainMenu(_graphObject);
      Mouse.ButtonUp += MouseUp;
      Mouse.Move += MouseMove;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      OnResize(e);
    }

    /*protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
    }*/

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      if(_game == null)
      {
        return;
      }
      _game.Tick(new Point(this.Mouse.X, this.Mouse.Y));
      if(!_game.Lose && !_game.Won)
      {
        return;
      }
      MessageBox.Show(_game.Lose
                        ? GameCoClassLibrary.Properties.Resources.Looser_message
                        : GameCoClassLibrary.Properties.Resources.Winner_message);
      float scaling = _game.Scaling;
      _game = null;
      _gameMenu = new MainMenu(_graphObject);
      GameResize(scaling);
    }

    /// <summary>
    /// Called when the frame is rendered.
    /// </summary>
    /// <param name="e">Contains information necessary for frame rendering.</param>
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      if(_gameMenu != null)
      {
        _gameMenu.Show();
      }
      if(_game != null)
      {
        _game.Render();
      }
      _graphObject.Render();
      SwapBuffers();
    }
  }
}