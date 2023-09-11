

namespace Launcher.Controls
{
  public class CategoriesPanelControl : Control
  {

    #region Свойства

    /// <summary>
    /// Задаёт или возвращает цвет гарницы.
    /// </summary>
    public Color BorderColor { get; set; }

    /// <summary>
    /// Задаёт или возваращет отображение границы.
    /// </summary>
    public bool Border { get; set; }

    #endregion

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      int cursorMouseX = Cursor.Position.X;
      Graphics graphics = e.Graphics;
      Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
      if (Border) graphics.DrawRectangle(new Pen(BorderColor), rectangle);
    }

    public CategoriesPanelControl()
    {
      Dock = DockStyle.Left;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
    }
  }
}
