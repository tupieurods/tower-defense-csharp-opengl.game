using System;
using System.Drawing;
using System.Windows.Forms;
using GameCoClassLibrary.Classes;
using GameCoClassLibrary.Enums;
using GameCoClassLibrary.Forms;
using GraphicLib.Interfaces;
using GraphicLib.OpenGl;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using BeginMode = OpenTK.Graphics.OpenGL.BeginMode;
using BlendingFactorDest = OpenTK.Graphics.OpenGL.BlendingFactorDest;
using BlendingFactorSrc = OpenTK.Graphics.OpenGL.BlendingFactorSrc;
using EnableCap = OpenTK.Graphics.OpenGL.EnableCap;
using GL = OpenTK.Graphics.OpenGL.GL;
using MainMenu = GameCoClassLibrary.Classes.MainMenu;
using MatrixMode = OpenTK.Graphics.OpenGL.MatrixMode;
using Menu = GameCoClassLibrary.Classes.Menu;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Tower_defence_with_OpenGL
{
  public class Program : GameWindow
  {
    [STAThread]
    static public void Main()
    {
      using (var program = new Program())
      {
        program.Run();
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
      this.ClientSize = new Size(Convert.ToInt32(Settings.WindowWidth * scaling), Convert.ToInt32(Settings.WindowHeight * scaling));
      if (_gameMenu != null)
      {
        _gameMenu.Scaling = scaling;
      }
      if (_game != null)
      {
        _game.Scaling = scaling;
      }
      GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(0, Settings.WindowWidth * scaling, Settings.WindowHeight * scaling, 0, -1, 1);
    }

    private void CreateNewGame(FormType formType)
    {
      FormForSelection selectorForm = new FormForSelection(formType);
      if (selectorForm.ShowDialog() != DialogResult.OK)
        return;
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
      if (_game != null)
      {
        _game.Scaling = _currentScale;
        _gameMenu = null;
        MessageBox.Show("Game conf loaded successeful");
      }
    }

    private MouseEventArgs CreateWinFormsArgsFromOpenTK(MouseButtonEventArgs inValue)
    {
      MouseButtons resultButton;
      switch (inValue.Button)
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
      if (_gameMenu != null)
      {
        result = _gameMenu.MouseUp(CreateWinFormsArgsFromOpenTK(e));
      }
      if (_game != null)
      {
        result = _game.MouseUp(CreateWinFormsArgsFromOpenTK(e));
      }
      switch (result)
      {
        case GameCoClassLibrary.Enums.Button.Empty:
          break;
        case GameCoClassLibrary.Enums.Button.BigScale:
          GameResize(2.0f);
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
      if (_game != null)
      {
        _game.MouseMove(e.Position);
      }
    }

    private Program()
      : base(Settings.WindowWidth, Settings.WindowHeight, new GraphicsMode(color: 32, depth: 32, stencil: 0, samples: 8), "Tower defence OpenGl privateBeta")
    {
      VSync = VSyncMode.On;
      _graphObject = new OpenGLGraphic(this.ClientSize);
      _currentScale = 1.0f;
      GameResize(1.0f);
      _gameMenu = new MainMenu(_graphObject);
      Mouse.ButtonUp += MouseUp;
      Mouse.Move += MouseMove;
      OnLoad(new EventArgs());
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      //GL.Enable(EnableCap.Texture2D);

      OnResize(e);
    }

    /*protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(0, Settings.WindowWidth, Settings.WindowHeight, 0, -1, 1);
    }*/

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);

      if (_gameMenu != null)
      {
        _gameMenu.Show();
      }
      if (_game == null)
        return;
      var mouse = OpenTK.Input.Mouse.GetState();
      if ((mouse[MouseButton.Left]) || (mouse[MouseButton.Right]))
      {
      }
      _game.Tick(new Point(this.Mouse.X, this.Mouse.Y));
      _game.Render();
      if (!_game.Lose && !_game.Won)
        return;
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
      SwapBuffers();
    }

  }




}
