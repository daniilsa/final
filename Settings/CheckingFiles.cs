using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Settings
{
  public class CheckingFiles
  {
    /// <summary>
    /// Проверка ресурсов файлов ПО.
    /// </summary>
    public void CheckingResources()
    {
      if (!Directory.Exists(DataClass.pathBackup)) Directory.CreateDirectory(DataClass.pathBackup);
      if (!Directory.Exists(DataClass.pathFiles)) Directory.CreateDirectory(DataClass.pathFiles);
      if (!Directory.Exists(DataClass.categoriesPathFiles)) Directory.CreateDirectory(DataClass.categoriesPathFiles);
      if (!Directory.Exists(DataClass.pathImages)) Directory.CreateDirectory(DataClass.pathImages);
      if (!Directory.Exists(DataClass.pathFont)) Directory.CreateDirectory(DataClass.pathFont);
      if (!File.Exists(@$"{DataClass.pathFiles}\IconLauncher.ico")) DataClass.trayActive = false;
    }
  }
}
