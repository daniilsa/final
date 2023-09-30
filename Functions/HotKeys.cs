using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LauncherNet.Functions
{
  public class HotKeys
  {
    public void CheckKeys(object s, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F5)
      {
        new SettingsForms().UpdateLauncher(DataClass.launcher);
      }
      else if (e.KeyCode == Keys.F1)
      {
        //TODO: Привязать помощь по ПО
        Console.WriteLine("Привязать помощь по ПО");
      }
      else if (e.KeyCode == Keys.X && e.Alt)
      {
        Application.Exit();
      }
      else if (e.Control)
      {
        try
        {
          if (e.KeyCode == Keys.A)
          {
            new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddApp, DataClass.activeAppPanelLauncher, DataClass.activeCategoryPanelLauncher.Name);
          }
          else if (e.KeyCode == Keys.Down)
          {
            DataClass.activeAppPanelLauncher.MouseWheelDown();
          }
          else if (e.KeyCode == Keys.Up)
          {
            DataClass.activeAppPanelLauncher.MouseWheelUp();
          }
          else
          {
            int key = (int)e.KeyCode - '0';

            if (key != 0)
              new FunctionsCategories().LoadFunctionCategory(DataClass.categoryElementLauncher[DataClass.categoryElementLauncher.Count - key], DataClass.mainAppsLauncher[DataClass.categoryElementLauncher.Count - key], DataClass.launcher);
            else if (key == 0) new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddCategory, null, null);
          }
        }
        catch
        {
          // Нет такой комбинации клавиш
        }

      }
    }
  }
}
