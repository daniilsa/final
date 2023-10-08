using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Front;

namespace LauncherNet._Front
{
  internal class DesignImageSelectionForm
  {
    /// <summary>
    /// Настраивает внешний вид всех элементов на форме выбора изображения.
    /// </summary>
    public void LoadDesignImageSelection()
    {
      if (DataImageSelectionForm.imageSelectionForm != null)
        DesignSelection(DataImageSelectionForm.imageSelectionForm);

      if (DataImageSelectionForm.mainAppsSelectionForm != null)
        DesignMainAppsElementSelection(DataImageSelectionForm.mainAppsSelectionForm);

      if (DataImageSelectionForm.imageElementsSelectionForm != null)
        foreach (Panel item in DataImageSelectionForm.imageElementsSelectionForm)
        {
          DesignImaggeElementSelection(item);
        }

      if (DataImageSelectionForm.bottomElementSelectionForm != null)
        DesignBottomElementSelection(DataImageSelectionForm.bottomElementSelectionForm);
    }

    /// <summary>
    /// Настраивает внешний вид формы выбора изображения.
    /// </summary>
    /// <param name="value"></param>
    private void DesignSelection(Form value)
    {
      value.BackColor = BackColorElements.AdditionalDarkColor;
    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми элементами выбора изображения.
    /// </summary>
    private void DesignMainAppsElementSelection(Panel value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
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
          ((PictureBox)item).BackColor = BackColorElements.AdditionalLight;
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
          fileControl.BackColor = BackColorElements.MainLightColor;

        textElement.Font = FontElements.FontApp;
        checkBoxElement.BackColor = Color.White;
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
        item.BackColor = BackColorElements.MainLightColor;
        item.Font = FontElements.FontApp;
        item.MouseEnter += (s, a) =>
        {
          item.BackColor = BackColorElements.MainDarkColor;
          item.ForeColor = FontElements.MainLightColorText;
        };
        item.MouseLeave += (s, a) =>
        {
          item.BackColor = BackColorElements.MainLightColor;
          item.ForeColor = FontElements.MainDarkColorText;
        };
      }
    }
  }
}
