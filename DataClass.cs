using Launcher.Controls;
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
    /// </summary>
    static public Size sizeStickingForm;

    /// <summary>
    /// Размер элемента с категориями.
    /// </summary>
    public static Size sizeCategoriesElement;

    /// <summary>
    /// Разрешение экрана в пикселях.
    /// </summary>
    static public Size screenSize;

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




    /// <summary>
    /// Активная панель с приложениями.
    /// </summary>
    static public Panel activeAppPanel;

    /// <summary>
    /// Последняя активная панель с приложениями.
    /// </summary>
    static public Panel lastAppPanel;

    /// <summary>
    /// Активная панель категории.
    /// </summary>
    static public TextElement activeCategoryPanel;

    /// <summary>
    /// Последняя активная панель категории.
    /// </summary>
    static public TextElement lastCategoryPanel;

    #endregion

    #region Шрифт


    #endregion

    #region Другое

    static public Sticking stickingForm;

    /// <summary>
    /// Количетсво искомых картинок в интернете.
    /// </summary>
    static public int countImageSearch = 10;

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
      pathBackup = pathFiles + "\\backup";
      categoriesPathFiles = @".\Files\Categories";
      pathImages = @".\Images";
      pathFont = @".\Font";

      code = "$SPRTR$";
      keyCategory = "lastCategory";

      appsElement = new List<Panel>();
      stickingForm = Sticking.Nope;

      categoryElement = new List<TextElement>();
      mainAppsControl = new List<Panel>();
    }

    #endregion
  }
}
