using LauncherNet.Info;

namespace LauncherNet.Controls
{
  public class ScrollBarElement : Control
  {

    #region Поля

    /// <summary>
    /// Высота одного элемента.
    /// </summary>
    private int heightElement = 0;

    /// <summary>
    /// Кол-во линий с элементами.
    /// </summary>
    private int countLines = 1;

    /// <summary>
    /// Экземпляр панели, в которую добавляются элементы из вне.
    /// </summary>
    private readonly Panel mainPanel;

    /// <summary>
    /// Плавность хода.
    /// </summary>
    private readonly int smoothing = 2;

    #endregion

    #region Свойства

    #region Public
    /// <summary>
    /// Возвращает или задаёт цвет заднего фона элемента скролла.
    /// </summary>
    public Color BackColorScroll { get; set; }

    /// <summary>
    /// Возвращает или задаёт цвет фона каретки скролла.
    /// </summary>
    public Color BackColorCaret { get; set; }

    /// <summary>
    /// Возвращает или задаёт ширину скролла.
    /// </summary>
    public int WidthScroll { get; set; }

    /// <summary>
    /// Возвращает или задаёт свойство "свежеоткрытой" панели. Свойство нужно для расчёта локации элемента при его открытии.
    /// </summary>
    public bool Open { get; set; }

    /// <summary>
    /// Возвращает или задаёт отступы между элментами по оси X.
    /// </summary>
    public int X_AxisIndentation { get; set; }

    /// <summary>
    /// Возвращает или задаёт отступы между элментами по оси Y.
    /// </summary>
    public int Y_AxisIndentation { get; set; }
    #endregion

    #region Private
    /// <summary>
    /// Возвращает или задаёт позицию картеки по оси Y.
    /// </summary>
    private int CaretLocationY { get; set; }

    /// <summary>
    /// Возвращает или задаёт высоту каретки
    /// </summary>
    private int CaretHeight { get; set; }

    /// <summary>
    /// Возвращает или задаёт дистанцию, на которое движется каретка при прокрутке элемента.
    /// </summary>
    private int DistanceCaret { get; set; }

    #endregion

    #endregion

    #region Методы

    /// <summary>
    /// Отрисовка элемента.
    /// </summary>
    /// <param name="e">Данные для обработки события рисования на элементе.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      mainPanel.Width = Width - WidthScroll;

      if (mainPanel.Location.Y == 40) mainPanel.Location = new Point(0, 0);
      if (Open)
      {
        mainPanel.Location = new Point(0, 0);
        Open = false;
      }
      else mainPanel.Location = new Point(0, mainPanel.Location.Y);
      LocationApps();

      Rectangle rectangleAll = new(0, 0, Width, Height);

      Graphics graphics = e.Graphics;
      graphics.FillRectangle(new SolidBrush(BackColor), rectangleAll);

      if (mainPanel.Height > Height)
      {
        CarriageHeightAndStepCalculation();

        Rectangle rectangleBackScroll = new(Width - WidthScroll, 0, WidthScroll, Height);
        graphics.FillRectangle(new SolidBrush(BackColorScroll), rectangleBackScroll);

        Rectangle rectangleCaret = new(Width - WidthScroll, CaretLocationY, WidthScroll, CaretHeight);
        graphics.FillRectangle(new SolidBrush(BackColorCaret), rectangleCaret);
      }
    }

    /// <summary>
    /// Прокрутка колесика мыши.
    /// </summary>
    /// <param name="e">Данные для обработки события прокрутки колесика мыши на элементе.</param>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);

