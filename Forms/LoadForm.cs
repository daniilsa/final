using LauncherNet.Elements;
using LauncherNet.Settings;
using System;
using System.Windows.Forms;

namespace LauncherNet.Forms
{
  public partial class LoadForm : Form
  {
    public LoadForm()
    {
      InitializeComponent();
      DoubleBuffered = true;
    }

    private void LoadForm_Load(object sender, EventArgs e)
    {
      new SettingsForms().SettingsLoadForm(this);
      new ElementsLoadForm().LoadElements(this);
    }
  }
}
