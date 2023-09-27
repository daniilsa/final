﻿using Launcher.Controls;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Functions;
using LauncherNet.Settings;
<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
using System.Xml.Linq;
using static LauncherNet.DataClass;

namespace LauncherNet.Elements
{
  public class ElementsLauncherForm
  {

<<<<<<< HEAD
    private bool activeCategory;

    /// <summary>
    /// Перетаскивание формы
    /// </summary>
    private bool drag;

    /// <summary>
    /// Стартовая позиция.
    /// </summary>
    private Point startPoint = new Point(0, 0);

=======
    private bool drag = false;
    private bool expand = false;
    private Point startPoint = new Point(0, 0);

    Size sizeForm;
    Location locationForm;


>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="launcher">"Экземпляр формы.</param>
    public void LoadElements(Form launcher)
    {
<<<<<<< HEAD
      activeCategory = false;
      drag= false;

      CreateTopElement(launcher);
      CreateCategoriesElement(launcher);
      if (activeCategory) new FunctionsCategories().LoadFunctionCategory(DataClass.activeCategoryPanelLauncher, DataClass.activeAppPanelLauncher, launcher);
=======
      Panel topPanel = CreateTopPanel(launcher);
      Panel mainPanel = CreateMainPanel(topPanel);

      launcher.Controls.Add(mainPanel);
      launcher.Controls.Add(topPanel);

      CreateCategoriesPanel(launcher, mainPanel);
    }

    /// <summary>
    /// Возвращает экземляр верхней панели приложения. 
    /// </summary>
    /// <returns></returns>
    private Panel CreateTopPanel(Form launcher)
    {
      Panel topPanel = new Panel()
      {
        Dock = DockStyle.Top,
        Height = 50,
        Cursor = Cursors.SizeAll,
      };

      topPanel.MouseDown += (s, a) =>
      {
        drag = true;
        startPoint = new Point(a.X, a.Y);
        if (launcher.WindowState == FormWindowState.Maximized)
        {
          launcher.WindowState = FormWindowState.Normal;
          launcher.Location = new Point(Cursor.Position.X - launcher.Width / 2, 0);
          startPoint = launcher.Location;
        }

        if (DataClass.stickingForm == DataClass.Sticking.Top || DataClass.stickingForm == DataClass.Sticking.Bottom)
        {
          launcher.Size = DataClass.sizeStickingForm;
          launcher.Location = DataClass.locationStickingForm.LocationElement;
          startPoint = launcher.Location;
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
        if (drag) launcher.Location = new Point(Cursor.Position.X - startPoint.X, Cursor.Position.Y - startPoint.Y);
      };
      topPanel.MouseUp += (s, a) =>
      {
        drag = false;
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

      Panel panelButtons = new Panel()
      {
        Dock = DockStyle.Right,
        //BackColor = Color.Red,
      };

      Size buttonSize = new Size(topPanel.Height, topPanel.Height);
      Location buttonLocation = new Location(0, 0);

      BorderButtonElement minimaze = new BorderButtonElement()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Minimaze,
        ForeColor = Color.White,
      };
      minimaze.Location = new Point(buttonLocation.X, buttonLocation.Y);
      //TODO: На подумать
      //minimaze.MouseLeave += (s, a) => minimaze.BackColor = new ColorElements().GetHeaderColor();
      //minimaze.MouseEnter += (s, a) => minimaze.BackColor = new ColorElements().GetHoverHeaderColor();
      minimaze.MouseDown += (s, a) => launcher.WindowState = FormWindowState.Minimized;
      buttonLocation.LocationElement = new Point(minimaze.Width + minimaze.Location.X, buttonLocation.Y);

      BorderButtonElement maximaze = new BorderButtonElement()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Maximaze,
        ForeColor = Color.White,
      };
      maximaze.Location = new Point(buttonLocation.X, buttonLocation.Y);
      //TODO: На подумать
      //maximaze.MouseLeave += (s, a) => maximaze.BackColor = new ColorElements().GetHeaderColor();
      //maximaze.MouseEnter += (s, a) => maximaze.BackColor = new ColorElements().GetHoverHeaderColor();
      maximaze.MouseDown += (s, a) =>
      {
        if (launcher.WindowState == FormWindowState.Maximized) launcher.WindowState = FormWindowState.Normal;
        else launcher.WindowState = FormWindowState.Maximized;
      };
      buttonLocation.LocationElement = new Point(maximaze.Width + maximaze.Location.X, buttonLocation.Y);

      BorderButtonElement exit = new BorderButtonElement()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ForeColor = Color.White,
        ChoiceElement = BorderButtonElement.Choice.Exit,
      };
      exit.Location = new Point(buttonLocation.X, buttonLocation.Y);
      //TODO: На подумать
      //exit.MouseLeave += (s, a) => exit.BackColor = new ColorElements().GetHeaderColor();
      //exit.MouseEnter += (s, a) => exit.BackColor = new ColorElements().GetHoverHeaderColor();
      exit.MouseDown += (s, a) => Application.Exit();
      panelButtons.Width = (minimaze.Width * 6) / 2;

