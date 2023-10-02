using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Info
{
  public class InfoElement
  {
    public void WriteInfoElement(Control value, string nameElement)
    {
      Console.WriteLine($"Параметры {nameElement}:");
      ColorTwoParameters("Ширина", value.Size.Width.ToString(), ConsoleColor.Green, true);
      ColorTwoParameters("Высота", value.Size.Height.ToString(), ConsoleColor.Green, true);
      ColorTwoParameters("Цвет фона", value.BackColor.ToString(), ConsoleColor.Green, true);
      ColorTwoParameters("Позиция на форме", value.Location.ToString(), ConsoleColor.Green, true);
      if (value.Controls.Count > 0) ColorTwoParameters("Кол-во дочерних элементов", value.Controls.Count.ToString(), ConsoleColor.Green, true);
    }

    public void ColorTwoParameters(string part1, string part2, ConsoleColor colorText, bool tabulation)
    {
      char tabulationChar = '\0';
      if (tabulation) tabulationChar = '\t';
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write($"{tabulationChar} \"{part1}\":");
      Console.ForegroundColor = colorText;
      Console.WriteLine($"{part2}");
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
