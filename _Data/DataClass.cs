using LauncherNet.DesignFront;

namespace LauncherNet
{
  public static class DataClass
  {

    #region Свойства

    #region Bool

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
    /// Запустить процесс.
    /// </summary>
    public static bool StartProcess { get; set; }

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

    /// <summary>
    /// Путь к картинкам.
    /// </summary>
    public static string PathImages => @".\Images";

    /// <summary>
    /// Путь к шрифтам
    /// </summary>
    public static string PathFont => @".\Font";

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

    public static Color FirstMainColor => Color.FromArgb(30, 30, 40);
    public static Color FirstAdditionalColor => BackColorElements.NewColor(FirstMainColor, 10);

    static public Color SecondMainColor => Color.FromArgb(212, 213, 187);
    static public Color SecondAdditionalMainColor => BackColorElements.NewColor(SecondMainColor, 30);

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
