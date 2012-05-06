using System;
using System.Windows.Forms;

namespace Tower_defense
{
  static class Program
  {
    /// <summary>
    /// Main entry point
    /// </summary>
    [STAThread]
    static void Main()
   {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new GameForm());
    }
  }
}
