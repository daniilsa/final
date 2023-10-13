using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet.DesignFront;
using LauncherNet.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet._Front
{
  internal class DesignSettingsApplicationForm
  {
    public void LoadDesignSettingsApplicationForm(bool visible)
    {
      if (DataSettingsApplicationForm.Form != null)
      {
        DesignForm(DataSettingsApplicationForm.Form, visible);
        try
        {
          foreach (Label item in DataSettingsApplicationForm.Form.Controls)
          {
            DesignLabel(item);
          }

        }
        catch { }
      }
    }

    private void DesignForm(Form value, bool visible)
    {
      value.BackColor = BackColorElements.MainDarkColor;
      if (!visible)
        value.Opacity = 0;

    }

    private void DesignLabel(Label value)
    {
      value.ForeColor = FontElements.MainLightColorText;
    }
   
  }
}
