using Launcher.Controls;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Front;
using LauncherNet.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherNet.Elements
{
  public class ElementsImageForm
  {
    TextElement lastTextElment = null;
    CheckBoxElement lastCheckboxElement = null;
    Form imageForm;

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="imageForm">Экземляр формы.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя добавляемого файла.</param>
    public void LoadElements(Form imageForm, string nameCategory, string nameFile)
    {
      this.imageForm = imageForm;

      DataClass.locationImage = string.Empty;
      DataClass.imageSelectionForm = imageForm;

      Panel topPanel = CreateTopPanel();
      DataClass.topElementSelectionForm = topPanel;

      Panel mainPanel = MainElement( topPanel);
      DataClass.mainAppsSelectionForm = mainPanel;

      Panel bottomPanel = BottomElement(mainPanel,nameFile,nameCategory);
      DataClass.bottomElementSelectionForm = bottomPanel;

      mainPanel = LoadImageSelection( mainPanel, nameCategory, nameFile);
      imageForm.Controls.Add(topPanel);
      imageForm.Controls.Add(mainPanel);
    }

    /// <summary>
    /// Возвращает экземляр верхней панели приложения. 
    /// </summary>
    /// <returns></returns>
    private Panel CreateTopPanel()
    {
      // Вся верхняя панель.
      Panel topPanel = new Panel()
      {
        Dock = DockStyle.Top,
        Height = 50,
      };

      // Панель с кнопками упралвения формой.
      Panel panelButtons = new Panel()
      {
        Dock = DockStyle.Right,
      };

      Size buttonSize = new Size(topPanel.Height, topPanel.Height);
      DataClass.Location buttonLocation = new DataClass.Location(0, 0);

      BorderButtonElement minimaze = new BorderButtonElement()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Minimaze,
        ForeColor = Color.White,
      };
      minimaze.Location = new Point(buttonLocation.X, buttonLocation.Y);
      minimaze.MouseDown += (s, a) => imageForm.WindowState = FormWindowState.Minimized;
      buttonLocation.LocationElement = new Point(minimaze.Width + minimaze.Location.X, buttonLocation.Y);

      BorderButtonElement maximaze = new BorderButtonElement()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonElement.Choice.Maximaze,
        ForeColor = Color.White,
      };
      maximaze.Location = new Point(buttonLocation.X, buttonLocation.Y);
      maximaze.MouseDown += (s, a) =>
      {
        if (imageForm.WindowState == FormWindowState.Maximized) imageForm.WindowState = FormWindowState.Normal;
        else imageForm.WindowState = FormWindowState.Maximized;
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
      exit.MouseDown += (s, a) => imageForm.Close();
      panelButtons.Width = (minimaze.Width * 6) / 2;

      panelButtons.Controls.Add(minimaze);
      panelButtons.Controls.Add(maximaze);
      panelButtons.Controls.Add(exit);
      topPanel.Controls.Add(panelButtons);

      return topPanel;
    }

    /// <summary>
    /// Главная панель со всеми элементами.
    /// </summary>
    /// <returns></returns>
    private Panel MainElement(Panel topPanel)
    {
      Panel mainPanel = new Panel()
      {
        Height = imageForm.Height - topPanel.Height,
        Width = imageForm.Width,
        Location = new Point(0, topPanel.Height),
        AutoScroll = true,
      };

      return mainPanel;
    }

    /// <summary>
    /// Загрузка элементов выбора изображения для обложки приложения.
    /// </summary>
    /// <param name="imageForm">Экземляр формы.</param>
    /// <param name="mainPanel">Главная панель со всеми элементами.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя добавляемого файла.</param>
    /// <returns></returns>
    private Panel LoadImageSelection(Panel mainPanel, string nameCategory, string nameFile)
    {
      List<string> imageResources = new SearchImage().ImageSearch(nameFile);
      int locationX = 24;
      int locationY = 19;

      //TODO: Разбить на разные методы
      for (int i = 0; i < DataClass.countImageSearch; i++)
      {
<<<<<<< HEAD
        // Главный элемент выбора картинки.
        Panel fileСontrols = new Panel
        {
          Size = new System.Drawing.Size(DataClass.sizeAppElement.Width, DataClass.sizeAppElement.Height),
          BorderStyle = BorderStyle.FixedSingle,
        };

        // Картинка файла
        PictureBox pictureBoxImageApp = new PictureBox
        {
          Height = DataClass.sizeAppElement.Height - 40,
          Dock = DockStyle.Top,
        };
=======
        Panel fileСontrols = new Panel();
        fileСontrols.Size = new System.Drawing.Size(DataClass.sizeAppElement.Width, DataClass.sizeAppElement.Height);
        fileСontrols.BorderStyle = BorderStyle.FixedSingle;

        // Картинка файла
        PictureBox pictureBoxImageApp = new PictureBox();
        pictureBoxImageApp.Height = DataClass.sizeAppElement.Height - 40;
        pictureBoxImageApp.Dock = DockStyle.Top;
        pictureBoxImageApp.BackColor = Color.Green;

>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
        if (imageResources != null)
        {
          pictureBoxImageApp.SizeMode = PictureBoxSizeMode.Zoom;
          pictureBoxImageApp.ImageLocation = imageResources[i];
        }

        // Для запуска файла
        Panel choisePanel = new Panel
        {
          Height = fileСontrols.Height - pictureBoxImageApp.Height,
          Width = fileСontrols.Width,
        };
        choisePanel.Location = new Point(0, fileСontrols.Height - choisePanel.Height);

        // Выбор картинки
        CheckBoxElement checkBoxElement = new CheckBoxElement
        {
          Width = 20,
          Height = 20,
          Active = false,
        };
        checkBoxElement.Location = new Point(10, (choisePanel.Height - checkBoxElement.Height) / 2);

        TextElement labelFileName = new TextElement
        {
          Height = choisePanel.Height,
          Text = "Выбрать",
          Width = choisePanel.Width - checkBoxElement.Width * 2,
          TextAlignHorizontal = StringAlignment.Near,
          Dock = DockStyle.Right,
        };

        choisePanel.Controls.Add(checkBoxElement);
        choisePanel.Controls.Add(labelFileName);

        checkBoxElement.MouseEnter += (s, a) =>
        {
          if (!checkBoxElement.Active) labelFileName.Text = "Выбрать?";
        };
        checkBoxElement.MouseLeave += (s, a) =>
        {
          if (!checkBoxElement.Active) labelFileName.Text = "Выбрать";
        };
        checkBoxElement.MouseDown += (s, a) =>
        {
          if (lastCheckboxElement != null)
          {
            lastCheckboxElement.Active = false;
            lastCheckboxElement.Invalidate();
            lastTextElment.Text = "Выбрать";
          }
          DataClass.locationImage = pictureBoxImageApp.ImageLocation;
          lastCheckboxElement = checkBoxElement;
          lastTextElment = labelFileName;
          checkBoxElement.Active = true;
          labelFileName.Text = "Выбрано";
        
        };

        fileСontrols.Controls.Add(pictureBoxImageApp);
        fileСontrols.Controls.Add(choisePanel);

        if (locationX + fileСontrols.Width + 10 < imageForm.Width)
        {
          fileСontrols.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataClass.sizeAppElement.Width + 10;
        }
        else
        {
<<<<<<< HEAD
          locationX = 24;
          locationY += DataClass.sizeAppElement.Height + 19;
=======
          locationX = 40;
          locationY += DataClass.sizeAppElement.Height + 22;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
          fileСontrols.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataClass.sizeAppElement.Width + 10;
        }

        mainPanel.Controls.Add(fileСontrols);
        DataClass.imageElementsSelectionForm.Add(fileСontrols);
      }
      return mainPanel;

    }

    /// <summary>
    /// Нижний элемент формы.
    /// </summary>
    /// <param name="mainPanel"></param>
    /// <returns></returns>
    private Panel BottomElement(Panel mainPanel, string nameFile, string nameCategory)
    {
      //TODO: Подумать про раскидку элементов по отдельным методам
      Panel bottomPanel = new Panel
      {
        Height = 80,
        Dock = DockStyle.Bottom,
        //BorderStyle = BorderStyle.None
      };

      TextElement yes = new TextElement
      {
        //BackColor = BackColorElements.BackColorForm,
        //Font = FontElements.FontApp,
        Height = 40,
        TextAlignHorizontal = StringAlignment.Center,
        Dock = DockStyle.None,
        Text = "Применить",
        Width = Convert.ToInt32(Math.Abs(DataClass.sizeAppElement.Width * 1.5)),
        Name = "Yes",
      };
      yes.Location = new Point(24, (bottomPanel.Height - yes.Height) / 2);
      yes.MouseEnter += (s, a) =>
      {
        if (lastTextElment == null)
        {
          yes.Text = "Выберите картинку!";
        }
      };
      yes.MouseLeave += (s, a) =>
      {
        yes.Text = "Применить";
      };
      yes.MouseDown += (s, a) =>
      {
        if (DataClass.locationImage != null && DataClass.locationImage != string.Empty)
        {
          DataClass.locationImage = DataClass.locationImage;
          new FunctionsApps().SaveImagefromInternet(nameCategory, nameFile);
          imageForm.Close();
        }
      };

      TextElement no = new TextElement
      {
        Height = 40,
        Width = Convert.ToInt32(Math.Abs(DataClass.sizeAppElement.Width * 1.5)),
        Dock = DockStyle.None,
        Text = "Отменить",
        TextAlignHorizontal = StringAlignment.Center,
        Name = "No",
      };
      no.Location = new Point(mainPanel.Width - 40 - no.Width, (bottomPanel.Height - no.Height) / 2);
      no.MouseEnter += (s, a) =>
      {
        no.BackColor = BackColorElements.BackColorTopElement;
        no.ForeColor = FontElements.DefaultForeColorCategory;
      };
      no.MouseLeave += (s, a) =>
      {
        no.BackColor = BackColorElements.BackColorForm;
        no.ForeColor = FontElements.DefaultForeColorApp;
      };
      no.MouseDown += (s, a) =>
      {
        DataClass.locationImage = string.Empty;
        imageForm.Close();
      };

      bottomPanel.Controls.Add(yes);
      bottomPanel.Controls.Add(no);
      mainPanel.Controls.Add(bottomPanel);

      return bottomPanel;
    }
  }
}