      panelButtons.Controls.Add(minimaze);
      panelButtons.Controls.Add(maximaze);
      panelButtons.Controls.Add(exit);
      topPanel.Controls.Add(panelButtons);

      DataClass.topElement = topPanel;
      return topPanel;
    }

    /// <summary>
    /// Возвращает экземляр панели, которая хранит в себе элемент с категориями, а так же меню с приложениями.
    /// </summary>
    /// <param name="topPanel"></param>
    /// <returns></returns>
    private Panel CreateMainPanel(Panel topPanel)
    {
      DataClass.Expand expandForm = DataClass.Expand.Nope;

      Panel mainPanel = new Panel()
      {
        Dock = DockStyle.Top,
        Height = DataClass.sizeForm.Height - topPanel.Height,
        BackColor = BackColorElements.BackColorTopElement,
        Padding = new Padding(2, 0, 2, 2),
      };
      mainPanel.MouseEnter += (s, a) =>
      {
        int pointX = Cursor.Position.X;
        int pointY = Cursor.Position.Y;

        DataClass.Location locationForm = DataClass.locationForm;
        Size sizeForm = DataClass.sizeForm;

        if (DataClass.launcher.WindowState != FormWindowState.Maximized)
        {
          if (pointX <= locationForm.X + 3 && pointY > locationForm.Y + sizeForm.Height - 3)
          {
            mainPanel.Cursor = Cursors.SizeNESW;
            expandForm = DataClass.Expand.LeftBottom;
          }
          else if (pointX >= locationForm.X + DataClass.sizeForm.Width - 3 && pointY > locationForm.Y + sizeForm.Height - 3)
          {
            mainPanel.Cursor = Cursors.SizeNWSE;
            expandForm = DataClass.Expand.RightBottom;
          }
          else if (pointX <= locationForm.X + 3)
          {
            mainPanel.Cursor = Cursors.SizeWE;
            expandForm = DataClass.Expand.Left;
          }
          else if (pointX >= locationForm.X + DataClass.sizeForm.Width - 3)
          {
            mainPanel.Cursor = Cursors.SizeWE;
            expandForm = DataClass.Expand.Right;
          }
          else if (pointY > locationForm.Y + sizeForm.Height - 3)
          {
            mainPanel.Cursor = Cursors.SizeNS;
            expandForm = DataClass.Expand.Bottom;
          }
        }
      };
      mainPanel.MouseLeave += (s, a) =>
      {
        mainPanel.Cursor = Cursors.Default;
        expandForm = DataClass.Expand.Nope;
      };
      mainPanel.MouseDown += (s, a) =>
      {
        startPoint = Cursor.Position;
        sizeForm = DataClass.launcher.Size;
        locationForm = new Location(DataClass.launcher.Location.X, DataClass.launcher.Location.Y);
        expand = true;
      };
      mainPanel.MouseMove += (s, a) =>
      {
        new SizeForm().ResizeForm(expandForm,expand,startPoint,locationForm, sizeForm);
      };
      mainPanel.MouseUp += (s, a) =>
      {
        expandForm = DataClass.Expand.Nope;
        expand = false;
      };

      DataClass.mainPanel = mainPanel;
      return mainPanel;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    }

    /// <summary>
    /// Создаёт и настраивает экземпляр верхней панели.
    /// </summary>
<<<<<<< HEAD
    /// <param name="launcher">Экземпляр формы.</param>
    private void CreateTopElement(Form launcher)
=======
    /// <param name="launcher">Форма, на которую добавляется панель.</param>
    /// <returns></returns>
    private void CreateCategoriesPanel(Form launcher, Panel mainPanel)
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    {
      //Вся верхняя панель
      Panel topPanel = new Panel()
      {
<<<<<<< HEAD
        Dock = DockStyle.Top,
        Height = 50,
        Cursor = Cursors.SizeAll,
      };
      topPanel.MouseDown += (s, a) =>
      {
        drag = true;
        startPoint = new Point(a.X, a.Y);
        if (launcher.WindowState == FormWindowState.Maximized)
        {
          launcher.WindowState = FormWindowState.Normal;
          launcher.Location = new Point(Cursor.Position.X - launcher.Width / 2, 0);
          startPoint = launcher.Location;
        }

        if (DataClass.stickingForm == DataClass.Sticking.Top || DataClass.stickingForm == DataClass.Sticking.Bottom)
        {
          launcher.Size = DataClass.sizeStickingForm;
          launcher.Location = DataClass.locationStickingForm.LocationElement;
          startPoint = launcher.Location;
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
        if (drag) launcher.Location = new Point(Cursor.Position.X - startPoint.X, Cursor.Position.Y - startPoint.Y);
      };
      topPanel.MouseUp += (s, a) =>
      {
        drag = false;
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

      Size buttonSize = new Size(topPanel.Height, topPanel.Height);
=======
        Width = DataClass.sizeForm.Width / 8,
        Dock = DockStyle.Left,
      };
      categoriesPanel.MouseDoubleClick += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddCategory, null, null);
      DataClass.categoriesElement = categoriesPanel;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f

      //Кнопка "скрыть" форму
      BorderButtonElement minimaze = new BorderButtonElement()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Minimaze,
        ForeColor = Color.White,
        Dock = DockStyle.Right,
      };
      minimaze.MouseDown += (s, a) => launcher.WindowState = FormWindowState.Minimized;

