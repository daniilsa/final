using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Controls
{
  public class ControlAddControl : Control
  {

    private int opacity;

    public Color BorderColor { get; set; }

    public int SizePlus { get; set; }

    public int Opacity { get {return opacity; } set { opacity = value;  Invalidate(); } }


    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (SizePlus <= 0) SizePlus = 1;
      else if (SizePlus > 6) SizePlus = 6;

      Rectangle thisElement = new(0, 0, Width, Height);

      float sizePen = 5;
      int indent = Convert.ToInt32(sizePen * 2);
      int lengthLine = Height / SizePlus;
      if (Width < Height) lengthLine = Width / SizePlus;


      Point[] pointsTopLeft = new Point[3]
      {
        new Point(indent, lengthLine),
        new Point(indent, indent),
        new Point(lengthLine ,indent),
      };
      Point[] pointsTopRight = new Point[3]
        {
          new Point(Width-lengthLine,indent),
          new Point(Width-1-indent,indent),
          new Point(Width-1-indent,lengthLine),
        };
      Point[] pointsBottomRight = new Point[3]
        {
          new Point(Width-1-indent,Height-lengthLine),
          new Point(Width-1-indent,Height-1-indent),
          new Point(Width-lengthLine,Height-1-indent),
        };
      Point[] pointsBottomLeft = new Point[3]
        {
          new Point(lengthLine,Height-1-indent),
          new Point(0 + indent,Height-1-indent),
          new Point(0+indent,Height-lengthLine),
        };

      Point center = new Point((Width - 1) / 2, (Height - 1) / 2);
      Point[] pluse = new Point[5]
      {
        new Point(center.X-lengthLine/2,center.Y),
        new Point(center.X+lengthLine/2,center.Y),
        center,
        new Point(center.X,center.Y-lengthLine/2),
        new Point(center.X,center.Y+lengthLine/2),
      };


      Graphics graphics = e.Graphics;
      graphics.FillRectangle(new SolidBrush(BackColor), thisElement);
      graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(Opacity, BorderColor)), sizePen), pointsTopLeft);
      graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(Opacity, BorderColor)), sizePen), pointsTopRight);
      graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(Opacity, BorderColor)), sizePen), pointsBottomRight);
      graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(Opacity, BorderColor)), sizePen), pointsBottomLeft);
      graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(Opacity, BorderColor)), sizePen), pluse);
    }

    public ControlAddControl()
    {
      DoubleBuffered = true;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      Width = 200;
      Height = 100;
      BackColor = Color.Red;
      BorderColor = Color.White;
      SizePlus = 4;
      Opacity = 80;
    }

  }
}
