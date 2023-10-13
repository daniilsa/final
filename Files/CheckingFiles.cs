﻿using LauncherNet._Data;
using System.Drawing.Drawing2D;
using System.Resources;

namespace LauncherNet.Files
{
  public class CheckingFiles
  {
    /// <summary>
    /// Проверка наличия ресурсов файлов ПО.
    /// </summary>
    public void CheckingResources()
    {
      CheckDirectory();
      CheckFile();
    }

    /// <summary>
    /// Проверка наличия директорий.
    /// </summary>
    private void CheckDirectory()
    {
      if (!Directory.Exists(DataClass.PathBackup))
        CreateDirectory(DataClass.PathBackup);

      if (!Directory.Exists(DataClass.PathFiles))
        CreateDirectory(DataClass.PathFiles);

      if (!Directory.Exists(DataClass.CategoriesPathFiles))
        CreateDirectory(DataClass.CategoriesPathFiles);

      if (!Directory.Exists(DataClass.PathImages))
        CreateDirectory(DataClass.PathImages);

    }

    /// <summary>
    /// Проверка наличия файлов.
    /// </summary>
    private void CheckFile()
    {
      if (!File.Exists(@$"{DataClass.PathBackup}\backUp"))
      {
        CreateFile(@$"{DataClass.PathBackup}\backUp");
      }

      if (!File.Exists(@$"{DataClass.PathBackup}\SettingsColor"))
        CreateFile(@$"{DataClass.PathBackup}\SettingsColor");

      if (!File.Exists($@"{DataClass.PathImages}\Default.jpg"))
      {
        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        int index = path.IndexOf("\\bin");
        path = path.Substring(0, index);
        if (File.Exists($@"{path}\Resources\Default.jpg"))
        {
          CopyFile($@"{path}\Resources\Default.jpg", $@"{DataClass.PathImages}\Default.jpg");
        }
      }

      if (!File.Exists(@$"{DataClass.PathFiles}\IconLauncher.ico"))
      {
        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        int index = path.IndexOf("\\bin");
        path = path.Substring(0, index);
        if (File.Exists($@"{path}\Resources\IconLauncher.ico"))
        {
          CopyFile($@"{path}\Resources\IconLauncher.ico", @$"{DataClass.PathFiles}\IconLauncher.ico");
          DataClass.TrayActive = true;
          if (DataLauncherForm.launcher != null)
            DataLauncherForm.launcher.Icon = new Icon(@$"{DataClass.PathFiles}\IconLauncher.ico");
        }
        else
        {
          DataClass.TrayActive = false;
        }
      }
      else
      {
        if (DataLauncherForm.launcher != null)
          DataLauncherForm.launcher.Icon = new Icon(@$"{DataClass.PathFiles}\IconLauncher.ico");
        DataClass.TrayActive = true;
      }
    }

    /// <summary>
    /// Создаёт категорию по указанному пути.
    /// </summary>
    /// <param name="path"></param>
    private void CreateDirectory(string path)
    {
      Directory.CreateDirectory(path);
    }

    /// <summary>
    /// Создаёт файлы по указаному пути. 
    /// </summary>
    /// <param name="path"></param>
    private void CreateFile(string path)
    {
      using (FileStream fs = File.Create(path))
      { 
       fs.Close();
      }
    }

    /// <summary>
    /// Копирует файлы из одного пути в другой.
    /// </summary>
    /// <param name="pathResoursec">Путь от куда.</param>
    /// <param name="pathFinal">Путь куда.</param>
    private void CopyFile(string pathResoursec, string pathFinal)
    {
      File.Copy(pathResoursec, pathFinal);
    }


  }
}
