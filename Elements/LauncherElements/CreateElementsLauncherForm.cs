using LauncherNet._Data;
using LauncherNet.Functions;

namespace LauncherNet.Elements.LauncherElements
{
  public class CreateElementsLauncherForm
  {
    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="launcher">"Экземпляр формы.</param>
    public void LoadElements(Form launcher)
    {
      DataLauncherForm.activeCategory = false;

      DataLauncherForm.topElementLauncher = new TopElement().CreateTopElement(launcher);
      launcher.Controls.Add(DataLauncherForm.topElementLauncher);
      if (DataClass.TrayActive)
        DataClass.iconLauncher = new Tray().CreateTrayElement();

      new CategoriesElement().CreateCategoriesElement(launcher);
      if (DataLauncherForm.activeCategory && DataLauncherForm.activeCategoryPanelLauncher != null && DataLauncherForm.activeAppPanelLauncher != null)
        new FunctionsCategories().LoadFunctionCategory(DataLauncherForm.activeCategoryPanelLauncher, DataLauncherForm.activeAppPanelLauncher, launcher);
    }
  }
}
