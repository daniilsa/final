using Launcher.Controls;
using LauncherNet.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LauncherNet
{
  static public class DataClass
  {

    #region Позже раскидать по категориям.

    static public bool downloadStage = false;
    static public Form launcher;
    static public Panel topElement;
    static public Panel categoriesElement;
    static public List<TextElement> categoryElement;
    static public List<Panel> mainAppsControl;

    static public Panel mainPanel;

    static public bool update;

    /// <summary>
    /// Список приложений актовной категории. 
    /// </summary>
    static public List<Panel> appsElement;

    #endregion

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

    #endregion

    #region Размеры элементов 

    /// <summary>
    /// Размер элемента с приложением.
    /// </summary>
    static public Size sizeAppElement;

    /// <summary>
    /// Размер всего приложения.
    /// </summary>
    static public Size sizeForm;

    /// <summary>
    /// Размер формы до прилипания.
<<<<<<< HEAD
=======
    /// </summary>
    static public Size sizeStickingForm;

    /// <summary>
    /// Размер элемента с категориями.
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    /// </summary>
    static public Size sizeStickingForm;

    /// <summary>
    /// Разрешение экрана в пикселях.
    /// </summary>
    static public Size screenSize;

    /// <summary>
    /// Ширина рамки формы.
    /// </summary>
    static public int borderFormWidth = 3;

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
    static public Location locationForm;

<<<<<<< HEAD
    /// <summary>
    /// Последняя позиция формы до "Прилипания".
    /// </summary>
=======
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    static public Location locationStickingForm;

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

<<<<<<< HEAD
    /*==ЛАУНЧЕР==*/

    /// <summary>
    /// Экземпляр формы лаунчера.
    /// </summary>
    static public Form launcher;
=======


>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f

    /// <summary>
    /// Активная панель с приложениями.
    /// </summary>
    static public ScrollBarElement activeAppPanelLauncher;
    //static public Panel activeAppPanelLauncher;

    /// <summary>
    /// Последняя активная панель с приложениями.
    /// </summary>
    static public ScrollBarElement lastAppPanelLauncher;
    //static public Panel lastAppPanelLauncher;

    /// <summary>
    /// Активный элемент с файлами лаунчера.
    /// </summary>
    static public Panel activeMainPanelLauncher;

    /// <summary>
    /// Экземпляр верхней панели лаунчера.
    /// </summary>
    static public Panel topElementLauncher;

    /// <summary>
    /// Экземпляр панели с категориями лаунчера.
    /// </summary>
    static public Panel categoriesElementLauncher;

    /// <summary>
    /// Экземпляры панелей с файлами лаунчера.
    /// </summary>
    static public List<ScrollBarElement> mainAppsLauncher;
    //static public List<Panel> mainAppsLauncher;

    /// <summary>
    /// Список приложений актовной категории. 
    /// </summary>
    static public List<Panel> appsElementLauncher;

    /// <summary>
    /// Активная панель категории.
    /// </summary>
    static public TextElement activeCategoryPanelLauncher;

    /// <summary>
    /// Последняя активная панель категории.
    /// </summary>
    static public TextElement lastCategoryPanelLauncher;

    static public Sticking stickingForm;

    /// <summary>
    /// Экземпляры панелей категории лаунчера.
    /// </summary>
    static public List<TextElement> categoryElementLauncher;

    static public ControlAddElement controlAddCategory;

    static public List<ControlAddElement> controlAddApp;

    /*==ВЫБОР КАРТИНОК==*/

    static public Form imageSelectionForm;
    static public Panel topElementSelectionForm;
    static public Panel mainAppsSelectionForm;
    static public List<Panel> imageElementsSelectionForm;
    static public Panel bottomElementSelectionForm;



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
      ChangeImage,
    }

    /// <summary>
    /// Список возможных "прилипаний" формы к границам экрана.
    /// </summary>
    public enum Sticking
    {
      Left,
      Right,
      Top,
      Bottom,
      Nope
    }

    /// <summary>
    /// Список возможных границ изменений формы.
    /// </summary>
    public enum Expand
    {
      Left,
      Right,
      Bottom,
      LeftBottom,
      RightBottom,
      Nope
    }
<<<<<<< HEAD

    #endregion

    #region Другое

    /// <summary>
    /// Сторона монитора, к которой "прилипает" форма.
    /// </summary>
    static public Sticking stickingForm;

    /// <summary>
    /// Количество искомых картинок в интернете.
    /// </summary>
    static public int countImageSearch = 9;

=======
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
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

<<<<<<< HEAD
      appsElementLauncher = new List<Panel>();
      stickingForm = Sticking.Nope;

      categoryElementLauncher = new List<TextElement>();
      mainAppsLauncher = new List<ScrollBarElement>();
      //mainAppsLauncher = new List<Panel>();
      imageElementsSelectionForm = new List<Panel>();
      controlAddApp = new List<ControlAddElement>();
      locationImage = string.Empty;
=======
      appsElement = new List<Panel>();
      stickingForm = Sticking.Nope;

      categoryElement = new List<TextElement>();
      mainAppsControl = new List<Panel>();
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
    }

    #endregion
  }
}
