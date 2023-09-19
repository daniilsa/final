using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.BackUp
{
  internal class BackUpClass
  {
    /// <summary>
    /// Возвращает имя последней активной категории.
    /// </summary>
    public string GetCategory()
    {
      string activeCategory = null;
      if (File.Exists(DataClass.pathBackup))
      {

        string[] backup = File.ReadAllLines(DataClass.pathBackup);
        try
        {
          int indexStr = 0;
          int indexFirst = 0;
          for (int i = 0; i < backup.Length; i++)
          {
            if (backup[i].IndexOf(DataClass.keyCategory) > -1)
            {
              indexStr = i;
              indexFirst = backup[i].IndexOf(DataClass.code) + DataClass.code.Length;
              break;
            }
          }
          Console.WriteLine(backup[indexStr].Substring(0, indexFirst));
          int indexLast = backup[indexStr].IndexOf(DataClass.code, indexFirst);
          Console.WriteLine(backup[indexStr].Substring(indexFirst, indexLast - indexFirst));
          activeCategory = backup[indexStr].Substring(indexFirst, indexLast - indexFirst);
        }
        catch
        {

        }
      }
      else
      {
        File.Create(DataClass.pathBackup);
      }
      return activeCategory;
    }

    /// <summary>
    /// Устанавливает имя активной категории.
    /// </summary>
    public void SetCategory()
    {
      string name = String.Empty;
      bool search = true;
      if (DataClass.activeAppPanel != null) name = DataClass.activeAppPanel.Name;
      string query = "lastCategory" + DataClass.code + name + DataClass.code;
      string[] backup = File.ReadAllLines(DataClass.pathBackup);
      for (int i = 0; i < backup.Length; i++)
      {
        if (backup[i].IndexOf(DataClass.keyCategory) > -1)
        {
          backup[i] = query;
          search = false;
          break;
        }
      }
      if (search)
      {
        Array.Resize(ref backup, backup.Length + 1);
        backup[backup.Length - 1] = query;
      }
      File.WriteAllLines(DataClass.pathBackup, backup);
    }
  }
}
