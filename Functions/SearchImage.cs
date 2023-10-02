using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherNet.Functions
{
  public class SearchImage
  {
    /// <summary>
    /// Поиск картинок в интернете.
    /// </summary>
    /// <param name="nameFile">Имя файла</param>
    public List<string> ImageSearch(string nameFile)
    {
      WebBrowser webBrowser = new WebBrowser();
      webBrowser.Dock = DockStyle.Left;
      webBrowser.Width = 500;
      using (Form form = new Form())
      {
        try
        {
          //Текст запроса
          string requestStart = "https://www.google.ru/search?q=" + nameFile
            + "+&newwindow=1&sxsrf=AJOqlzWdMdNNhjb3bV8rxo6WQTq4Xg_CJw:1677077214554&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjQoYm9r6n9AhWXHXcKHYTUAFEQ_AUoAXoECAEQAw&biw=1920&bih=901r";
          
          // Отправляем запрос
          webBrowser.Navigate(requestStart);

          // Крадём исходный файл HTML
          WebRequest req = WebRequest.Create(requestStart);
          string source = string.Empty;
          using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
          {
            source = reader.ReadToEnd();
          }

          // Находим нужную часть кода и вытаскиваем URL картинки
          string searchStr = "alt=\"\" src=\"";
          string lastStr = "\"/>";

          int indexFirst = 0;
          int indexLast = 0;

          List<string> imageResources = new List<string>();

          for (int i = 0; i < DataClass.countImageSearch; i++)
          {
            indexFirst = source.IndexOf(searchStr, indexFirst);
            indexLast = source.IndexOf(lastStr, indexFirst);

            indexFirst += searchStr.Length;
            int lengthStr = indexLast - indexFirst;

            string goodUrl = source.Substring(indexFirst, lengthStr);
            imageResources.Add(goodUrl);
          }

          return imageResources;
        }

        catch
        {
          MessageBox.Show("Невозможно найти изображение. Возможно отсутсвует подключение к интернету!");
        }

        return null;
      }

    }

  }
}
