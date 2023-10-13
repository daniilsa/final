using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet._Front;
using LauncherNet.BackUp;
using LauncherNet.DesignFront;
using LauncherNet.Files;
using LauncherNet.Front;

namespace LauncherNet.Elements.SettingsApplicationFormElements
{

  internal class CreateElementsSettingsApplicationForm
  {
    private Label? mainColorFirstText;
    private Label? additionalColorFirstText;
    private Label? mainColorSeconfText;
    private Label? additionalColorSeconfText;

    private PictureBox? mainColorFirstColor;
    private PictureBox? additionalColorFirstColor;
    private PictureBox? mainColorSecondColor;
    private PictureBox? additionalColorSecondColor;

    private TextControl? yes;
    private TextControl? defaultColor;

    private Panel? testPanel;
    private List<TextControl> categoryList = new List<TextControl>();
    private Panel? categoriesPanel;
    private Panel? topPanel;
    private Label? topLabel;
    private Panel? mainApps;


    public static Label? Label;
    /// <summary>
    /// Настройка элементов при запуске формы.
    /// </summary>
    /// <param name="value">Экземпляр формы.</param>
    /// <param name="text">Текст приветствия.</param>
    public void CreateElementsDownloadForm(Form value, string? text)
    {
      Label = HiThere(value, text);
      value.Controls.Add(Label);
    }

    /// <summary>
    /// Элемент текста приветствия.
    /// </summary>
    /// <param name="value">Экземпляр формы.</param>
    /// <param name="text">Текст приветствия.</param>
    /// <returns></returns>
    private Label HiThere(Form value, string? text)
    {
      Label hello = new Label()
      {
        Text = text,
      };
      hello.Font = new Font(hello.Font.FontFamily, 40);
      hello.Size = TextRenderer.MeasureText(hello.Text, hello.Font);
      hello.Location = new((value.Width - hello.Width) / 2, (value.Height - hello.Height) / 2);
      DataSettingsApplicationForm.HelloText = hello;

      return hello;
    }

    /// <summary>
    /// Установка текста приветствия.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="text"></param>
    public void SetText(Form value, string text, Font font)
    {
      if (Label != null)
      {
        Label.Text = text;
        Label.Font = font;
        Label.Size = TextRenderer.MeasureText(Label.Text, Label.Font);
        Label.Location = new((value.Width - Label.Width) / 2, (value.Height - Label.Height) / 2);
      }
    }

    /// <summary>
    /// Форма настроек приложения.
    /// </summary>
    /// <param name="value"></param>
    public void CreaeteElementForm(Form value)
    {
      value.Controls.Clear();
      int locationX = CreatePanelLabel();
      CreatePanelColor(locationX);

      value.Controls.Add(mainColorFirstText);
      value.Controls.Add(additionalColorFirstText);
      value.Controls.Add(mainColorSeconfText);
      value.Controls.Add(additionalColorSeconfText);

      value.Controls.Add(mainColorFirstColor);
      value.Controls.Add(additionalColorFirstColor);
      value.Controls.Add(mainColorSecondColor);
      value.Controls.Add(additionalColorSecondColor);

      new DesignSettingsApplicationForm().LoadDesignSettingsApplicationForm(true);

      PanelButton(value);
      value.Controls.Add(yes);
      value.Controls.Add(defaultColor);

      TestPanel(value);
      value.Controls.Add(testPanel);
    }

