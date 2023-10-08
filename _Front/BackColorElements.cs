namespace LauncherNet.DesignFront
{
  public static class BackColorElements
  {

    #region Свойства

    public static Color MainLightColor => Color.FromArgb(212, 213, 187);
    public static Color AdditionalLight => NewColor(MainLightColor, 30);

    public static Color MainDarkColor => Color.FromArgb(30, 30, 40);
    public static Color AdditionalDarkColor => NewColor(MainDarkColor, 10);


    /// <summary>
    /// Возвращает цвет фона формы лаунчера.
    /// </summary>
    //static public Color DefaultColorLauncher => Color.FromArgb(212, 213, 187);

    /// <summary>
    /// Возвращает цвет фона верхнего элемента формы.
    /// </summary>
    //static public Color DefaultColorTopElement => Color.FromArgb(30, 30, 40);

    /// <summary>
    /// Возвращает цвет фона элемента со всеми категориями.
    /// </summary>
    //static public Color DefaultColorCategoriesElement => MainDarkColor;

    /// <summary>
    /// Возвращает цвет фона категории по умолчанию.
    /// </summary>
    // public Color DefaultColorCategory => MainDarkColor;

    /// <summary>
    /// Возвращает цвет фона элемента со всеми приложениями.
    /// </summary>
    //static public Color DefaultColorMainApps => MainLightColor;

    /// <summary>
    /// Возвращает цвет фона элемента приложения.
    /// </summary>
    //static public Color DefaultColorAppElement => AdditionalLight;

    /// <summary>
    /// Возвращает цвет фона имени приложения.
    /// </summary>
    //static public Color DefaultColorTextApp => AdditionalLight;

    /// <summary>
    /// Возвращает цвет фона формы выбора изображений.
    /// </summary>
    //static public Color DefaultColorImageSelectionForm => MainDarkColor;

    /// <summary>
    /// Возвращает цвет фона формы создания или добавления категории.
    /// </summary>
    //static public Color DefaultColorFunctionForm => AdditionalDarkColor;

    /// <summary>
    /// Возвращает цвет фона контекстного меню по умолчанию.
    /// </summary>
    //static public Color DefaultColorContextMenu => MainDarkColor;


    /// <summary>
    /// Возвращает цвет фона категории при наведении мыши.
    /// </summary>
    //static public Color HoverBackColorCategory => AdditionalDarkColor;

    /// <summary>
    /// Возвращает цвет фона активной категории.
    /// </summary>
    //static public Color ActiveBackColorCategory => MainLightColor;

    /// <summary>
    /// Возвращает текст фоона имени приложения при наведении.
    /// </summary>
    //static public Color HoverBackColorTextApp => MainDarkColor;

    /// <summary>
    /// Возвращает цвет фона контекстного меню при наведении.
    /// </summary>
    //static public Color HoverColorContextMenu => MainLightColor;

    #endregion

    #region Методы

    /// <summary>
    /// Расчёт цвета.
    /// </summary>
    /// <param name="oldColor">Используемый цвет.</param>
    /// <param name="difference">Разница в цветовой гамме(целое число).</param>
    /// <returns></returns>
    private static Color NewColor(Color oldColor, int difference)
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
