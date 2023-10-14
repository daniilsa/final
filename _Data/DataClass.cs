using LauncherNet.DesignFront;

namespace LauncherNet
{
  /// <summary>
  /// Общие поля, свойства и методы приложения.
  /// </summary>
  public static class DataClass
  {

    #region Свойства

    #region Bool

    /// <summary>
    /// Возвращает или задаёт параметр самого первого запуска приложения.
    /// </summary>
    public static bool FirstStart { get; set; }

    /// <summary>
    /// "Триггер" загрузки приложения
    /// </summary>
    public static bool DownloadStage { get; set; }

    /// <summary>
    /// "Триггер" обновления элементов приложения.
    /// </summary>
    public static bool Update { get; set; }

    /// <summary>
    /// Уводить ли приложение в Трэй.
    /// </summary>
    public static bool TrayActive { get; set; }

    /// <summary>
    /// Подключение к интернету.
    /// </summary>
    public static bool InternetСonnection { get; set; }

    /// <summary>
    /// Запустить процесс приложения.
    /// </summary>
    public static bool StartProcess { get; set; }

    /// <summary>
    /// Задаёт или возвращает значения вызова Help.
    /// </summary>
    public static bool HelpExist { get; set; }

    #endregion

    #region Numbers

    /// <summary>
    /// Ширина рамки формы.
    /// </summary>
    public static int borderFormWidth => 3;

    /// <summary>
    /// Разрешение экрана в пикселях.
    /// </summary>
    public static Size screenSize => Screen.PrimaryScreen.Bounds.Size;

    #endregion

    #region Chars

    /// <summary>
    /// Путь к текстовым файлам категорий.
    /// </summary>
    public static string PathFiles => @".\Files";

    /// <summary>
    /// Путь к файлу с последними настройками.
    /// </summary>
    public static string PathBackup => @".\Settings";

    /// <summary>
    /// Путь к текстовым файлам категорий.
    /// </summary>
    public static string CategoriesPathFiles => @".\Files\Categories";
    public static string Help => @".\Help\index.htm";

    /// <summary>
    /// Путь к картинкам.
    /// </summary>
    public static string PathImages => @".\Images";

    /// <summary>
    /// Разделительный "символ" между параметрами приложения. 
    /// </summary>
    public static string Code => "$SPRTR$";

    /// <summary>
    /// Ключ для поиска активной категории при закрытии приложения.
    /// </summary>
    public static string KeyCategory => "lastCategory";

    #endregion

    #region Elements

    /// <summary>
    /// Иконка приложения.
    /// </summary>
    public static NotifyIcon? iconLauncher { get; set; }

    #endregion

    #region Colors

    /// <summary>
    /// Первый основной цвет приложения по умолчанию.
    /// </summary>
    public static Color DefaultFirstMainColor => Color.FromArgb(30, 30, 40);

    /// <summary>
    /// Первый дополнительный цвет приложения по умолчанию.
    /// </summary>
    public static Color _DefaultFirstAdditionalColor => BackColorElements.NewColor(DefaultFirstMainColor, 10);

    /// <summary>
    /// Второй основной цвет приложения по умолчанию.
    /// </summary>
    static public Color _DefaultSecondMainColor => Color.FromArgb(212, 213, 187);

    /// <summary>
    /// Второй дополнительный цвет приложения по умолчанию.
    /// </summary>
    static public Color _DefaultSecondAdditionalMainColor => BackColorElements.NewColor(_DefaultSecondMainColor, 30);

    #endregion

    #endregion

    #region Методы

    /// <summary>
    /// Возвращает домен приложения.
    /// </summary>
    /// <returns></returns>
    public static AppDomain GetDomain()
    {
      return AppDomain.CurrentDomain;
    }

    #endregion

  }
}
