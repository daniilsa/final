namespace LauncherNet._Data
{
  public static class DataImageSelectionForm
  {

    /// <summary>
    /// Возвращает или задаёт экземпляр формы выбора картинок.
    /// </summary>
    public static Form? imageSelectionForm { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр элемента верхнего меню.
    /// </summary>
    public static Panel? topElementSelectionForm { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр контрола со всеми элементами.
    /// </summary>
    public static Panel? mainAppsSelectionForm { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр элемента нижнего меню.
    /// </summary>
    public static Panel? bottomElementSelectionForm { get; set; }

    /// <summary>
    /// Количество искомых картинок в интернете.
    /// </summary>
    public static int countImageSearch => 9;

    /// <summary>
    /// Список экземпляров элементов с картинками.
    /// </summary>
    public static List<Panel>? imageElementsSelectionForm = new List<Panel>();
  }
}
