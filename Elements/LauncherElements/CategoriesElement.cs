using Launcher.Controls;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Front;
using LauncherNet.Functions;
using System.Xml.Linq;

namespace LauncherNet.Elements.LauncherElements
{
  internal class CategoriesElement
  {
    /// <summary>
    /// Создаёт и настраивает экземпляр панели с категориями.
    /// </summary>
    /// <param name="launcher">Экземпляр формы.</param>
    public void CreateCategoriesElement(Form launcher)
    {
      // Панель с категориями.
      Panel categoriesPanel = new();
      if (DataClass.topElementLauncher != null)
      {
        categoriesPanel.Size = new Size(DataClass.sizeForm.Width / 8, DataClass.sizeForm.Height - DataClass.topElementLauncher.Height - DataClass.borderFormWidth);
        categoriesPanel.Location = new Point(DataClass.borderFormWidth, DataClass.topElementLauncher.Height);
      }

      DataClass.categoriesElementLauncher = categoriesPanel;
      launcher.Controls.Add(categoriesPanel);

      string[] nameFile = Directory.GetFiles(DataClass.categoriesPathFiles);

      for (int i = nameFile.Length - 1; i >= 0; i--)
      {
        string name = nameFile[i][(nameFile[i].LastIndexOf("\\") + 1)..];

        //Панель со всеми приложениями
        ScrollBarControl panelApps = new AppsElement().CreateAppsElement(launcher, name);
        launcher.Controls.Add(panelApps);

        ContextMenuStrip functionCategories = CreateContextMenu(launcher, panelApps, name);
        TextControl categoryPanel = CreateCategoryElement(launcher, categoriesPanel, panelApps, functionCategories, name);
        CheckLastCategory(categoryPanel, panelApps);

        DataClass.mainAppsLauncher?.Add(panelApps);
        DataClass.categoryElementLauncher?.Add(categoryPanel);

        categoriesPanel.Controls.Add(categoryPanel);
      }

      ControlAddControl addCategoryElement = new AddElements().CreateAddCategoryElement(categoriesPanel);
      categoriesPanel.Controls.Add(addCategoryElement);
    }

    /// <summary>
    /// Возвращает элемент категории.
    /// </summary>
    /// <param name="launcher">Экземпляр формы.</param>
    /// <param name="categoriesPanel">Элемент с категориями.</param>
    /// <param name="panelApps">Элемент с приложениями.</param>
    /// <param name="functionCategories">Контекстное меню функций категории.</param>
    /// <param name="name">Имя категории.</param>
    /// <returns></returns>
    private TextControl CreateCategoryElement(Form launcher, Panel categoriesPanel, ScrollBarControl panelApps, ContextMenuStrip functionCategories, string name)
    {
      // Панель категории.
      TextControl categoryPanel = new()
      {
        Height = DataClass.sizeForm.Height / 15,
        Width = categoriesPanel.Width,
        Text = name,
        Name = name,
      };
      categoryPanel.MouseDown += (s, e) => CheckMouseDown(e, categoryPanel, panelApps, functionCategories, launcher);

      return categoryPanel;
    }

    /// <summary>
    /// Проверка последней активной категории прошлого сеанса.
    /// </summary>
    /// <param name="categoryPanel"></param>
    /// <param name="panelApps"></param>
    private void CheckLastCategory(TextControl categoryPanel, ScrollBarControl panelApps)
    {
      string lastCategory = new LastSessionClass().GetCategory();
      if (categoryPanel.Text == lastCategory)
      {
        DataClass.lastAppPanelLauncher = panelApps;
        DataClass.lastCategoryPanelLauncher = categoryPanel;
        DataClass.activeAppPanelLauncher = panelApps;
        DataClass.activeCategoryPanelLauncher = categoryPanel;
        DataClass.activeCategory = true;
      }
    }

    /// <summary>
    /// Возвращает экземпляр конекстного меню.
    /// </summary>
    /// <param name="launcher"></param>
    /// <param name="panelApps"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private ContextMenuStrip CreateContextMenu(Form launcher, ScrollBarControl panelApps, string name)
    {

      ContextMenuStrip functionCategories = new();
      functionCategories.Items.Add("Добавить приложение");
      functionCategories.Items.Add("Переименовать категорию");
      functionCategories.Items.Add("Создать новую категорию");
      functionCategories.Items.Add("Удалить категорию");

      functionCategories.Items[0].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddApp, panelApps, name);
      functionCategories.Items[1].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.RenameCategory, panelApps, name);
      functionCategories.Items[2].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddCategory, panelApps, name);
      functionCategories.Items[3].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.DeleteCategory, panelApps, name);

      DataClass.functionCategories.Add(functionCategories);
      return functionCategories;
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