    /// <summary>
    /// Создаёт панель с тектовыми элементами.
    /// </summary>
    private int CreatePanelLabel()
    {
      int maxWidth = 0;
      mainColorFirstText = CreateTextSettings("Основной цвет категорий :");
      mainColorFirstText.Location = new Point(20, 20);
      if (maxWidth < mainColorFirstText.Width)
        maxWidth = mainColorFirstText.Width;

      additionalColorFirstText = CreateTextSettings("Дополнительный цвет категорий:");
      additionalColorFirstText.Location = new Point(20, mainColorFirstText.Location.Y + mainColorFirstText.Height + 10);
      if (maxWidth < additionalColorFirstText.Width)
        maxWidth = additionalColorFirstText.Width;

      mainColorSeconfText = CreateTextSettings("Основной цвет панели приложений:");
      mainColorSeconfText.Location = new Point(20, additionalColorFirstText.Location.Y + additionalColorFirstText.Height + 40);
      if (maxWidth < mainColorSeconfText.Width)
        maxWidth = mainColorSeconfText.Width;

      additionalColorSeconfText = CreateTextSettings("Дополнительный цвет панели приложений:");
      additionalColorSeconfText.Location = new Point(20, mainColorSeconfText.Location.Y + mainColorSeconfText.Height + 10);
      if (maxWidth < additionalColorSeconfText.Width)
        maxWidth = additionalColorSeconfText.Width;



      return maxWidth += 40;
    }

    /// <summary>
    /// Создаёт панель с отображаемыми цветами.
    /// </summary>
    private void CreatePanelColor(int locationX)
    {

      if (mainColorFirstText != null)
      {
        mainColorFirstColor = CreateColorSettings(BackColorElements.MainDarkColor, mainColorFirstText.Height);
        mainColorFirstColor.Location = new Point(locationX, mainColorFirstText.Location.Y);
      }

      if (mainColorFirstText != null && additionalColorFirstText != null)
      {
        additionalColorFirstColor = CreateColorSettings(BackColorElements.AdditionalDarkColor, mainColorFirstText.Height);
        additionalColorFirstColor.Location = new Point(locationX, additionalColorFirstText.Location.Y);
      }

      if (mainColorFirstText != null && mainColorSeconfText != null)
      {
        mainColorSecondColor = CreateColorSettings(BackColorElements.MainLightColor, mainColorFirstText.Height);
        mainColorSecondColor.Location = new Point(locationX, mainColorSeconfText.Location.Y);
      }

      if (mainColorFirstText != null && additionalColorSeconfText != null)
      {
        additionalColorSecondColor = CreateColorSettings(BackColorElements.AdditionalLight, mainColorFirstText.Height);
        additionalColorSecondColor.Location = new Point(locationX, additionalColorSeconfText.Location.Y);
      }
    }

    /// <summary>
    /// Создаёт панель с кнопками.
    /// </summary>
    /// <param name="value"></param>
    private void PanelButton(Form value)
    {

      yes = new()
      {
        Text = "Продолжить",
        TextAlignHorizontal = StringAlignment.Center,
        Dock = DockStyle.None,
        Width = (value.Width / 2) - 40,
        Font = mainColorFirstText.Font,
        BackColor = additionalColorFirstColor.BackColor,
        ForeColor = mainColorFirstText.ForeColor,
      };
      yes.Location = new Point(20, additionalColorSecondColor.Location.Y + additionalColorSecondColor.Height + 20);
      yes.Height = TextRenderer.MeasureText(yes.Text, yes.Font).Height + 10;

      yes.MouseEnter += (s, a) =>
      {
        yes.BackColor = mainColorFirstText.ForeColor;
        yes.ForeColor = additionalColorFirstColor.BackColor;
      };
      yes.MouseLeave += (s, a) =>
      {
        yes.BackColor = additionalColorFirstColor.BackColor;
        yes.ForeColor = mainColorFirstText.ForeColor;

      };
      yes.MouseClick += (s, a) =>
      {
        WorkingColor.FirstMainColor = mainColorFirstColor.BackColor;
        WorkingColor.FirstAdditionalColor = additionalColorFirstColor.BackColor;
        WorkingColor.SecondMainColor = mainColorSecondColor.BackColor;
        WorkingColor.SecondAdditionalColor = additionalColorSecondColor.BackColor;
        new LastSessionClass().GetLastRun();
        value.Close();
      };

      defaultColor = new()
      {
        Text = "По умолчанию",
        TextAlignHorizontal = StringAlignment.Center,
        BackColor = additionalColorFirstColor.BackColor,
        Dock = DockStyle.None,
        Width = (value.Width / 2) - 40,
        Font = mainColorFirstText.Font,
        ForeColor = mainColorFirstText.ForeColor,
      };
      defaultColor.Location = new Point(20 + yes.Location.X + yes.Width, yes.Location.Y);
      defaultColor.Height = TextRenderer.MeasureText(defaultColor.Text, defaultColor.Font).Height + 10;

      defaultColor.MouseEnter += (s, a) =>
      {
        defaultColor.BackColor = mainColorFirstText.ForeColor;
        defaultColor.ForeColor = additionalColorFirstColor.BackColor;
      };
      defaultColor.MouseLeave += (s, a) =>
      {
        defaultColor.BackColor = additionalColorFirstColor.BackColor;
        defaultColor.ForeColor = mainColorFirstText.ForeColor;

      };
      defaultColor.MouseClick += (s, a) =>
      {
        WorkingColor.FirstMainColor = DataClass.FirstMainColor;
        WorkingColor.FirstAdditionalColor = DataClass.FirstAdditionalColor;
        WorkingColor.SecondMainColor = DataClass.SecondMainColor;
        WorkingColor.SecondAdditionalColor = DataClass.SecondAdditionalMainColor;
        new LastSessionClass().GetLastRun();
        value.Close();
      };

    }

