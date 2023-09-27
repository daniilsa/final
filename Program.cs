using LauncherNet.Forms;
using LauncherNet.Settings;

namespace LauncherNet
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      ApplicationConfiguration.Initialize();
      Application.Run(StartProgramm.Open());
      //Application.Run(new TestForm());
    }
  }
}