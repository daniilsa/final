using LauncherNet.Elements;
using LauncherNet.Front;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherNet.Forms
{
  public partial class ImageSelectionForm : Form
  {

    public string NameFile { get; set; }
    public string NameCategory { get; set; }

    public ImageSelectionForm()
    {
      InitializeComponent();
      DoubleBuffered = true;
      NameFile = string.Empty;
      NameCategory = string.Empty;
    }

    public new void Load()
    {
      new SettingsForms().SettingsImageForm(this);
      new ElementsImageForm().LoadElements(this, NameCategory, NameFile);
      new DesignElements().LoadDesignImageSelection();
    }
  }
}