    /// <summary>
    /// Создаёт тестовую панель.
    /// </summary>
    private void TestPanel(Form value)
    {
      testPanel = new Panel()
      {
        Height = value.Height - (yes.Location.Y + yes.Height + 40),
        BackColor = Color.White,
        Location = new Point(0, yes.Location.Y + yes.Height + 40),
        Width = value.Width,
      };

      topPanel = new Panel()
      {
        Width = testPanel.Width,
        Height = 60,
        Location = new Point(0, 0),
      };
      topPanel.BackColor = mainColorFirstColor.BackColor;

      topLabel = CreateTextSettings("Тестовый вид");
      topLabel.Location = new(0, 5);
      topLabel.ForeColor = mainColorFirstText.ForeColor;

      topPanel.Height = topLabel.Height + 10;
      topPanel.Controls.Add(topLabel);

      categoriesPanel = new()
      {
        Location = new Point(0, topPanel.Height),
        Height = testPanel.Height - topPanel.Height,
        BackColor = topPanel.BackColor,
        Width = 150,
      };
      for (int i = 3; i >= 1; i--)
      {
        TextControl category = new()
        {
          Dock = DockStyle.Top,
          BackColor = topPanel.BackColor,
          Width = categoriesPanel.Width,
          Height = 60,
          ForeColor = mainColorFirstText.ForeColor,
          Font = new Font(mainColorFirstText.Font.FontFamily, 10),
          Tag = "none",
        };
        if (i == 3)
        {
          category.Tag = "Active";
          category.Text = $"Активная";
          category.BackColor = mainColorSecondColor.BackColor;
          category.ForeColor = mainColorFirstColor.BackColor;
        }
        if (i == 2)
        {
          category.Tag = "Hover";
          category.Text = $"При наведении";
          category.BackColor = additionalColorFirstColor.BackColor;
        }
        if (i == 1)
        {
          category.Tag = "Nope";
          category.Text = $"Категория";
        }

        categoriesPanel.Controls.Add(category);
        categoryList.Add(category);
      }

      mainApps = new()
      {
        Width = value.Width - categoriesPanel.Width,
        Height = value.Height - topPanel.Height,
        BackColor = mainColorSecondColor.BackColor,
        Location = new(categoriesPanel.Width, topPanel.Height)
      };

      testPanel.Controls.Add(topPanel);
      testPanel.Controls.Add(categoriesPanel);
      testPanel.Controls.Add(mainApps);
    }

