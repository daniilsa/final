namespace LauncherNet._DataStatic
{
  internal static class DataHelpForm
  {
    /// <summary>
    /// Возвращает или задаёт экземпляр формы помощи.
    /// </summary>
    public static Form? helpForm { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр верхней панели.
    /// </summary>
    public static Panel? topElement { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр элемента с информацией.
    /// </summary>
    public static Panel? mainElement { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр элемента с разделами.
    /// </summary>
    public static Panel? categoriesElement { get; set; }

  }
}
