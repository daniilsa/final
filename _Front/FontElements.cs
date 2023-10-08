using LauncherNet.DesignFront;
using LauncherNet.Settings;
using System.Drawing.Text;

namespace LauncherNet.Front
{
  public static class FontElements
  {

    #region Свойства

    /// <summary>
    /// Возвращает шрифт элемента с категорией.
    /// </summary>
    public static Font FontCategory { get; set; }

    /// <summary>
    /// Возвращает шрифт подкатегорий.
    /// </summary>
    public static Font FontLabel { get; set; }


    /// <summary>
    /// Возвращает шрифт информационного текста.
    /// </summary>
    public static Font FontLabelInfo { get; set; }

    /// <summary>
    /// Возвращает шрифт элемента с приложением.
    /// </summary>
    public static Font FontApp { get; set; }


    public static Color MainLightColorText => BackColorElements.MainLightColor;
    public static Color MainDarkColorText => BackColorElements.MainDarkColor;

    /// <summary>
    /// Возвращает цвет шрифта категорий.
    /// </summary>
    /// <returns></returns>
    //static public Color DefaultForeColorCategory => BackColorElements.MainLightColor;

    /// <summary>
    /// Возвращает цвет текста активной категории.
    /// </summary>
   // static public Color ActiveForeColorCategory => BackColorElements.MainDarkColor;

    /// <summary>
    /// Возвращает цвет текста приложения.
    /// </summary>
    //static public Color DefaultForeColorApp => MainDarkColorText;

    /// <summary>
    /// Возвращает цвет текста при наведении на элемент.
    /// </summary>
    //static public Color HoverForeColorApp => MainLightColorText;

    /// <summary>
    /// Возвращает цвет шрифта контекстного меню.
    /// </summary>
    //static public Color DefaultColorTextContextMenuStrip => MainLightColorText;

    /// <summary>
    /// Возвращает цвет шрифта контекстного меню при наведении на элемент.
    /// </summary>
    //static public Color HoverColorTextContextMenuStrip => MainLightColorText;

    #endregion

    #region Методы

    /// <summary>
    /// Обновляет шрифт
    /// </summary>
    public static void UpdateFont()
    {
      PrivateFontCollection fontCollection = new PrivateFontCollection();
      FontCategory = new Font("Segoe UI", 15);
      FontApp = new Font("Segoe UI", 9);
      try
      {
        string font = FontResource.String1;
        fontCollection.AddFontFile($@"{font}");
        FontCategory = new Font(fontCollection.Families[0], 15);
        FontApp = new Font(fontCollection.Families[0], 9);
        FontLabel = FontCategory;
        FontLabelInfo = FontApp;
      }
      catch
      {
        // Шрифт не найден
      }
    }

    /// <summary>
    /// Вовзращщает шрифт.
    /// </summary>
    /// <returns></returns>
    public static Font GetFont()
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
      FontCategory = new Font("Segoe UI", 15);
      FontApp = new Font("Segoe UI", 9);
      FontLabel = FontCategory;
      FontLabelInfo = FontApp;
      UpdateFont();
    }

    #endregion
  }
}
