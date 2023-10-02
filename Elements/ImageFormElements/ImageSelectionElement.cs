using Launcher.Controls;
using LauncherNet.Controls;
using LauncherNet.Functions;

namespace LauncherNet.Elements.ImageFormElements
{
  internal class ImageSelectionElement
  {
    /// <summary>
    /// Последний элемент с текстом.
    /// </summary>
    TextElement lastTextElment = null;

    /// <summary>
    /// Последний чек-бокс
    /// </summary>
    CheckBoxElement lastCheckboxElement = null;

    /// <summary>
    /// Список расположения изображений.
    /// </summary>
    List<string> imageResources = null;

    /// <summary>
    /// Загрузка элементов выбора изображения для обложки приложения.
    /// </summary>
    /// <param name="nameFile">Имя добавляемого файла.</param>
    /// <returns></returns>
    public Panel CreateImageSelection(string nameFile)
    {
      Panel mainPanel = new()
      {
        AutoScroll = true,
        Size = DataClass.imageSelectionForm.Size,
        Location = new Point(0, 0),
      };

      imageResources = new SearchImage().ImageSearch(nameFile);
      int locationX = 24;
      int locationY = 19;

      for (int i = 0; i < DataClass.countImageSearch; i++)
      {
        Panel fileСontrols = CreateFileElements();
        PictureBox pictureBoxImageApp = CreateImageAppElement();

        CheckImageResours(pictureBoxImageApp, i);
        Panel selectionElement = CreateMainSelectionElement(fileСontrols, pictureBoxImageApp);

        fileСontrols.Controls.Add(pictureBoxImageApp);
        fileСontrols.Controls.Add(selectionElement);
        LocationElements(ref locationX, ref locationY, fileСontrols);

        mainPanel.Controls.Add(fileСontrols);
        DataClass.imageElementsSelectionForm.Add(fileСontrols);
      }
      return mainPanel;
    }

    /// <summary>
    /// Возвращает элемент выбора картинки.
    /// </summary>
    /// <returns></returns>
    private Panel CreateFileElements()
    {
      Panel fileСontrols = new()
      {
        Size = new Size(DataClass.sizeAppElement.Width, DataClass.sizeAppElement.Height),
        BorderStyle = BorderStyle.FixedSingle,
      };

      return fileСontrols;
    }

    /// <summary>
    /// Возвращает элемент с обложкой файла.
    /// </summary>
    /// <returns></returns>
    private PictureBox CreateImageAppElement()
    {
      PictureBox pictureBoxImageApp = new()
      {
        Height = DataClass.sizeAppElement.Height - 40,
        Dock = DockStyle.Top,
      };

      return pictureBoxImageApp;
    }

    /// <summary>
    /// Пнаель выбора изображения.
    /// </summary>
    /// <param name="fileСontrols">Общий элемент выбора картинки.</param>
    /// <param name="pictureBoxImageApp">Элемент с картинкой.</param>
    /// <returns></returns>
    private Panel CreateMainSelectionElement(Panel fileСontrols, PictureBox pictureBoxImageApp)
    {
      int width = 20;

      Panel selectionElement = CreateSelectionElement(fileСontrols, pictureBoxImageApp);
      TextElement labelFileName = CreateTextElement(selectionElement, width);
      CheckBoxElement checkBoxElement = CreateCheckBox(selectionElement, labelFileName, pictureBoxImageApp, 20);

      selectionElement.Controls.Add(checkBoxElement);
      selectionElement.Controls.Add(labelFileName);

      return selectionElement;
    }

    /// <summary>
    /// Создаёт панель для элементов выбора картинки.
    /// </summary>
    /// <param name="fileСontrols">Общий элемент выбора картинки.</param>
    /// <param name="pictureBoxImageApp">Элемент с картинкой.</param>
    /// <returns></returns>
    private Panel CreateSelectionElement(Panel fileСontrols, PictureBox pictureBoxImageApp)
    {
      Panel selectionElement = new()
      {
        Height = fileСontrols.Height - pictureBoxImageApp.Height,
        Width = fileСontrols.Width,
      };
      selectionElement.Location = new Point(0, fileСontrols.Height - selectionElement.Height);

      return selectionElement;
    }

