using LauncherNet.Files;

namespace LauncherNet.DesignFront
{
  /// <summary>
  /// Цвета фона.
  /// </summary>
  public static class BackColorElements
  {

    #region Свойства

    /// <summary>
    /// Возвращает или задаёт первый основной цвет приложения.
    /// </summary>
    public static Color MainLightColor { get; set; }

    /// <summary>
    /// Возвращает или задаёт первый дополнительный цвет приложения.
    /// </summary>
    public static Color AdditionalLight { get; set; }


    /// <summary>
    /// Возвращает или задаёт второй основной цвет приложения.
    /// </summary>
    public static Color MainDarkColor { get; set; }

    /// <summary>
    /// Возвращает или задаёт второй дополнительный цвет приложения.
    /// </summary>
    public static Color AdditionalDarkColor { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Расчёт цвета.
    /// </summary>
    /// <param name="oldColor">Используемый цвет.</param>
    /// <param name="difference">Разница в цветовой гамме(целое число).</param>
    /// <returns></returns>
    public static Color NewColor(Color oldColor, int difference)
    {
      int red;
      int green;
      int blue;

      if (oldColor.R - difference >= difference) red = oldColor.R - difference;
      else red = oldColor.R + difference;
      if (oldColor.G - difference >= difference) green = oldColor.G - difference;
      else green = oldColor.G + difference;
      if (oldColor.B - difference >= difference) blue = oldColor.B - difference;
      else blue = oldColor.B + difference;

      return Color.FromArgb(red, green, blue);
    }

    #endregion

  }
}
