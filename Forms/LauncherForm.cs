namespace LauncherNet
{
  public partial class LauncherForm : Form
  {
    public LauncherForm()
    {
      DoubleBuffered = true;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      InitializeComponent();
    }
  }
}