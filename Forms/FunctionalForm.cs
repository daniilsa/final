using LauncherNet.Functions;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LauncherNet.Forms
{
  public partial class FunctionalForm : Form
  {
    public FunctionalForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Запуск формы функций категорий.
    /// </summary>
    /// <param name="functionCategory"></param>
    public void CategoryForm(DataClass.FunctionCategory functionCategory, string nameCategory)
    {
      new SettingsForms().SettingsFunctionalForm(this);
      if (functionCategory == DataClass.FunctionCategory.AddCategory) CreateCategory();
      else if (functionCategory == DataClass.FunctionCategory.RenameCategory) RenameCategory(nameCategory);
      else if (functionCategory == DataClass.FunctionCategory.AddApp) CreateApp();

      this.Location = new Point((DataClass.screenSize.Width - this.Width) / 2, (DataClass.screenSize.Height - this.Height) / 2);
      this.ShowDialog();
    }

    /// <summary>
    /// Запуск формы функций приложений.
    /// </summary>
    /// <param name="functionCategory"></param>
    public void AppForm(DataClass.FunctionApp functionCategory, string nameCategory, string nameFile, string pathImage)
    {
      new SettingsForms().SettingsFunctionalForm(this);
      if (functionCategory == DataClass.FunctionApp.ChangeImage) ChangeImage(nameCategory, nameFile, pathImage);

      this.Location = new Point((DataClass.screenSize.Width - this.Width) / 2, (DataClass.screenSize.Height - this.Height) / 2);
      this.ShowDialog();
    }

    /// <summary>
    /// Настройка внешнего вида формы при добавлении новой категории.
    /// </summary>
    private void CreateCategory()
    {
      //Вся панель настроек
      Panel panelSettings = new Panel()
      {
        Dock = DockStyle.Fill,
        Padding = new Padding(10, 10, 10, 10),
        BackColor = Color.FromArgb(20, 20, 30),
      };

      // Текст: "Введите имя новой категории:"
      Label categoryName = new Label
      {
        Text = "Введите имя новой категории:",
        Dock = DockStyle.Top,
        Location = new System.Drawing.Point(15, 15),
        Font = new System.Drawing.Font("Winston Bold", 14),
        ForeColor = Color.White,
        Width = panelSettings.Width,
      };

      // Ввод для имени новой категории
      TextBox textBoxName = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(categoryName.Location.X, categoryName.Location.Y + categoryName.Height + 10),
        BackColor = Color.FromArgb(40, 40, 50),
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        BorderStyle = BorderStyle.None
      };

      // Кнопка для применения действий.
      Button buttonYes = new Button
      {
        Size = new Size(100, 30),
        Text = "Применить",
        Location = new Point(textBoxName.Location.X, textBoxName.Location.Y + textBoxName.Height + 10),
        ForeColor = Color.White
      };
      buttonYes.Click += (s, e) =>
      {
        new FunctionsCategories().CreateCategory(textBoxName.Text);
        DataClass.update = true;
        this.Close();
      };

      // Кнопка Отменить.
      Button buttonNo = new Button
      {
        Size = new Size(100, 30),
        Text = "Отменить",
        ForeColor = Color.White,
      };
      buttonNo.Location = new Point(textBoxName.Width - buttonNo.Width + 15, buttonYes.Location.Y);
      buttonNo.Click += (s, e) =>
      {
        DataClass.update = false;
        this.Close();
      };

      panelSettings.Controls.Add(textBoxName);
      panelSettings.Controls.Add(categoryName);
      panelSettings.Controls.Add(buttonYes);
      panelSettings.Controls.Add(buttonNo);
      textBoxName.Focus();

      this.Controls.Add(panelSettings);
      this.Height = buttonNo.Location.Y + buttonNo.Height + 30;
    }

    /// <summary>
    /// Настройка внешнего вида формы при функции переименовть категорию.
    /// </summary>
    /// <param name="form"></param>
    private void RenameCategory(string nameCategory)
    {
      //Панель настроек
      Panel panelSettings = new Panel
      {
        Dock = DockStyle.Fill,
        Padding = new Padding(10, 10, 10, 10),
        BackColor = Color.FromArgb(20, 20, 30)
      };

      // Текст : "Введите имя категории:"
      Label categoryOldName = new Label
      {
        Text = "Введите имя категории:",
        Location = new System.Drawing.Point(15, 15),
        Width = panelSettings.Width,
        Dock = DockStyle.Top,
        Font = new System.Drawing.Font("Winston Bold", 14),
        ForeColor = Color.White,
        BackColor = Color.FromArgb(20, 20, 30),
      };

      // Поле для ввода имени категории
      TextBox textBoxOldNameCategory = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(categoryOldName.Location.X, categoryOldName.Location.Y + categoryOldName.Height + 10),
        Text = nameCategory,
        BackColor = Color.FromArgb(40, 40, 50),
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        BorderStyle = BorderStyle.None
      };

      // Текст : "Введите новое имя категории:",
      Label categoryNewName = new Label
      {
        Text = "Введите новое имя категории:",
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        Width = panelSettings.Width,
        Location = new Point(textBoxOldNameCategory.Location.X, textBoxOldNameCategory.Location.Y + textBoxOldNameCategory.Height + 10)
      };

      // Поле для ввода имени приложения
      TextBox textBoxNewNameFile = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(categoryNewName.Location.X, categoryNewName.Location.Y + categoryNewName.Height + 10),
        BackColor = Color.FromArgb(40, 40, 50),
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        BorderStyle = BorderStyle.None
      };

      // Кнопка для применения действий.
      Button buttonYes = new Button
      {
        Size = new Size(100, 30),
        Text = "Применить",
        Location = new Point(textBoxNewNameFile.Location.X, textBoxNewNameFile.Location.Y + textBoxNewNameFile.Height + 10),
        ForeColor = Color.White
      };
      buttonYes.Click += (s, e) =>
      {
        new FunctionsCategories().RenameCategory(textBoxOldNameCategory.Text, textBoxNewNameFile.Text);
        this.Close();
      };

      // Кнопка для выхода
      Button buttonNo = new Button
      {
        Size = new Size(100, 30),
        Text = "Отменить",
        ForeColor = Color.White
      };
      buttonNo.Location = new Point(textBoxNewNameFile.Width - buttonNo.Width + 15, buttonYes.Location.Y);
      buttonNo.Click += (s, e) =>
      {
        this.Close();
      };

      // Сбор всего вместе
      panelSettings.Controls.Add(categoryOldName);
      panelSettings.Controls.Add(textBoxOldNameCategory);
      panelSettings.Controls.Add(categoryNewName);
      panelSettings.Controls.Add(textBoxNewNameFile);
      panelSettings.Controls.Add(buttonNo);
      panelSettings.Controls.Add(buttonYes);
      textBoxOldNameCategory.Focus();

      this.Controls.Add(panelSettings);
      this.AutoSize = true;
      this.Height = buttonNo.Location.Y + buttonNo.Height + 30;

    }

    /// <summary>
    /// Настройка внешнего вида формы при добавлении приложения.
    /// </summary>
    /// <param name="form"></param>
    private void CreateApp()
    {
      bool triggerImage = false;
      string imagePath = null;
      //Панель настроек
      Panel panelSettings = new Panel
      {
        Dock = DockStyle.Fill,
        Padding = new Padding(10, 10, 10, 10),
        BackColor = Color.FromArgb(20, 20, 30)
      };

      // Текст : "Введите имя категории:"
      Label categoryName = new Label
      {
        Text = "Введите имя категории:",
        Location = new System.Drawing.Point(15, 15),
        Width = panelSettings.Width,
        Dock = DockStyle.Top,
        Font = new System.Drawing.Font("Winston Bold", 14),
        ForeColor = Color.White,
        BackColor = Color.FromArgb(20, 20, 30),
      };

      // Поле для ввода имени категории
      TextBox textBoxNameCategory = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(categoryName.Location.X, categoryName.Location.Y + categoryName.Height + 10),
        BackColor = Color.FromArgb(40, 40, 50),
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        BorderStyle = BorderStyle.None
      };
      if (DataClass.activeAppPanelLauncher != null && DataClass.activeAppPanelLauncher.Name.Length > 0)
        textBoxNameCategory.Text = DataClass.activeAppPanelLauncher.Name;

      // Текст : "Введите имя приложения:"
      Label appName = new Label
      {
        Text = "Введите имя приложения:",
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        Width = panelSettings.Width,
        Location = new Point(textBoxNameCategory.Location.X, textBoxNameCategory.Location.Y + textBoxNameCategory.Height + 10)
      };

      // Поле для ввода имени приложения
      TextBox textBoxNameFile = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(appName.Location.X, appName.Location.Y + appName.Height + 10),
        BackColor = Color.FromArgb(40, 40, 50),
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        BorderStyle = BorderStyle.None
      };

      // Текст : "Введите путь приложения:"
      Label pathFile = new Label
      {
        Text = "Введите путь приложения:",
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        Width = panelSettings.Width,
        Location = new Point(textBoxNameFile.Location.X, textBoxNameFile.Location.Y + textBoxNameFile.Height + 10)
      };

      // Поле для ввода пути приложения
      TextBox textBoxPathFile = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(pathFile.Location.X, pathFile.Location.Y + pathFile.Height + 10),
        BackColor = Color.FromArgb(40, 40, 50),
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 14),
        BorderStyle = BorderStyle.None
      };
      textBoxPathFile.MouseDoubleClick += (sender, e) =>
      {
        OpenFileDialog OFD = new OpenFileDialog();
        OFD.Filter = "Приложение (*.exe)|*.exe";
        if (OFD.ShowDialog() == DialogResult.OK)
        {
          ((TextBox)sender).Text = OFD.FileName;
          int indexLast = OFD.FileName.LastIndexOf('.');
          int indexFerst = OFD.FileName.LastIndexOf('\\') + 1;
          for (; indexFerst < indexLast; indexFerst++)
            textBoxNameFile.Text += OFD.FileName[indexFerst];
        }
      };

      // Предупреждение о загрузке обложки
      Label warningLabel = new Label
      {
        Text = "Внимание! Обложка для этого приложения будет загружена автоматически. Если вы хотите загрузить свою обложку, пожалуйста, нажмите на кнопку 'Добавить изображение'",
        ForeColor = Color.White,
        Font = new System.Drawing.Font("Winston Bold", 9),
        Width = this.Width - 30,
        Location = new Point(textBoxPathFile.Location.X, textBoxPathFile.Location.Y + textBoxPathFile.Height + 10),
      };
      warningLabel.Height *= 2;

      // Кнопка для добавлении изображение вручную
      Button addImageButton = new Button
      {
        Size = new Size(100, 30),
        Text = "Добавить изображение",
        Width = this.Width - 30,
        Location = new Point(textBoxPathFile.Location.X, warningLabel.Location.Y + warningLabel.Height + 10),
        ForeColor = Color.White
      };
      addImageButton.Click += (s, e) =>
      {
        OpenFileDialog OFD = new OpenFileDialog();
        if (OFD.ShowDialog() == DialogResult.OK)
        {
          imagePath = OFD.FileName;
          if (imagePath.EndsWith(".png") || imagePath.EndsWith(".jpg"))
          {
            triggerImage = true;
            addImageButton.Text = imagePath;
          }
          else MessageBox.Show("К сожалению данное программное обеспечение не поддерживает данное расширение файла");
        }
      };

      // Кнопка для добавления приложения в лаунчер
      Button buttonYes = new Button
      {
        Size = new Size(100, 30),
        Text = "Применить",
        Location = new Point(textBoxPathFile.Location.X, addImageButton.Location.Y + addImageButton.Height + 10),
        ForeColor = Color.White
      };
      buttonYes.Click += (s, e) =>
      {
        if (new FunctionsCategories().CreateApp(textBoxNameCategory.Text, textBoxNameFile.Text, textBoxPathFile.Text, imagePath, addImageButton.Text, triggerImage))
        {
          if (DataClass.locationImage != null && DataClass.locationImage != string.Empty)
          {
            DataClass.update = true;
            this.Close();
          }
        }
      };

      // Кнопка для выхода
      Button buttonNo = new Button
      {
        Size = new Size(100, 30),
        Text = "Отменить",
        ForeColor = Color.White
      };
      buttonNo.Location = new Point(textBoxPathFile.Width - buttonNo.Width + 15, buttonYes.Location.Y);
      buttonNo.Click += (s, e) =>
      {
        DataClass.update = false;
        this.Close();
      };

      // Сбор всего вместе
      panelSettings.Controls.Add(categoryName);
      panelSettings.Controls.Add(textBoxNameCategory);
      panelSettings.Controls.Add(appName);
      panelSettings.Controls.Add(textBoxNameFile);
      panelSettings.Controls.Add(pathFile);
      panelSettings.Controls.Add(textBoxPathFile);
      panelSettings.Controls.Add(textBoxPathFile);
      panelSettings.Controls.Add(warningLabel);
      panelSettings.Controls.Add(addImageButton);
      panelSettings.Controls.Add(buttonNo);
      panelSettings.Controls.Add(buttonYes);
      textBoxNameCategory.Focus();

      this.Controls.Add(panelSettings);
      this.AutoSize = true;
      this.Height = buttonNo.Location.Y + buttonNo.Height + 30;
    }

    /// <summary>
    /// Настройка внешнего вида формы смены обложки приложения.
    /// </summary>
    private void ChangeImage(string nameCategory, string nameFile, string pathImage)
    {
      //Вся панель настроек
      Panel panelSettings = new Panel()
      {
        Dock = DockStyle.Fill,
        Padding = new Padding(10, 10, 10, 10),
        //BackColor = Color.FromArgb(20, 20, 30),
        BackColor = Color.LightBlue,
      };

      // Текст: "Введите имя новой категории:"
      Label categoryName = new Label
      {
        Text = "Введите путь к изображению:",
        Dock = DockStyle.Top,
        Location = new System.Drawing.Point(15, 15),
        //Font = new System.Drawing.Font("Winston Bold", 14),
        //ForeColor = Color.White,
        Width = panelSettings.Width,
      };

      // Ввод для имени новой категории
      TextBox textBoxPathFile = new TextBox
      {
        Width = this.Width - 30,
        Location = new Point(categoryName.Location.X, categoryName.Location.Y + categoryName.Height + 10),
        //BackColor = Color.FromArgb(40, 40, 50),
        //ForeColor = Color.White,
        //Font = new System.Drawing.Font("Winston Bold", 14),
        //BorderStyle = BorderStyle.None
      };
      //TODO: Дописать метод добавки пути к картинке
      textBoxPathFile.MouseDoubleClick += (sender, e) =>
      {
        OpenFileDialog OFD = new OpenFileDialog();
        OFD.Filter = "Изображение |*.jpg;*jpeg;*png";
        if (OFD.ShowDialog() == DialogResult.OK)
        {
          //((TextBox)sender).Text = OFD.FileName;
          //int indexLast = OFD.FileName.LastIndexOf('.');
          //int indexFerst = OFD.FileName.LastIndexOf('\\') + 1;
          //for (; indexFerst < indexLast; indexFerst++)
          //  textBoxPathFile.Text += OFD.FileName[indexFerst];
          textBoxPathFile.Text = OFD.FileName;
        }
      };
      // Кнопка для применения действий.
      Button buttonYes = new Button
      {
        Size = new Size(100, 30),
        Text = "Применить",
        Location = new Point(textBoxPathFile.Location.X, textBoxPathFile.Location.Y + textBoxPathFile.Height + 10),
        //ForeColor = Color.White
      };
      buttonYes.Click += (s, e) =>
      {
        new FunctionsApps().ChangeImage(nameCategory, nameFile, textBoxPathFile.Text);
        DataClass.update = true;
        this.Close();
      };

      // Кнопка Отменить.
      Button buttonNo = new Button
      {
        Size = new Size(100, 30),
        Text = "Отменить",
        //ForeColor = Color.White,
      };
      buttonNo.Location = new Point(textBoxPathFile.Width - buttonNo.Width + 15, buttonYes.Location.Y);
      buttonNo.Click += (s, e) =>
      {
        DataClass.update = false;
        this.Close();
      };

      panelSettings.Controls.Add(textBoxPathFile);
      panelSettings.Controls.Add(categoryName);
      panelSettings.Controls.Add(buttonYes);
      panelSettings.Controls.Add(buttonNo);
      textBoxPathFile.Focus();

      this.Controls.Add(panelSettings);
      this.Height = buttonNo.Location.Y + buttonNo.Height + 30;
    }

  }
}
