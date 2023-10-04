using LauncherNet;
using LauncherNet.Front;
using LauncherNet.Settings;

namespace Launcher.Controls
{
  public class TextControl : Control
  {
    /// <summary>
    /// Положение текста на элементе
    /// </summary>
    private StringFormat SF = new StringFormat();

    /// <summary>
    /// Задаёт выравнивание текста по горизонтали.
    /// </summary>
    public StringAlignment TextAlignHorizontal { set { SF.Alignment = value; } }

    /// <summary>
    /// Задаёт выравнивание текста по вертикали.
    /// </summary>
    public StringAlignment TextAlignVertical { set { SF.LineAlignment = value; } }

    /// <summary>
    /// Отрисовка элемента управления.
    /// </summary>
    /// <param name="e">Данные для рисования.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics graphics = e.Graphics;
      graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

      Rectangle rectangle = new Rectangle(0, 0, Width, Height);
      Rectangle rectangleText = new Rectangle(10, 0, Width, Height);

      try
      {
        if (FontElements.FontCategory.Name.Contains("Parameter is not valid")) return;
      }
      catch
      {
        Font = FontElements.GetFont();
      }

      graphics.FillRectangle(new SolidBrush(BackColor), rectangle);
      graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectangleText, SF);
    }

    /// <summary>
    /// Действия, при изменения текста элемента.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
      Invalidate();
    }

    /// <summary>
    /// Задаёт параметры по-умолчанию.
    /// </summary>
    public TextControl()
    {
      Dock = DockStyle.Top;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
      TextAlignHorizontal = StringAlignment.Near;
      SF.Alignment = StringAlignment.Near;
      SF.LineAlignment = StringAlignment.Center;
    }
  }


}
