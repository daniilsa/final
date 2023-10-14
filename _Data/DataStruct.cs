namespace LauncherNet._Data
{

  /// <summary>
  /// Структуры приложения.
  /// </summary>
  public static class DataStruct
  {
    /// <summary>
    /// Заполнение локации элемента.
    /// </summary>
    public struct Location
    {
      private Point location = new Point();

      public Point LocationElement { get { return location; } set { location = value; } }

      public int X { get { return location.X; } }
      public int Y { get { return location.Y; } }

      public Location(int x, int y)
      {
        location = new Point(x, y);
      }
    }
  }
}
