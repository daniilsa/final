using LauncherNet._Data;
using LauncherNet.Functions;
using System.Diagnostics;

namespace LauncherNet.Settings
{
  /// <summary>
  /// Активация приложения. Получение фокуса.
  /// </summary>
  internal class ActivateApplication
  {

    /// <summary>
    /// Проверка на 1 экземпляр приложения. В попытке запустить 2 экземпляр, станет активным 1 экземпляр.
    /// </summary>
    public void CheckAndOpenProcess()
    {
      System.Timers.Timer timer = new System.Timers.Timer()
      {
        Interval = 100,
      };
      timer.Elapsed += (s, a) =>
      {

        Process[] processes = Process.GetProcessesByName(DataClass.GetDomain().FriendlyName);
        if (processes.Length > 1)
        {
          DataLauncherForm.launcher?.Invoke(() =>
          {
            if (DataLauncherForm.launcher.Visible == false)
              new Tray().FromTray(DataClass.iconLauncher);

            DataLauncherForm.launcher.Activate();
          });
        }
      };
      timer.Start();
    }

  }
}
