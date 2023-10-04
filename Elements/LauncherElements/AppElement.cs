using Launcher.Controls;
using LauncherNet._Front;
using LauncherNet.Controls;
using LauncherNet.Functions;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LauncherNet.Elements.LauncherElements
{
  internal class AppElement
  {
    /// <summary>
    /// Создаёт и настраивает элемент приложения.
    /// </summary>
    /// <param name="pathFile">Путь к файлу.</param>
    /// <param name="dataFile">Данные о приложении.</param>
    /// <param name="nameCategory">Имя категориию</param>
    /// <returns></returns>
    public Panel CreateAppElement(Form launcher, string pathFile, string dataFile, string nameCategory)
    {
      string nameFile = string.Empty;
      string pathApp = string.Empty;
      DataDivision(dataFile, ref nameFile, ref pathApp);

      // Главная панель
      Panel fileСontrols = new()
      {
        Size = new Size(DataClass.sizeAppElement.Width, DataClass.sizeAppElement.Height)
      };

      // Картинка файла
      PictureBox pictureBoxImageApp = new()
      {
        Height = DataClass.sizeAppElement.Height - 40,
        Dock = DockStyle.Top,
        Name = nameFile,
        Tag = nameCategory
      };

      // Для запуска файла
      TextControl labelFileName = new()
      {
        Height = fileСontrols.Height - pictureBoxImageApp.Height,
        Width = pictureBoxImageApp.Width,
        Dock = DockStyle.Bottom,
        Text = nameFile,
      };

      labelFileName.MouseEnter += (s, a) => labelFileName.Text = "Открыть";
      labelFileName.MouseLeave += (s, a) => labelFileName.Text = nameFile;

      ContextMenuStrip functionApp = CreateContextMenu(launcher, pathFile,pathApp,nameCategory,nameFile);

      //Действие на ЛКМ и ПКМ
      labelFileName.MouseDown += (s, e) => CheckMouseDown(e, pathFile, pathApp, functionApp);

      //Собираем всё вместе
      fileСontrols.Controls.Add(pictureBoxImageApp);
      fileСontrols.Controls.Add(labelFileName);
      return fileСontrols;
    }

    /// <summary>
    /// Возвращает экземпляр контекстного меню.
    /// </summary>
    /// <param name="launcher">Экзепляр формцы.</param>
    /// <param name="pathFile">Путь к файлу со всеми приложениями.</param>
    /// <param name="pathApp">Путь к приложению.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя приложения</param>
    /// <returns></returns>
    private ContextMenuStrip CreateContextMenu(Form launcher, string pathFile, string pathApp, string nameCategory, string nameFile)
    {
      ContextMenuStrip functionApp = new();
      functionApp.Items.Add("Открыть");
      functionApp.Items.Add("Расположение файла");
      functionApp.Items.Add("Сменить обложку");
      functionApp.Items.Add("Удалить файл из лаунчера");

      functionApp.Items[0].Click += (s, e) => new FunctionsApps().StartApp(pathFile, pathApp);
      functionApp.Items[1].Click += (s, e) => new FunctionsApps().LocationApp(launcher, pathApp, nameCategory, nameFile);
      functionApp.Items[2].Click += (s, e) =>
      {
        new FunctionsApps().FormImage(nameCategory, nameFile);
        if (DataClass.update)
        {
          DataClass.update = false;
          new SettingsForms().UpdateLauncher(launcher);
        }
      };
      functionApp.Items[3].Click += (s, e) => new FunctionsApps().DeleteApp(launcher, nameCategory, nameFile, false);

      DataClass.functionApp.Add(functionApp);
      return functionApp;
    }

    /// <summary>
    /// Деление данных. Вытаскивает имя и путь приложения.
    /// </summary>
    /// <param name="data">Данные о приложении.</param>
    /// <param name="nameFile">Имя приложения.</param>
    /// <param name="pathApp">Путь к приложению.</param>
    private void DataDivision(string data, ref string nameFile, ref string pathApp)
    {
      int indexFerst = data.IndexOf(DataClass.code) + DataClass.code.Length;
      int indexLast = data.IndexOf("$", indexFerst);
      nameFile = data[indexFerst..indexLast];

      indexFerst = indexLast + DataClass.code.Length;
      indexLast = data.IndexOf("$", indexFerst);
      pathApp = data[indexFerst..indexLast];
    }

    /// <summary>
    /// Проверка кнопки мышки и вызов функций.
    /// </summary>
    /// <param name="e">Событие мыши.</param>
    /// <param name="categoryPanel">Панель с категориями.</param>
    /// <param name="panelApps">ПАнель с приложениями.</param>
    /// <param name="functionCategories">Контекстное меню.</param>
    /// <param name="launcher"></param>
    private void CheckMouseDown(MouseEventArgs e, string pathFile, string pathApp, ContextMenuStrip functionApp)
    {
      if (e.Button == MouseButtons.Left)
        OpenApp(pathFile, pathApp);
      else if (e.Button == MouseButtons.Right)
        OpenContextMenuStrip(functionApp);

    }

    /// <summary>
    /// Открывает категорию.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="categoryPanel"></param>
    /// <param name="panelApps"></param>
    /// <param name="launcher"></param>
    private void OpenApp(string pathFile, string pathApp)
    {
      new FunctionsApps().StartApp(pathFile, pathApp);
    }

    /// <summary>
    /// Откровыает контекстное меню элемента.
    /// </summary>
    /// <param name="functionCategories"></param>
    private void OpenContextMenuStrip(ContextMenuStrip functionCategories)
    {
      functionCategories.Show(Cursor.Position);
    }

  }
}
