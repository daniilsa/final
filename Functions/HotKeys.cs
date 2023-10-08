﻿using LauncherNet._Data;
using LauncherNet._DataStatic;
using LauncherNet.Forms;
using LauncherNet.Settings;

namespace LauncherNet.Functions
{
  public class HotKeys
  {
    public void CheckKeys(object s, KeyEventArgs e)
    {
      if (DataLauncherForm.launcher != null && e.KeyCode == Keys.F5)
      {
        new SettingsForms().UpdateLauncher(DataLauncherForm.launcher);
      }
      else if (e.KeyCode == Keys.F1)
      {
        //TODO: Привязать помощь по ПО
        if (DataHelpForm.helpForm != null)
        {
          DataHelpForm.helpForm.Focus();
          DataHelpForm.helpForm.Activate();
        }
        else
        {
          new HelpForm().Show();
        }
      }
      else if (e.KeyCode == Keys.X && e.Alt)
      {
        Application.Exit();
      }
      else if (DataLauncherForm.launcher != null && e.Control)
      {
        try
        {
          if (e.KeyCode == Keys.A)
          {
            if (DataLauncherForm.activeCategoryPanelLauncher != null)
              new FunctionsCategories().StartFunction(DataLauncherForm.launcher, DataEnum.FunctionCategory.AddApp, DataLauncherForm.activeAppPanelLauncher, DataLauncherForm.activeCategoryPanelLauncher.Name);
            else
              new FunctionsCategories().StartFunction(DataLauncherForm.launcher, DataEnum.FunctionCategory.AddApp, DataLauncherForm.activeAppPanelLauncher, string.Empty);
          }
          else if (e.KeyCode == Keys.O)
          {
            MessageBox.Show("Добавить настройки программы");
          }
          else if (e.KeyCode == Keys.Down)
          {
            DataLauncherForm.activeAppPanelLauncher?.MouseWheelDown();
          }
          else if (e.KeyCode == Keys.Up)
          {
            DataLauncherForm.activeAppPanelLauncher?.MouseWheelUp();
          }
          else
          {
            int key = (int)e.KeyCode - '0';

            if (DataLauncherForm.categoryElementLauncher != null && DataLauncherForm.mainAppsLauncher != null && key != 0)
              new FunctionsCategories().LoadFunctionCategory(DataLauncherForm.categoryElementLauncher[DataLauncherForm.categoryElementLauncher.Count - key], DataLauncherForm.mainAppsLauncher[DataLauncherForm.categoryElementLauncher.Count - key], DataLauncherForm.launcher);
            else if (key == 0) new FunctionsCategories().StartFunction(DataLauncherForm.launcher, DataEnum.FunctionCategory.AddCategory, null, null);
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
