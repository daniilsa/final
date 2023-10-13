using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet._Front;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.Elements.LauncherElements;
using LauncherNet.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Settings
{
  internal class UpdateClass
  {
    /// <summary>
    /// Обновление элементов в лаунчере.
    /// </summary>
    /// <param name="value">Экземпляр формы</param>
    public void UpdateMethod(Form value)
    {
      new CheckingFiles().CheckingResources();
      DataLauncherForm.appsElementLauncher = new List<Panel>();
      DataLauncherForm.mainAppsLauncher = new List<ScrollBarControl>();
      DataLauncherForm.categoryElementLauncher = new List<TextControl>();
      DataLauncherForm.controlAddApp = new List<ControlAddControl>();

      value.Controls.Clear();
      DataLauncherForm.appsElementLauncher.Clear();
      new LastSessionClass().SetCategory();
      new CreateElementsLauncherForm().LoadElements(value);
      new DesignLauncherForm().LoadDesignLauncher();
      Thread.Sleep(100);
    }
  }
}
