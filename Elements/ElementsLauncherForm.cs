using Launcher.Controls;
using LauncherNet.BackUp;
using LauncherNet.Design;
using LauncherNet.Functions;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherNet.Elements
{
  public class ElementsLauncherForm
  {

    /// <summary>
    /// Ширина панели с приложением.
    /// </summary>
    const int WidthPanelCategory = 167;

    /// <summary>
    /// Высота панели с приложением.
    /// </summary>
    const int HeightPanelCategory = 268;

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="launcher">"Экземпляр формы.</param>
    public void LoadElements(Form launcher)
    {
      LoadCategoriesPanel(launcher);
    }

    /// <summary>
    /// Создание панели с категориями.
    /// </summary>
    /// <param name="launcher">Форма, на которую добавляется панель.</param>
    /// <returns></returns>
    private void LoadCategoriesPanel(Form launcher)
    {
      CategoriesPanelControl categoriesPanel = new CategoriesPanelControl()
      {
        Height = DataClass.sizeForm.Height,
        Width = DataClass.sizeForm.Width / 8,
        Border = true,
        BorderColor = Color.Black,
      };
      DataClass.categoriesElementSize.Width = categoriesPanel.Width;
      launcher.Controls.Add(categoriesPanel);

      string lastCategory = new BackUpClass().GetCategory();
      string[] nameFile = Directory.GetFiles(DataClass.categoriesPathFiles);

      for (int i = nameFile.Length - 1; i >= 0; i--)
      {
        string name = nameFile[i].Substring(nameFile[i].LastIndexOf("\\") + 1, nameFile[i].Length - (nameFile[i].LastIndexOf("\\") + 1));

        Panel panelApps = CreateMain(launcher, name);
        CategoryPanelControl categoryPanel = new CategoryPanelControl()
        {
          Height = DataClass.sizeForm.Height / 15,
          Width = categoriesPanel.Width,
          BackColor = Color.Green,
          Text = name,
        };
        ContextMenuStrip contextMenuButton = new ContextMenuStrip();

        contextMenuButton.Items.Add("Добавить приложение");
        contextMenuButton.Items.Add("Переименовать категорию");
        contextMenuButton.Items.Add("Создать новую категорию");
        contextMenuButton.Items.Add("Удалить категорию");

        contextMenuButton.Items[0].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddApp, panelApps, name);
        contextMenuButton.Items[1].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.RenameCategory, panelApps, name);
        contextMenuButton.Items[2].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddCategory, panelApps, name);
        contextMenuButton.Items[3].Click += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.DeleteCategory, panelApps, name);

        categoryPanel.MouseEnter += (s, e) => DesignLauncherForm.SetHoverСolorCategory(categoryPanel);
        categoryPanel.MouseLeave += (s, e) => DesignLauncherForm.ResetColor(categoryPanel);
        categoryPanel.MouseDown += (s, e) => new FunctionsCategories().OpenCategory(e, contextMenuButton, categoryPanel, panelApps, launcher);


        if (categoryPanel.Text == lastCategory) new FunctionsCategories().OpenCategory(null, contextMenuButton, categoryPanel, panelApps, launcher);


        categoriesPanel.Controls.Add(categoryPanel);
        launcher.Controls.Add(panelApps);
        launcher.Controls.Add(categoriesPanel);
      }
    }

    /// <summary>
    /// Создаёт новую панель с файлами определённой категории.
    /// </summary>
    /// <param name="name">Имя категории</param>
    /// <returns></returns>
    public Panel CreateMain(Form launcher, string name)
    {
      Panel panelApp = new Panel
      {
        Dock = DockStyle.Right,
        Width = DataClass.sizeForm.Width - DataClass.categoriesElementSize.Width - 15,
        Visible = false,
        AutoScroll = true,
        Name = name,
      };

      string pathFile = DataClass.categoriesPathFiles + "\\" + name;
      string pathImages = DataClass.pathImages + "\\" + name + "\\";

      if (File.Exists(pathFile))
      {
        string[] dataFiles = File.ReadAllLines(pathFile);

        foreach (string dataFile in dataFiles)
        {
          try
          {
            panelApp.Controls.Add(CreateAppElement(launcher, pathFile, pathImages, dataFile, panelApp.Name));
          }
          catch
          {

          }
        }
      }
      else
      {
        File.Create(pathFile);
      }

      panelApp.SizeChanged += (s, a) => LocationApps();


      return panelApp;
    }

    /// <summary>
    /// Создание элемента приложения.
    /// </summary>
    /// <param name="pathFile"></param>
    /// <param name="pathImages"></param>
    /// <param name="dataFile"></param>
    /// <param name="nameCategory"></param>
    /// <returns></returns>
    public Panel CreateAppElement(Form launcher, string pathFile, string pathImages, string dataFile, string nameCategory)
    {
      int indexFerst = dataFile.IndexOf(DataClass.code) + DataClass.code.Length;
      int indexLast = dataFile.IndexOf("$", indexFerst);
      string nameFile = dataFile.Substring(indexFerst, (indexLast - indexFerst));
      indexFerst = indexLast + DataClass.code.Length;
      indexLast = dataFile.IndexOf("$", indexFerst);
      string pathApp = dataFile.Substring(indexFerst, (indexLast - indexFerst));

      // Главная панель
      Panel fileСontrols = new Panel();
      fileСontrols.Size = new System.Drawing.Size(WidthPanelCategory, HeightPanelCategory);

      // Картинка файла
      PictureBox pictureBoxImageApp = new PictureBox();
      pictureBoxImageApp.Height = HeightPanelCategory - 40;
      pictureBoxImageApp.Dock = DockStyle.Top;
      pictureBoxImageApp.BackgroundImageLayout = ImageLayout.Zoom;

      if (File.Exists(pathImages + nameFile + ".jpg"))
      {

        using (var imgStream = File.OpenRead(pathImages + nameFile + ".jpg"))
        {
          pictureBoxImageApp.BackgroundImage = Image.FromStream(imgStream);
        }

        //pictureBoxImageApp.BackgroundImage = new Bitmap(pathImages + nameFile + ".jpg");
      }
      else
      {
        try
        {
          using (var imgStream = File.OpenRead(@$"{DataClass.pathImages}\Default.jpg"))
          {
            pictureBoxImageApp.BackgroundImage = Image.FromStream(imgStream);
          }
          //pictureBoxImageApp.BackgroundImage = new Bitmap(@$"{DataClass.pathImages}\Default.jpg");
        }
        catch
        {
          pictureBoxImageApp.BackColor = Color.Red;
        }
      }

      // Для запуска файла
      Label labelFileName = new Label();
      labelFileName.Height = fileСontrols.Height - pictureBoxImageApp.Height;
      labelFileName.Dock = DockStyle.Bottom;
      labelFileName.Text = nameFile;
      labelFileName.BorderStyle = BorderStyle.FixedSingle;

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
        new SettingsForms().UpdateLauncher(launcher);
      };
      contextMenuButton.Items[3].Click += (s, e) => new FunctionsApps().DeleteApp(launcher,  nameCategory, labelFileName.Text, false);

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
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    public void LocationApps()
    {
      int locationX = 40;
      int locationY = 40;

      if (DataClass.activeAppPanel != null)
        foreach (Panel app in DataClass.allApps)
        {
          if (locationX + 200 < DataClass.activeAppPanel.Width)
          {
            app.Location = new System.Drawing.Point(locationX, locationY);
            locationX += WidthPanelCategory + 10;
          }
          else
          {
            locationX = 40;
            locationY += HeightPanelCategory + 22;
            app.Location = new System.Drawing.Point(locationX, locationY);
            locationX += WidthPanelCategory + 10;
          }
        }
    }
  }
}
