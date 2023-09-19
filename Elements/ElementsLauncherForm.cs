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
using System.Xml.Linq;

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
      Panel categoriesPanel = new Panel()
      {
        //Height = DataClass.sizeForm.Height,
        Width = DataClass.sizeForm.Width / 8,
        BackColor = new ColorElements().GetHeaderColor(),
        Dock = DockStyle.Left,
      };

      categoriesPanel.MouseDoubleClick += (s, e) => new FunctionsCategories().StartFunction(launcher, DataClass.FunctionCategory.AddCategory, null, null);

      DataClass.categoriesElementSize.Width = categoriesPanel.Width;
      launcher.Controls.Add(categoriesPanel);

      string lastCategory = new BackUpClass().GetCategory();
      string[] nameFile = Directory.GetFiles(DataClass.categoriesPathFiles);

      for (int i = nameFile.Length - 1; i >= 0; i--)
      {
        string name = nameFile[i].Substring(nameFile[i].LastIndexOf("\\") + 1, nameFile[i].Length - (nameFile[i].LastIndexOf("\\") + 1));

        Panel panelApps = CreateMain(launcher, name);
        TextElement categoryPanel = new TextElement()
        {
          Height = DataClass.sizeForm.Height / 15,
          Width = categoriesPanel.Width,
          BackColor = new ColorElements().GetHeaderColor(),
          Text = name,
          Font = new FontElements().GetHeaderFont(),
          ForeColor = new FontElements().GetHeaderFontColor(),
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

        categoryPanel.MouseEnter += (s, e) =>
        {
          if (categoryPanel != DataClass.activeCategoryPanel) categoryPanel.BackColor = new ColorElements().GetHoverHeaderColor();
        };

        categoryPanel.MouseLeave += (s, e) =>
        {
          if (categoryPanel != DataClass.activeCategoryPanel) categoryPanel.BackColor = new ColorElements().GetHeaderColor();
        };

        categoryPanel.MouseDown += (s, e) => new FunctionsCategories().LoadFunctionCategory(e, functionCategories, categoryPanel, panelApps, launcher);


        if (categoryPanel.Text == lastCategory) new FunctionsCategories().LoadFunctionCategory(null, functionCategories, categoryPanel, panelApps, launcher);

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
        Dock = DockStyle.Left,
        Width = DataClass.sizeForm.Width - DataClass.categoriesElementSize.Width - 15,
        Visible = false,
        AutoScroll = true,
        Name = name,
        BackColor = new ColorElements().GetMainColor(),
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
      pictureBoxImageApp.BackColor = new ColorElements().GetNameAppBackColor();

      if (File.Exists(pathImages + nameFile + ".jpg"))
      {

        using (var imgStream = File.OpenRead(pathImages + nameFile + ".jpg"))
        {
          pictureBoxImageApp.BackgroundImage = Image.FromStream(imgStream);
        }
      }
      else
      {
        try
        {
          using (var imgStream = File.OpenRead(@$"{DataClass.pathImages}\Default.jpg"))
          {
            pictureBoxImageApp.BackgroundImage = Image.FromStream(imgStream);
          }
        }
        catch
        {
          pictureBoxImageApp.BackColor = Color.Red;
        }
      }

      // Для запуска файла
      TextElement labelFileName = new TextElement
      {
        Height = fileСontrols.Height - pictureBoxImageApp.Height,
        Width = pictureBoxImageApp.Width,
        Dock = DockStyle.Bottom,
        Text = nameFile,
        BackColor = new ColorElements().GetNameAppBackColor(),
        ForeColor = new FontElements().GetNameAppFontColor(),
        Font = new FontElements().GetFooterFont(),
      };

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
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    public void LocationApps()
    {
      int locationX = 40;
      int locationY = 40;

      if (DataClass.activeAppPanel != null)
      {
        DataClass.activeAppPanel.VerticalScroll.Value = 0;
        DataClass.activeAppPanel.Width = DataClass.sizeForm.Width - DataClass.categoriesElementSize.Width - 15;

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
}
