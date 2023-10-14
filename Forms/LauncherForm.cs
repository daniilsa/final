using System.Diagnostics;

namespace LauncherNet
{
  public partial class LauncherForm : Form
  {
    public LauncherForm()
    {
      InitializeComponent();
      DoubleBuffered = true;
      Load();

    }

    private void Load()
    {

      if (File.Exists($@".\{DataClass.Help}"))
      {
        helpProvider1.HelpNamespace = $@".\{DataClass.Help}";
        DataClass.HelpExist = true;
      }
    }

    public void DeleteHelp()
    {
      DataClass.HelpExist = false;
      helpProvider1.ResetShowHelp(this);
    }
  }
}