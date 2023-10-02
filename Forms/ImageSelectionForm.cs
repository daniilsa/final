using LauncherNet.Elements.ImageFormElements;
using LauncherNet.Front;
using LauncherNet.Settings;

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
      new CreateElementsImageForm().LoadElements(this, NameCategory, NameFile);
      new DesignElements().LoadDesignImageSelection();
    }
  }
}
