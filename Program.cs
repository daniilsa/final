using EnvDTE;
using LauncherNet.BackUp;
using LauncherNet.Forms;
using LauncherNet.Functions;
using LauncherNet.Settings;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Process = System.Diagnostics.Process;

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

      AppDomain.CurrentDomain.ProcessExit += (s, a) =>
      {
        if (DataClass.startProcess)
        {
          new LastSessionClass().SetCategory();
          new Tray().FromTray(DataClass.iconLauncher);
        }
      };

      Process[] processes = Process.GetProcessesByName(DataClass.processLauncher.FriendlyName);
      if (processes.Length <= 1)
      {
        ApplicationConfiguration.Initialize();
        Application.Run(StartProgramm.Open());
        //Application.Run(new TestForm());
      }
    }
  }
}