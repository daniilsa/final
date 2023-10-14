using LauncherNet._Data;
using LauncherNet.DesignFront;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LauncherNet._Data.DataEnum;

namespace LauncherNet.Files
{
  /// <summary>
  /// Работа с файлами.
  /// </summary>
  public class WorkingColor
  {
    /// <summary>
    /// Возваращает или устанавливает первый основной цвет. 
    /// </summary>
    static public Color FirstMainColor
    {
      get
      {
        return GetColor(DataClass.DefaultFirstMainColor, DataEnum.ColorLauncher.FirstMainColor);
      }
      set
      {
        SetColor(value, DataEnum.ColorLauncher.FirstMainColor);
      }
    }

    /// <summary>
    /// Возваращает или устанавливает первый дополнительный цвет. 
    /// </summary>
    static public Color FirstAdditionalColor
    {
      get
      {
        return GetColor(DataClass._DefaultFirstAdditionalColor, DataEnum.ColorLauncher.FirstAdditionColor);

      }
      set
      {
        SetColor(value, DataEnum.ColorLauncher.FirstAdditionColor);
      }
    }

    /// <summary>
    /// Возваращает или устанавливает второй основной цвет. 
    /// </summary>
    static public Color SecondMainColor
    {
      get
      {
        return GetColor(DataClass._DefaultSecondMainColor, DataEnum.ColorLauncher.SecondMainColor);
      }
      set
      {
        SetColor(value, DataEnum.ColorLauncher.SecondMainColor);
      }
    }

    /// <summary>
    /// Возваращает или устанавливает второй дополнительный цвет. 
    /// </summary>
    static public Color SecondAdditionalColor
    {
      get
      {
        return GetColor(DataClass._DefaultSecondAdditionalMainColor, DataEnum.ColorLauncher.SecondAdditionColor);
      }
      set
      {
        SetColor(value, DataEnum.ColorLauncher.SecondAdditionColor);
      }
    }

    /// <summary>
    /// Устанавливает цвет определенной "Должности".
    /// </summary>
    /// <param name="color"></param>
    /// <param name="colorLauncher"></param>
    static private void SetColor(Color color, DataEnum.ColorLauncher colorLauncher)
    {
      bool next = true;
      string[] temporary = File.ReadAllLines($@"{DataClass.PathBackup}\SettingsColor");
      for (int i = 0; i < temporary.Length; i++)
      {
        if (temporary[i].Contains(colorLauncher.ToString()))
        {
          temporary[i] = colorLauncher.ToString() + DataClass.Code + color.R.ToString() + ";" + color.G.ToString() + ";" + color.B.ToString() + ";" + DataClass.Code;
          next = false;
        }
      }
      if (next)
      {
        string result = colorLauncher.ToString() + DataClass.Code + color.R.ToString() + ";" + color.G.ToString() + ";" + color.B.ToString() + ";" + DataClass.Code;
        Array.Resize(ref temporary, temporary.Count() + 1);
        temporary[temporary.Count() - 1] = result;
      }
      File.WriteAllLines($@"{DataClass.PathBackup}\SettingsColor", temporary);
    }

    /// <summary>
    /// Возвращает цвет определенной "Должности".
    /// </summary>
    static private Color GetColor(Color defaultColor, DataEnum.ColorLauncher colorLauncher)
    {
      Color color = new Color();
      if (File.ReadAllLines($@"{DataClass.PathBackup}\SettingsColor").Length > 0)
      {
        if (!new WorkingColor().PullingColorFromFile($@"{DataClass.PathBackup}\SettingsColor", ref color, colorLauncher))
        {
          SetColor(defaultColor, colorLauncher);
          color = GetColor(defaultColor, colorLauncher);
          return color;
        }
      }
      else
      {
        SetColor(defaultColor, colorLauncher);
        color = GetColor(defaultColor, colorLauncher);
        return color;
      }
      return color;
    }

    /// <summary>
    /// Вытаскивает цвет из файла.
    /// </summary>
    /// <param name="pathFile">Путь к файлу.</param>
    /// <param name="color">Экземпляр цвета.</param>
    /// <returns>Успех выполнения.</returns>
    private bool PullingColorFromFile(string pathFile, ref Color color, DataEnum.ColorLauncher colorLauncher)
    {
      bool exit = false;
      string[] temporary = File.ReadAllLines($@"{DataClass.PathBackup}\SettingsColor");
      foreach (string item in temporary)
      {
        if (item.Contains(colorLauncher.ToString()))
        {
          try
          {
            int indexFirst = item.IndexOf(DataClass.Code) + DataClass.Code.Length;
            int indexLast = item.LastIndexOf(DataClass.Code);
            int lenght = indexLast - indexFirst;
            string result = item.Substring(indexFirst, lenght);

            indexFirst = 0;
            indexLast = result.IndexOf(";", indexFirst);
            int colorR = Convert.ToInt32(result.Substring(indexFirst, indexLast - indexFirst));

            indexFirst = indexLast + 1;
            indexLast = result.IndexOf(";", indexFirst);
            int colorG = Convert.ToInt32(result.Substring(indexFirst, indexLast - indexFirst));

            indexFirst = indexLast + 1;
            indexLast = result.IndexOf(";", indexFirst);
            int colorB = Convert.ToInt32(result.Substring(indexFirst, indexLast - indexFirst));

            color = Color.FromArgb(colorR, colorG, colorB);

            exit = true;
          }
          catch
          {
            exit = true;
          }

        }

      }
      return exit;
    }

    /// <summary>
    /// Перезаписывает цвет в переменных.
    /// </summary>
    static public void RewritingColor()
    {
      BackColorElements.MainDarkColor = WorkingColor.FirstMainColor;
      BackColorElements.AdditionalDarkColor = WorkingColor.FirstAdditionalColor;

      BackColorElements.MainLightColor = WorkingColor.SecondMainColor;
      BackColorElements.AdditionalLight = WorkingColor.SecondAdditionalColor;

    }

  }
}
