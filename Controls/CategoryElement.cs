
namespace Launcher.Controls
{
  public class CategoryPanelControl : Control
  {
    /// <summary>
    /// Положение текста на элементе
    /// </summary>
    StringFormat SF = new StringFormat();

    Color BorderColor { get; set; }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics graphics = e.Graphics;
      Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
      Rectangle rectangleText = new Rectangle(10, 0, this.Width - 1, this.Height - 1);
      graphics.DrawRectangle(new Pen(BorderColor), rectangle);
      graphics.DrawString(Text, this.Font, new SolidBrush(Color.Black), rectangleText, SF);
    }

    public CategoryPanelControl()
    {
      Dock = DockStyle.Top;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
      SF.Alignment = StringAlignment.Near;
      SF.LineAlignment = StringAlignment.Center;
    }
  }


}
