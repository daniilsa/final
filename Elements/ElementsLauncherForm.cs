using Launcher.Controls;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.Functions;
using LauncherNet.Settings;
using static LauncherNet.DataClass;

namespace LauncherNet.Elements
{
  public class ElementsLauncherForm
  {

    private bool activeCategory;

    /// <summary>
    /// Перетаскивание формы
    /// </summary>
    private bool drag;

    /// <summary>
    /// Стартовая позиция.
    /// </summary>
    private Point startPoint = new(0, 0);

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="launcher">"Экземпляр формы.</param>
    public void LoadElements(Form launcher)
    {
      activeCategory = false;
      drag = false;

      CreateTopElement(launcher);
      CreateCategoriesElement(launcher);
      if (activeCategory) new FunctionsCategories().LoadFunctionCategory(DataClass.activeCategoryPanelLauncher, DataClass.activeAppPanelLauncher, launcher);
    }

    /// <summary>
    /// Создаёт и настраивает экземпляр верхней панели.
    /// </summary>
    /// <param name="launcher">Экземпляр формы.</param>
    private void CreateTopElement(Form launcher)
    {
      // Вся верхняя панель
      Panel topPanel = new()
      {
        Dock = DockStyle.Top,
        Height = 50,
        Cursor = Cursors.SizeAll,
      };
      topPanel.MouseDown += (s, a) =>
      {
        this.drag = true;
        this.startPoint = new Point(a.X, a.Y);
        if (launcher.WindowState == FormWindowState.Maximized)
        {
          launcher.WindowState = FormWindowState.Normal;
          launcher.Location = new Point(Cursor.Position.X - launcher.Width / 2, 0);
          this.startPoint = launcher.Location;
        }

        if (DataClass.stickingForm == DataClass.Sticking.Top || DataClass.stickingForm == DataClass.Sticking.Bottom)
        {
          launcher.Size = DataClass.sizeStickingForm;
          launcher.Location = DataClass.locationStickingForm.LocationElement;
          this.startPoint = launcher.Location;
          DataClass.stickingForm = DataClass.Sticking.Nope;
        }
        else if (DataClass.stickingForm == DataClass.Sticking.Left || DataClass.stickingForm == DataClass.Sticking.Right)
        {
          launcher.Size = DataClass.sizeStickingForm;
          DataClass.stickingForm = DataClass.Sticking.Nope;
        }

        SizeElements();
      };
      topPanel.MouseMove += (s, a) =>
      {
        if (this.drag)
        {
          launcher.Location = new Point(Cursor.Position.X - this.startPoint.X, Cursor.Position.Y - this.startPoint.Y);
        }
      };
      topPanel.MouseUp += (s, a) =>
      {
        this.drag = false;
        if (launcher.Location.Y < 0)
        {
          DataClass.sizeStickingForm = launcher.Size;
          DataClass.stickingForm = Sticking.Top;
          DataClass.locationStickingForm.LocationElement = new Point(launcher.Location.X, 0);
          launcher.Location = new Point(0, 0);
          launcher.Width = DataClass.screenSize.Width;
          launcher.Height = DataClass.screenSize.Height / 2;

        }
        else if (launcher.Location.X < 0)
        {
          DataClass.sizeStickingForm = launcher.Size;
          DataClass.stickingForm = Sticking.Left;
          DataClass.locationStickingForm.LocationElement = new Point(launcher.Location.X, 0);
          launcher.Location = new Point(0, 0);
          launcher.Width = DataClass.screenSize.Width / 2;
          launcher.Height = DataClass.screenSize.Height;
        }
        else if (launcher.Location.X + launcher.Width > DataClass.screenSize.Width)
        {
          DataClass.sizeStickingForm = launcher.Size;
          DataClass.stickingForm = Sticking.Right;
          DataClass.locationStickingForm.LocationElement = new Point(launcher.Location.X, 0);
          launcher.Location = new Point(DataClass.screenSize.Width / 2, 0);
          launcher.Width = DataClass.screenSize.Width / 2;
          launcher.Height = DataClass.screenSize.Height;
        }
        else if (launcher.Location.Y + launcher.Height > DataClass.screenSize.Height)
        {
          DataClass.sizeStickingForm = launcher.Size;
          DataClass.stickingForm = Sticking.Bottom;
          DataClass.locationStickingForm.LocationElement = new Point(launcher.Location.X, 0);
          launcher.Location = new Point(0, DataClass.screenSize.Height / 2);
          launcher.Width = DataClass.screenSize.Width;
          launcher.Height = DataClass.screenSize.Height / 2;
        }

      };

      Size buttonSize = new(topPanel.Height, topPanel.Height);

      // Кнопка "скрыть" форму
      BorderButtonElement minimaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Minimaze,
        ForeColor = Color.White,
        Dock = DockStyle.Right,
      };
      minimaze.MouseDown += (s, a) => launcher.WindowState = FormWindowState.Minimized;

