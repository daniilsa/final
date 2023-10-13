using LauncherNet._Data;
using LauncherNet.DesignFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet._Front
{
  internal class DesignLoadForm
  {

    public void LoadDesignLoadForm()
    {
      if (DataLoadForm.Form != null)
      {
        DesignForm(DataLoadForm.Form);
        DesignLeftBorder(DataLoadForm.LeftBorder);
        DesignProgressBar(DataLoadForm.ProgressBar, DataLoadForm.CarretBar);

        DesignStartProgramm(DataLoadForm.StartProgrammText);
        DesingTextInfo(DataLoadForm.InfoProgressText);
      }
    }


    private void DesignForm(Form value)
    {
      value.FormBorderStyle = FormBorderStyle.None;
      value.BackColor = BackColorElements.AdditionalLight;
    }

    private void DesignLeftBorder(PictureBox value)
    {
      value.BackColor = BackColorElements.MainDarkColor;
    }

    private void DesignProgressBar(Panel progreeBar, Panel caretBar)
    {

      progreeBar.BackColor = BackColorElements.MainLightColor;
      caretBar.BackColor = BackColorElements.AdditionalDarkColor;

    }

    private void DesignStartProgramm(Label value)
    { 
    
      value.ForeColor = BackColorElements.AdditionalDarkColor;
    }
    private void DesingTextInfo(Label value)
    {
      value.ForeColor = BackColorElements.AdditionalDarkColor;
    }

  }
}
