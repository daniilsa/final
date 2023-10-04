using LauncherNet.DesignFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet._Front
{
  public class ContextMenuStripRenderer : ToolStripProfessionalRenderer
  {
    public ContextMenuStripRenderer() : base(new MyColors()) { }
  }

  public class MyColors : ProfessionalColorTable
  {
    public override Color ImageMarginGradientBegin => BackColorElements.DefaultColorContextMenu;
    public override Color ImageMarginGradientMiddle => BackColorElements.DefaultColorContextMenu;
    public override Color ImageMarginGradientEnd => BackColorElements.DefaultColorContextMenu;

    public override Color MenuItemSelected => BackColorElements.DefaultColorContextMenu;
    public override Color MenuItemSelectedGradientBegin => BackColorElements.DefaultColorContextMenu;
    public override Color MenuItemSelectedGradientEnd => BackColorElements.HoverColorContextMenu;
    public override Color ToolStripContentPanelGradientBegin => BackColorElements.DefaultColorContextMenu;
    public override Color MenuItemBorder => BackColorElements.DefaultColorContextMenu;
  }
}
