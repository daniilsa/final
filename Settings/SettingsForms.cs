using LauncherNet.BackUp;
using LauncherNet.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Settings
{
  public class SettingsForms
  {
    /// <summary>
    /// Настройка формы лаунчера.
    /// </summary>
    /// <param name="launcher">"Экземпляр формы</param>
    public void SettingsLauncherForm(Form launcher)
    {
      launcher.Size = new Size(700, 600);
      launcher.MinimumSize = new Size(700, 600);
      launcher.WindowState = FormWindowState.Maximized;
      launcher.Text = "Launcher";
      //launcher.FormBorderStyle = FormBorderStyle.None;

      launcher.SizeChanged += (s, a) =>
      {
        DataClass.sizeForm.Width = launcher.Width;
        if (DataClass.activeAppPanel != null)
        {

          DataClass.activeAppPanel.Width = DataClass.sizeForm.Width - DataClass.sizeCategoriesElement.Width - 15;
          new ElementsLauncherForm().LocationApps();

          new ElementsLauncherForm().SizeAppsPanel();

        }
      };


      launcher.LocationChanged += (s, a) => DataClass.locationForm = new DataClass.Location(launcher.Location.X, launcher.Location.Y);

      launcher.FormClosing += (s, a) => new BackUpClass().SetCategory();

      DataClass.sizeForm = new Size(DataClass.screenSize.Width, DataClass.screenSize.Height);
      DataClass.locationForm = new DataClass.Location(launcher.Location.X, launcher.Location.Y);

    }

    /// <summary>
    /// Обновление элементов в лаунчере.
    /// </summary>
    /// <param name="launcher">Экземпляр формы</param>
    public void UpdateLauncher(Form launcher)
    {
      launcher.Controls.Clear();
      DataClass.allApps.Clear();
      new BackUpClass().SetCategory();
      new ElementsLauncherForm().LoadElements(launcher);
    }

    /// <summary>
    /// Настройки формы добавления приложений, категорий.
    /// </summary>
    /// <param name="functional"></param>
    public void SettingsFunctionalForm(Form functional)
    {
      functional.Width = 400;
      functional.FormBorderStyle = FormBorderStyle.None;
      functional.StartPosition = FormStartPosition.CenterScreen;
    }

    /// <summary>
    /// Настройки формы выбора обложки для приложения.
    /// </summary>
    /// <param name="imageSelection">Экземпляр формы</param>
    public void SettingsImageForm(Form imageSelection)
    {
      imageSelection.Size = new Size((DataClass.sizelAppElement.Width * 5) + (10 * 4) + 80, (DataClass.sizelAppElement.Height * 2) + (22 * 1) + 120);
      imageSelection.StartPosition = FormStartPosition.CenterScreen;
      imageSelection.Text = "Выбор обложки";
      imageSelection.FormBorderStyle = FormBorderStyle.None;

    }
  }
}
