using LauncherNet._Data;

namespace LauncherNet.BackUp
{
  internal class LastSessionClass
  {

    public bool GetLastRun()
    {
      try
      {
        if (File.Exists($@"{DataClass.PathBackup}\backUp"))
        {
          string[] backup = File.ReadAllLines($@"{DataClass.PathBackup}\backUp");
          for (int i = 0; i < backup.Length; i++)
            if (backup[i].Contains($@"firstStart{DataClass.Code}false"))
            {
              return false;
            }
          Array.Resize(ref backup, backup.Length + 1);
          backup[backup.Length - 1] = $"firstStart{DataClass.Code}false";
          File.WriteAllLines($@"{DataClass.PathBackup}\backUp", backup);
        }
        return true;
      }
      catch
      {
        GetLastRun();
      }
      return true;
    }

    /// <summary>
    /// Возвращает имя последней активной категории.
    /// </summary>
    public string GetCategory()
    {
      string activeCategory = string.Empty;
      if (File.Exists($@"{DataClass.PathBackup}\backUp"))
      {
        try
        {
          string[] backup = File.ReadAllLines($@"{DataClass.PathBackup}\backUp");

          int indexStr = 0;
          int indexFirst = 0;
          for (int i = 0; i < backup.Length; i++)
          {
            if (backup[i].IndexOf(DataClass.KeyCategory) > -1)
            {
              indexStr = i;
              indexFirst = backup[i].IndexOf(DataClass.Code) + DataClass.Code.Length;
              break;
            }
          }
          Console.WriteLine(backup[indexStr].Substring(0, indexFirst));
          int indexLast = backup[indexStr].IndexOf(DataClass.Code, indexFirst);
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
        File.Create($@"{DataClass.PathBackup}\backUp");
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
        if (DataLauncherForm.activeAppPanelLauncher != null) name = DataLauncherForm.activeAppPanelLauncher.Name;
        string query = "lastCategory" + DataClass.Code + name + DataClass.Code;
        string[] backup = File.ReadAllLines($@"{DataClass.PathBackup}\backUp");
        for (int i = 0; i < backup.Length; i++)
        {
          if (backup[i].IndexOf(DataClass.KeyCategory) > -1)
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
        File.WriteAllLines($@"{DataClass.PathBackup}\backUp", backup);
      }
      catch
      {
        // Скорее всего, пользователь только зашёл в ПО и выщел, не добавив категорию
        // В общем, нет категорий в приложении
      }
    }
  }
}
