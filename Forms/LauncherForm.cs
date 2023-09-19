
using LauncherNet.BackUp;
using LauncherNet.Elements;
using LauncherNet.Settings;

namespace LauncherNet
{
  public partial class LauncherForm : Form
  {
    public LauncherForm()
    {
      DoubleBuffered = true;
      InitializeComponent();
      Load();
    }

    public void Load()
    {
      new CheckingFiles().CheckingResources();
      new SettingsForms().SettingsLauncherForm(this);
      new ElementsLauncherForm().LoadElements(this);
    }

  }
}