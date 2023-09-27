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
<<<<<<< HEAD
      //Application.Run(new TestForm());
=======
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    }
  }
}