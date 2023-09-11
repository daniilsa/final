using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet
{
  static public class DataClass
  {
    #region Размеры элементов 

    /// <summary>
    /// Размер всего приложения.
    /// </summary>
    static public Size sizeForm;

    /// <summary>
    /// Размер элемента с категориями.
    /// </summary>
    public static Size categoriesElementSize;

    /// <summary>
    /// Разрешение экрана в пикселях.
    /// </summary>
    static public Size screenSize = Screen.PrimaryScreen.Bounds.Size;

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
    public static string pathFiles = @".\Files";

    /// <summary>
    /// Путь к файлу с последними настройками.
    /// </summary>
    public static string pathBackup = pathFiles + "\\backup";

    /// <summary>
    /// Путь к текстовым файлам категорий.
    /// </summary>
    public static string categoriesPathFiles = @".\Files\Categories";

    /// <summary>
    /// Путь к картинкам.
    /// </summary>
    public static string pathImages = @".\Images";

    #endregion

    #region Ключи

    /// <summary>
    /// Разделительный "символ" между параметрами приложения. 
    /// </summary>
    public static string code = "$SPRTR$";

    /// <summary>
    /// Ключ для поиска активной категории при закрытии приложения.
    /// </summary>
    public static string keyCategory = "lastCategory";

    #endregion

    #region Работа с панелями категорий

    /// <summary>
    /// Список приложений актовной категории. 
    /// </summary>
    static public List<Panel> allApps= new List<Panel>();

    /// <summary>
    /// Активная панель с приложениями.
    /// </summary>
    static public Panel activeAppPanel;

    /// <summary>
    /// Последняя активная панель с приложениями.
    /// </summary>
    static public Panel lastAppPanel;

    #endregion

    #region Другое

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

  }

}
