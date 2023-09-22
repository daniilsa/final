
using System.Reflection.Metadata;
using System;
using LauncherNet.Settings;
using LauncherNet;
using LauncherNet.Front;
using System.Drawing.Text;

namespace Launcher.Controls
{
  public class TextElement : Control
  {
    /// <summary>
    /// Положение текста на элементе
    /// </summary>
    StringFormat SF = new StringFormat();


    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      Graphics graphics = e.Graphics;
      graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

      Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
      Rectangle rectangleText = new Rectangle(10, 0, this.Width, this.Height);

      try
      {
        if (FontElements.FontCategory.Name.Contains("Parameter is not valid"))
          new SettingsForms().UpdateLauncher(DataClass.launcher);
      }
      catch
      {
        this.Font = FontElements.GetFont();
      }

      graphics.DrawRectangle(new Pen(this.BackColor), rectangle);
      graphics.DrawString(Text, this.Font, new SolidBrush(this.ForeColor), rectangleText, SF);
    }

    public TextElement()
    {
      Dock = DockStyle.Top;
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
      SF.Alignment = StringAlignment.Near;
      SF.LineAlignment = StringAlignment.Center;
    }
  }


}
