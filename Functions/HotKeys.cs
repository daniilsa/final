using LauncherNet._Data;
using LauncherNet._DataStatic;
using LauncherNet._Front;
using LauncherNet.Files;
using LauncherNet.Forms;
using LauncherNet.Settings;
using System.Diagnostics;

namespace LauncherNet.Functions
{
  public class HotKeys
  {
    public void CheckKeys(object s, KeyEventArgs e)
    {
      if (DataLauncherForm.launcher != null && e.KeyCode == Keys.F5)
      {
        new UpdateClass().UpdateMethod(DataLauncherForm.launcher);
      }
      else if (e.KeyCode == Keys.F1)
      {
        ////TODO: Привязать помощь по ПО
        //if (DataHelpForm.helpForm != null)
        //{
        //  DataHelpForm.helpForm.Focus();
        //  DataHelpForm.helpForm.Activate();
        //}
        //else
        //{
        //  new HelpForm().Show();
        //}

        if (!DataClass.HelpExist)
          MessageBox.Show("Помощь отсутвует!","Внимание!",MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            new SettingsApplicationForm(null, false).ShowDialog();
            WorkingColor.RewritingColor();
            new DesignLauncherForm().LoadDesignLauncher();
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
