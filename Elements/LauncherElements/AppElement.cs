using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.Functions;
using LauncherNet.Settings;

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
        Size = new Size(DataLauncherForm.sizeAppElement.Width, DataLauncherForm.sizeAppElement.Height),
        Name = nameFile,
      };

      // Картинка файла
      PictureBox pictureBoxImageApp = new()
      {
        Height = DataLauncherForm.sizeAppElement.Height - 40,
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

      ContextMenuStrip functionsApp = CreateContextMenu(launcher, pathFile, pathApp, nameCategory, nameFile);

      //Действие на ЛКМ и ПКМ
      labelFileName.MouseDown += (s, e) => CheckMouseDown(e, pathFile, pathApp, functionsApp);

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
      ContextMenuStrip functionsApp = new();
      functionsApp.Items.Add("Открыть");
      functionsApp.Items.Add("Расположение файла");
      functionsApp.Items.Add("Сменить обложку");
      functionsApp.Items.Add("Удалить файл из лаунчера");

      functionsApp.Items[0].Click += (s, e) => new FunctionsApps().StartApp(pathFile, pathApp);
      functionsApp.Items[1].Click += (s, e) => new FunctionsApps().LocationApp(launcher, pathApp, nameCategory, nameFile);
      functionsApp.Items[2].Click += (s, e) =>
      {
        new FunctionsApps().FormImage(nameCategory, nameFile);
        if (DataClass.Update)
        {
          DataClass.Update = false;
          new UpdateClass().UpdateMethod(launcher);
        }
      };
      functionsApp.Items[3].Click += (s, e) => new FunctionsApps().DeleteApp(nameCategory, nameFile, false);
      DataLauncherForm.functionsApp?.Add(functionsApp);
      return functionsApp;
    }

    /// <summary>
    /// Деление данных. Вытаскивает имя и путь приложения.
    /// </summary>
    /// <param name="data">Данные о приложении.</param>
    /// <param name="nameFile">Имя приложения.</param>
    /// <param name="pathApp">Путь к приложению.</param>
    private void DataDivision(string data, ref string nameFile, ref string pathApp)
    {
      int indexFerst = data.IndexOf(DataClass.Code) + DataClass.Code.Length;
      int indexLast = data.IndexOf("$", indexFerst);
      nameFile = data[indexFerst..indexLast];

      indexFerst = indexLast + DataClass.Code.Length;
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
