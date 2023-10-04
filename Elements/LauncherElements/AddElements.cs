using LauncherNet.Controls;
using LauncherNet.Functions;

namespace LauncherNet.Elements.LauncherElements
{
  internal class AddElements
  {

    /// <summary>
    /// Элемент добавления категории.
    /// </summary>
    /// <returns></returns>
    public ControlAddControl CreateAddCategoryElement(Panel categoriesPanel)
    {
      ControlAddControl controlAddElement = new()
      {
        Height = DataClass.sizeForm.Height / 15,
        Width = categoriesPanel.Width,
        Name = "PlusCategories",
        SizePlus = 4,
      };

      if (DataClass.categoryElementLauncher != null)
      {
        controlAddElement.Location = new Point(0, DataClass.categoryElementLauncher.Count * controlAddElement.Height);
      }
      controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddCategory, null, null);
      DataClass.controlAddCategory = controlAddElement;
      return controlAddElement;
    }

    /// <summary>
    /// Элемент добавления категории.
    /// </summary>
    /// <param name="categoriesPanel">Панель с категориями.</param>
    /// <returns></returns>
    public ControlAddControl CreateAddAppElement()
    {
      ControlAddControl controlAddElement = new()
      {
        Height = DataClass.sizeAppElement.Height,
        Width = DataClass.sizeAppElement.Width,
        Name = "PlusApp",
        SizePlus = 6,
      };

      if (DataClass.activeCategoryPanelLauncher != null)
      {
        controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddApp, DataClass.activeAppPanelLauncher, DataClass.activeCategoryPanelLauncher.Name);
      }
      else
      {
        controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddApp, DataClass.activeAppPanelLauncher, string.Empty);
      }
        DataClass.controlAddApp?.Add(controlAddElement);
      return controlAddElement;
    }

  }
}