    /// <summary>
    /// Создаёт элемент с текстом настроек.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private Label CreateTextSettings(string text)
    {
      Label label = new Label()
      {
        Text = text,
      };
      label.Font = new Font(label.Font.FontFamily, 15);
      label.Size = TextRenderer.MeasureText(label.Text, label.Font);

      return label;
    }

    /// <summary>
    /// Создаёт элемент отображения цвета.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private PictureBox CreateColorSettings(Color color, int hieght)
    {
      PictureBox pictureBox = new()
      {
        BackColor = color,
        Size = new Size(Convert.ToInt32(hieght * 2), hieght),
        BorderStyle = BorderStyle.FixedSingle,
        Tag = "false",
      };

      pictureBox.MouseClick += (s, a) =>
      {
        Color color = pictureBox.BackColor;
        if (SettingsColor(ref color))
        {
          pictureBox.BackColor = color;

          if (pictureBox == mainColorFirstColor)
          {
            if (additionalColorFirstColor?.Tag.ToString() != "true")
            {
              additionalColorFirstColor.BackColor = BackColorElements.NewColor(pictureBox.BackColor, 30);
            }
          }
          else if (pictureBox == mainColorSecondColor)
          {
            if (additionalColorSecondColor?.Tag.ToString() != "true")
            {
              additionalColorSecondColor.BackColor = BackColorElements.NewColor(pictureBox.BackColor, 30);
            }
          }
          pictureBox.Tag = "true";
          NewColor();
        }
      };

      return pictureBox;
    }

    /// <summary>
    /// Форма выбора цвета.
    /// </summary>
    /// <param name="color">Экземпляр цвета.</param>
    /// <returns></returns>
    private bool SettingsColor(ref Color color)
    {
      Cyotek.Windows.Forms.ColorPickerDialog colorPickerDialog = new Cyotek.Windows.Forms.ColorPickerDialog();
      colorPickerDialog.BackColor = BackColorElements.MainDarkColor;
      colorPickerDialog.Color = color;

      foreach (Control item in colorPickerDialog.Controls)
      {
        if (item != null && item.GetType() == new Button().GetType())
        {
          item.BackColor = BackColorElements.MainDarkColor;
          item.ForeColor = FontElements.MainLightColorText;
        }

        if (item != null && item.GetType() == new Cyotek.Windows.Forms.ColorEditor().GetType())
        {
          foreach (Control i1 in item.Controls)
          {
            if (i1.GetType() == new Label().GetType())
              i1.ForeColor = FontElements.MainLightColorText;



            if (i1.GetType() == new NumericUpDown().GetType())
            {
              i1.ForeColor = FontElements.MainLightColorText;
              i1.BackColor = BackColorElements.AdditionalDarkColor;
            }
          }
        }
      }
      colorPickerDialog.ShowDialog();
      color = colorPickerDialog.Color;
      if (colorPickerDialog.DialogResult == DialogResult.Cancel) return false;
      else return true;
    }

    /// <summary>
    /// Устанавливает выбранные цвета на элементы.
    /// </summary>
    private void NewColor()
    {
      topLabel.ForeColor = mainColorSecondColor.BackColor;
      topPanel.BackColor = mainColorFirstColor.BackColor;
      categoriesPanel.BackColor = topPanel.BackColor;
      mainApps.BackColor = mainColorSecondColor.BackColor;

      foreach (TextControl item in categoryList)
      {
        if (item.Tag.ToString() == "Nope")
        {
          item.BackColor = topPanel.BackColor;
          item.ForeColor = mainColorSecondColor.BackColor;
        }
        else if (item.Tag.ToString() == "Hover")
        {
          item.BackColor = additionalColorFirstColor.BackColor;
          item.ForeColor = mainColorSecondColor.BackColor;
        }
        else if (item.Tag.ToString() == "Active")
        {
          item.BackColor = mainColorSecondColor.BackColor;
          item.ForeColor = mainColorFirstColor.BackColor;
        }
      }
    }
  }
}
