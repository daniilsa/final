using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Front;
using LauncherNet.Settings;

namespace LauncherNet._Front
{
  public class DesignLauncherForm
  {
    /// <summary>
    /// Настраивает внешний вид всех элементов на форме лаунчера.
    /// </summary>
    public void LoadDesignLauncher()
    {
      if (DataLauncherForm.launcher != null)
      {
        try
        {
          if (FontElements.FontCategory.Name.Contains("Parameter is not valid"))
            new UpdateClass().UpdateMethod(DataLauncherForm.launcher);
          else
          {
            DesignLauncher(DataLauncherForm.launcher);
            if (DataLauncherForm.topElementLauncher != null)
              DesignTopElement(DataLauncherForm.topElementLauncher);

            if (DataLauncherForm.categoriesElementLauncher != null)
              DesignCategoriesElementLauncher(DataLauncherForm.categoriesElementLauncher);

            if (DataLauncherForm.categoryElementLauncher != null)
            {
              foreach (TextControl value in DataLauncherForm.categoryElementLauncher)
                DesignCategoryElementLauncher(value);
            }

            if (DataLauncherForm.controlAddCategory != null)
              DesignCategoryAddElement(DataLauncherForm.controlAddCategory);

            if (DataLauncherForm.mainAppsLauncher != null)
              foreach (ScrollBarControl value in DataLauncherForm.mainAppsLauncher)
              {
                DesignMainAppsElementLauncher(value);
              }

            if (DataLauncherForm.controlAddApp != null)
              foreach (ControlAddControl value in DataLauncherForm.controlAddApp)
              {
                DesignAppAddElements(value);
              }

            if (DataLauncherForm.functionsApp != null)
              foreach (ContextMenuStrip value in DataLauncherForm.functionsApp)
              {
                DesignContextMenuFunctionsApp(value);
              }

            if (DataLauncherForm.functionsCategory != null)
              foreach (ContextMenuStrip value in DataLauncherForm.functionsCategory)
              {
                DesignContextMenuFunctionsApp(value);
              }

          }
        }
        catch
        {
          new UpdateClass().UpdateMethod(DataLauncherForm.launcher);
        }
      }
    }

    /// <summary>
    /// Настраивает внешний вид формы.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    private void DesignLauncher(Form value)
    {
      value.BackColor = BackColorElements.MainLightColor;
    }

    /// <summary>
    /// Настраивает внешний вид верхней панели.
    /// </summary>
    private void DesignTopElement(Panel value)
    {
      value.BackColor = BackColorElements.MainDarkColor;

      foreach (var element in value.Controls)
        if (element.GetType() == new BorderButtonControl().GetType())
        {
          if (element is BorderButtonControl button)
          {
            button.ForeColor = FontElements.MainLightColorText;

            button.MouseEnter += (s, a) =>
            {
              button.BackColor = BackColorElements.AdditionalDarkColor;
            };
            button.MouseLeave += (s, a) =>
            {
              button.BackColor = BackColorElements.MainDarkColor;
            };
          }
        }
        else if (element.GetType() == new Label().GetType())
        {
          if (element is Label text)
          {
            text.Font = FontElements.FontLabelInfo;
            text.ForeColor = FontElements.MainLightColorText;
          }
        }
    }

    /// <summary>
    /// Настраивает внешний вид  элемента со всеми категориями.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    private void DesignCategoriesElementLauncher(Panel value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
    }

