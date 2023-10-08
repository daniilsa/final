using LauncherNet._Data;
using LauncherNet.Controls;
using LauncherNet.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Elements.LauncherElements
{
  internal class ContextMenuCategories
  {

    /// <summary>
    /// Возвращает экземпляр конекстного меню.
    /// </summary>
    /// <param name="launcher"></param>
    /// <param name="panelApps"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public ContextMenuStrip CreateContextMenu(Form launcher, ScrollBarControl panelApps, string name)
    {
      ContextMenuStrip functionsCategory = new()
      {
        Name = name,
      };
      functionsCategory.Items.Add("Добавить приложение");
      functionsCategory.Items.Add("Переименовать категорию");
      functionsCategory.Items.Add("Создать новую категорию");
      functionsCategory.Items.Add("Удалить категорию");

      functionsCategory.Items[0].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataEnum.FunctionCategory.AddApp, panelApps, functionsCategory.Name);
      functionsCategory.Items[1].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataEnum.FunctionCategory.RenameCategory, panelApps, functionsCategory.Name);
      functionsCategory.Items[2].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataEnum.FunctionCategory.AddCategory, panelApps, functionsCategory.Name);
      functionsCategory.Items[3].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataEnum.FunctionCategory.DeleteCategory, panelApps, functionsCategory.Name);

      DataLauncherForm.functionsCategory?.Add(functionsCategory);
      return functionsCategory;
    }
  }
}
