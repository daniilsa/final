using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet._Front;
using LauncherNet.Controls;
using LauncherNet.Elements.LauncherElements;
using LauncherNet.Forms;
using LauncherNet.Settings;
using System.Windows.Forms.VisualStyles;

namespace LauncherNet.Functions
{
  public class FunctionsCategories
  {


    private bool openProgramm = true;

    /// <summary>
    /// Открытие категории или её функций.
    /// </summary>
    public void LoadFunctionCategory(TextControl categoryPanel, ScrollBarControl panelApps, Form launcher)
    {

      if (DataLauncherForm.activeAppPanelLauncher == panelApps && !openProgramm)
        return;
      openProgramm = false;

      if (DataLauncherForm.activeAppPanelLauncher == null)
      {
        DataLauncherForm.activeAppPanelLauncher = panelApps;
        DataLauncherForm.lastAppPanelLauncher = panelApps;

        DataLauncherForm.activeCategoryPanelLauncher = categoryPanel;
        DataLauncherForm.lastCategoryPanelLauncher = categoryPanel;
      }
      else
      {
        DataLauncherForm.lastAppPanelLauncher = DataLauncherForm.activeAppPanelLauncher;
        DataLauncherForm.activeAppPanelLauncher = panelApps;

        DataLauncherForm.lastCategoryPanelLauncher = DataLauncherForm.activeCategoryPanelLauncher;
        DataLauncherForm.activeCategoryPanelLauncher = categoryPanel;

      }

      launcher.Text = DataLauncherForm.activeAppPanelLauncher.Name;

      DataLauncherForm.appsElementLauncher?.Clear();

      foreach (var item in DataLauncherForm.activeAppPanelLauncher.Controls)
      {
        try
        {
          DataLauncherForm.appsElementLauncher?.Add(((Panel)item));
        }
        catch
        {
          // TODO: Проверить, почему тут try catch
          // Нам нужны только панели, а не Panel item он ругался. Так что это, какого-то рода, костыль)
        }
      }

      new SizeSettings().SizeElements();
      DataLauncherForm.lastAppPanelLauncher.Visible = false;
      DataLauncherForm.activeAppPanelLauncher.Visible = true;
      DataLauncherForm.activeAppPanelLauncher.Open = true;
      if (DataLauncherForm.lastCategoryPanelLauncher != null)
        new DesignLauncherForm().DesignCategoryElementLauncher(DataLauncherForm.lastCategoryPanelLauncher);

      if (DataLauncherForm.activeCategoryPanelLauncher != null)
        new DesignLauncherForm().DesignCategoryElementLauncher(DataLauncherForm.activeCategoryPanelLauncher);
    }

    /// <summary>
    /// Вызов нужного метода по клику на контекстное меню категорий.
    /// </summary>
    /// <param name="launcher">Экземпляр формы лаунчера.</param>
    /// <param name="functionCategory">Вызванная функция.</param>
    /// <param name="nameCategory">Имя категории.</param>
    public void StartFunction(Form? launcher, DataEnum.FunctionCategory functionCategory, ScrollBarControl? panelApps, string? nameCategory)
    {
      if (functionCategory == DataEnum.FunctionCategory.AddCategory) FormCategory();
      else if (functionCategory == DataEnum.FunctionCategory.RenameCategory)
      {
        if (nameCategory != null) FormRenameCategory(nameCategory);
      }
      else if (functionCategory == DataEnum.FunctionCategory.DeleteCategory)
      {
        if (nameCategory != null) DeleteCategory(nameCategory);
      }
      else if (functionCategory == DataEnum.FunctionCategory.AddApp)
      {
        if (panelApps != null && nameCategory != null) FormAddApp(panelApps, nameCategory);
        else if (panelApps != null) FormAddApp(panelApps, string.Empty);
      }

      if (launcher != null && DataClass.Update)
      {
        new UpdateClass().UpdateMethod(launcher);
        DataClass.Update = false;
      }
    }

    /// <summary>
    /// Запускает форму создания новой категории.
    /// </summary>
    private void FormCategory()
    {
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.CategoryForm(DataEnum.FunctionCategory.AddCategory, string.Empty);
    }

    /// <summary>
    /// Запускает форму переименовки категории.
    /// </summary>
    private void FormRenameCategory(string nameCategory)
    {
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.CategoryForm(DataEnum.FunctionCategory.RenameCategory, nameCategory);
    }

    /// <summary>
    /// Запускает форму для добавления приложения в опредлённую категорию.
    /// </summary>
    private void FormAddApp(ScrollBarControl panelApps, string nameCategory)
    {
      DataLauncherForm.activeAppPanelLauncher = panelApps;
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.CategoryForm(DataEnum.FunctionCategory.AddApp, nameCategory);
    }

