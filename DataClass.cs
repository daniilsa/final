using Launcher.Controls;
using LauncherNet.Controls;

namespace LauncherNet
{
  public static class DataClass
  {
    #region Поля

    #region Триггеры

    /// <summary>
    /// "Триггер" загрузки приложения
    /// </summary>
    static public bool downloadStage = false;

    /// <summary>
    /// "Триггер" обновления элементов приложения.
    /// </summary>
    static public bool update;

    /// <summary>
    /// Есть ли активная категория.
    /// </summary>
    static public bool activeCategory = false;

    /// <summary>
    /// Перетаскивание формы
    /// </summary>
    static public bool drag = false;

    #endregion

    #region Размеры элементов 

    /// <summary>
    /// Размер элемента с приложением.
    /// </summary>
    public static Size sizeAppElement;

    /// <summary>
    /// Размер всего приложения.
    /// </summary>
    public static Size sizeForm;

    /// <summary>
    /// Размер формы до прилипания.
    /// </summary>
    public static Size sizeStickingForm;

    /// <summary>
    /// Разрешение экрана в пикселях.
    /// </summary>
    public static Size screenSize;

    /// <summary>
    /// Ширина рамки формы.
    /// </summary>
    public static int borderFormWidth = 3;

    #endregion

    #region Локация элментов

    /// <summary>
    /// Заполнение локации элемента.
    /// </summary>
    public struct Location
    {
      private Point location = new Point();

      public Point LocationElement { get { return location; } set { location = value; } }

      public int X { get { return location.X; } }
      public int Y { get { return location.Y; } }

      public Location(int x, int y)
      {
        location = new Point(x, y);
      }
    }

    /// <summary>
    /// Локация приложения.
    /// </summary>
    public static Location locationForm;

    /// <summary>
    /// Последняя позиция формы до "Прилипания".
    /// </summary>
    public static Location locationStickingForm;

    #endregion

    #region Путь к файлам

    /// <summary>
    /// Путь к текстовым файлам категорий.
    /// </summary>
    public static string pathFiles;

    /// <summary>
    /// Путь к файлу с последними настройками.
    /// </summary>
    public static string pathBackup;

    /// <summary>
    /// Путь к текстовым файлам категорий.
    /// </summary>
    public static string categoriesPathFiles;

    /// <summary>
    /// Путь к картинкам.
    /// </summary>
    public static string pathImages;

    /// <summary>
    /// Путь к шрифтам
    /// </summary>
    public static string pathFont;

    /// <summary>
    /// Путь к выбранно йкртинке из интернета;
    /// </summary>
    public static string locationImage;

    #endregion

    #region Ключи

    /// <summary>
    /// Разделительный "символ" между параметрами приложения. 
    /// </summary>
    public static string code;

    /// <summary>
    /// Ключ для поиска активной категории при закрытии приложения.
    /// </summary>
    public static string keyCategory;

    #endregion

    #region Экземпляры элементов


    #region Лаунчер (Основная форма)

    /// <summary>
    /// Экземпляр формы лаунчера.
    /// </summary>
    public static Form launcher;

    /// <summary>
    /// Активная панель с приложениями.
    /// </summary>
    public static ScrollBarElement activeAppPanelLauncher;

    /// <summary>
    /// Последняя активная панель с приложениями.
    /// </summary>
    public static ScrollBarElement lastAppPanelLauncher;

    /// <summary>
    /// Активный элемент с файлами лаунчера.
    /// </summary>
    public static Panel activeMainPanelLauncher;

    /// <summary>
    /// Экземпляр верхней панели лаунчера.
    /// </summary>
    public static Panel topElementLauncher;

    /// <summary>
    /// Экземпляр панели с категориями лаунчера.
    /// </summary>
    public static Panel categoriesElementLauncher;

    /// <summary>
    /// Экземпляры панелей с файлами лаунчера.
    /// </summary>
    public static List<ScrollBarElement> mainAppsLauncher;

    /// <summary>
    /// Список приложений актовной категории. 
    /// </summary>
    public static List<Panel> appsElementLauncher;

    /// <summary>
    /// Активная панель категории.
    /// </summary>
    public static TextElement activeCategoryPanelLauncher;

    /// <summary>
    /// Последняя активная панель категории.
    /// </summary>
    public static TextElement lastCategoryPanelLauncher;

    /// <summary>
    /// Экземпляры панелей категории лаунчера.
    /// </summary>
    public static List<TextElement> categoryElementLauncher;

    /// <summary>
    /// Экземпляр элемента добавления категории.
    /// </summary>
    public static ControlAddElement controlAddCategory;

