using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet._Data
{
  /// <summary>
  /// Поля, свойства, методы формы настроек.
  /// </summary>
  static public class DataSettingsApplicationForm
  {
    /// <summary>
    /// Возвращает или задаёт экземпляр формы настроек.
    /// </summary>
    static public Form? Form { get; set; }

    /// <summary>
    /// Возвращает или задаёт экземпляр приветсвенного текста.
    /// </summary>
    static public Label? HelloText { get; set; }
      
  }
}