    /// <summary>
    /// Удаляет категорию из лаунчера.
    /// </summary>
    private void DeleteCategory(string nameCategory)
    {
      DialogResult dialogResult = MessageBox.Show($@"Вы уверены что хотите удалить категорию {nameCategory}?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
      if (dialogResult == DialogResult.OK)
      {
        File.Delete($@"{DataClass.CategoriesPathFiles}\{nameCategory}");
        Directory.Delete($@"{DataClass.PathImages}\{nameCategory}", true);
      }
      DeleteCategoryForForm(nameCategory);
    }

    /// <summary>
    /// Сообщение о неподключенной функции.
    /// </summary>
    public void Default()
    {
      MessageBox.Show("Функция временно не подключена!");
    }

    /// <summary>
    /// Создаёт новую категорию.
    /// </summary>
    /// <param name="nameCategory">Имя категории.</param>
    public bool CreateCategory(string nameCategory)
    {
      FileStream? fstream = null;
      if (!File.Exists($@"{DataClass.CategoriesPathFiles}\{nameCategory}"))
      {
        try
        {
          fstream = new FileStream($@"{DataClass.CategoriesPathFiles}\{nameCategory}", FileMode.Create);
          fstream?.Close();
          Directory.CreateDirectory($@"{DataClass.PathImages}\{nameCategory}");
          AddCategory(nameCategory);
          return true;
        }
        catch
        {
          return false;
        }
      }
      else
      {
        DialogResult dialog = MessageBox.Show("Данная категория уже создана! Вы уверены что хотите удалить все данные в категории?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (dialog == DialogResult.Yes)
        {
          try
          {
            fstream = new FileStream($@"{DataClass.CategoriesPathFiles}\{nameCategory}", FileMode.Create);
            fstream?.Close();
            Directory.CreateDirectory($@"{DataClass.PathImages}\{nameCategory}");
            AddCategory(nameCategory);
            return true;
          }
          catch
          {
            return false;
          }
        }
        else
        {
          return false;
        }
      }
    }

    /// <summary>
    /// Переименовывает существующую категорию.
    /// </summary>
    /// <param name="oldName">Имя категории.</param>
    /// <param name="newName">Новое имя категории.</param>
    public bool RenameCategory(string oldName, string newName)
    {
      try
      {
        if (Directory.Exists($@"{DataClass.PathImages}\{oldName}"))
        {
          Directory.Move($@"{DataClass.PathImages}\{oldName}", $@"{DataClass.PathImages}\{newName}");
        }
        else
        {
          Directory.CreateDirectory($@"{DataClass.PathImages}\{newName}");
        }
        File.Move($@"{DataClass.CategoriesPathFiles}\{oldName}", $@"{DataClass.CategoriesPathFiles}\{newName}");
        NewNameCategory(oldName, newName);

        return true;
      }
      catch
      {
        MessageBox.Show($"Невозможно переименовать категорию, так как категория с названием \"{newName}\" уже существует!");
        return false;
      }
    }

    /// <summary>
    /// Запись данных о приложении в файл.
    /// </summary>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="pathFile">Путь к приложению.</param>
    public bool CreateApp(string nameCategory, string nameFile, string pathFile, string? imagePath, string nameImage, bool triggerImage)
    {
      if (File.Exists(pathFile))
      {
        if (File.Exists($@"{DataClass.CategoriesPathFiles}\{nameCategory}"))
        {
          string[] collection = File.ReadAllLines($@"{DataClass.CategoriesPathFiles}\{nameCategory}");
          bool next = true;
          for (int i = 0; i < collection.Length; i++)
          {
            if (collection[i].Contains(nameFile))
            {
              MessageBox.Show($@"Файл {nameFile} уже существует. Пожалуйста, введите уникально имя приложения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              next = false;
              break;
            }
          }
          if (next)
          {
            if (!triggerImage)
            {
              ImageSelectionForm iamgeForm = new()
              {
                NameFile = nameFile,
                NameCategory = nameCategory
              };
              iamgeForm.Load();
              try
              {
                iamgeForm.ShowDialog();
              }
              catch
              {
                // Форма не откроется, если нет интернета или пошли какие-то другие неполадки.
              }
            }
            else
            {
              DataLauncherForm.locationImage = imagePath;

              try
              {
                if (imagePath != null)
                  File.Copy(imagePath, $@"{DataClass.PathImages}\{nameCategory}\{nameFile}\.jpg");
              }
              catch
              {
                File.Delete($@"{DataClass.PathImages}\{nameCategory}\{nameFile}\.jpg");

                if (imagePath != null)
                  File.Copy(imagePath, $@"{DataClass.PathImages}\{nameCategory}\{nameFile}\.jpg");
              }
            }

            if (DataLauncherForm.locationImage != string.Empty || !DataClass.InternetСonnection)
            {
              if (collection.Length > 0) File.AppendAllText($@"{DataClass.CategoriesPathFiles}\{nameCategory}", $"\r\n{DataClass.Code}{nameFile}{DataClass.Code}{pathFile}{DataClass.Code}");
              else File.AppendAllText($@"{DataClass.CategoriesPathFiles}\{nameCategory}", $"{DataClass.Code}{nameFile}{DataClass.Code}{pathFile}{DataClass.Code}");

              AddApp(nameCategory, nameFile, pathFile);
            }
            else return false;
          }
          else return false;
        }
        else
        {
          DialogResult dialogResult = MessageBox.Show(@$"Категория не найдена! Хотите создать категорию с именем {nameCategory}?", "Предупреждение.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
          if (dialogResult == DialogResult.OK)
          {
            CreateCategory(nameCategory);
            CreateApp(nameCategory, nameFile, pathFile, imagePath, nameImage, triggerImage);
            return false;
          }
        }
      }
      else
      {
        MessageBox.Show($@"Не найден путь: {pathFile}.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      return true;
    }

    /// <summary>
    /// Переписывает имя категории, в котором произошли изменения.
    /// </summary>
    /// <param name="oldName">Старое имя категории.</param>
    /// <param name="newName">Новое имя категории.</param>
    private void NewNameCategory(string oldName, string newName)
    {
      if (DataLauncherForm.categoriesElementLauncher != null)
      {
        foreach (Control item in DataLauncherForm.categoriesElementLauncher.Controls)
        {
          if (item != null)
          {
            if (item.GetType() == new TextControl().GetType())
            {
              TextControl value = (TextControl)item;
              if (value.Text == oldName)
              {
                value.Text = newName;
                value.Name = newName;
                break;
              }
            }
          }
        }

        foreach (ContextMenuStrip value in DataLauncherForm.functionsCategory)
        {
          if (value != null)
          {
            if (value.Name == oldName)
            {
              value.Name = newName;
              break;
            }
          }
        }
      }
    }

    /// <summary>
    /// Добавление новой категории.
    /// </summary>
    /// <param name="nameCategory"></param>
    private void AddCategory(string nameCategory)
    {
      if (DataLauncherForm.launcher != null && DataLauncherForm.categoriesElementLauncher != null)
      {
        ScrollBarControl panelApps = new AppsElement().CreateAppsElement(DataLauncherForm.launcher, nameCategory);
        ContextMenuStrip functionCategories = new ContextMenuCategories().CreateContextMenu(DataLauncherForm.launcher, panelApps, nameCategory);
        TextControl categoryElement = new CategoryElement().CreateCategoryElement(DataLauncherForm.launcher, DataLauncherForm.categoriesElementLauncher, panelApps, functionCategories, nameCategory);
        new DesignLauncherForm().DesignCategoryElementLauncher(categoryElement);

        DataLauncherForm.categoriesElementLauncher.Controls.Add(categoryElement);

        foreach (Control item in DataLauncherForm.categoriesElementLauncher.Controls)
        {
          if (item.GetType() == new ControlAddControl().GetType())
          {
            item.Location = new(item.Location.X, item.Location.Y + categoryElement.Height);
          }
        }
      }
    }

    /// <summary>
    /// Удаление категории из приложения.
    /// </summary>
    /// <param name="nameCategory"></param>
    private void DeleteCategoryForForm(string nameCategory)
    {
      Control categoryElement = new Control();

      if (DataLauncherForm.categoriesElementLauncher != null)
      {
        foreach (Control item in DataLauncherForm.categoriesElementLauncher.Controls)
        {
          if (item.Text == nameCategory)
          {
            DataLauncherForm.categoriesElementLauncher.Controls.Remove(item);
            categoryElement = item;
          }
        }

        foreach (Control item in DataLauncherForm.categoriesElementLauncher.Controls)
        {
          if (item.GetType() == new ControlAddControl().GetType())
          {
            item.Location = new(item.Location.X, item.Location.Y - categoryElement.Height);
          }
        }
      }

    }

    private void AddApp(string nameCategory, string nameFile, string pathFileApp)
    {
      if (DataLauncherForm.launcher != null)
      {
        string pathFile = DataClass.CategoriesPathFiles + "\\" + nameCategory;
        if (File.Exists(pathFileApp))
        {
          string[] dataFiles = File.ReadAllLines(pathFile);
          foreach (string dataFile in dataFiles)
          {
            if (dataFile.Contains(nameFile))
            {
              Panel appElement = new AppElement().CreateAppElement(DataLauncherForm.launcher, pathFileApp, dataFile, nameCategory);

              foreach (ScrollBarControl value in DataLauncherForm.mainAppsLauncher)
              {
                if (value.Name == nameCategory)
                {
                  value.AddControl(appElement);
                  new DesignLauncherForm().DesignAppElementLauncher(appElement);

                  break;
                }
              }
              break;
            }
          }
        }
      }
    }
  }
}
