using LauncherNet.Controls;
using LauncherNet.Functions;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LauncherNet.DataClass;

namespace LauncherNet.Elements.LauncherElements
{
  internal class AddElements
  {

    /// <summary>
    /// Элемент добавления категории.
    /// </summary>
    /// <returns></returns>
    public ControlAddElement CreateAddCategoryElement(Panel categoriesPanel)
    {
      ControlAddElement controlAddElement = new()
      {
        Height = DataClass.sizeForm.Height / 15,
        Width = categoriesPanel.Width,
        Name = "PlusCategories",
        SizePlus = 4,
      };
      controlAddElement.Location = new Point(0, DataClass.categoryElementLauncher.Count * controlAddElement.Height);
      controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddCategory, null, null);
      DataClass.controlAddCategory = controlAddElement;
      return controlAddElement;
    }

    /// <summary>
    /// Элемент добавления категории.
    /// </summary>
    /// <param name="categoriesPanel">Панель с категориями.</param>
    /// <returns></returns>
    public ControlAddElement CreateAddAppElement()
    {
      ControlAddElement controlAddElement = new()
      {
        Height = sizeAppElement.Height,
        Width = sizeAppElement.Width,
        Name = "PlusApp",
        SizePlus = 6,
      };

      controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(launcher, FunctionCategory.AddApp, activeAppPanelLauncher, activeCategoryPanelLauncher.Name);
      controlAddApp.Add(controlAddElement);
      return controlAddElement;
    }

  }
}
