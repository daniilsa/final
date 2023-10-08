namespace LauncherNet.Settings
{
  public class CheckingFiles
  {

    static public string[]? FilesCategories { get; set; }
    static List<string[]> filesApps = new List<string[]>();

    /// <summary>
    /// Проверка ресурсов файлов ПО.
    /// </summary>
    public void CheckingResources()
    {
      if (!Directory.Exists(DataClass.PathBackup)) Directory.CreateDirectory(DataClass.PathBackup);
      if (!Directory.Exists(DataClass.PathFiles)) Directory.CreateDirectory(DataClass.PathFiles);
      if (!Directory.Exists(DataClass.CategoriesPathFiles)) Directory.CreateDirectory(DataClass.CategoriesPathFiles);
      if (!Directory.Exists(DataClass.PathImages)) Directory.CreateDirectory(DataClass.PathImages);
      if (!Directory.Exists(DataClass.PathFont)) Directory.CreateDirectory(DataClass.PathFont);

      if (!File.Exists(@$"{DataClass.PathFiles}\IconLauncher.ico")) DataClass.TrayActive = false;
      if (!File.Exists(@$"{DataClass.PathBackup}\backUp")) File.Create(@$"{DataClass.PathBackup}\backUp");

      FilesCategories = Directory.GetFiles($@"{DataClass.PathFiles}\Categories");
      for (int i = 0; i < FilesCategories.Length; i++)
      {
        filesApps.Add(File.ReadAllLines($@"{FilesCategories[i]}"));
      }
    }

    /// <summary>
    /// Проверка изменений файлов.
    /// </summary>
    public bool CheckingChangesFiles()
    {
      bool apps = CheckingApps();
      return true;
    }

    /// <summary>
    /// Перезапись имен категорий.
    /// </summary>
    public void OverwritingCategoriesName()
    {
      string[] temporaryCategories = Directory.GetFiles($@"{DataClass.PathFiles}\Categories");
      FilesCategories = temporaryCategories;
    }

    /// <summary>
    /// Проверка изменений кол-ва категорий.
    /// </summary>
    private bool CheckingApps()
    {
      return false;
    }

  }
}