      // Кнопка "развернуть" форму на весь экран
      BorderButtonElement maximaze = new BorderButtonElement()
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

      //Кнопка закрыть форму
      BorderButtonElement exit = new BorderButtonElement()
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
      Panel categoriesPanel = new Panel()
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
        string name = nameFile[i].Substring(nameFile[i].LastIndexOf("\\") + 1, nameFile[i].Length - (nameFile[i].LastIndexOf("\\") + 1));
<<<<<<< HEAD

        //Панель со всеми приложениями
        ScrollBarElement panelApps = CreateAppsElement(launcher, name);
        launcher.Controls.Add(panelApps);

        // Панель категории.
=======
        Panel panelApps = CreateAppsPanel(launcher, name);
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
        TextElement categoryPanel = new TextElement()
        {
          Height = DataClass.sizeForm.Height / 15,
          Width = categoriesPanel.Width,
          Text = name,
<<<<<<< HEAD
          Name = name,
=======
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
        };

        ContextMenuStrip functionCategories = new ContextMenuStrip();
        functionCategories.Items.Add("Добавить приложение");
        functionCategories.Items.Add("Переименовать категорию");
        functionCategories.Items.Add("Создать новую категорию");
        functionCategories.Items.Add("Удалить категорию");

        functionCategories.Items[0].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddApp, panelApps, name);
        functionCategories.Items[1].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.RenameCategory, panelApps, name);
        functionCategories.Items[2].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddCategory, panelApps, name);
        functionCategories.Items[3].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.DeleteCategory, panelApps, name);

<<<<<<< HEAD
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
=======
        categoryPanel.MouseDown += (s, e) => new FunctionsCategories().LoadFunctionCategory(e, functionCategories, categoryPanel, panelApps, launcher);
        if (categoryPanel.Text == lastCategory) new FunctionsCategories().LoadFunctionCategory(null, functionCategories, categoryPanel, panelApps, launcher);
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f

        DataClass.mainAppsControl.Add(panelApps);
        DataClass.categoryElement.Add(categoryPanel);
        
        categoriesPanel.Controls.Add(categoryPanel);
<<<<<<< HEAD
=======
        mainPanel.Controls.Add(panelApps);
        mainPanel.Controls.Add(categoriesPanel);
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
      }

      ControlAddElement addCategoryElement = CreateAddCategoryElement(categoriesPanel);
      categoriesPanel.Controls.Add(addCategoryElement);
    }

    /// <summary>
    /// Создаёт и настраивает панель с файлами определённой категории.
    /// </summary>
    /// <param name="nameCategoty">Имя категории</param>
    /// <returns></returns>
<<<<<<< HEAD
    public ScrollBarElement CreateAppsElement(Form launcher, string nameCategoty)
