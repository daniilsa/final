namespace LauncherNet.DesignFront
{
  public static class BackColorElements
  {

    #region Свойства

    public static Color MainLightColor { get; set; }
    public static Color AdditionalLight { get; set; }

    public static Color MainDarkColor { get; set; }
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
