using LauncherNet.Controls;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Elements.LauncherElements
{
  internal class AppsElement
  {

    /// <summary>
    /// Создаёт и настраивает панель с файлами определённой категории.
    /// </summary>
    /// <param name="nameCategoty">Имя категории</param>
    /// <returns></returns>
    public ScrollBarControl CreateAppsElement(Form launcher, string nameCategoty)
    {
      ScrollBarControl panelApps = new()
      {
        Visible = false,
        Name = nameCategoty,
        BackColor = Color.Green,
      };

      if (DataClass.categoriesElementLauncher != null)
      {
        panelApps.Width = DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth;
        panelApps.Height = DataClass.categoriesElementLauncher.Height;

        if (DataClass.topElementLauncher != null)
          panelApps.Location = new Point(DataClass.categoriesElementLauncher.Width, DataClass.topElementLauncher.Height);
      }

      string pathFile = DataClass.categoriesPathFiles + "\\" + nameCategoty;

      if (File.Exists(pathFile))
      {
        string[] dataFiles = File.ReadAllLines(pathFile);

        foreach (string dataFile in dataFiles)
        {
          try
          {
            Panel elementApp = new AppElement().CreateAppElement(launcher, pathFile, dataFile, panelApps.Name);
            panelApps.AddControl(elementApp);
          }
          catch
          {
            // А вдруг какие-то данные поломались.. Не выкидывать же ошибку.
          }
        }
      }
      else
      {
        File.Create(pathFile);
      }
      panelApps.AddControl(new AddElements().CreateAddAppElement());

      return panelApps;
    }
  }
}
