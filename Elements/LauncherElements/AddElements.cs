using LauncherNet._Data;
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
    public ControlAddControl CreateAddCategoryElement(ScrollBarControl categoriesPanel)
    {
      ControlAddControl controlAddElement = new()
      {
        Height = DataLauncherForm.sizeMainForm.Height / 15,
        Width = categoriesPanel.Width,
        Name = "PlusCategories",
        SizePlus = 4,
      };

      if (DataLauncherForm.categoryElementLauncher != null)
      {
        controlAddElement.Location = new Point(0, DataLauncherForm.categoryElementLauncher.Count * controlAddElement.Height);
      }
      controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataLauncherForm.launcher, DataEnum.FunctionCategory.AddCategory, null, null);
      DataLauncherForm.controlAddCategory = controlAddElement;
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
        Height = DataLauncherForm.sizeAppElement.Height,
        Width = DataLauncherForm.sizeAppElement.Width,
        Name = "PlusApp",
        SizePlus = 6,
      };

      if (DataLauncherForm.activeCategoryPanelLauncher != null)
      {
        controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataLauncherForm.launcher, DataEnum.FunctionCategory.AddApp, DataLauncherForm.activeAppPanelLauncher, DataLauncherForm.activeCategoryPanelLauncher.Name);
      }
      else
      {
        controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataLauncherForm.launcher, DataEnum.FunctionCategory.AddApp, DataLauncherForm.activeAppPanelLauncher, string.Empty);
      }
      DataLauncherForm.controlAddApp?.Add(controlAddElement);
      return controlAddElement;
    }

  }
}
