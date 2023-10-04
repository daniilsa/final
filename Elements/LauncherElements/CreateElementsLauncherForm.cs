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
      DataClass.activeCategory = false;
      DataClass.drag = false;

      DataClass.topElementLauncher = new TopElement().CreateTopElement(launcher);
      launcher.Controls.Add(DataClass.topElementLauncher);
      if (DataClass.trayActive)
        DataClass.iconLauncher = new Tray().CreateTrayElement();

      new CategoriesElement().CreateCategoriesElement(launcher);
      if (DataClass.activeCategory && DataClass.activeCategoryPanelLauncher != null && DataClass.activeAppPanelLauncher != null)
        new FunctionsCategories().LoadFunctionCategory(DataClass.activeCategoryPanelLauncher, DataClass.activeAppPanelLauncher, launcher);
    }
  }
}
