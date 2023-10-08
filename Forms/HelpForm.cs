using LauncherNet._DataStatic;
using LauncherNet._Front;
using LauncherNet.Elements.HelpElements;
using LauncherNet.Settings;

namespace LauncherNet.Forms
{
  public partial class HelpForm : Form
  {
    public HelpForm()
    {
      InitializeComponent();
      Load();
    }

    private new void Load()
    {
      DataHelpForm.helpForm = this;
      new SettingsForms().SettingsHelpForm(this);
      new CreateElementsHelpForm().LoadElements(this);
      new DesignHelpForm().LoadDesignHelpForm();
    }
  }
}
