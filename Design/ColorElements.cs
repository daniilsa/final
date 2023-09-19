using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Design
{
  public class ColorElements
  {
    /// <summary>
    /// Возвращает цвет фона элемента категории по умолчанию.
    /// </summary>
    public Color GetHeaderColor()
    {
      return Color.FromArgb(30, 30, 40);
    }

    /// <summary>
    /// Возвращает цвет фона элемента категории при наведении курсора мыши.
    /// </summary>
    public Color GetHoverHeaderColor()
    {
      return Color.FromArgb(20, 20, 30);
    }

    /// <summary>
    /// Возвращает цвет фона элемента активной категории.
    /// </summary>
    public Color GetActiveHeaderColor()
    {
      return Color.FromArgb(212, 213, 187);
    }

    /// <summary>
    /// Возвращает цвет фона элемента с приложениями.
    /// </summary>
    /// <returns></returns>
    public Color GetMainColor()
    { 
     return Color.FromArgb(212, 213, 187);
    }

    /// <summary>
    /// Возвращает цвет фона элемента с названием приложения.
    /// </summary>
    /// <returns></returns>
    public Color GetNameAppBackColor()
    {
      return  Color.FromArgb(182, 183, 152);
    }
  }
}
