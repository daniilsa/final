using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet._Data
{
  /// <summary>
  /// Поля, свойства, методы формы загрузки.
  /// </summary>
  static public  class DataLoadForm
  {
    /// <summary>
    /// Возвращает или задаёт экземпляр формы загрузки.
    /// </summary>
    static public Form? Form { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр левой границы.
    /// </summary>
    static public PictureBox? LeftBorder { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр текст запуска программы.
    /// </summary>
    static public Label? StartProgrammText  { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр текс информации о запуске программы.
    /// </summary>
    static public Label? InfoProgressText { get; set; }


    /// <summary>
    /// Возвращает или задаёт экземпляр прогресс бара.
    /// </summary>
    static public Panel? ProgressBar { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр каретки прогресс бара.
    /// </summary>
    static public Panel? CarretBar { get; set; }



  }
}
