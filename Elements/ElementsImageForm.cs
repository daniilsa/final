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


    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="imageForm">Экземляр формы.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя добавляемого файла.</param>
    public void LoadElements(Form imageForm,string nameCategory, string nameFile)
    {
      Panel mainPanel = MainElement();
      mainPanel = LoadImageSelection(imageForm, mainPanel, nameCategory, nameFile);
      imageForm.Controls.Add(mainPanel);
    }

    /// <summary>
    /// Главная панель со всеми элементами.
    /// </summary>
    /// <returns></returns>
    private Panel MainElement()
    {
      Panel mainPanel = new Panel()
      {
        Dock = DockStyle.Fill,
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
    private Panel LoadImageSelection(Form imageForm, Panel mainPanel, string nameCategory, string nameFile)
    {

      List<string> imageResources = new SearchImage().ImageSearch(nameFile);

      int locationX = 40;
      int locationY = 40;


      for (int i = 0; i < DataClass.countImageSearch; i++)
      {
        Panel fileСontrols = new Panel();
        fileСontrols.Size = new System.Drawing.Size(DataClass.sizelAppElement.Width, DataClass.sizelAppElement.Height);
        fileСontrols.BorderStyle = BorderStyle.FixedSingle;

        // Картинка файла
        PictureBox pictureBoxImageApp = new PictureBox();
        pictureBoxImageApp.Height = DataClass.sizelAppElement.Height - 40;
        pictureBoxImageApp.Dock = DockStyle.Top;
        pictureBoxImageApp.BackColor = Color.Green;

        if (imageResources != null)
        {
          pictureBoxImageApp.ImageLocation = imageResources[i];
          pictureBoxImageApp.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Для запуска файла
        Label labelFileName = new Label();
        labelFileName.Height = fileСontrols.Height - pictureBoxImageApp.Height;
        labelFileName.Dock = DockStyle.Bottom;
        labelFileName.Text = "Выбрать";
        labelFileName.BorderStyle = BorderStyle.FixedSingle;

        labelFileName.MouseDown += (s, a) =>
        {
          DataClass.locationImage = pictureBoxImageApp.ImageLocation;
          new FunctionsApps().SaveImagefromInternet(nameCategory, nameFile);
          imageForm.Close();

        };

        fileСontrols.Controls.Add(pictureBoxImageApp);
        fileСontrols.Controls.Add(labelFileName);

        if (locationX + fileСontrols.Width + 10 < imageForm.Width)
        {
          fileСontrols.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataClass.sizelAppElement.Width + 10;
        }
        else
        {
          locationX = 40;
          locationY += DataClass.sizelAppElement.Height + 22;
          fileСontrols.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataClass.sizelAppElement.Width + 10;
        }
        mainPanel.Controls.Add(fileСontrols);
      }
      return mainPanel;
    }
  }
}
