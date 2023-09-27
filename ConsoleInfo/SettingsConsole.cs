using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.ConsoleClass
{
  static public class SettingsConsole
  {
    /// <summary>
    /// Получение экзампляра консоли.
    /// </summary>
    [DllImport("kernel32.dll", ExactSpelling = true)]
    static extern IntPtr GetConsoleWindow();

    /// <summary>
    /// Скрыть или отобразить консоль.
    /// </summary>
    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary>
    /// Установить локацию консоли.
    /// </summary>
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

    static private IntPtr MyConsole = GetConsoleWindow();

    /// <summary>
    /// Сколько бы я не искал, так и не понял за что отвечает, но без неё на работает(
    /// </summary>
    private const int SWP_NOSIZE = 1;

    /// <summary>
    /// Параметр скрытия консоли.
    /// </summary>
    private const int SW_HIDE = 0;

    /// <summary>
    /// Параметр отображения консоли.
    /// </summary>
    private const int SW_SHOW = 5;

    /// <summary>
    /// Отображает консоль на мониторе
    /// </summary>
    static public void ShowConsole()
    {
      ShowWindow(MyConsole, SW_SHOW);
    }

    /// <summary>
    /// Скрывает консоль на мониторе.
    /// </summary>
    static public void HideConsole()
    {
      ShowWindow(MyConsole, SW_HIDE);
    }

    /// <summary>
    /// Устанавливает локацию консоли на мониторе.
    /// </summary>
    static private void LocationConsole()
    {
      int xpos = -1920;
      int ypos = 0;
      SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
    }

    static SettingsConsole()
    {
      LocationConsole();
    }

  }
}
