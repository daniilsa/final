using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Controls
{
  public class CheckBoxControl : Control
  {
    /// <summary>
    /// Задаёт или возваращет активность элемента(крестик).
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Отрисовка элемента управления.
    /// </summary>
    /// <param name="e">Данные для рисования.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (Active)
      {
        int widthPen = 2;
        Graphics graphics = e.Graphics;

        Point line1_1 = new Point(widthPen, widthPen);
        Point line1_2 = new Point(Width - widthPen, Height - widthPen);
        graphics.DrawLine(new Pen(Color.Green, widthPen), line1_1,line1_2);

        Point line2_1 = new Point(widthPen, Height - widthPen);
        Point line2_2 = new Point(Width - widthPen, widthPen);
        graphics.DrawLine(new Pen(Color.Green, widthPen), line2_1, line2_2);
      }
    }

    /// <summary>
    /// Событие по нажатию на элемент управленияю
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      Invalidate();
    }

    /// <summary>
    /// Задаёт параметры по-умолчанию.
    /// </summary>
    public CheckBoxControl()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
      Active = false;
      Height = Width;
    }
  }
}
