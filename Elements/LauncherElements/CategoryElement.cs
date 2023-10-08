using Launcher.Controls;
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
  internal class CategoryElement
  {
    /// <summary>
    /// Возвращает элемент категории.
    /// </summary>
    /// <param name="launcher">Экземпляр формы.</param>
    /// <param name="categoriesPanel">Элемент с категориями.</param>
    /// <param name="panelApps">Элемент с приложениями.</param>
    /// <param name="functionCategories">Контекстное меню функций категории.</param>
    /// <param name="name">Имя категории.</param>
    /// <returns></returns>
    public TextControl CreateCategoryElement(Form launcher, Panel categoriesPanel, ScrollBarControl panelApps, ContextMenuStrip functionCategories, string name)
    {
      // Панель категории.
      TextControl categoryPanel = new()
      {
        Height = DataLauncherForm.sizeMainForm.Height / 15,
        Width = categoriesPanel.Width,
        Text = name,
        Name = name,
      };
      categoryPanel.MouseDown += (s, e) => CheckMouseDown(e, categoryPanel, panelApps, functionCategories, launcher);
      return categoryPanel;
    }

    /// <summary>
    /// Проверка кнопки мышки и вызов функций.
    /// </summary>
    /// <param name="e">Событие мыши.</param>
    /// <param name="categoryPanel">Панель с категориями.</param>
    /// <param name="panelApps">ПАнель с приложениями.</param>
    /// <param name="functionCategories">Контекстное меню.</param>
    /// <param name="launcher"></param>
    private void CheckMouseDown(MouseEventArgs e, TextControl categoryPanel, ScrollBarControl panelApps, ContextMenuStrip functionCategories, Form launcher)
    {
      if (e.Button == MouseButtons.Left)
        OpenCetegory(categoryPanel, panelApps, launcher);
      else if (e.Button == MouseButtons.Right)
        OpenContextMenuStrip(functionCategories);
    }

    /// <summary>
    /// Открывает категорию.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="categoryPanel"></param>
    /// <param name="panelApps"></param>
    /// <param name="launcher"></param>
    private void OpenCetegory(TextControl categoryPanel, ScrollBarControl panelApps, Form launcher)
    {
      new FunctionsCategories().LoadFunctionCategory(categoryPanel, panelApps, launcher);
    }

    /// <summary>
    /// Открывает контекстное меню элемента.
    /// </summary>
    /// <param name="functionCategories"></param>
    private void OpenContextMenuStrip(ContextMenuStrip functionCategories)
    {
      functionCategories.Show(Cursor.Position);
    }
  }
}
