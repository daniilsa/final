using LauncherNet.Elements.LoadFormElements;
using LauncherNet.Settings;

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
      new CreateElementsLoadForm().LoadElements(this);
    }
  }
}
