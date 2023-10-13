using LauncherNet._Data;
using LauncherNet.DesignFront;
using LauncherNet.Front;

namespace LauncherNet._Front
{
  internal class DesignFunctionalForm
  {
    /// <summary>
    /// Настройка всех элементов "Функциональной" формы.
    /// </summary>
    public void LoadDesignFunctionalForm()
    {
      Panel? panelSettings = null;
      if (DataFunctionalForm.functionalForm?.Controls.Count <= 0) return;

      for (int i = 0; i < DataFunctionalForm.functionalForm?.Controls.Count; i++)
      {
        if (DataFunctionalForm.functionalForm.Controls[i].GetType() == new Panel().GetType())
        {
          panelSettings = DataFunctionalForm.functionalForm.Controls[i] as Panel;
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
      value.BackColor = BackColorElements.AdditionalDarkColor;
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
      value.ForeColor = FontElements.MainLightColorText;
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
      value.Font = FontElements.FontLabelInfo;
      //value.ForeColor = Color.White;
      value.ForeColor = FontElements.MainLightColorText;

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
      value.BackColor = BackColorElements.MainDarkColor;
      value.ForeColor = FontElements.MainLightColorText;
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
      value.ForeColor = FontElements.MainLightColorText;
    }
  }
}
