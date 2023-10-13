using LauncherNet.DesignFront;
using LauncherNet.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet._Front
{
  internal class ColorSettings
  {

    public void RewritingColor()
    {
      BackColorElements.MainDarkColor = WorkingColor.FirstMainColor;
      BackColorElements.AdditionalDarkColor = WorkingColor.FirstAdditionalColor;

      BackColorElements.MainLightColor = WorkingColor.SecondMainColor;
      BackColorElements.AdditionalLight = WorkingColor.SecondAdditionalColor;

    }

  }
}
