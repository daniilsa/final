using LauncherNet._Data;

namespace LauncherNet.Functions
{
  public class MovingForm
  {
    /// <summary>
    /// Перемещение.
    /// </summary>
    private bool drag = false;

    /// <summary>
    /// Стартовая позиция.
    /// </summary>
    private Point startPoint = new(0, 0);

    /// <summary>
    /// Сторона монитора, к которой "прилипает" форма.
    /// </summary>
    private DataEnum.Sticking stickingForm = DataEnum.Sticking.Nope;

    /// <summary>
    /// Размер формы до прилипания.
    /// </summary>
    private Size sizeStickingForm;

    /// <summary>
    /// Последняя позиция формы до "Прилипания".
    /// </summary>
    private static DataStruct.Location locationStickingForm;

    /// <summary>
    /// Проверка на "Прилипание" формы к краям экрана.
    /// </summary>
    public bool CheckSticking { get; set; }

    /// <summary>
    /// Проверки для перемещения элемента.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    /// <param name="e">Событие мыши.</param>
    public void CheckingToMoveAnElement(Form value, MouseEventArgs e)
    {
      drag = true;
      startPoint = new Point(e.X, e.Y);

      if (value?.WindowState == FormWindowState.Maximized)
      {
        value.WindowState = FormWindowState.Normal;
        value.Location = new Point(Cursor.Position.X - value.Width / 2, 0);
        startPoint = value.Location;
      }
      if ((stickingForm == DataEnum.Sticking.Top || stickingForm == DataEnum.Sticking.Bottom) && value != null)
      {
        value.Size = sizeStickingForm;
        value.Location = locationStickingForm.LocationElement;
        startPoint = value.Location;
        stickingForm = DataEnum.Sticking.Nope;
      }
      else if ((stickingForm == DataEnum.Sticking.Left || stickingForm == DataEnum.Sticking.Right) && value != null)
      {
        value.Size = sizeStickingForm;
        stickingForm = DataEnum.Sticking.Nope;
      }
    }

    /// <summary>
    /// Перемещение элемента.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    public void MovingAnElement(Form value)
    {
      if (drag && value != null)
      {
        value.Location = new Point(Cursor.Position.X - startPoint.X, Cursor.Position.Y - startPoint.Y);
      }
    }

    /// <summary>
    /// Проверяет "прилипание" элемента к границам экрана.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    public void CheckingForSticking(Form value)
    {
      drag = false;
      if (value != null && CheckSticking)
      {
        if (value.Location.Y < 0)
        {
          sizeStickingForm = value.Size;
          stickingForm = DataEnum.Sticking.Top;
          locationStickingForm.LocationElement = new Point(value.Location.X, 0);
          value.Location = new Point(0, 0);
          value.Width = DataClass.screenSize.Width;
          value.Height = DataClass.screenSize.Height / 2;

        }
        else if (value.Location.X < 0)
        {
          sizeStickingForm = value.Size;
          stickingForm = DataEnum.Sticking.Left;
          locationStickingForm.LocationElement = new Point(value.Location.X, 0);
          value.Location = new Point(0, 0);
          value.Width = DataClass.screenSize.Width / 2;
          value.Height = DataClass.screenSize.Height;
        }
        else if (value.Location.X + value.Width > DataClass.screenSize.Width)
        {
          sizeStickingForm = value.Size;
          stickingForm = DataEnum.Sticking.Right;
          locationStickingForm.LocationElement = new Point(value.Location.X, 0);
          value.Location = new Point(DataClass.screenSize.Width / 2, 0);
          value.Width = DataClass.screenSize.Width / 2;
          value.Height = DataClass.screenSize.Height;
        }
        else if (value.Location.Y + value.Height > DataClass.screenSize.Height)
        {
          sizeStickingForm = value.Size;
          stickingForm = DataEnum.Sticking.Bottom;
          locationStickingForm.LocationElement = new Point(value.Location.X, 0);
          value.Location = new Point(0, DataClass.screenSize.Height / 2);
          value.Width = DataClass.screenSize.Width;
          value.Height = DataClass.screenSize.Height / 2;
        }
      }
    }

  }
}
