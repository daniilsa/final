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

      new CategoriesElement().CreateCategoriesElement(launcher);
      if (DataClass.activeCategory) new FunctionsCategories().LoadFunctionCategory(DataClass.activeCategoryPanelLauncher, DataClass.activeAppPanelLauncher, launcher);
    }
  }
}
