using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Design
{
  public class FontElements
  {

    #region Поля

    /// <summary>
    /// Путь к шрифтам
    /// </summary>
    static private string pathFont = DataClass.pathFont;

    /// <summary>
    /// Коллекция шрифтов.
    /// </summary>
    static private PrivateFontCollection fontCollection = new PrivateFontCollection();

    /// <summary>
    /// Шрифт заголовков.
    /// </summary>
    static private Font headerFont;

    /// <summary>
    /// Шрифт наименований.
    /// </summary>
    static private Font footerFont;

    #endregion

    #region Методы

    /// <summary>
    /// Возвращает шрифт заголовков.
    /// </summary>
    /// <returns></returns>
    public Font GetHeaderFont()
    {
      return headerFont;
    }

    /// <summary>
    /// Возвращает шрифт названия приложений.
    /// </summary>
    /// <returns></returns>
    public Font GetFooterFont()
    {
      return footerFont;
    }

    /// <summary>
    /// Возвращает цвет шрифта заголовков.
    /// </summary>
    /// <returns></returns>
    public Color GetHeaderFontColor()
    {
      return Color.FromArgb(212, 213, 187);
    }

    /// <summary>
    /// Возвращает цвет шрифта при активной категории.
    /// </summary>
    /// <returns></returns>
    public Color GetActiveHeaderFontColor()
    {
      return Color.FromArgb(30, 30, 40);
    }

    /// <summary>
    /// Возвращает цвет шрифта наименования приложений.
    /// </summary>
    /// <returns></returns>
    public Color GetNameAppFontColor()
    {
      return new ColorElements().GetHeaderColor();
    }


    #endregion

    #region Конструктор

    /// <summary>
    /// Считывает шрифты в переменные.
    /// </summary>
    public FontElements()
    {

      headerFont = new Font("Segoe UI", 9);
      footerFont = new Font("Segoe UI", 9);
      if (Directory.Exists(pathFont))
      {
        string[] paths = Directory.GetFiles($@"{pathFont}\");

        if (paths.Length > 0)
        {
          fontCollection.AddFontFile($@"{paths[0]}");
          headerFont = new Font(fontCollection.Families[0], 15);
          footerFont = new Font(fontCollection.Families[0], 10);
        }
      }
    }

    #endregion
  }
}
