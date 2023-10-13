using LauncherNet._Front;
using LauncherNet.Elements.ProgressBarForm;
using LauncherNet.Settings;

namespace LauncherNet.Forms
{
  public partial class ProgressBarForm : Form
  {
    public ProgressBarForm(string text)
    {
      InitializeComponent();
      DoubleBuffered = true;
      LoadForm_Load(text);
    }

    private void LoadForm_Load(string text)
    {
      new SettingsAuxiliaryForms().SettingsLoadForm(this);
      new CreateElementsLoadForm().LoadElements(this, text);
      new DesignLoadForm().LoadDesignLoadForm();
    }
  }
}
