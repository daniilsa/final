using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.Controls;
using LauncherNet.Functions;

namespace LauncherNet.Elements.ImageFormElements
{
  internal class ImageSelectionElement
  {
    /// <summary>
    /// Последний элемент с текстом.
    /// </summary>
    private TextControl? lastTextElment = null;

    /// <summary>
    /// Последний чек-бокс
    /// </summary>
    private CheckBoxControl? lastCheckboxElement = null;

    /// <summary>
    /// Список расположения изображений.
    /// </summary>
    private List<string>? imageResources = null;

    /// <summary>
    /// Загрузка элементов выбора изображения для обложки приложения.
    /// </summary>
    /// <param name="nameFile">Имя добавляемого файла.</param>
    /// <returns></returns>
    public Panel? CreateImageSelection(string nameFile, ref bool next)
    {
      Panel mainPanel = new()
      {
        AutoScroll = true,
        Location = new Point(0, 0),
      };

      if (DataImageSelectionForm.imageSelectionForm != null)
        mainPanel.Size = DataImageSelectionForm.imageSelectionForm.Size;
      imageResources = new SearchImage().ImageSearch(nameFile, ref next);
      if (!next) return null;

      int locationX = 24;
      int locationY = 19;

      for (int i = 0; i < DataImageSelectionForm.countImageSearch; i++)
      {
        Panel fileСontrols = CreateFileElements();
        PictureBox pictureBoxImageApp = CreateImageAppElement();

        CheckImageResours(pictureBoxImageApp, i);
        Panel selectionElement = CreateMainSelectionElement(fileСontrols, pictureBoxImageApp);

        fileСontrols.Controls.Add(pictureBoxImageApp);
        fileСontrols.Controls.Add(selectionElement);
        LocationElements(ref locationX, ref locationY, fileСontrols);

        mainPanel.Controls.Add(fileСontrols);
        DataImageSelectionForm.imageElementsSelectionForm?.Add(fileСontrols);
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
        Size = new Size(DataLauncherForm.sizeAppElement.Width, DataLauncherForm.sizeAppElement.Height),
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
        Height = DataLauncherForm.sizeAppElement.Height - 40,
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
      TextControl labelFileName = CreateTextElement(selectionElement, width);
      CheckBoxControl checkBoxElement = CreateCheckBox(selectionElement, labelFileName, pictureBoxImageApp, 20);

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
    private TextControl CreateTextElement(Panel selectionElement, int width)
    {

      TextControl labelFileName = new()
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
    private CheckBoxControl CreateCheckBox(Panel selectionElement, TextControl labelFileName, PictureBox pictureBoxImageApp, int width)
    {
      CheckBoxControl checkBoxElement = new()
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
    private void TextSelectionElements(CheckBoxControl checkBoxElement, TextControl labelFileName, bool mouseEnter)
    {
      if (!checkBoxElement.Active && mouseEnter) labelFileName.Text = "Выбрать?";
      else if (!checkBoxElement.Active) labelFileName.Text = "Выбрать";
    }

    /// <summary>
    /// Проверяет и устанавливает картинку на элемент.
    /// </summary>
    /// <param name="pictureBoxImageApp">Элемент с картинкой.</param>
    /// <param name="index">Номер картинки в списке.</param>
    private void CheckImageResours(PictureBox pictureBoxImageApp, int index)
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
    private void ImageSelection(CheckBoxControl checkBoxElement, PictureBox pictureBoxImageApp, TextControl labelFileName)
    {
      if (lastCheckboxElement != null && lastTextElment != null)
      {
        lastCheckboxElement.Active = false;
        lastCheckboxElement.Invalidate();
        lastTextElment.Text = "Выбрать";
      }
      DataLauncherForm.locationImage = pictureBoxImageApp.ImageLocation;
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
      if (locationX + fileСontrols.Width + 10 < DataImageSelectionForm.imageSelectionForm?.Width)
      {
        fileСontrols.Location = new Point(locationX, locationY);
        locationX += DataLauncherForm.sizeAppElement.Width + 10;
      }
      else
      {
        locationX = 24;
        locationY += DataLauncherForm.sizeAppElement.Height + 19;
        fileСontrols.Location = new Point(locationX, locationY);
        locationX += DataLauncherForm.sizeAppElement.Width + 10;
      }
    }
  }
}
