﻿using Launcher.Controls;
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
    public void LoadFunctionCategory(MouseEventArgs e, ContextMenuStrip contextMenuButton, TextElement categoryPanel, Panel panelApps, Form launcher)
    {
      if (e == null || e.Button == MouseButtons.Left)
      {
        if (DataClass.activeAppPanel == null)
        {
          DataClass.activeAppPanel = panelApps;
          DataClass.lastAppPanel = panelApps;

          DataClass.activeCategoryPanel = categoryPanel;
          DataClass.lastCategoryPanel = categoryPanel;
        }
        else
        {
          DataClass.lastAppPanel = DataClass.activeAppPanel;
          DataClass.activeAppPanel = panelApps;

          DataClass.lastCategoryPanel = DataClass.activeCategoryPanel;
          DataClass.activeCategoryPanel = categoryPanel;

        }
        DataClass.lastAppPanel.Visible = false;
        DataClass.activeAppPanel.Visible = true;

        //TODO: На подумать
        //DataClass.lastCategoryPanel.BackColor = new ColorElements().GetHeaderColor();
        //DataClass.activeCategoryPanel.BackColor = new ColorElements().GetActiveHeaderColor();
        //
        //DataClass.lastCategoryPanel.ForeColor = new FontElements().GetHeaderFontColor();
        //DataClass.activeCategoryPanel.ForeColor = new FontElements().GetActiveHeaderFontColor();

        launcher.Text = DataClass.activeAppPanel.Name;

        DataClass.appsElement.Clear();

        foreach (var item in DataClass.activeAppPanel.Controls)
        {
          try
          {
            DataClass.appsElement.Add((item as Panel));
          }
          catch { }
        }

        new ElementsLauncherForm().LocationApps();
        new ElementsLauncherForm().SizeElements();

      }
      else if (e.Button == MouseButtons.Right)
      {
        contextMenuButton.Show(System.Windows.Forms.Cursor.Position);
      }
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

      if (DataClass.update)
      {
        new SettingsForms().UpdateLauncher(launcher);
        DataClass.update = false;
      }
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
      File.Move($@"{DataClass.categoriesPathFiles}\{oldName}", $@"{DataClass.categoriesPathFiles}\{newName}");
      Directory.Move($@"{DataClass.pathImages}\{oldName}", $@"{DataClass.pathImages}\{newName}");
      Task.Delay(1000).Wait();
    }

    /// <summary>
    /// Запись данных о приложении в файл.
    /// </summary>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="pathFile">Путь к приложению.</param>
    public bool CreateApp(string nameCategory, string nameFile, string pathFile, string imagePath, string nameImage, bool triggerImage)
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
              MessageBox.Show($@"Файл {nameFile} уже существует. Пожалуйста, введите уникально имя приложения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              next = false;
              break;
            }
          }

          if (next)
          {
            //TODO: Триггер для теста формы поиска картинок, потом выключить
            //triggerImage = true;

            if (!triggerImage)
            {
              ImageSelectionForm iamgeForm = new ImageSelectionForm();
              iamgeForm.NameFile = nameFile;
              iamgeForm.NameCategory = nameCategory;
              iamgeForm.Load();
              iamgeForm.ShowDialog();
            } /*new SearchImage().StartSearch(nameCategory, nameFile);*/
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
            if (collection.Length > 0) File.AppendAllText($@"{DataClass.categoriesPathFiles}\{nameCategory}", $"\r\n{DataClass.code}{nameFile}{DataClass.code}{pathFile}{DataClass.code}");
            else File.AppendAllText($@"{DataClass.categoriesPathFiles}\{nameCategory}", $"{DataClass.code}{nameFile}{DataClass.code}{pathFile}{DataClass.code}");
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
  }
}
