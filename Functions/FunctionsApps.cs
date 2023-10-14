using LauncherNet._Data;
using LauncherNet._Front;
using LauncherNet.Controls;
using LauncherNet.Forms;
using System.Net;
using static System.Windows.Forms.Control;

namespace LauncherNet.Functions
{
  internal class FunctionsApps
  {

    public void StartFunction(DataEnum.FunctionApp functionApp, string? nameCategory, string? nameFile, string? pathFile, string? pathApp)
    {
      if (functionApp == DataEnum.FunctionApp.Open && pathFile != null && pathApp != null)
      {
        StartApp(pathFile, pathApp);
      }
      else if (functionApp == DataEnum.FunctionApp.PathFile && nameCategory != null && nameFile != null && pathApp != null)
      {
        LocationApp(pathApp, nameCategory, nameFile);
      }
      else if (functionApp == DataEnum.FunctionApp.ChangeImage && nameCategory != null && nameFile != null)
      {
        FormImage(nameCategory, nameFile);
      }
      else if (functionApp == DataEnum.FunctionApp.Delete && nameCategory != null && nameFile != null)
      {
        DeleteApp(nameCategory, nameFile, true);
      }

      new DesignLauncherForm().LoadDesignLauncher();
    }

    /// <summary>
    /// Запуск программы.
    /// </summary>
    /// <param name="pathFile">Путь к файлу категории</param>
    /// <param name="pathApp">Путь к запускаемому файлу</param>
    private void StartApp(string pathFile, string pathApp)
    {
      try
      {
        System.Diagnostics.Process.Start(pathApp);
      }
      catch
      {
        DialogResult result = MessageBox.Show("По данному пути приложение не обнаружено!.Хотите удалить приложение из списка ? ", "Внимание!",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1,
                                              MessageBoxOptions.DefaultDesktopOnly);
        if (result == DialogResult.Yes)
        {
          string[] temporaryString = System.IO.File.ReadAllLines(pathFile);
          List<string> newfileLine = new();

          for (int i = 0; i < temporaryString.Length; i++)
          {
            if (temporaryString[i].Contains(pathApp)) continue;
            else newfileLine.Add(temporaryString[i]);
          }
          string[] newFile = newfileLine.ToArray();
          System.IO.File.WriteAllLines(pathFile, newFile);
          MessageBox.Show("Приложение успешно удалено!");
        }
      }
    }

