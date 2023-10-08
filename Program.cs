using LauncherNet.BackUp;
using LauncherNet.Forms;
using LauncherNet.Functions;
using Process = System.Diagnostics.Process;

namespace LauncherNet
{
  internal static class Program
  {

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {

      AppDomain.CurrentDomain.ProcessExit += (s, a) =>
      {
        if (DataClass.StartProcess)
        {
          new LastSessionClass().SetCategory();
          new Tray().FromTray(DataClass.iconLauncher);
        }
      };

      Process[] processes = Process.GetProcessesByName(DataClass.GetDomain().FriendlyName);
      if (processes.Length <= 1)
      {

        ApplicationConfiguration.Initialize();
        if (new LastSessionClass().GetLastRun())
        {
          Application.Run(new HelpForm());
        }
        Application.Run(StartProgramm.Open());
        //Application.Run(new SettingsApplicationForm());
        //Application.Run(new HelpForm());
        //Application.Run(new TestForm());
      }
    }
  }
}