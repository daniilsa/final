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
      if (!Directory.Exists(DataClass.pathFiles)) Directory.CreateDirectory(DataClass.pathFiles);
      if (!Directory.Exists(DataClass.categoriesPathFiles)) Directory.CreateDirectory(DataClass.categoriesPathFiles);
      if (!Directory.Exists(DataClass.pathImages)) Directory.CreateDirectory(DataClass.pathImages);
      if (!File.Exists(DataClass.pathFiles + "\\backup")) File.Create(DataClass.pathFiles + "\\backup");
      if (!File.Exists(@$"{DataClass.pathImages}\Default.jpg")) 
        MessageBox.Show("0_0 Не найден системный файл ПО. Все обложки без картинки будут красного цвета!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