    /// <summary>
    /// Экземпляр элемента добавления приложения в категорию.
    /// </summary>
    public static List<ControlAddElement> controlAddApp;

    #endregion

    #region Форма добавления категории.

    /// <summary>
    /// Экзмепляр формы добавления категории.
    /// </summary>
    static public Form functionalForm;

    #endregion


    #region Форма выбора картинок

    /// <summary>
    /// Экземпляр формы выбора картинок.
    /// </summary>
    public static Form imageSelectionForm;

    /// <summary>
    /// Экземпляр элемента верхнего меню.
    /// </summary>
    public static Panel topElementSelectionForm;

    /// <summary>
    /// Экземпляр контрола со всеми элементами.
    /// </summary>
    public static Panel mainAppsSelectionForm;

    /// <summary>
    /// Список экземпляров элементов с картинками.
    /// </summary>
    public static List<Panel> imageElementsSelectionForm;

    /// <summary>
    /// Экземпляр элемента нижнего меню.
    /// </summary>
    public static Panel bottomElementSelectionForm;

    #endregion

    #endregion

    #region Перечисления

    /// <summary>
    /// Функции категорий.
    /// </summary>
    public enum FunctionCategory
    {
      /// <summary>
      /// Добавление приложения в категорию.
      /// </summary>
      AddApp,

      /// <summary>
      /// Добавление категории в лаунчер.
      /// </summary>
      AddCategory,

      /// <summary>
      /// Удаление категории из лаунчера.
      /// </summary>
      DeleteCategory,

      /// <summary>
      /// Переименование категории в лаунчере.
      /// </summary>
      RenameCategory,
    }

    /// <summary>
    /// Функции приложений.
    /// </summary>
    public enum FunctionApp
    {

      /// <summary>
      /// Открыть приложение.
      /// </summary>
      Open,

      /// <summary>
      /// Открыть расположение файла.
      /// </summary>
      PathFile,

      /// <summary>
      /// Смена картинки приложения.
      /// </summary>
      ChangeImage,

      /// <summary>
      /// Удалить из лаунчера.
      /// </summary>
      Delete
    }

    /// <summary>
    /// Список возможных "прилипаний" формы к границам экрана.
    /// </summary>
    public enum Sticking
    {
      /// <summary>
      /// Левая граница экрана.
      /// </summary>
      Left,

      /// <summary>
      /// Правая граница экрана.
      /// </summary>
      Right,

      /// <summary>
      /// Верхняя граница экрана.
      /// </summary>
      Top,

      /// <summary>
      /// Нижняя граница экрана.
      /// </summary>
      Bottom,

      /// <summary>
      /// Не прилипает к границе экрана.
      /// </summary>
      Nope
    }

    /// <summary>
    /// Список возможных границ изменений формы.
    /// </summary>
    public enum Expand
    {
      /// <summary>
      /// Левая граница формы.
      /// </summary>
      Left,

      /// <summary>
      /// Правая граница формы.
      /// </summary>
      Right,

      /// <summary>
      /// НИжняя граница формы.
      /// </summary>
      Bottom,

      /// <summary>
      /// Левая нижняя граница формы.
      /// </summary>
      LeftBottom,

      /// <summary>
      /// Правая нижняяя граница формы.
      /// </summary>
      RightBottom,

      /// <summary>
      /// Никакая из перечисленных граница формы.
      /// </summary>
      Nope
    }

    #endregion

    #region Другое

    /// <summary>
    /// Сторона монитора, к которой "прилипает" форма.
    /// </summary>
    public static Sticking stickingForm;

    /// <summary>
    /// Количество искомых картинок в интернете.
    /// </summary>
    public static int countImageSearch = 9;

    #endregion

    #endregion

    #region Конструктор

    /// <summary>
    /// Заполнение первичных данных для работы ПО.
    /// </summary>
    static DataClass()
    {
      sizeAppElement = new Size(167, 268);
      screenSize = Screen.PrimaryScreen.Bounds.Size;

      pathFiles = @".\Files";
      pathBackup = @".\BackUp\backup";
      categoriesPathFiles = @".\Files\Categories";
      pathImages = @".\Images";
      pathFont = @".\Font";

      code = "$SPRTR$";
      keyCategory = "lastCategory";

      appsElementLauncher = new List<Panel>();
      stickingForm = Sticking.Nope;

      categoryElementLauncher = new List<TextElement>();
      mainAppsLauncher = new List<ScrollBarElement>();
      //mainAppsLauncher = new List<Panel>();
      imageElementsSelectionForm = new List<Panel>();
      controlAddApp = new List<ControlAddElement>();
      locationImage = string.Empty;
    }

    #endregion
  }
}
