using LauncherNet.DesignFront;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Front
{
  static public class FontElements
  {

    #region Свойства

    /// <summary>
    /// Возвращает шрифт элемента с категорией.
    /// </summary>
    static public Font FontCategory { get; set; }

    static public Font FontLabel { get; set; }
    static public Font FontLabelInfo { get; set; }

    /// <summary>
    /// Возвращает шрифт элемента с приложением.
    /// </summary>
    static public Font FontApp { get; set; }

    /// <summary>
    /// Возвращает цвет шрифта категорий.
    /// </summary>
    /// <returns></returns>
    static public Color DefaultForeColorCategory { get; set; }

    /// <summary>
    /// Возвращает цвет текста активной категории.
    /// </summary>
    static public Color ActiveForeColorCategory { get; set; }

    /// <summary>
    /// Возвращает цвет текста приложения.
    /// </summary>
    static public Color DefaultForeColorApp { get; set; }

    /// <summary>
    /// Возвращает цвет текста при наведении на элемент.
    /// </summary>
    static public Color HoverForeColorApp { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Обновляет шрифт
    /// </summary>
    static public void UpdateFont()
    {
      PrivateFontCollection fontCollection = new PrivateFontCollection();
      FontCategory = new Font("Segoe UI", 15);
      FontApp = new Font("Segoe UI", 9);
      DefaultForeColorCategory = BackColorElements.DefaultColorLauncher;
      ActiveForeColorCategory = BackColorElements.DefaultColorTopElement;
      DefaultForeColorApp = ActiveForeColorCategory;
      HoverForeColorApp = DefaultForeColorCategory;

      string font = FontResource.String1;
      fontCollection.AddFontFile($@"{font}");
      FontCategory = new Font(fontCollection.Families[0], 15);
      FontApp = new Font(fontCollection.Families[0], 9);
      FontLabel = FontCategory;
      FontLabelInfo = FontApp;
    }

    /// <summary>
    /// Вовзращщает шрифт.
    /// </summary>
    /// <returns></returns>
    static public Font GetFont()
    {
      PrivateFontCollection fontCollection = new PrivateFontCollection();
      string font = FontResource.String1;
      fontCollection.AddFontFile($@"{font}");
      return new Font(fontCollection.Families[0], 9);
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Считывает шрифты в переменные.
    /// </summary>
    static FontElements()
    {
      UpdateFont();
    }

    #endregion
  }
}
