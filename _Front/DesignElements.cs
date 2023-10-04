using Launcher.Controls;
using LauncherNet._Front;
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
      value.BackColor = BackColorElements.DefaultColorTopElement;

      foreach (var panel in value.Controls)
      {
        if (panel.GetType() == new Panel().GetType())
        {
          foreach (var buttonElements in ((Panel)panel).Controls)
            if (buttonElements.GetType() == new BorderButtonControl().GetType())
            {
              BorderButtonControl? button = buttonElements as BorderButtonControl;

              if (button != null)
              {
                button.MouseEnter += (s, a) =>
                {
                  button.BackColor = BackColorElements.HoverColorCategory;
                };
                button.MouseLeave += (s, a) =>
                {
                  button.BackColor = BackColorElements.DefaultColorTopElement;
                };
              }
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
      if (DataClass.launcher != null)
      {
        try
        {
          if (FontElements.FontCategory.Name.Contains("Parameter is not valid"))
            new SettingsForms().UpdateLauncher(DataClass.launcher);
          else
          {
            DesignLauncher(DataClass.launcher);
            if (DataClass.topElementLauncher != null)
              DesignTopElement(DataClass.topElementLauncher);

            if (DataClass.categoriesElementLauncher != null)
              DesignCategoriesElementLauncher(DataClass.categoriesElementLauncher);

            if (DataClass.categoryElementLauncher != null)
            {
              foreach (TextControl value in DataClass.categoryElementLauncher)
                DesignCategoryElementLauncher(value);
            }

            if (DataClass.controlAddCategory != null)
              DesignCategoryAddElement(DataClass.controlAddCategory);

            if (DataClass.mainAppsLauncher != null)
              foreach (ScrollBarControl value in DataClass.mainAppsLauncher)
              {
                DesignMainAppsElementLauncher(value);
              }

            if (DataClass.controlAddApp != null)
              foreach (ControlAddControl value in DataClass.controlAddApp)
              {
                DesignAppAddElements(value);
              }

            if (DataClass.functionApp != null)
            {
              foreach (ContextMenuStrip? item in DataClass.functionApp)
              {
                if (item != null)
                  DesignContextMenuFunctionsApp(item);
              }
              ;
            }

            if (DataClass.functionCategories != null)
            {
              foreach (ContextMenuStrip? item in DataClass.functionCategories)
              {
                if (item != null)
                  DesignContextMenuFunctionsApp(item);
              }
              
            }
          }
        }
        catch
        {
          new SettingsForms().UpdateLauncher(DataClass.launcher);
        }
      }
    }

    /// <summary>
    /// Настраивает внешний вид формы.
    /// </summary>
    private void DesignLauncher(Form value)
    {
      value.BackColor = BackColorElements.DefaultColorLauncher;
    }

    /// <summary>
    /// Настраивает внешний вид  элемента со всеми категориями.
    /// </summary>
    private void DesignCategoriesElementLauncher(Panel value)
    {
      value.BackColor = BackColorElements.DefaultColorCategoriesElement;
    }

    /// <summary>
    /// Настраивает внешний вид элемента категории.
    /// </summary>
    public void DesignCategoryElementLauncher(TextControl value)
    {
      value.Font = FontElements.FontCategory;
      value.ForeColor = FontElements.DefaultForeColorCategory;
      value.BackColor = BackColorElements.DefaultColorCategory;

      value.MouseEnter += (s, e) =>
      {
        if (value != DataClass.activeCategoryPanelLauncher) value.BackColor = BackColorElements.HoverColorCategory;
      };
      value.MouseLeave += (s, e) =>
      {
        if (value != DataClass.activeCategoryPanelLauncher) value.BackColor = BackColorElements.DefaultColorCategory;
      };
      value.MouseDown += (s, e) =>
      {
        DataClass.lastCategoryPanelLauncher.ForeColor = FontElements.DefaultForeColorCategory;
        DataClass.lastCategoryPanelLauncher.BackColor = BackColorElements.DefaultColorCategory;
        value.BackColor = BackColorElements.ActiveColorCategory;
        value.ForeColor = FontElements.ActiveForeColorCategory;
      };

      if (DataClass.activeCategoryPanelLauncher != null)
      {
        DataClass.activeCategoryPanelLauncher.ForeColor = FontElements.ActiveForeColorCategory;
        DataClass.activeCategoryPanelLauncher.BackColor = BackColorElements.ActiveColorCategory;
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента создания новой категории.
    /// </summary>
    /// <param name="value"></param>
    private void DesignCategoryAddElement(ControlAddControl value)
    {
      value.BackColor = BackColorElements.DefaultColorCategory;
      value.BorderColor = FontElements.DefaultForeColorCategory;
      value.MouseEnter += (s, e) => value.Opacity = 255;
      value.MouseLeave += (s, e) => value.Opacity = 80;
    }

    /// <summary>
    /// Настраивает внешний вид элемента добавления приложения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignAppAddElements(ControlAddControl value)
    {
      value.BackColor = BackColorElements.DefaultColorAppElement;
      value.BorderColor = FontElements.DefaultForeColorApp;
      value.MouseEnter += (s, e) => value.Opacity = 255;
      value.MouseLeave += (s, e) => value.Opacity = 80;

    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми приложениями.
    /// </summary>
    private void DesignMainAppsElementLauncher(ScrollBarControl value)
    {
      try
      {
        value.BackColor = BackColorElements.DefaultColorMainApps;
        value.BackColorScroll = BackColorElements.DefaultColorMainApps;
        value.BackColorCaret = BackColorElements.DefaultColorTopElement;

        foreach (Panel mainPanel in value.Controls)
        {
          mainPanel.BackColor = BackColorElements.DefaultColorMainApps;
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
          picture.BackColor = BackColorElements.DefaultColorAppElement;
          pathFile = DataClass.categoriesPathFiles + "\\" + picture.Tag.ToString();
          pathImages = DataClass.pathImages + "\\" + picture.Tag.ToString() + "\\";
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
              using var imgStream = File.OpenRead(@$"{DataClass.pathImages}\Default.jpg");
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
          text.BackColor = BackColorElements.DefaultColorTextApp;
          text.ForeColor = FontElements.DefaultForeColorApp;
          text.Font = FontElements.FontApp;

          text.MouseEnter += (s, a) =>
          {
            text.BackColor = BackColorElements.HoverColorTextApp;
            text.ForeColor = FontElements.HoverForeColorApp;

          };
          text.MouseLeave += (s, a) =>
          {
            text.BackColor = BackColorElements.DefaultColorTextApp;
            text.ForeColor = FontElements.DefaultForeColorApp;
          };
        }
      }
    }

    private void DesignContextMenuFunctionsApp(ContextMenuStrip value)
    {
      value.BackColor = BackColorElements.DefaultColorContextMenu;
      value.ForeColor = FontElements.DefaultColorTextContextMenuStrip;
      value.Renderer = new ContextMenuStripRenderer();

    }

    #endregion

    #region Настройки "Дизайна" функций программы (Создания катгеорий, добавления приложений, выбор изображения)

    public void LoadDesignFunctionalForm()
    {
      Panel? panelSettings = null;
      if (DataClass.functionalForm?.Controls.Count <= 0) return;

      for (int i = 0; i < DataClass.functionalForm?.Controls.Count; i++)
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
          if (item != null && item.GetType() == new TextBox().GetType())
          {
            DesignTextBoxFunctionalForm((TextBox)item);
            widthElements = ((TextBox)item).Width;
          }

          else if (item != null && item.GetType() == new Label().GetType())
          {
            if (((Label)item).Name != "Info")
              DesignLabelFunctionalForm((Label)item);
            else
              DesignLabelInfoFunctionalForm((Label)item, widthElements);
          }

          else if (item != null && item.GetType() == new Button().GetType())
          {
            DesignButtonFunctionalForm((Button)item);
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
      value.BackColor = BackColorElements.DefaultColorFunctionForm;
    }

    /// <summary>
    /// Настройка внешнего вида элемента отображемого текста.
    /// </summary>
    /// <param name="value"></param>
    private void DesignLabelFunctionalForm(Label value)
    {
      //value.Font = new System.Drawing.Font("Winston Bold", 14);
      value.Font = FontElements.FontLabel;
      // value.ForeColor = Color.White;
      value.ForeColor = FontElements.DefaultForeColorCategory;
      value.Width = TextRenderer.MeasureText(value.Text, value.Font).Width;
    }

    /// <summary>
    /// Настройка внешнего вида элемента отображаемой информации.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="widthpanel"></param>
    private void DesignLabelInfoFunctionalForm(Label value, int widthpanel)
    {
      //value.Font = new System.Drawing.Font("Winston Bold", 9);
      value.Font = value.Font = FontElements.FontLabelInfo;
      //value.ForeColor = Color.White;
      value.ForeColor = FontElements.DefaultForeColorCategory;

      double height = TextRenderer.MeasureText(value.Text, value.Font).Width / Convert.ToDouble(widthpanel);
      double temporary = Math.IEEERemainder(height, 1.00);
      if (temporary != 0) height++;
      value.Height = (int)height * TextRenderer.MeasureText(value.Text, value.Font).Height;
    }

    /// <summary>
    /// Настройка внешнего вида элемента ввода текста.
    /// </summary>
    /// <param name="value"></param>
    private void DesignTextBoxFunctionalForm(TextBox value)
    {
      value.BackColor = Color.FromArgb(40, 40, 50);
      value.ForeColor = FontElements.DefaultForeColorCategory;
      //value.ForeColor = Color.White;
      value.Font = FontElements.FontLabelInfo;
      value.BorderStyle = BorderStyle.None;
    }

    /// <summary>
    /// Настройки внешнего вида кнопок.
    /// </summary>
    /// <param name="value"></param>
    private void DesignButtonFunctionalForm(Button value)
    {
      //value.ForeColor = Color.White;
      value.Font = FontElements.FontLabelInfo;
      value.ForeColor = FontElements.DefaultForeColorCategory;
    }

    #endregion

    #region Настройки "Дизайна" выбора изображения

    /// <summary>
    /// Настраивает внешний вид всех элементов на форме выбора изображения.
    /// </summary>
    public void LoadDesignImageSelection()
    {
      if (DataClass.imageSelectionForm != null)
        DesignSelection(DataClass.imageSelectionForm);

      if (DataClass.mainAppsSelectionForm != null)
        DesignMainAppsElementSelection(DataClass.mainAppsSelectionForm);

      if (DataClass.imageElementsSelectionForm != null)
        foreach (Panel item in DataClass.imageElementsSelectionForm)
        {
          DesignImaggeElementSelection(item);
        }

      if (DataClass.bottomElementSelectionForm != null)
        DesignBottomElementSelection(DataClass.bottomElementSelectionForm);
    }

    /// <summary>
    /// Настраивает внешний вид формы выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignSelection(Form value)
    {
      value.BackColor = BackColorElements.DefaultColorFunctionForm;
    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми элементами выбора изображения.
    /// </summary>
    private void DesignMainAppsElementSelection(Panel value)
    {
      value.BackColor = BackColorElements.DefaultColorTopElement;
    }

    /// <summary>
    /// Настраивает внешний вид элемента выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignImaggeElementSelection(Panel value)
    {
      Panel? fileControl = new();
      TextControl? textElement = new();
      CheckBoxControl? checkBoxElement = new();

      foreach (var item in value.Controls)
      {
        if (item != null && item.GetType() == new PictureBox().GetType())
        {
          ((PictureBox)item).BackColor = BackColorElements.DefaultColorAppElement;
        }
      }
      foreach (var panel in value.Controls)
      {
        if (panel != null && panel.GetType() == new Panel().GetType())
        {
          fileControl = panel as Panel;

          foreach (var check in ((Panel)panel).Controls)
            if (check.GetType() == new CheckBoxControl().GetType())
              checkBoxElement = check as CheckBoxControl;

          foreach (var text in ((Panel)panel).Controls)
            if (text.GetType() == new TextControl().GetType())
              textElement = text as TextControl;
        }
        if (fileControl != null)
          fileControl.BackColor = BackColorElements.DefaultColorLauncher;

        textElement.Font = FontElements.FontApp;
        checkBoxElement.BackColor = Color.White;
        checkBoxElement.MouseEnter += (s, a) =>
        {
          //fileControl.BackColor = BackColorElements.DefaultColorLauncher;
          //textElement.ForeColor = FontElements.DefaultForeColorApp;
        };
        checkBoxElement.MouseLeave += (s, a) =>
        {
          //fileControl.BackColor = BackColorElements.DefaultColorLauncher;
          // textElement.ForeColor = FontElements.DefaultForeColorApp;
        };

      }
    }

    /// <summary>
    /// Настраивает нижний элемент на форме выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignBottomElementSelection(Panel value)
    {
      foreach (TextControl item in value.Controls)
      {
        item.BackColor = BackColorElements.DefaultColorLauncher;
        item.Font = FontElements.FontApp;
        item.MouseEnter += (s, a) =>
        {
          item.BackColor = BackColorElements.DefaultColorTopElement;
          item.ForeColor = FontElements.DefaultForeColorCategory;
        };
        item.MouseLeave += (s, a) =>
        {
          item.BackColor = BackColorElements.DefaultColorLauncher;
          item.ForeColor = FontElements.DefaultForeColorApp;
        };
      }
    }

    #endregion
  }

}