    /// <summary>
    /// Создаёт элемент подписи под картинкой.
    /// </summary>
    /// <param name="selectionElement">Панель со всеми элементами выбора картнки.</param>
    /// <param name="width">Ширина элемента.</param>
    /// <returns></returns>
    private TextElement CreateTextElement(Panel selectionElement, int width)
    {

      TextElement labelFileName = new()
      {
        Height = selectionElement.Height,
        Text = "Выбрать",
        Width = selectionElement.Width - width * 2,
        TextAlignHorizontal = StringAlignment.Near,
        Dock = DockStyle.Right,
      };

      return labelFileName;
    }

    /// <summary>
    /// Создаёт элемент чек-бокс.
    /// </summary>
    /// <param name="selectionElement">Панель со всеми элементами выбора картнки.</param>
    /// <param name="labelFileName">Элемент с текстом картинки.</param>
    /// <param name="pictureBoxImageApp">Элемент с картинкой.</param>
    /// <param name="width">Ширина элемента.</param>
    /// <returns></returns>
    private CheckBoxElement CreateCheckBox(Panel selectionElement,TextElement labelFileName, PictureBox pictureBoxImageApp, int width)
    {
      CheckBoxElement checkBoxElement = new()
      {
        Width = width,
        Height = width,
        Active = false,
      };
      checkBoxElement.Location = new Point(10, (selectionElement.Height - checkBoxElement.Height) / 2);
      checkBoxElement.MouseEnter += (s, a) => TextSelectionElements(checkBoxElement, labelFileName, true);
      checkBoxElement.MouseLeave += (s, a) => TextSelectionElements(checkBoxElement, labelFileName, false);
      checkBoxElement.MouseDown += (s, a) => ImageSelection(checkBoxElement, pictureBoxImageApp, labelFileName);
      return checkBoxElement;
    }

    /// <summary>
    /// Смена текста элемента.
    /// </summary>
    /// <param name="checkBoxElement">Экземпляр чек бокса.</param>
    /// <param name="labelFileName">Экземпляр текста.</param>
    /// <param name="mouseEnter">Наведение мыши.</param>
    private void TextSelectionElements(CheckBoxElement checkBoxElement, TextElement labelFileName, bool mouseEnter)
    {
      if (!checkBoxElement.Active && mouseEnter) labelFileName.Text = "Выбрать?";
      else if (!checkBoxElement.Active) labelFileName.Text = "Выбрать";
    }

    /// <summary>
    /// Проверяет и устанавливает картинку на элемент.
    /// </summary>
    /// <param name="pictureBoxImageApp">Элемент с картинкой.</param>
    /// <param name="index">Номер картинки в списке.</param>
    private void CheckImageResours(PictureBox pictureBoxImageApp , int index)
    {
      if (imageResources != null)
      {
        pictureBoxImageApp.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxImageApp.ImageLocation = imageResources[index];
      }
    }

    /// <summary>
    /// Выбор изображения.
    /// </summary>
    /// <param name="checkBoxElement">Экземпляр чек бокса.</param>
    /// <param name="pictureBoxImageApp">Экземпляр отображения изображения.</param>
    /// <param name="labelFileName">Экземпляр текста.</param>
    private void ImageSelection(CheckBoxElement checkBoxElement, PictureBox pictureBoxImageApp, TextElement labelFileName)
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
    }

    /// <summary>
    /// Расположение элемента на форме.
    /// </summary>
    /// <param name="locationX">Ось X.</param>
    /// <param name="locationY">ОСь Y.</param>
    /// <param name="fileСontrols">"Экземпляр элемента./</param>
    private void LocationElements(ref int locationX, ref int locationY, Panel fileСontrols)
    {
      if (locationX + fileСontrols.Width + 10 < DataClass.imageSelectionForm.Width)
      {
        fileСontrols.Location = new Point(locationX, locationY);
        locationX += DataClass.sizeAppElement.Width + 10;
      }
      else
      {
        locationX = 24;
        locationY += DataClass.sizeAppElement.Height + 19;
        fileСontrols.Location = new Point(locationX, locationY);
        locationX += DataClass.sizeAppElement.Width + 10;
      }
    }
  }
}
