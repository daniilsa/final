using LauncherNet.DesignFront;

namespace LauncherNet._Front
{
  public class ContextMenuStripRenderer : ToolStripProfessionalRenderer
  {
    public ContextMenuStripRenderer() : base(new MyColors()) { }
  }

  public class MyColors : ProfessionalColorTable
  {
    public override Color ImageMarginGradientBegin => BackColorElements.MainDarkColor;
    public override Color ImageMarginGradientMiddle => BackColorElements.MainDarkColor;
    public override Color ImageMarginGradientEnd => BackColorElements.MainDarkColor;
    public override Color MenuItemSelected => BackColorElements.MainDarkColor;
    public override Color MenuItemSelectedGradientBegin => BackColorElements.MainDarkColor;
    public override Color MenuItemSelectedGradientEnd => BackColorElements.MainLightColor;
    public override Color ToolStripContentPanelGradientBegin => BackColorElements.MainDarkColor;
    public override Color MenuItemBorder => BackColorElements.MainDarkColor;
  }
}
