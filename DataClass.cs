using Launcher.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet
{
  static public class DataClass
  {
    #region Поля

    #region Размеры элементов 

    /// <summary>
    /// Размер элемента с приложением.
    /// </summary>
    static public Size sizelAppElement;

    /// <summary>
    /// Размер всего приложения.
    /// </summary>
    static public Size sizeForm;

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
      private int[] location = new int[2];

      public int[] LocationElement { get { return location; } }

      public Location(int x, int y)
      {
        location[0] = x;
        location[1] = y;
      }
    }

    /// <summary>
    /// Локация приложения.
    /// </summary>
    static public Location locationForm;

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

    #region Работа с панелями категорий

    /// <summary>
    /// Список приложений актовной категории. 
    /// </summary>
    static public List<Panel> allApps;

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

    #endregion

    #endregion

    #region Конструктор

    /// <summary>
    /// Заполнение первичных данных для работы ПО.
    /// </summary>
    static DataClass()
    {
      sizelAppElement = new Size(167, 268);
      screenSize = Screen.PrimaryScreen.Bounds.Size;

      pathFiles = @".\Files";
      pathBackup = pathFiles + "\\backup";
      categoriesPathFiles = @".\Files\Categories";
      pathImages = @".\Images";
      pathFont = @".\Font";

      code = "$SPRTR$";
      keyCategory = "lastCategory";

      allApps = new List<Panel>();
    }

    #endregion
  }
}
