
using LauncherNet.BackUp;
using LauncherNet.Elements;
using LauncherNet.Front;
using LauncherNet.Settings;
using Microsoft.VisualStudio.Shell.Interop;

namespace LauncherNet
{
  public partial class LauncherForm : Form
  {
    public LauncherForm()
    {
      DoubleBuffered = true;
      InitializeComponent();
    }
  }
}