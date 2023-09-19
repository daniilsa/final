using LauncherNet.Forms;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Functions
{
  internal class FunctionsApps
  {

    /// <summary>
    /// Запуск программы.
    /// </summary>
    /// <param name="pathFile">Путь к файлу категории</param>
    /// <param name="pathApp">Путь к запускаемому файлу</param>
    public void StartApp(string pathFile, string pathApp)
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
          List<string> newfileLine = new List<string>();

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
    /// <param name="launcher">Экземпляр формы.</param>
    /// <param name="pathApp">Путь к файлу.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="nameCategory">Имя категории.</param>
    public void LocationApp(Form launcher, string pathApp, string nameCategory, string nameFile)
    {
      //TODO: Если путь не существует, то предложить удалить файл из лаунчера
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
            DeleteApp(launcher, nameCategory, nameFile, true);
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
    public void FormImage(string nameCategory, string nameFile, string pathImage)
    {
      FunctionalForm functionalForm = new FunctionalForm();
      functionalForm.AppForm(DataClass.FunctionApp.ChangeImage, nameCategory, nameFile, pathImage);
    }

    /// <summary>
    /// Смена картинок приложения.
    /// </summary>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя приложения.</param>
    /// <param name="pathImageNew"></param>
    public void ChangeImage(string nameCategory, string nameFile, string pathImageNew)
    {
      string pathImageOld = DataClass.pathImages+"\\"+nameCategory+"\\"+nameFile+".jpg";
      if (File.Exists(pathImageNew))
      {
        FileInfo fileInfo = new FileInfo(pathImageOld);
        fileInfo.Delete();
        File.Move(pathImageNew, pathImageOld);
      }
      else
      { 
        MessageBox.Show($"Новая картинка не найдена!");
      }
    }

    /// <summary>
    /// Удаление приложения из лаунчера
    /// </summary>
    /// <param name="launcher">Экземпляр формы.</param>
    /// <param name="nameFile">Имя файла.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="question">Задавать ли вопрос о удалении файла.</param>
    public void DeleteApp(Form launcher, string nameCategory, string nameFile, bool question)
    {
      if (question)
      {
        string nameFiliDelete = nameFile;
        string pathFildeDelete = DataClass.categoriesPathFiles + "\\" + nameCategory;
        string[] readText = File.ReadAllLines(pathFildeDelete);
        string[] newText = new string[readText.Count() - 1];
        int j = 0;
        for (int index = 0; index < readText.Count(); index++)
          if (readText[index].LastIndexOf(nameFiliDelete) == -1) { newText[j] = readText[index]; j++; }
        File.WriteAllLines(pathFildeDelete, newText);
        new SettingsForms().UpdateLauncher(launcher);

      }
      else if (MessageBox.Show($"Удалить {nameFile} из категории {nameCategory}?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
      {
        string nameFiliDelete = nameFile;
        string pathFildeDelete = DataClass.categoriesPathFiles + "\\" + nameCategory;
        string[] readText = File.ReadAllLines(pathFildeDelete);
        string[] newText = new string[readText.Count() - 1];
        int j = 0;
        for (int index = 0; index < readText.Count(); index++)
          if (readText[index].LastIndexOf(nameFiliDelete) == -1) { newText[j] = readText[index]; j++; }
        File.WriteAllLines(pathFildeDelete, newText);
        new SettingsForms().UpdateLauncher(launcher);
      }
    }

    /// <summary>
    /// Сохранение картинки из интернета.
    /// </summary>
    /// <param name="nameCategory"></param>
    /// <param name="nameFile"></param>
    public void SaveImagefromInternet(string nameCategory, string nameFile)
    {
      if (Directory.Exists($@"{DataClass.pathImages}\{nameCategory}"))
      {
        using (WebClient client = new WebClient()) client.DownloadFile(new Uri(DataClass.locationImage), $@"{DataClass.pathImages}\{nameCategory}\{nameFile}.jpg");
      }
      else
      {
        Directory.CreateDirectory($@"{DataClass.pathImages}\{nameCategory}");
        using (WebClient client = new WebClient()) client.DownloadFile(new Uri(DataClass.locationImage), $@"{DataClass.pathImages}\{nameCategory}\{nameFile}.jpg");
      }
    }
  }
}