=======
    public Panel CreateAppsPanel(Form launcher, string nameCategoty)
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    {
      ScrollBarElement panelApps = new ScrollBarElement
      {
<<<<<<< HEAD
        Visible = false,
        Name = nameCategoty,
        BackColor = Color.Green,
        Width = DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth,
        Height = DataClass.categoriesElementLauncher.Height,
        Location = new Point(DataClass.categoriesElementLauncher.Width, DataClass.topElementLauncher.Height),
      };


=======
        Width = DataClass.sizeForm.Width - DataClass.sizeCategoriesElement.Width,
        Visible = false,
        AutoScroll = true,
        Name = nameCategoty,
      };
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
      string pathFile = DataClass.categoriesPathFiles + "\\" + nameCategoty;
      string pathImages = DataClass.pathImages + "\\" + nameCategoty + "\\";

      if (File.Exists(pathFile))
      {
        string[] dataFiles = File.ReadAllLines(pathFile);

        foreach (string dataFile in dataFiles)
        {
          try
          {
            Panel elementApp = CreateAppElement(launcher, pathFile, pathImages, dataFile, panelApps.Name);
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
    private Panel CreateAppElement(Form launcher, string pathFile, string pathImages, string dataFile, string nameCategory)
    {
      int indexFerst = dataFile.IndexOf(DataClass.code) + DataClass.code.Length;
      int indexLast = dataFile.IndexOf("$", indexFerst);
      string nameFile = dataFile.Substring(indexFerst, (indexLast - indexFerst));
      indexFerst = indexLast + DataClass.code.Length;
      indexLast = dataFile.IndexOf("$", indexFerst);
      string pathApp = dataFile.Substring(indexFerst, (indexLast - indexFerst));

      // Главная панель
      Panel fileСontrols = new Panel()
      {
        Size = new System.Drawing.Size(DataClass.sizeAppElement.Width, DataClass.sizeAppElement.Height)
      };

      // Картинка файла
      PictureBox pictureBoxImageApp = new PictureBox
      {
        Height = DataClass.sizeAppElement.Height - 40,
        Dock = DockStyle.Top,
        Name = nameFile,
        Tag = nameCategory
      };

      // Для запуска файла
      TextElement labelFileName = new TextElement
      {
        Height = fileСontrols.Height - pictureBoxImageApp.Height,
        Width = pictureBoxImageApp.Width,
        Dock = DockStyle.Bottom,
        Text = nameFile,
      };

      labelFileName.MouseEnter += (s, a) => labelFileName.Text = "Открыть";
      labelFileName.MouseLeave += (s, a) => labelFileName.Text = nameFile;

      ContextMenuStrip contextMenuButton = new ContextMenuStrip();
      contextMenuButton.Items.Add("Открыть");
      contextMenuButton.Items.Add("Расположение файла");
      contextMenuButton.Items.Add("Сменить обложку");
      contextMenuButton.Items.Add("Удалить файл из лаунчера");

      contextMenuButton.Items[0].Click += (s, e) => new FunctionsApps().StartApp(pathFile, pathApp);
      contextMenuButton.Items[1].Click += (s, e) => new FunctionsApps().LocationApp(launcher, pathApp, nameCategory, nameFile);
      contextMenuButton.Items[2].Click += (s, e) =>
      {
        new FunctionsApps().FormImage(nameCategory, nameFile, pathImages);
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
      ControlAddElement controlAddElement = new ControlAddElement()
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
      ControlAddElement controlAddElement = new ControlAddElement()
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
<<<<<<< HEAD
      DataClass.activeAppPanelLauncher.LocationApps();
=======
      int locationX = 40;
      int locationY = 40;
      int indentX = 10;

      if (DataClass.activeAppPanel != null)
      {
        DataClass.activeAppPanel.VerticalScroll.Value = 0;
        DataClass.mainPanel.Height = DataClass.sizeForm.Height - DataClass.topElement.Height;
        DataClass.activeAppPanel.Width = DataClass.sizeForm.Width - DataClass.sizeCategoriesElement.Width - 15;
        DataClass.activeAppPanel.Height = DataClass.mainPanel.Height;

        DataClass.activeAppPanel.HorizontalScroll.Value = 0;

        foreach (Panel app in DataClass.appsElement)
        {
          if (locationX + app.Width+25 < DataClass.activeAppPanel.Width)
          {
            app.Location = new System.Drawing.Point(locationX, locationY);
            locationX += DataClass.sizeAppElement.Width + indentX;
          }
          else
          {
            locationX = 40;
            locationY += DataClass.sizeAppElement.Height + 22;
            app.Location = new System.Drawing.Point(locationX, locationY);
            locationX += DataClass.sizeAppElement.Width + 10;
          }
        }
      }
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    }

    /// <summary>
    /// Размер панели с элементамии приложений.
    /// </summary>
    public void SizeElements()
    {
<<<<<<< HEAD
      DataClass.categoriesElementLauncher.Height = DataClass.sizeForm.Height - DataClass.topElementLauncher.Height - DataClass.borderFormWidth;
      DataClass.activeAppPanelLauncher.Resize(DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth, DataClass.categoriesElementLauncher.Height);
=======
      DataClass.mainPanel.Height = DataClass.sizeForm.Height - DataClass.topElement.Height;
      DataClass.activeAppPanel.Dock = DockStyle.Fill;
      DataClass.activeAppPanel.Width = DataClass.sizeForm.Width - DataClass.sizeCategoriesElement.Width - 15;
      DataClass.activeAppPanel.Height = DataClass.mainPanel.Height;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    }
  }
}
