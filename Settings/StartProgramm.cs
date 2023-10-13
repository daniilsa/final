using LauncherNet._Data;
using LauncherNet._Front;
using LauncherNet.DesignFront;
using LauncherNet.Elements.LauncherElements;
using LauncherNet.Files;
using LauncherNet.Forms;
using LauncherNet.Settings;
using ThreadState = System.Threading.ThreadState;

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
      new CheckingFiles().CheckingResources();
      WorkingColor.RewritingColor();
      DataLauncherForm.launcher = new LauncherForm();

      Thread thread = new Thread(() => new ProgressBarForm("ЗАПУСК ПРОГРАММЫ").ShowDialog());
      thread.Start();

      new SettingsLauncherForm().SettingsForm(DataLauncherForm.launcher);
      new CreateElementsLauncherForm().LoadElements(DataLauncherForm.launcher);
      new DesignLauncherForm().LoadDesignLauncher();
      new CheckingFiles().CheckingResources();

      Thread.Sleep(3000);
      DataClass.DownloadStage = true;

      System.Windows.Forms.Timer timer = new()
      {
        Interval = 1000,
      };
      timer.Tick += (s, a) =>
      {
        if (thread.ThreadState == ThreadState.Aborted)
        {
          timer.Stop();
        };
      };
      timer.Start();
      new ActivateApplication().CheckAndOpenProcess();

      while (thread.ThreadState != ThreadState.Stopped) ;
      return DataLauncherForm.launcher;
    }

  }
}