    /// <summary>
    /// Настраивает внешний вид элемента категории.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    public void DesignCategoryElementLauncher(TextControl value)
    {
      value.Font = FontElements.FontCategory;
      value.ForeColor = FontElements.MainLightColorText;
      value.BackColor = BackColorElements.MainDarkColor;

      value.MouseEnter += (s, e) =>
      {
        if (value != DataLauncherForm.activeCategoryPanelLauncher) value.BackColor = BackColorElements.AdditionalDarkColor;
      };
      value.MouseLeave += (s, e) =>
      {
        if (value != DataLauncherForm.activeCategoryPanelLauncher) value.BackColor = BackColorElements.MainDarkColor;
      };

      if (DataLauncherForm.activeCategoryPanelLauncher != null)
      {
        DataLauncherForm.activeCategoryPanelLauncher.ForeColor = FontElements.MainDarkColorText;
        DataLauncherForm.activeCategoryPanelLauncher.BackColor = BackColorElements.MainLightColor;
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента создания новой категории.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    private void DesignCategoryAddElement(ControlAddControl value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
      value.BorderColor = FontElements.MainLightColorText;
      value.MouseEnter += (s, e) => value.Opacity = 255;
      value.MouseLeave += (s, e) => value.Opacity = 80;
    }

    /// <summary>
    /// Настраивает внешний вид элемента добавления приложения.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    public void DesignAppAddElements(ControlAddControl value)
    {
      value.BackColor = BackColorElements.AdditionalLight;
      value.BorderColor = FontElements.MainDarkColorText;
      value.MouseEnter += (s, e) => value.Opacity = 255;
      value.MouseLeave += (s, e) => value.Opacity = 80;

    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми приложениями.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    private void DesignMainAppsElementLauncher(ScrollBarControl value)
    {
      try
      {
        value.BackColor = BackColorElements.MainLightColor;
        value.BackColorScroll = BackColorElements.MainLightColor;
        value.BackColorCaret = BackColorElements.MainDarkColor;

        foreach (Panel mainPanel in value.Controls)
        {
          mainPanel.BackColor = BackColorElements.MainLightColor;
          foreach (Panel control in mainPanel.Controls)
            DesignAppElementLauncher(control);
        }
      }
      catch
      {
        // Сюда, ПОЧЕМУ-ТО попадает плашка добавления приложения, так что пусть будет
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента с приложением.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    public void DesignAppElementLauncher(Panel value)
    {
      if (value.Controls[0].GetType() == new PictureBox().GetType() && value.Controls[1].GetType() == new TextControl().GetType())
      {
        PictureBox? picture = new();
        foreach (var pictureBox in value.Controls)
          if (pictureBox.GetType() == new PictureBox().GetType())
          {
            picture = pictureBox as PictureBox;
            break;
          }

        string pathFile = string.Empty;
        string pathImages = string.Empty;
        if (picture != null)
        {
          picture.BackgroundImageLayout = ImageLayout.Zoom;
          picture.BackColor = BackColorElements.AdditionalLight;
          pathFile = DataClass.CategoriesPathFiles + "\\" + picture.Tag.ToString();
          pathImages = DataClass.PathImages + "\\" + picture.Tag.ToString() + "\\";
        }
        if (pathImages != string.Empty && picture != null)
        {
          if (File.Exists(pathImages + picture.Name + ".jpg"))
          {
            using var imgStream = File.OpenRead(pathImages + picture.Name + ".jpg");
            picture.BackgroundImage = Image.FromStream(imgStream);
          }
          else
          {
            try
            {
              using var imgStream = File.OpenRead(@$"{DataClass.PathImages}\Default.jpg");
              picture.BackgroundImage = Image.FromStream(imgStream);
            }
            catch
            {
              picture.BackColor = Color.Red;
            }
          }
        }

        TextControl? text = new();
        foreach (var textElement in value.Controls)
          if (textElement.GetType() == new TextControl().GetType())
          {
            text = textElement as TextControl;
            break;
          }
        if (text != null)
        {
          text.BackColor = BackColorElements.AdditionalLight;
          text.ForeColor = FontElements.MainDarkColorText;
          text.Font = FontElements.FontApp;

          text.MouseEnter += (s, a) =>
          {
            text.BackColor = BackColorElements.MainDarkColor;
            text.ForeColor = FontElements.MainLightColorText;
          };
          text.MouseLeave += (s, a) =>
          {
            text.BackColor = BackColorElements.AdditionalLight;
            text.ForeColor = FontElements.MainDarkColorText;
          };
        }
      }
    }

    /// <summary>
    /// Настраивает внешний вид контектного меню.
    /// </summary>
    /// <param name="value">Элемент для настроек.</param>
    private void DesignContextMenuFunctionsApp(ContextMenuStrip value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
      value.ForeColor = FontElements.MainLightColorText;
      value.Renderer = new ContextMenuStripRenderer();

    }
  }
}
