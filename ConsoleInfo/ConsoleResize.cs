using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.ConsoleInfo
{
  public class ConsoleResize
  {
    public void LeftResize(int differenceWidth, Point startPoint)
    {
      Console.Write($@"Позиция курсора по оси X: ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(Cursor.Position.X);
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write($@"Позиция формы по оси X: ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(DataClass.launcher.Location.X);
      Console.ForegroundColor = ConsoleColor.White;

      if (differenceWidth < 0)
        Console.Write($@"Форма увеличина на : ");
      else 
        Console.Write($@"Форма уменьшина на : ");

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(Math.Abs(differenceWidth));
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
    }
  }
}
