using LauncherNet._Data;
using LauncherNet.Controls;

namespace LauncherNet.Elements.LauncherElements
{
  internal class AppsElement
  {

    /// <summary>
    /// Создаёт и настраивает панель с файлами определённой категории.
    /// </summary>
    /// <param name="nameCategory">Имя категории</param>
    /// <returns></returns>
    public ScrollBarControl CreateAppsElement(Form launcher, string nameCategory)
    {
      ScrollBarControl panelApps = new()
      {
        Visible = false,
        Name = nameCategory,
        BackColor = Color.Green,
        ScrollElements = ScrollBarControl.ScrollControls.Apps,
      };

      panelApps.AddControl(new AddElements().CreateAddAppElement());

      if (DataLauncherForm.categoriesElementLauncher != null)
      {
        panelApps.Width = DataLauncherForm.sizeMainForm.Width - DataLauncherForm.categoriesElementLauncher.Width - DataClass.borderFormWidth;
        panelApps.Height = DataLauncherForm.categoriesElementLauncher.Height;

        if (DataLauncherForm.topElementLauncher != null)
          panelApps.Location = new Point(DataLauncherForm.categoriesElementLauncher.Width, DataLauncherForm.topElementLauncher.Height);
      }

      string pathFile = DataClass.CategoriesPathFiles + "\\" + nameCategory;

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
   

      return panelApps;
    }
  }
}