      // Кнопка "развернуть" форму на весь экран
      BorderButtonElement maximaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Maximaze,
        ForeColor = Color.White,
        Dock = DockStyle.Right,
      };
      maximaze.MouseDown += (s, a) =>
      {
        if (launcher.WindowState == FormWindowState.Maximized) launcher.WindowState = FormWindowState.Normal;
        else launcher.WindowState = FormWindowState.Maximized;
      };

      // Кнопка закрыть форму
      BorderButtonElement exit = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ForeColor = Color.White,
        ChoiceElement = BorderButtonElement.Choice.Exit,
        Dock = DockStyle.Right,
      };
      exit.MouseDown += (s, a) => Application.Exit();

      topPanel.Controls.Add(minimaze);
      topPanel.Controls.Add(maximaze);
      topPanel.Controls.Add(exit);
      launcher.Controls.Add(topPanel);

      DataClass.topElementLauncher = topPanel;
    }

    /// <summary>
    /// Создаёт и настраивает экземпляр панели с категориями.
    /// </summary>
    /// <param name="launcher">Экземпляр формы.</param>
    private void CreateCategoriesElement(Form launcher)
    {
      // Панель с категориями.
      Panel categoriesPanel = new()
      {
        Size = new Size(DataClass.sizeForm.Width / 8, DataClass.sizeForm.Height - DataClass.topElementLauncher.Height - borderFormWidth),
        Location = new Point(borderFormWidth, DataClass.topElementLauncher.Height),
      };
      DataClass.categoriesElementLauncher = categoriesPanel;
      launcher.Controls.Add(categoriesPanel);

      string lastCategory = new BackUpClass().GetCategory();
      string[] nameFile = Directory.GetFiles(DataClass.categoriesPathFiles);

      for (int i = nameFile.Length - 1; i >= 0; i--)
      {
        string name = nameFile[i][(nameFile[i].LastIndexOf("\\") + 1)..];

        //Панель со всеми приложениями
        ScrollBarElement panelApps = CreateAppsElement(launcher, name);
        launcher.Controls.Add(panelApps);

        // Панель категории.
        TextElement categoryPanel = new()
        {
          Height = DataClass.sizeForm.Height / 15,
          Width = categoriesPanel.Width,
          Text = name,
          Name = name,
        };

        ContextMenuStrip functionCategories = new();
        functionCategories.Items.Add("Добавить приложение");
        functionCategories.Items.Add("Переименовать категорию");
        functionCategories.Items.Add("Создать новую категорию");
        functionCategories.Items.Add("Удалить категорию");

        functionCategories.Items[0].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddApp, panelApps, name);
        functionCategories.Items[1].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.RenameCategory, panelApps, name);
        functionCategories.Items[2].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddCategory, panelApps, name);
        functionCategories.Items[3].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.DeleteCategory, panelApps, name);

        categoryPanel.MouseDown += (s, e) =>
        {
          if (e.Button == MouseButtons.Left)
            new FunctionsCategories().LoadFunctionCategory(categoryPanel, panelApps, launcher);
          else if (e.Button == MouseButtons.Right)
            functionCategories.Show(System.Windows.Forms.Cursor.Position);

        };

        if (categoryPanel.Text == lastCategory)
        {
          DataClass.lastAppPanelLauncher = panelApps;
          DataClass.lastCategoryPanelLauncher = categoryPanel;
          DataClass.activeAppPanelLauncher = panelApps;
          DataClass.activeCategoryPanelLauncher = categoryPanel;
          activeCategory = true;
        }


        DataClass.mainAppsLauncher.Add(panelApps);
        DataClass.categoryElementLauncher.Add(categoryPanel);

        categoriesPanel.Controls.Add(categoryPanel);
      }

      ControlAddElement addCategoryElement = CreateAddCategoryElement(categoriesPanel);
      categoriesPanel.Controls.Add(addCategoryElement);
    }

    /// <summary>
    /// Создаёт и настраивает панель с файлами определённой категории.
    /// </summary>
    /// <param name="nameCategoty">Имя категории</param>
    /// <returns></returns>
    public ScrollBarElement CreateAppsElement(Form launcher, string nameCategoty)
    {
      ScrollBarElement panelApps = new()
      {
        Visible = false,
        Name = nameCategoty,
        BackColor = Color.Green,
        Width = DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth,
        Height = DataClass.categoriesElementLauncher.Height,
        Location = new Point(DataClass.categoriesElementLauncher.Width, DataClass.topElementLauncher.Height),
      };


      string pathFile = DataClass.categoriesPathFiles + "\\" + nameCategoty;

      if (File.Exists(pathFile))
      {
        string[] dataFiles = File.ReadAllLines(pathFile);

        foreach (string dataFile in dataFiles)
        {
          try
          {
            Panel elementApp = CreateAppElement(launcher, pathFile, dataFile, panelApps.Name);
            panelApps.AddControl(elementApp);
          }
          catch
          {
            // А вдруг какие-то данные поломались.. Не выкидывать же ошибку.
          }
        }
      }
      else
      {
        File.Create(pathFile);
      }
      panelApps.AddControl(CreateAddAppElement());

      return panelApps;
    }

    /// <summary>
    /// Создаёт и настраивает элемент приложения.
    /// </summary>
    /// <param name="pathFile">Путь к файлу.</param>
    /// <param name="pathImages">Путь к картинке.</param>
    /// <param name="dataFile">Данные файла?)</param>
    /// <param name="nameCategory">Имя категориию</param>
    /// <returns></returns>
    private Panel CreateAppElement(Form launcher, string pathFile, string dataFile, string nameCategory)
    {
      int indexFerst = dataFile.IndexOf(DataClass.code) + DataClass.code.Length;
      int indexLast = dataFile.IndexOf("$", indexFerst);
      string nameFile = dataFile[indexFerst..indexLast];
      indexFerst = indexLast + DataClass.code.Length;
      indexLast = dataFile.IndexOf("$", indexFerst);
      string pathApp = dataFile[indexFerst..indexLast];

      // Главная панель
      Panel fileСontrols = new()
      {
        Size = new System.Drawing.Size(DataClass.sizeAppElement.Width, DataClass.sizeAppElement.Height)
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
      TextElement labelFileName = new()
      {
        Height = fileСontrols.Height - pictureBoxImageApp.Height,
        Width = pictureBoxImageApp.Width,
        Dock = DockStyle.Bottom,
        Text = nameFile,
      };

      labelFileName.MouseEnter += (s, a) => labelFileName.Text = "Открыть";
      labelFileName.MouseLeave += (s, a) => labelFileName.Text = nameFile;

      ContextMenuStrip contextMenuButton = new();
      contextMenuButton.Items.Add("Открыть");
      contextMenuButton.Items.Add("Расположение файла");
      contextMenuButton.Items.Add("Сменить обложку");
      contextMenuButton.Items.Add("Удалить файл из лаунчера");

      contextMenuButton.Items[0].Click += (s, e) => new FunctionsApps().StartApp(pathFile, pathApp);
      contextMenuButton.Items[1].Click += (s, e) => new FunctionsApps().LocationApp(launcher, pathApp, nameCategory, nameFile);
      contextMenuButton.Items[2].Click += (s, e) =>
      {
        new FunctionsApps().FormImage(nameCategory, nameFile);
        if (DataClass.update)
        {
          DataClass.update = false;
          new SettingsForms().UpdateLauncher(launcher);
        }
      };
      contextMenuButton.Items[3].Click += (s, e) => new FunctionsApps().DeleteApp(launcher, nameCategory, labelFileName.Text, false);

      //Действие на ЛКМ и ПКМ
      labelFileName.MouseDown += (s, e) =>
      {
        if (e.Button == MouseButtons.Right)
        {
          contextMenuButton.Show(System.Windows.Forms.Cursor.Position);
        }
        else if (e.Button == MouseButtons.Left)
        {
          new FunctionsApps().StartApp(pathFile, pathApp);
        }
      };

      //Собираем всё вместе
      fileСontrols.Controls.Add(pictureBoxImageApp);
      fileСontrols.Controls.Add(labelFileName);
      return fileСontrols;
    }

    /// <summary>
    /// Элемент добавления категории.
    /// </summary>
    /// <returns></returns>
    private ControlAddElement CreateAddCategoryElement(Panel categoriesPanel)
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
    private ControlAddElement CreateAddAppElement()
    {
      ControlAddElement controlAddElement = new()
      {
        Height = DataClass.sizeAppElement.Height,
        Width = DataClass.sizeAppElement.Width,
        Name = "PlusApp",
        SizePlus = 6,
      };

      controlAddElement.MouseDown += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddApp, DataClass.activeAppPanelLauncher, DataClass.activeCategoryPanelLauncher.Name);
      DataClass.controlAddApp.Add(controlAddElement);
      return controlAddElement;
    }

    /// <summary>
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    public void LocationApps()
    {
      //DataClass.activeAppPanelLauncher.LocationApps();
    }

    /// <summary>
    /// Размер панели с элементамии приложений.
    /// </summary>
    public void SizeElements()
    {
      DataClass.categoriesElementLauncher.Height = DataClass.sizeForm.Height - DataClass.topElementLauncher.Height - DataClass.borderFormWidth;
      DataClass.activeAppPanelLauncher.Resize(DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth, DataClass.categoriesElementLauncher.Height);
    }
  }
}
