﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.BackUp
{
  internal class LastSessionClass
  {
    /// <summary>
    /// Возвращает имя последней активной категории.
    /// </summary>
    public string GetCategory()
    {
      string activeCategory = string.Empty;
      if (File.Exists($@"{DataClass.pathBackup}\backUp"))
      {
        string[] backup = File.ReadAllLines($@"{DataClass.pathBackup}\backUp");
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
          // Может не найти нужные строчки. Ну не нашёл дык не нашёл)
          // Скорее всего это означает, что приложение запущенно впервые.
          // Или кто-то залез в эти файлы, или ещё чот-то... Крч не суть важно.
        }
      }
      else
      {
        File.Create($@"{DataClass.pathBackup}\backUp");
      }
      return activeCategory;
    }

    /// <summary>
    /// Устанавливает имя активной категории.
    /// </summary>
    public void SetCategory()
    {
      try
      {
        string name = String.Empty;
        bool search = true;
        if (DataClass.activeAppPanelLauncher != null) name = DataClass.activeAppPanelLauncher.Name;
        string query = "lastCategory" + DataClass.code + name + DataClass.code;
        string[] backup = File.ReadAllLines($@"{DataClass.pathBackup}\backUp");
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
        File.WriteAllLines($@"{DataClass.pathBackup}\backUp", backup);
      }
      catch
      {
        // Скорее всего, пользователь только зашёл в ПО и выщел, не добавив категорию
        // В общем, нет категорий в приложении
      }
    }
  }
}