      if (mainPanel.Height > Height)
      {
        if (e.Delta < 0)
        {
          if (CaretLocationY + CaretHeight + (DistanceCaret / smoothing) <= Height)
          {
            CaretLocationY = Convert.ToInt32(CaretLocationY + (DistanceCaret / smoothing));
            mainPanel.Location = new Point(0, mainPanel.Location.Y - ((heightElement + Y_AxisIndentation) / smoothing));
          }
          else
          {
            CaretLocationY = Height - CaretHeight;
            mainPanel.Location = new Point(0, -(mainPanel.Height - Height) - Y_AxisIndentation * 3);
          }
        }
        else if (e.Delta > 0)
        {
          if (CaretLocationY - (DistanceCaret / smoothing) >= 0)
          {
            CaretLocationY = Convert.ToInt32(CaretLocationY - (DistanceCaret / smoothing));
            mainPanel.Location = new Point(0, mainPanel.Location.Y + ((heightElement + Y_AxisIndentation) / smoothing));
          }
          else
          {
            CaretLocationY = 0;
            mainPanel.Location = new Point(0, 0);
          }
        }
        Invalidate();
      }
    }

    /// <summary>
    /// Расчёт высоты и "дистанции" картеки
    /// </summary>
    private void CarriageHeightAndStepCalculation()
    {
      double onePercent = GetValueOnePercent();
      new InfoElement().ColorTwoParameters("Один процент от высоты панели с элементами(пиксели) = ", onePercent.ToString(), ConsoleColor.Green, false);

      double visiblePartAsPercentage = GetPercentageOfForm();
      new InfoElement().ColorTwoParameters("Видимая часть элементов(%) = ", visiblePartAsPercentage.ToString(), ConsoleColor.Green, false);

      CaretHeight = GetСarriageHeight(onePercent, visiblePartAsPercentage);
      new InfoElement().ColorTwoParameters("Высота каретки(пиксели) = ", CaretHeight.ToString(), ConsoleColor.Green, false);

      int distentionRestScroll = GetEmptyScrollLength();
      new InfoElement().ColorTwoParameters("\"Пустая\" часть скролла(пиксели) = ", distentionRestScroll.ToString(), ConsoleColor.Green, false);

      double numberInvisibleLines = GetPercentageInvisibleLines();
      new InfoElement().ColorTwoParameters("Линии, не отображемые на элементе(кол-во) = ", numberInvisibleLines.ToString(), ConsoleColor.Green, false);

      DistanceCaret = GetCarriagePitch(numberInvisibleLines, distentionRestScroll);
      new InfoElement().ColorTwoParameters("Шаг каретки(пиксели) = ", DistanceCaret.ToString(), ConsoleColor.Green, false);
    }

    /// <summary>
    /// Возвращает один процент от высоты формы в пикселях.
    /// </summary>
    /// <returns></returns>
    private Double GetValueOnePercent()
    {
      return Convert.ToDouble(Height) / 100;
    }

    /// <summary>
    /// Возвращает видимую часть элементов на формк в процентах.
    /// </summary>
    /// <returns></returns>
    private Double GetPercentageOfForm()
    {
      return Convert.ToDouble(Height) * 100 / mainPanel.Height;
    }

    /// <summary>
    /// Возвращает высоту каретки в пикселях.
    /// </summary>
    /// <param name="onePercent">Один процент высоты формы.</param>
    /// <param name="visiblePartAsPercentage">Видимая часть элементов на форме в процентах.</param>
    /// <returns></returns>
    private int GetСarriageHeight(double onePercent, double visiblePartAsPercentage)
    {
      return Convert.ToInt32(onePercent * visiblePartAsPercentage);
    }

    /// <summary>
    /// Возвращет "пустую дистанцию" скролла в пикселях.
    /// </summary>
    /// <returns></returns>
    private int GetEmptyScrollLength()
    {
      return Height - CaretHeight;
    }

    /// <summary>
    /// Возвращет невидмую часть линий в количесвте. 
    /// </summary>
    /// <returns></returns>
    private Double GetPercentageInvisibleLines()
    {
      return Math.Abs(countLines - (Convert.ToDouble(Height) / heightElement));
    }

    /// <summary>
    /// Возвращает шаг каретки в пикселях.
    /// </summary>
    /// <param name="numberInvisibleLines">Кол-во невидимых линий.</param>
    /// <param name="distentionRestScroll">Пустая дистанция скролла.</param>
    /// <returns></returns>
    private int GetCarriagePitch(double numberInvisibleLines, int distentionRestScroll)
    {
      return Convert.ToInt32(distentionRestScroll / numberInvisibleLines);
    }

    /// <summary>
    /// Меняет размеры элемента.
    /// </summary>
    /// <param name="width">Ширина элемента.</param>
    /// <param name="height">Высота элемента.</param>
    public void Resize(int width, int height)
    {
      Width = width;
      Height = height;

      mainPanel.Width = Width - WidthScroll;
      mainPanel.Location = new Point(mainPanel.Location.X, 0);
      CaretLocationY = 0;
      CarriageHeightAndStepCalculation();
      LocationApps();
      Invalidate();

      new InfoElement().WriteInfoElement(DataClass.launcher, "Вся форма");
      new InfoElement().WriteInfoElement(mainPanel, "Панель с приложениями");
      new InfoElement().ColorTwoParameters("Позиция каретки", CaretLocationY.ToString(), ConsoleColor.Green, false);
    }

    /// <summary>
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    public void LocationApps()
    {
      int locationX = 40;
      int locationY = 40;
      countLines = 1;
      mainPanel.Height = heightElement + Y_AxisIndentation;
      int i = 0;

      foreach (Control app in mainPanel.Controls)
      {
        i++;
        if (locationX + app.Width + 25 < DataClass.activeAppPanelLauncher.Width)
        {
          app.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataClass.sizeAppElement.Width + X_AxisIndentation;
        }
        else
        {
          mainPanel.Height += (heightElement + Y_AxisIndentation);
          countLines++;
          locationX = 40;
          locationY += DataClass.sizeAppElement.Height + Y_AxisIndentation;
          app.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataClass.sizeAppElement.Width + X_AxisIndentation;
        }
      }

      mainPanel.Height += Y_AxisIndentation;
      Console.WriteLine($"Кол-во линий: {countLines}");
    }

    /// <summary>
    /// Добавление элемента в панель элементов).
    /// </summary>
    /// <param name="value">Экземпляр элемента.</param>
    public void AddControl(Control value)
    {
      if (heightElement < value.Height) heightElement = value.Height;
      mainPanel.Controls.Add(value);
      Invalidate();
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Задаёт начальные параметры элемента.
    /// </summary>
    public ScrollBarElement()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
      Width = 100;
      Height = 100;
      BackColor = Color.Red;
      BackColorScroll = Color.Orange;
      BackColorCaret = Color.Yellow;
      WidthScroll = 10;
      CaretLocationY = 0;
      DistanceCaret = 0;
      mainPanel = new Panel()
      {
        BackColor = Color.LightBlue,
        Name = "System.ScrollBarElement.mainPanel",
      };
      X_AxisIndentation = 10;
      Y_AxisIndentation = 20;
      mainPanel.Location = new Point(0, 0);
      Controls.Add(mainPanel);
    }

    #endregion
  }
}
