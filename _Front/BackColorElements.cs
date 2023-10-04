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
    /// Возвращает цвет фона формы лаунчера.
    /// </summary>
    static public Color DefaultColorLauncher => Color.FromArgb(212, 213, 187);

    /// <summary>
    /// Возвращает цвет фона верхнего элемента формы.
    /// </summary>
    static public Color DefaultColorTopElement => Color.FromArgb(30, 30, 40);

    /// <summary>
    /// Возвращает цвет фона элемента со всеми категориями.
    /// </summary>
    static public Color DefaultColorCategoriesElement => DefaultColorTopElement;

    /// <summary>
    /// Возвращает цвет фона категории по умолчанию.
    /// </summary>
    static public Color DefaultColorCategory => DefaultColorTopElement;

    /// <summary>
    /// Возвращает цвет фона элемента со всеми приложениями.
    /// </summary>
    static public Color DefaultColorMainApps => DefaultColorLauncher;

    /// <summary>
    /// Возвращает цвет фона элемента приложения.
    /// </summary>
    static public Color DefaultColorAppElement => NewColor(DefaultColorLauncher, 30);

    /// <summary>
    /// Возвращает цвет фона имени приложения.
    /// </summary>
    static public Color DefaultColorTextApp => DefaultColorAppElement;

    /// <summary>
    /// Возвращает цвет фона формы выбора изображений.
    /// </summary>
    static public Color DefaultColorImageSelectionForm => DefaultColorTopElement;

    /// <summary>
    /// Возвращает цвет фона формы создания или добавления категории.
    /// </summary>
    static public Color DefaultColorFunctionForm => HoverColorCategory;

    /// <summary>
    /// Возвращает цвет фона контекстного меню по умолчанию.
    /// </summary>
    static public Color DefaultColorContextMenu => DefaultColorTopElement;

    /// <summary>
    /// Возвращает цвет фона категории при наведении мыши.
    /// </summary>
    static public Color HoverColorCategory => NewColor(DefaultColorTopElement, 10);

    /// <summary>
    /// Возвращает цвет фона активной категории.
    /// </summary>
    static public Color ActiveColorCategory => DefaultColorLauncher;

    /// <summary>
    /// Возвращает текст фона имени приложения при наведении.
    /// </summary>
    static public Color HoverColorTextApp => DefaultColorCategoriesElement;

    /// <summary>
    /// Возвращает цвет фона контекстного меню при наведении.
    /// </summary>
    static public Color HoverColorContextMenu => DefaultColorLauncher;
    #endregion

    #region Методы

    /// <summary>
    /// Расчёт цвета.
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
      else red = DefaultColorLauncher.R + difference;
      if (oldColor.G - difference >= difference) green = oldColor.G - difference;
      else green = DefaultColorLauncher.G + difference;
      if (oldColor.B - difference >= difference) blue = oldColor.B - difference;
      else blue = DefaultColorLauncher.B + difference;

      return Color.FromArgb(red, green, blue);
    }

    #endregion


  }
}
