using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.Functions;

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
      ScrollBarControl categoriesPanel = new(DataLauncherForm.sizeMainForm.Width / 8)
      {
        ScrollElements = ScrollBarControl.ScrollControls.Categories,
        Tag = "Categories",
      };
      ControlAddControl addCategoryElement = new AddElements().CreateAddCategoryElement(categoriesPanel);
      categoriesPanel.AddControl(addCategoryElement);

      if (DataLauncherForm.topElementLauncher != null)
      {
        categoriesPanel.Size = new Size(DataLauncherForm.sizeMainForm.Width / 8, DataLauncherForm.sizeMainForm.Height - DataLauncherForm.topElementLauncher.Height - DataClass.borderFormWidth);
        categoriesPanel.Location = new Point(DataClass.borderFormWidth, DataLauncherForm.topElementLauncher.Height);
      }

      DataLauncherForm.categoriesElementLauncher = categoriesPanel;
      launcher.Controls.Add(categoriesPanel);

      string[] nameFile = Directory.GetFiles(DataClass.CategoriesPathFiles);

      for (int i = nameFile.Length - 1; i >= 0; i--)
      {
        string name = nameFile[i][(nameFile[i].LastIndexOf("\\") + 1)..];

        //Панель со всеми приложениями
        ScrollBarControl panelApps = new AppsElement().CreateAppsElement(launcher, name);
        launcher.Controls.Add(panelApps);

        ContextMenuStrip functionCategories = new ContextMenuCategories().CreateContextMenu(launcher, panelApps, name);
        TextControl categoryPanel = new CategoryElement().CreateCategoryElement(launcher, categoriesPanel, panelApps, functionCategories, name);
        CheckLastCategory(categoryPanel, panelApps);

        DataLauncherForm.mainAppsLauncher?.Add(panelApps);
        DataLauncherForm.categoryElementLauncher?.Add(categoryPanel);

        categoriesPanel.AddControl(categoryPanel);
      }

 
     
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
        DataLauncherForm.lastAppPanelLauncher = panelApps;
        DataLauncherForm.lastCategoryPanelLauncher = categoryPanel;
        DataLauncherForm.activeAppPanelLauncher = panelApps;
        DataLauncherForm.activeCategoryPanelLauncher = categoryPanel;
        DataLauncherForm.activeCategory = true;
      }
    }







  }
}
