using LauncherNet.Elements;
using LauncherNet.Forms;
using LauncherNet.Front;
<<<<<<< HEAD
using LauncherNet.Info;
using LauncherNet.Settings;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
=======
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet
{
<<<<<<< HEAD
  
  /// <summary>
  /// Начало программы.
  /// </summary>
  static class StartProgramm 
=======
  /// <summary>
  /// Начало программы.
  /// </summary>
  static class StartProgramm
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
  {

    /// <summary>
    /// Запуск всех ключевых моментов работы программы.
    /// </summary>
    static public Form Open()
    {
      DataClass.launcher = new LauncherForm();
<<<<<<< HEAD
      Thread thread = new Thread(() => new LoadForm().ShowDialog());
=======
      Thread thread = new Thread(()=> new LoadForm().ShowDialog());
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
      thread.Start();

      new CheckingFiles().CheckingResources();
      new SettingsForms().SettingsLauncherForm(DataClass.launcher);
      new ElementsLauncherForm().LoadElements(DataClass.launcher);
<<<<<<< HEAD
      new DesignElements().LoadDesignLauncher();

=======
      new DesignElements().Load();
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
      Thread.Sleep(3000);
      DataClass.downloadStage = true;

      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Interval = 1000;

      timer.Tick += (s, a) =>
      {
        if (thread.ThreadState == ThreadState.Aborted)
        {
          timer.Stop();
        };
      };
      timer.Start();

<<<<<<< HEAD
    

      while (thread.ThreadState != ThreadState.Stopped) ;
=======
      while (thread.ThreadState != ThreadState.Stopped);
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
      return DataClass.launcher;
    }

  }
}
