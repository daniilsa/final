using Launcher.Controls;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LauncherNet.Front
{
  public class DesignElements
  {

    #region Общие настройки "Дизайна"

    /// <summary>
    /// Настраивает внешний вид верхней панели.
    /// </summary>
    private void DesignTopElement(Panel value)
    {
      value.BackColor = BackColorElements.BackColorTopElement;

      foreach (var panel in value.Controls)
      {
        if (panel.GetType() == new Panel().GetType())
        {
          foreach (var buttonElements in ((Panel)panel).Controls)
            if (buttonElements.GetType() == new BorderButtonElement().GetType())
            {
              BorderButtonElement button = buttonElements as BorderButtonElement;

              button.MouseEnter += (s, a) =>
              {
                button.BackColor = BackColorElements.HoverBackColorCategory;
              };
              button.MouseLeave += (s, a) =>
              {
                button.BackColor = BackColorElements.BackColorTopElement;
              };
            }

          break;
        }
      }

    }

    #endregion

    #region Настройки "Дизайна" лаунчера

    /// <summary>
    /// Настраивает внешний вид всех элементов на форме лаунчера.
    /// </summary>
    public void LoadDesignLauncher()
    {
      try
      {
        if (FontElements.FontCategory.Name.Contains("Parameter is not valid"))
          new SettingsForms().UpdateLauncher(DataClass.launcher);
        else
        {
          DesignLauncher(DataClass.launcher);
          DesignTopElement(DataClass.topElementLauncher);
          DesignCategoriesElementLauncher(DataClass.categoriesElementLauncher);

          if (DataClass.categoryElementLauncher != null)
          {
            foreach (TextElement value in DataClass.categoryElementLauncher)
              DesignCategoryElementLauncher(value);

            DesignCategoryAddElement(DataClass.controlAddCategory);
          }

          if (DataClass.mainAppsLauncher != null)
            foreach (ScrollBarElement value in DataClass.mainAppsLauncher)
            {
              DesignMainAppsElementLauncher(value);
            }

          foreach (ControlAddElement value in DataClass.controlAddApp)
          {
            DesignAppAddElements(value);
          }
        }
      }
      catch
      {
        new SettingsForms().UpdateLauncher(DataClass.launcher);
      }
    }

    /// <summary>
    /// Настраивает внешний вид формы.
    /// </summary>
    private void DesignLauncher(Form value)
    {
      value.BackColor = BackColorElements.BackColorForm;
    }

    /// <summary>
    /// Настраивает внешний вид  элемента со всеми категориями.
    /// </summary>
    private void DesignCategoriesElementLauncher(Panel value)
    {
      value.BackColor = BackColorElements.BackColorCategoriesElement;
    }

    /// <summary>
    /// Настраивает внешний вид элемента категории.
    /// </summary>
    public void DesignCategoryElementLauncher(TextElement value)
    {
      value.Font = FontElements.FontCategory;
      value.ForeColor = FontElements.DefaultForeColorCategory;
      value.BackColor = BackColorElements.DefaultBackColorCategory;

      value.MouseEnter += (s, e) =>
      {
        if (value != DataClass.activeCategoryPanelLauncher) value.BackColor = BackColorElements.HoverBackColorCategory;
      };
      value.MouseLeave += (s, e) =>
      {
        if (value != DataClass.activeCategoryPanelLauncher) value.BackColor = BackColorElements.DefaultBackColorCategory;
      };
      value.MouseDown += (s, e) =>
      {
        DataClass.lastCategoryPanelLauncher.ForeColor = FontElements.DefaultForeColorCategory;
        DataClass.lastCategoryPanelLauncher.BackColor = BackColorElements.DefaultBackColorCategory;
        value.BackColor = BackColorElements.ActiveBackColorCategory;
        value.ForeColor = FontElements.ActiveForeColorCategory;
      };

      if (DataClass.activeCategoryPanelLauncher != null)
      {
        DataClass.activeCategoryPanelLauncher.ForeColor = FontElements.ActiveForeColorCategory;
        DataClass.activeCategoryPanelLauncher.BackColor = BackColorElements.ActiveBackColorCategory;
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента создания новой категории.
    /// </summary>
    /// <param name="value"></param>
    private void DesignCategoryAddElement(ControlAddElement value)
    {
      value.BackColor = BackColorElements.DefaultBackColorCategory;
      value.BorderColor = FontElements.DefaultForeColorCategory;
      value.MouseEnter += (s, e) => value.Opacity = 255;
      value.MouseLeave += (s, e) => value.Opacity = 80;
    }

    /// <summary>
    /// Настраивает внешний вид элемента добавления приложения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignAppAddElements(ControlAddElement value)
    {
      value.BackColor = BackColorElements.BackColorAppElement;
      value.BorderColor = FontElements.DefaultForeColorApp;
      value.MouseEnter += (s, e) => value.Opacity = 255;
      value.MouseLeave += (s, e) => value.Opacity = 80;

    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми приложениями.
    /// </summary>
    private void DesignMainAppsElementLauncher(ScrollBarElement value)
    {
      try
      {
        value.BackColor = BackColorElements.BackColorMainApps;
        value.BackColorScroll = BackColorElements.BackColorMainApps;
        value.BackColorCaret = BackColorElements.BackColorTopElement;

        foreach (Panel mainPanel in value.Controls)
        {
          mainPanel.BackColor = BackColorElements.BackColorMainApps;
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
    private void DesignAppElementLauncher(Panel value)
    {
      if (value.Controls[0].GetType() == new PictureBox().GetType() && value.Controls[1].GetType() == new TextElement().GetType())
      {
        PictureBox picture = new();
        foreach (var pictureBox in value.Controls)
          if (pictureBox.GetType() == new PictureBox().GetType())
          {
            picture = pictureBox as PictureBox;
            break;
          }

        picture.BackgroundImageLayout = ImageLayout.Zoom;
        picture.BackColor = BackColorElements.BackColorAppElement;

        string pathFile = DataClass.categoriesPathFiles + "\\" + picture.Tag.ToString();
        string pathImages = DataClass.pathImages + "\\" + picture.Tag.ToString() + "\\";

        if (File.Exists(pathImages + picture.Name + ".jpg"))
        {
          using var imgStream = File.OpenRead(pathImages + picture.Name + ".jpg");
          picture.BackgroundImage = Image.FromStream(imgStream);
        }
        else
        {
          try
          {
            using var imgStream = File.OpenRead(@$"{DataClass.pathImages}\Default.jpg");
            picture.BackgroundImage = Image.FromStream(imgStream);
          }
          catch
          {
            picture.BackColor = Color.Red;
          }
        }

        TextElement text = new();
        foreach (var textElement in value.Controls)
          if (textElement.GetType() == new TextElement().GetType())
          {
            text = textElement as TextElement;
            break;
          }
        text.BackColor = BackColorElements.DefaultBackColorTextApp;
        text.ForeColor = FontElements.DefaultForeColorApp;
        text.Font = FontElements.FontApp;

        text.MouseEnter += (s, a) =>
        {
          text.BackColor = BackColorElements.HoverBackColorTextApp;
          text.ForeColor = FontElements.HoverForeColorApp;

        };
        text.MouseLeave += (s, a) =>
        {
          text.BackColor = BackColorElements.DefaultBackColorTextApp;
          text.ForeColor = FontElements.DefaultForeColorApp;
        };

      }
    }

    #endregion

    #region Настройки "Дизайна" функций программы (Создания катгеорий, добавления приложений, выбор изображения)

    public void LoadDesignFunctionalForm()
    {
      Panel panelSettings = null;
      if (DataClass.functionalForm.Controls.Count <= 0) return;

      for (int i = 0; i < DataClass.functionalForm.Controls.Count; i++)
      {
        if (DataClass.functionalForm.Controls[i].GetType() == new Panel().GetType())
        {
          panelSettings = DataClass.functionalForm.Controls[i] as Panel;
          break;
        }
      }

      if (panelSettings != null)
      {
        DesignPanelFunctionalForm(panelSettings);
        int widthElements = 0;
        foreach (var item in panelSettings.Controls)
        {
          if (item.GetType() == new TextBox().GetType())
          {
            DesignTextBoxFunctionalForm(item as TextBox);
            widthElements = (item as TextBox).Width;
          }

          else if (item.GetType() == new Label().GetType())
          {
            if ((item as Label).Name != "Info")
              DesignLabelFunctionalForm(item as Label);
            else
              DesignLabelInfoFunctionalForm(item as Label, widthElements);
          }

          else if (item.GetType() == new Button().GetType())
          {
            DesignButtonFunctionalForm(item as Button);
          }
        }
      }
    }

    /// <summary>
    /// Настройка внешнего вида панели.
    /// </summary>
    /// <param name="value"></param>
    private void DesignPanelFunctionalForm(Panel value)
    {
      value.BackColor = Color.FromArgb(20, 20, 30);
    }

    /// <summary>
    /// Настройка внешнего вида элемента отображемого текста.
    /// </summary>
    /// <param name="value"></param>
    private void DesignLabelFunctionalForm(Label value)
    {
      value.Font = new System.Drawing.Font("Winston Bold", 14);
      value.ForeColor = Color.White;
      value.Width = TextRenderer.MeasureText(value.Text, value.Font).Width;
    }


    private void DesignLabelInfoFunctionalForm(Label value, int widthpanel)
    {
      value.Font = new System.Drawing.Font("Winston Bold", 9);
      value.ForeColor = Color.White;
      double height = TextRenderer.MeasureText(value.Text, value.Font).Width / Convert.ToDouble(widthpanel);
      double temporary = Math.IEEERemainder(height, 1.00);
      if (temporary != 0) height ++;
      value.Height = (int)height * TextRenderer.MeasureText(value.Text, value.Font).Height;
    }

    /// <summary>
    /// Настройка внешнего вида элемента ввода текста.
    /// </summary>
    /// <param name="value"></param>
    private void DesignTextBoxFunctionalForm(TextBox value)
    {
      value.BackColor = Color.FromArgb(40, 40, 50);
      value.ForeColor = Color.White;
      value.Font = new System.Drawing.Font("Winston Bold", 14);
      value.BorderStyle = BorderStyle.None;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    private void DesignButtonFunctionalForm(Button value)
    {
      value.ForeColor = Color.White;
    }



    #endregion

    #region Настройки "Дизайна" выбора изображения

    /// <summary>
    /// Настраивает внешний вид всех элементов на форме выбора изображения.
    /// </summary>
    public void LoadDesignImageSelection()
    {
      DesignSelection(DataClass.imageSelectionForm);
      DesignTopElement(DataClass.topElementSelectionForm);
      DesignMainAppsElementSelection(DataClass.mainAppsSelectionForm);
      foreach (Panel item in DataClass.imageElementsSelectionForm)
      {
        DesignImaggeElementSelection(item);
      }
      DesignBottomElementSelection(DataClass.bottomElementSelectionForm);
    }

    /// <summary>
    /// Настраивает внешний вид формы выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignSelection(Form value)
    {
      value.BackColor = BackColorElements.BackColorImageSelectionForm;
    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми элементами выбора изображения.
    /// </summary>
    private void DesignMainAppsElementSelection(Panel value)
    {
      value.BackColor = BackColorElements.BackColorTopElement;
    }

    /// <summary>
    /// Настраивает внешний вид элемента выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignImaggeElementSelection(Panel value)
    {
      Panel fileControl = new();
      TextElement textElement = new();
      CheckBoxElement checkBoxElement = new();

      foreach (var item in value.Controls)
      {
        if (item.GetType() == new PictureBox().GetType())
        {
          (item as PictureBox).BackColor = BackColorElements.BackColorAppElement;
        }
      }
      foreach (var panel in value.Controls)
      {
        if (panel.GetType() == new Panel().GetType())
        {
          fileControl = (panel as Panel);

          foreach (var check in (panel as Panel).Controls)
            if (check.GetType() == new CheckBoxElement().GetType())
              checkBoxElement = check as CheckBoxElement;

          foreach (var text in (panel as Panel).Controls)
            if (text.GetType() == new TextElement().GetType())
              textElement = text as TextElement;
        }

        fileControl.BackColor = BackColorElements.BackColorForm;
        textElement.Font = FontElements.FontApp;
        checkBoxElement.BackColor = Color.White;
        checkBoxElement.MouseEnter += (s, a) =>
        {
          fileControl.BackColor = BackColorElements.BackColorTopElement;
          textElement.ForeColor = FontElements.DefaultForeColorCategory;
        };
        checkBoxElement.MouseLeave += (s, a) =>
        {
          fileControl.BackColor = BackColorElements.BackColorForm;
          textElement.ForeColor = FontElements.DefaultForeColorApp;
        };

      }
    }

    /// <summary>
    /// Настраивает нижний элемент на форме выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignBottomElementSelection(Panel value)
    {
      foreach (TextElement item in value.Controls)
      {
        item.BackColor = BackColorElements.BackColorForm;
        item.Font = FontElements.FontApp;
        item.MouseEnter += (s, a) =>
        {
          item.BackColor = BackColorElements.BackColorTopElement;
          item.ForeColor = FontElements.DefaultForeColorCategory;
        };
        item.MouseLeave += (s, a) =>
        {
          item.BackColor = BackColorElements.BackColorForm;
          item.ForeColor = FontElements.DefaultForeColorApp;
        };
      }
    }

    #endregion
  }

}

