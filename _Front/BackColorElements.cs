using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.DesignFront
{
  static public class BackColorElements
  {
    #region Свойства


    /// <summary>
    /// Возвращает цвет фона формы.
    /// </summary>
    static public Color BackColorForm { get; }

    /// <summary>
    /// Возвращает цвет фона верхнего элемента.
    /// </summary>
    static public Color BackColorTopElement { get; }

    /// <summary>
    /// Возвращает цвет фона элемента со всеми категориями.
    /// </summary>
    static public Color BackColorCategoriesElement { get; }

    /// <summary>
    /// Возвращает цвет фона категории по умолчанию.
    /// </summary>
    static public Color DefaultBackColorCategory { get; }

    /// <summary>
    /// Возвращает цвет фона категории при наведении мыши.
    /// </summary>
    static public Color HoverBackColorCategory { get; }

    /// <summary>
    /// Возвращает цвет фона активной категории.
    /// </summary>
    static public Color ActiveBackColorCategory { get; }

    /// <summary>
    /// Возвращает цвет фона элемента со всеми приложениями.
    /// </summary>
    static public Color BackColorMainApps { get; }

    /// <summary>
    /// Возвращает цвет фона элемента приложения.
    /// </summary>
    static public Color BackColorAppElement { get; }

    /// <summary>
    /// Возвращает цвет фона имени приложения.
    /// </summary>
    static public Color DefaultBackColorTextApp { get; }

    #endregion

    #region Методы

    /// <summary>
    /// Расчёт нового цвета.
    /// </summary>
    /// <param name="oldColor">Используемый цвет.</param>
    /// <param name="difference">Разница в цветовой гамме(целое число).</param>
    /// <returns></returns>
    static private Color NewColor(Color oldColor, int difference)
    {
      int red;
      int green;
      int blue;

      if (oldColor.R - difference >= difference) red = oldColor.R - difference;
      else red = BackColorForm.R + difference;
      if (oldColor.G - difference >= difference) green = oldColor.G - difference;
      else green = BackColorForm.G + difference;
      if (oldColor.B - difference >= difference) blue = oldColor.B - difference;
      else blue = BackColorForm.B + difference;

      return Color.FromArgb(red, green, blue);
    } 

    #endregion

    #region Конструктор

    /// <summary>
    /// Задаёт настройки цвета элементов.
    /// </summary>
    static BackColorElements()
    {
      BackColorForm = Color.FromArgb(212, 213, 187);
      BackColorTopElement = Color.FromArgb(30, 30, 40);
      BackColorCategoriesElement = BackColorTopElement;
      DefaultBackColorCategory = BackColorTopElement;
      HoverBackColorCategory = NewColor(BackColorTopElement,10);
      ActiveBackColorCategory = BackColorForm;
      BackColorMainApps = BackColorForm;
      BackColorAppElement = NewColor(BackColorForm, 30);
      DefaultBackColorTextApp = BackColorAppElement;
    }

    #endregion

  }
}
