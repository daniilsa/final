using LauncherNet.Elements.LauncherElements;
using LauncherNet.Forms;
using LauncherNet.Front;
using LauncherNet.Settings;

namespace LauncherNet
{

  /// <summary>
  /// Начало программы.
  /// </summary>
  internal static class StartProgramm
  {

    /// <summary>
    /// Запуск всех ключевых моментов работы программы.
    /// </summary>
    public static Form Open()
    {
      DataClass.launcher = new LauncherForm();
      Thread thread = new Thread(() => new LoadForm().ShowDialog());
      thread.Start();

      new CheckingFiles().CheckingResources();
      new SettingsForms().SettingsLauncherForm(DataClass.launcher);
      new CreateElementsLauncherForm().LoadElements(DataClass.launcher);
      new DesignElements().LoadDesignLauncher();

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

      while (thread.ThreadState != ThreadState.Stopped) ;
      return DataClass.launcher;
    }

  }
}
