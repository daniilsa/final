using LauncherNet.Elements;
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
    }

    public void Load()
    {
      new SettingsForms().SettingsImageForm(this);
      new ElementsImageForm().LoadElements(this, NameCategory, NameFile);
    }
  }
}
