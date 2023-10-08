using Launcher.Controls;
using LauncherNet._DataStatic;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Front;

namespace LauncherNet._Front
{
  internal class DesignHelpForm
  {
    public void LoadDesignHelpForm()
    {
      if (DataHelpForm.topElement != null)
      {
        DesignTopElement(DataHelpForm.topElement);
      }

      if (DataHelpForm.categoriesElement != null)
      {
        DesignCategoryesElemntHelpForm(DataHelpForm.categoriesElement);
      }

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
    /// Настраивает внешний вид элемента с категориями.
    /// </summary>
    /// <param name="value"></param>
    private void DesignCategoryesElemntHelpForm(Panel value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
      if (DataHelpForm.categoriesElement != null)
      {
        foreach (TextControl item in DataHelpForm.categoriesElement.Controls)
        {
          DesignCategoryElementHelpForm(item);
        }
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента раздела помощи.
    /// </summary>
    /// <param name="value"></param>
    private void DesignCategoryElementHelpForm(TextControl value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
      value.Font = new Font(FontElements.FontCategory.FontFamily, 10);
      value.ForeColor = FontElements.MainLightColorText;

      value.MouseEnter += (s, a) => value.BackColor = BackColorElements.AdditionalDarkColor;
      value.MouseLeave += (s, a) => value.BackColor = BackColorElements.MainDarkColor;
    }

    /// <summary>
    /// Настройка "Дизайна" главного элемента формы помощи.
    /// </summary>
    /// <param name="value"></param>
    public void DesignMainElementHelpForm(Panel value)
    {

      foreach (Control item in value.Controls)
      {
        if (item.GetType() == new Label().GetType())
        {
          Label label = (Label)item;
          label.Font = new Font(FontElements.FontCategory.FontFamily, 15);
          label.ForeColor = FontElements.MainDarkColorText;
        }
        if (item.GetType() == new TextControl().GetType())
        {
          TextControl label = (TextControl)item;
          label.ForeColor = FontElements.MainDarkColorText;
          if (label.Tag.ToString() == "Subtitle")
            label.Font = new Font(FontElements.FontCategory.FontFamily, 13);
          else
            label.Font = new Font(FontElements.FontCategory.FontFamily, 11);
        }
      }
    }
  }
}
