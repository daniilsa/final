using Launcher.Controls;
using LauncherNet.Controls;

namespace LauncherNet._Data
{
  public static class DataLauncherForm
  {

    #region Bool

    /// <summary>
    /// Возвращает или задаёт наличие активной категория.
    /// </summary>
    public static bool activeCategory { get; set; }

    #endregion

    #region Numbers

    /// <summary>
    /// Размер элемента с приложением.
    /// </summary>
    public static Size sizeAppElement = new(167, 268);

    /// <summary>
    /// Размер главной формы.
    /// </summary>
    public static Size sizeMainForm;

    #endregion

    #region Chars

    /// <summary>
    /// Возвращает или задаёт путь к выбранной кртинке из интернета.
    /// </summary>
    public static string? locationImage { get; set; }

    #endregion

    #region Elements

    /// <summary>
    /// Возвращает или задаёт экземпляр формы лаунчера.
    /// </summary>
    public static Form? launcher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр активного элемента с приложениями.
    /// </summary>
    public static ScrollBarControl? activeAppPanelLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр последнего активного элемента с приложениями.
    /// </summary>
    public static ScrollBarControl? lastAppPanelLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр активного элемента с файлами лаунчера.
    /// </summary>
    public static Panel? activeMainPanelLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр верхней панели лаунчера.
    /// </summary>
    public static Panel? topElementLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр панели с категориями лаунчера.
    /// </summary>
    public static Panel? categoriesElementLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр активного элемента категории.
    /// </summary>
    public static TextControl? activeCategoryPanelLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр последнего активного элемениа категории.
    /// </summary>
    public static TextControl? lastCategoryPanelLauncher { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр элемента добавления категории.
    /// </summary>
    public static ControlAddControl? controlAddCategory { get; set; }

    /// <summary>
    /// Экземпляры панелей категории лаунчера.
    /// </summary>
    public static List<TextControl> categoryElementLauncher = new List<TextControl>();

    /// <summary>
    /// Экземпляр элемента добавления приложения в категорию.
    /// </summary>
    public static List<ControlAddControl> controlAddApp = new List<ControlAddControl>();

    /// <summary>
    /// Экземпляры контекстного меню приложений.
    /// </summary>
    public static List<ContextMenuStrip> functionsApp = new List<ContextMenuStrip>();

    /// <summary>
    /// Экземпляры контекстного меню категорий.
    /// </summary>
    public static List<ContextMenuStrip> functionsCategory = new List<ContextMenuStrip>();

    /// <summary>
    /// Экземпляры панелей с файлами лаунчера.
    /// </summary>
    public static List<ScrollBarControl> mainAppsLauncher = new List<ScrollBarControl>();

    /// <summary>
    /// Список приложений актовной категории. 
    /// </summary>
    public static List<Panel> appsElementLauncher = new List<Panel>();

    #endregion

    #region Location

    /// <summary>
    /// Возвращает или задаёт расположение на экране главной формы.
    /// </summary>
    public static DataStruct.Location locationMainForm { get; set; }

    /// <summary>
    ///  Возвращает или задаёт расположение на экране главной формы до "Прилипания".
    /// </summary>
    public static DataStruct.Location locationStickingMainForm { get; set; }

    #endregion


    #region Экземпляры элементов



    #endregion

  }
}
