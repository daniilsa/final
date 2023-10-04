using LauncherNet.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        Process[] processes = Process.GetProcessesByName(DataClass.processLauncher.FriendlyName);
        if (processes.Length > 1)
        {
          DataClass.launcher?.Invoke(() =>
          {
            if (DataClass.launcher.Visible == false)
              new Tray().FromTray(DataClass.iconLauncher);

            DataClass.launcher.Activate();
          });
        }
      };
      timer.Start();
    }

  }
}