    /// <summary>
    /// Открыть расположение файла.
    /// </summary>
    /// <param name="pathApp">Путь к файлу.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="nameCategory">Имя категории.</param>
    private void LocationApp(string pathApp, string nameCategory, string nameFile)
    {
        string argument = "";
      int lastIndex = pathApp.LastIndexOf("\\");
      for (int index = 0; index < lastIndex; index++)
        argument += pathApp[index];
      if (pathApp.Contains("steam"))
      {
        MessageBox.Show($"Путь данного файла: {pathApp}. Откройте путь к приложению через Steam.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (Directory.Exists(argument)) System.Diagnostics.Process.Start("explorer.exe", argument);
        else
        {
          if (MessageBox.Show($"Внимание! Приложение удалено или перенесено. Хотите удалить приложение {nameFile} из лаунчера?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
          {
            DeleteApp(nameCategory, nameFile, true);
          }
        }
      }
    }

    /// <summary>
    /// Запускает форму смены картинки.
    /// </summary>
    /// <param name="nameCategory"></param>
    /// <param name="nameFile"></param>
    /// <param name="pathImage"></param>
    private void FormImage(string nameCategory, string nameFile)
    {
      FunctionalForm functionalForm = new();
      functionalForm.AppForm(DataEnum.FunctionApp.ChangeImage, nameCategory, nameFile);
    }

    /// <summary>
    /// Смена картинок приложения.
    /// </summary>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя приложения.</param>
    /// <param name="pathImageNew"></param>
    public void ChangeImage(string nameCategory, string nameFile, string pathImageNew)
    {
      string pathImageOld = DataClass.PathImages + "\\" + nameCategory + "\\" + nameFile + ".jpg";
      if (File.Exists(pathImageNew))
      {
        FileInfo fileInfo = new(pathImageOld);
        fileInfo.Delete();
        File.Move(pathImageNew, pathImageOld);
        ChangeImageApp(nameCategory, nameFile);
      }
      else
      {
        MessageBox.Show($"Новая картинка не найдена!");
      }
    }

    /// <summary>
    /// Удаление приложения из лаунчера
    /// </summary>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="question">Задавать ли вопрос о удалении файла.</param>
    private void DeleteApp(string nameCategory, string nameFile, bool question)
    {
      if (!question)
      {
        string nameFiliDelete = nameFile;
        string pathFildeDelete = DataClass.CategoriesPathFiles + "\\" + nameCategory;
        string[] readText = File.ReadAllLines(pathFildeDelete);
        string[] newText = new string[readText.Length - 1];
        int j = 0;
        for (int index = 0; index < readText.Length; index++)
          if (readText[index].LastIndexOf(nameFiliDelete) == -1) { newText[j] = readText[index]; j++; }
        File.WriteAllLines(pathFildeDelete, newText);
        DeleteAppForForm(nameCategory, nameFile);
        //new SettingsForms().UpdateLauncher(launcher);

      }
      else if (MessageBox.Show($"Удалить {nameFile} из категории {nameCategory}?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
      {
        string nameFiliDelete = nameFile;
        string pathFildeDelete = DataClass.CategoriesPathFiles + "\\" + nameCategory;
        string[] readText = File.ReadAllLines(pathFildeDelete);
        string[] newText = new string[readText.Length - 1];
        int j = 0;
        for (int index = 0; index < readText.Length; index++)
          if (readText[index].LastIndexOf(nameFiliDelete) == -1) { newText[j] = readText[index]; j++; }
        File.WriteAllLines(pathFildeDelete, newText);
        DeleteAppForForm(nameCategory, nameFile);
        //new SettingsForms().UpdateLauncher(launcher);
      }
    }

    /// <summary>
    /// Сохранение картинки из интернета.
    /// </summary>
    /// <param name="nameCategory"></param>
    /// <param name="nameFile"></param>
    public void SaveImageFromInternet(string nameCategory, string nameFile)
    {
      if (Directory.Exists($@"{DataClass.PathImages}\{nameCategory}") && DataLauncherForm.locationImage != null)
      {
        try
        {
          using WebClient client = new();
          client.DownloadFile(new Uri(DataLauncherForm.locationImage), $@"{DataClass.PathImages}\{nameCategory}\{nameFile}.jpg");
        }
        catch
        {
          MessageBox.Show("Ошибка при скачивании обложки. Пожалуйста, попробуйте загрузить обложку самостоятельно!");
        }
      }
      else if (DataLauncherForm.locationImage != null)
      {
        Directory.CreateDirectory($@"{DataClass.PathImages}\{nameCategory}");
        try
        {
          using WebClient client = new();
          client.DownloadFile(new Uri(DataLauncherForm.locationImage), $@"{DataClass.PathImages}\{nameCategory}\{nameFile}.jpg");
        }
        catch
        {
          MessageBox.Show("Ошибка при скачивании обложки. Пожалуйста, попробуйте загрузить обложку самостоятельно!");
        }
      }
    }

    /// <summary>
    /// Удаление приложения из приложения.
    /// </summary>
    /// <param name="nameCategory"></param>
    /// <param name="nameFile"></param>
    private void DeleteAppForForm(string nameCategory, string nameFile)
    {
      foreach (ScrollBarControl item in DataLauncherForm.mainAppsLauncher)
      {
        if (item.Name == nameCategory)
        {
          item.DeleteControl(nameFile);
        }
      }
    }

    private void ChangeImageApp(string nameCategory, string nameFile)
    {
      ControlCollection? mainCollection = null;
      foreach (ScrollBarControl item in DataLauncherForm.mainAppsLauncher)
      {
        if (item.Name == nameCategory)
        {
          mainCollection = item.GetControls();
        }
      }

      if (mainCollection != null)
      {
        foreach (Control item in mainCollection)
        {
          if (item.Name == nameFile)
          {
            new DesignLauncherForm().DesignAppElementLauncher((Panel)item);
          }
        }
      }


    }
  }
}
