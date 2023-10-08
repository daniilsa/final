using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.Functions;

namespace LauncherNet.Elements.ImageFormElements
{
  internal class BottomElement
  {
    /// <summary>
    /// Последняя выбранная картинка.
    /// </summary>
    private TextControl? lastTextElment = null;

    /// <summary>
    /// Нижний элемент формы.
    /// </summary>
    /// <param name="mainPanel">Главная панель.</param>
    /// <returns></returns>
    public Panel CreateBottomElement(Form imageForm, Panel? mainPanel, string nameFile, string nameCategory)
    {
      Panel bottomPanel = new()
      {
        Height = 80,
        Dock = DockStyle.Bottom,
      };

      TextControl yes = YesElement(imageForm, bottomPanel, nameFile, nameCategory);
      TextControl no = NoElement(imageForm, bottomPanel, mainPanel);

      bottomPanel.Controls.Add(yes);
      bottomPanel.Controls.Add(no);
      mainPanel?.Controls.Add(bottomPanel);

      return bottomPanel;
    }

    /// <summary>
    /// Элемент сохранения параметров.
    /// </summary>
    /// <param name="imageForm">Экземпляр формы.</param>
    /// <param name="bottomPanel">Нижняя панель.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <returns></returns>
    private TextControl YesElement(Form imageForm, Panel bottomPanel, string nameFile, string nameCategory)
    {
      TextControl yes = new()
      {
        //BackColor = BackColorElements.BackColorForm,
        //Font = FontElements.FontApp,
        Height = 40,
        TextAlignHorizontal = StringAlignment.Center,
        Dock = DockStyle.None,
        Text = "Применить",
        Width = Convert.ToInt32(Math.Abs(DataLauncherForm.sizeAppElement.Width * 1.5)),
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
      yes.MouseLeave += (s, a) => yes.Text = "Применить";
      yes.MouseDown += (s, a) => SaveImage(imageForm, nameFile, nameCategory);

      return yes;
    }

    /// <summary>
    /// Элемент, отменяюший все выбранные параметры.
    /// </summary>
    /// <param name="imageForm">Экземпляр формы.</param>
    /// <param name="bottomPanel">Нижняя панель.</param>
    /// <param name="mainPanel">Главная панель.</param>
    /// <returns></returns>
    private TextControl NoElement(Form imageForm, Panel bottomPanel, Panel? mainPanel)
    {
      TextControl no = new()
      {
        Height = 40,
        Width = Convert.ToInt32(Math.Abs(DataLauncherForm.sizeAppElement.Width * 1.5)),
        Dock = DockStyle.None,
        Text = "Отменить",
        TextAlignHorizontal = StringAlignment.Center,
        Name = "No",
      };
      if (mainPanel != null)
      {
        no.Location = new Point(mainPanel.Width - 40 - no.Width, (bottomPanel.Height - no.Height) / 2);
      }
      else
      {
        no.Location = new Point(0, (bottomPanel.Height - no.Height) / 2);
      }
      no.MouseDown += (s, a) => CloseElement(imageForm);

      return no;
    }

    /// <summary>
    /// Скачивает изображение на компьютер.
    /// </summary>
    /// <param name="imageForm">Экземпляр формы.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="nameCategory">Имя категории.</param>
    private void SaveImage(Form imageForm, string nameFile, string nameCategory)
    {
      if (DataLauncherForm.locationImage != null && DataLauncherForm.locationImage != string.Empty)
      {
        new FunctionsApps().SaveImageFromInternet(nameCategory, nameFile);
        imageForm.Close();
      }
    }

    /// <summary>
    /// Закрывает элемент выбора картинки.
    /// </summary>
    /// <param name="imageForm">Экземпляр формы.</param>
    private void CloseElement(Form imageForm)
    {
      DataLauncherForm.locationImage = string.Empty;
      imageForm.Close();

    }
  }
}
