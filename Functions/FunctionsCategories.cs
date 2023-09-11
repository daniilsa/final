using Launcher.Controls;
using LauncherNet.Elements;
using LauncherNet.Forms;
using LauncherNet.Settings;
using System;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LauncherNet.Functions
{
  public class FunctionsCategories
  {
    /// <summary>
    /// Открытие категории или её функций.
    /// </summary>
    public void LoadFunctionCategory(MouseEventArgs e, ContextMenuStrip contextMenuButton, CategoryPanelControl categoryPanel, Panel panelApps, Form launcher)
    {
      if (e == null || e.Button == MouseButtons.Left)
      {
        categoryPanel.BackColor = Color.Red;
        if (DataClass.activeAppPanel == null)
        {
          DataClass.activeAppPanel = panelApps;
          DataClass.lastAppPanel = panelApps;
        }
        else
        {
          DataClass.lastAppPanel = DataClass.activeAppPanel;
          DataClass.activeAppPanel = panelApps;
        }
        DataClass.lastAppPanel.Visible = false;
        DataClass.activeAppPanel.Visible = true;
        launcher.Text = DataClass.activeAppPanel.Name;

        DataClass.allApps.Clear();

        foreach (Panel item in DataClass.activeAppPanel.Controls)
        {
          DataClass.allApps.Add(item);
        }

        new ElementsLauncherForm().LocationApps();
      }
      else if (e.Button == MouseButtons.Right)
      {
        LoadContextMenu(contextMenuButton);
      }
    }

    private void LoadContextMenu(ContextMenuStrip contextMenuButton)
    {
      contextMenuButton.Show(System.Windows.Forms.Cursor.Position);
    }

    /// <summary>
    /// Вызов нужного метода по клику на контекстное меню категорий.
    /// </summary>
    /// <param name="launcher">Экземпляр формы лаунчера.</param>
    /// <param name="functionCategory">Вызванная функция.</param>
    /// <param name="nameCategory">Имя категории.</param>
    public void StartFunction(Form launcher, DataClass.FunctionCategory functionCategory, Panel panelApps, string nameCategory)
    {
      if (functionCategory == DataClass.FunctionCategory.AddCategory) FormCategory(nameCategory);
      else if (functionCategory == DataClass.FunctionCategory.RenameCategory) FormRenameCategory(nameCategory);
      else if (functionCategory == DataClass.FunctionCategory.DeleteCategory) Delete(nameCategory);
      else if (functionCategory == DataClass.FunctionCategory.AddApp) FormAddApp(panelApps, nameCategory);
      new SettingsForms().UpdateLauncher(launcher);
    }

    /// <summary>
    /// Запускает форму создания новой категории.
    /// </summary>
    private void FormCategory(string nameCategory)
    {
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.CategoryForm(DataClass.FunctionCategory.AddCategory, nameCategory);
    }

    /// <summary>
    /// Запускает форму переименовки категории.
    /// </summary>
    private void FormRenameCategory(string nameCategory)
    {
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.CategoryForm(DataClass.FunctionCategory.RenameCategory, nameCategory);
    }

    /// <summary>
    /// Запускает форму для добавления приложения в опредлённую категорию.
    /// </summary>
    private void FormAddApp(Panel panelApps, string nameCategory)
    {
      DataClass.activeAppPanel = panelApps;
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.CategoryForm(DataClass.FunctionCategory.AddApp, nameCategory);
    }

    /// <summary>
    /// Удаляет категорию из лаунчера.
    /// </summary>
    private void Delete(string nameCategory)
    {
      DialogResult dialogResult = MessageBox.Show($@"Вы уверены что хотите удалить категорию {nameCategory}?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
      if (dialogResult == DialogResult.OK)
        File.Delete($@"{DataClass.categoriesPathFiles}\{nameCategory}");
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
    public void CreateCategory(string nameCategory)
    {
      FileStream fstream = null;
      try
      {
        fstream = new FileStream($@"{DataClass.categoriesPathFiles}\{nameCategory}", FileMode.Create);
      }
      finally
      {
        fstream?.Close();
      }
    }

    /// <summary>
    /// Переименовывает существующую категорию.
    /// </summary>
    /// <param name="oldName">Имя категории.</param>
    /// <param name="newName">Новое имя категории.</param>
    public void RenameCategory(string oldName, string newName)
    {
      File.Move($@"{DataClass.categoriesPathFiles}\{oldName}", $@"{DataClass.categoriesPathFiles}\\{newName}");
      Task.Delay(1000).Wait();
    }

    /// <summary>
    /// Запись данных о приложении в файл.
    /// </summary>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="pathFile">Путь к приложению.</param>
    public void CreateApp(string nameCategory, string nameFile, string pathFile, string imagePath, string nameImage, bool triggerImage)
    {
      if (File.Exists(pathFile))
      {
        if (File.Exists($@"{DataClass.categoriesPathFiles}\{nameCategory}"))
        {
          string[] collection = File.ReadAllLines($@"{DataClass.categoriesPathFiles}\{nameCategory}");
          bool next = true;
          for (int i = 0; i < collection.Length; i++)
          {
            if (collection[i].Contains(nameFile))
            {
              MessageBox.Show($@"Файл {nameFile} уже существует.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
              next = false;
              break;
            }
          }

          if (next)
          {
            if (!triggerImage) new SearchImage().StartSearch(nameCategory, nameFile);
            else
            {
              try
              {
                File.Copy(imagePath, $@"{DataClass.pathImages}\{nameCategory}\{nameFile}\.jpg");
              }
              catch
              {
                File.Delete($@"{DataClass.pathImages}\{nameCategory}\{nameFile}\.jpg");
                File.Copy(imagePath, $@"{DataClass.pathImages}\{nameCategory}\{nameFile}\.jpg");
              }
            }
            if (collection.Length>0) File.AppendAllText($@"{DataClass.categoriesPathFiles}\{nameCategory}",$"\r\n{DataClass.code}{nameFile}{DataClass.code}{pathFile}{DataClass.code}");
            else File.AppendAllText($@"{DataClass.categoriesPathFiles}\{nameCategory}",$"{DataClass.code}{nameFile}{DataClass.code}{pathFile}{DataClass.code}");
          }
        }
        else
        {
          DialogResult dialogResult = MessageBox.Show(@$"Категория не найдена! Хотите создать категорию с именем {nameCategory}?", "Предупреждение.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
          if (dialogResult == DialogResult.OK)
          {
            CreateCategory(nameCategory);
            CreateApp(nameCategory, nameFile, pathFile, imagePath, nameImage, triggerImage);
            return;
          }
        }
      }
      else
      {
        MessageBox.Show($@"Не найден путь: {pathFile}.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

  }
}
