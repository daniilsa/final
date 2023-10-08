using LauncherNet._Data;
using LauncherNet.Info;
using System.Windows.Forms;

namespace LauncherNet.Controls
{
  public class ScrollBarControl : Control
  {

    #region Поля

    /// <summary>
    /// Высота одного элемента.
    /// </summary>
    private Size sizeElement = new(0, 0);

    /// <summary>
    /// Кол-во линий с элементами.
    /// </summary>
    private int countLines = 1;

    /// <summary>
    /// Элементов на линии.
    /// </summary>
    private int elementsOnTheLine = 0;

    /// <summary>
    /// Можно ли изменить количество элементов на линии.
    /// </summary>
    private bool calculationOfElements;


    /// <summary>
    /// Смена локации scroll.
    /// </summary>
    private bool expectationScroll = false;

    /// <summary>
    /// Смена локации main.
    /// </summary>
    private bool expectationMain = false;

    /// <summary>
    /// Экземпляр панели, в которую добавляются элементы из вне.
    /// </summary>
    private readonly Panel mainPanel;

    private readonly Panel scrollBar;

    private readonly Panel caretScroll;

    /// <summary>
    /// Плавность хода.
    /// </summary>
    private readonly int smoothing = 1;

    #endregion

    #region Свойства

    #region Public
    /// <summary>
    /// Возвращает или задаёт цвет заднего фона элемента скролла.
    /// </summary>
    public Color BackColorScroll { get { return scrollBar.BackColor; } set { scrollBar.BackColor = value; } }

    /// <summary>
    /// Возвращает или задаёт цвет фона каретки скролла.
    /// </summary>
    public Color BackColorCaret { get { return caretScroll.BackColor; } set { caretScroll.BackColor = value; } }

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



    #region Расчёты для скролла

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
      caretScroll.Height = CaretHeight;
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
      return Math.Abs(countLines - (Convert.ToDouble(Height) / sizeElement.Height));
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

    #endregion

    /// <summary>
    /// Прокрутка колесика мыши.
    /// </summary>
    /// <param name="e">Данные для обработки события прокрутки колесика мыши на элементе.</param>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);
      if (mainPanel.Height > Height && !expectationMain)
      {
        scrollBar.Visible = true;
        if (e.Delta < 0)
        {
          MouseWheelDown();
        }
        else if (e.Delta > 0)
        {
          MouseWheelUp();
        }
      }
    }

    public async void MouseWheelDown()
    {
      if (mainPanel.Height > Height && !expectationMain)
      {
        scrollBar.Visible = true;
        if (caretScroll.Height + caretScroll.Location.Y < Height)
        {
          if (caretScroll.Location.Y + CaretHeight + (DistanceCaret / smoothing) <= Height)
          {
            int count = 0;
            int mainLocationY = mainPanel.Location.Y - ((sizeElement.Height + Y_AxisIndentation) / smoothing);
            int temporaryLocationY = mainPanel.Location.Y;
            int scroolLocationY = Convert.ToInt32(caretScroll.Location.Y + (DistanceCaret / smoothing));

            // Для адеватного расчёта дистанции каретки (появилось при плавности) )
            while (!expectationMain && temporaryLocationY >= mainLocationY)
            {
              if (temporaryLocationY <= mainPanel.Height - Height - Y_AxisIndentation * 3)
              {
                temporaryLocationY -= 10;
                count++;
              }
              else
              {
                break;
              }
            }

            int distance = scroolLocationY / count;

            while (!expectationMain || !expectationScroll)
            {
              expectationMain = true;
              expectationScroll = true;

              await Task.Delay(1);
              if (mainPanel.Location.Y <= mainPanel.Height - Height - Y_AxisIndentation * 3)
              {
                if (mainPanel.Location.Y >= mainLocationY)
                {
                  mainPanel.Location = new Point(0, mainPanel.Location.Y - 10);
                  expectationMain = false;
                }
              }

              if ((caretScroll.Height + caretScroll.Location.Y + distance) <= Height)
              {
                if (caretScroll.Location.Y <= scroolLocationY)
                {
                  caretScroll.Location = new Point(0, caretScroll.Location.Y + distance);
                  expectationScroll = false;
                }
              }
            }

            mainPanel.Location = new Point(0, mainLocationY);
            scrollBar.Location = new Point(0, scroolLocationY);
            expectationMain = false;
            expectationScroll = false;
          }
          else
          {
            int count = 0;
            int mainLocationY = -(mainPanel.Height - Height) - Y_AxisIndentation * 3;
            int temporaryLocationY = mainPanel.Location.Y;
            int scroolLocationY = Height - CaretHeight;

            // Для адеватного расчёта дистанции каретки (появилось при плавности) )
            while (temporaryLocationY >= mainLocationY)
            {
              if (temporaryLocationY <= mainPanel.Height - Height - Y_AxisIndentation * 3)
              {
                temporaryLocationY -= 10;
                count++;
              }
              else
              {
                break;
              }
            }

            int distance = (Height - caretScroll.Location.Y - caretScroll.Height) / count;
            if (distance <= 0)
              distance = 1;

            while (!expectationMain || !expectationScroll)
            {
              expectationMain = true;
              expectationScroll = true;

              await Task.Delay(1);
              if (mainPanel.Location.Y <= mainPanel.Height - Height - Y_AxisIndentation * 3)
              {
                if (mainPanel.Location.Y >= mainLocationY)
                {
                  mainPanel.Location = new Point(0, mainPanel.Location.Y - 10);
                  expectationMain = false;
                }
              }

              if ((caretScroll.Height + caretScroll.Location.Y + distance) <= Height)
              {
                if (caretScroll.Location.Y <= scroolLocationY)
                {
                  caretScroll.Location = new Point(0, caretScroll.Location.Y + distance);
                  expectationScroll = false;
                }
              }
            }

            caretScroll.Location = new Point(0, Height - CaretHeight);
            mainPanel.Location = new Point(0, -(mainPanel.Height - Height) - Y_AxisIndentation * 3);
            expectationMain = false;
            expectationScroll = false;
          }
        }
      }
    }

    public async void MouseWheelUp()
    {
      if (caretScroll.Location.Y > 0)
      {
        if (caretScroll.Location.Y - (DistanceCaret / smoothing) >= 0)
        {
          int count = 0;
          int mainLocationY = mainPanel.Location.Y + ((sizeElement.Height + Y_AxisIndentation) / smoothing);
          int temporaryLocationY = mainPanel.Location.Y;
          int scroolLocationY = Convert.ToInt32(caretScroll.Location.Y - (DistanceCaret / smoothing));
          int difference = caretScroll.Location.Y - scroolLocationY;

          // Для адеватного расчёта дистанции каретки (появилось при плавности).
          while (!expectationMain && temporaryLocationY <= mainLocationY)
          {
            if (temporaryLocationY <= mainLocationY)
            {
              temporaryLocationY += 10;
              count++;
            }
            else
            {
              break;
            }
          }

          int distance = difference / count;

          while (!expectationMain || !expectationScroll)
          {
            expectationMain = true;
            expectationScroll = true;

            await Task.Delay(1);
            if (mainPanel.Location.Y <= 0)
            {
              if (mainPanel.Location.Y <= mainLocationY)
              {
                mainPanel.Location = new Point(0, mainPanel.Location.Y + 10);
                expectationMain = false;
              }
            }

            if (caretScroll.Location.Y >= 0)
            {
              if (caretScroll.Location.Y >= scroolLocationY)
              {
                caretScroll.Location = new Point(0, caretScroll.Location.Y - distance);
                expectationScroll = false;
              }
            }
          }

          mainPanel.Location = new Point(0, mainLocationY);
          scrollBar.Location = new Point(0, scroolLocationY);
          expectationMain = false;
          expectationScroll = false;
        }
        else
        {
          int count = 0;
          int mainLocationY = 0;
          int temporaryLocationY = mainPanel.Location.Y;
          int scroolLocationY = 0;
          int difference = caretScroll.Location.Y - scroolLocationY;

          // Для адеватного расчёта дистанции каретки (появилось при плавности).
          while (!expectationMain && temporaryLocationY <= mainLocationY)
          {
            if (temporaryLocationY <= mainLocationY)
            {
              temporaryLocationY += 10;
              count++;
            }
            else
            {
              break;
            }
          }

          int distance = difference / count;

          while (!expectationMain || !expectationScroll)
          {
            expectationMain = true;
            expectationScroll = true;

            await Task.Delay(1);
            if (mainPanel.Location.Y <= mainLocationY)
            {
              mainPanel.Location = new Point(0, mainPanel.Location.Y + 10);
              expectationMain = false;
            }

            if (caretScroll.Location.Y >= scroolLocationY)
            {
              caretScroll.Location = new Point(0, caretScroll.Location.Y - distance);
              expectationScroll = false;
            }
          }

          caretScroll.Location = new Point(0, mainLocationY);
          mainPanel.Location = new Point(0, scroolLocationY);
          expectationMain = false;
          expectationScroll = false;
        }
      }

    }

    /// <summary>
    /// Меняет размеры элемента.
    /// </summary>
    /// <param name="width">Ширина элемента.</param>
    /// <param name="height">Высота элемента.</param>
    public new void Resize(int width, int height)
    {
      Width = width;
      Height = height;
      scrollBar.Visible = true;

      mainPanel.Width = Width - WidthScroll;
      mainPanel.Location = new Point(mainPanel.Location.X, 0);

      if (mainPanel.Height <= Height) scrollBar.Visible = false;
      else scrollBar.Visible = true;

      caretScroll.Location = new Point(0, 0);
      CarriageHeightAndStepCalculation();

      //TODO: Расчитать момент расчёта локации
      //if (elementsOnTheLine * (sizeAppElement.Width + X_AxisIndentation) >= mainPanel.Width)
      //  LocationApps();
      //
      //else if ((elementsOnTheLine + 1) * (sizeAppElement.Width + X_AxisIndentation) <= mainPanel.Width)
      //  LocationApps();

      LocationApps();
    }

    /// <summary>
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    private void LocationApps()
    {
      int locationX = 40;
      int locationY = 40;
      elementsOnTheLine = 0;
      countLines = 1;
      calculationOfElements = true;
      mainPanel.Height = sizeElement.Height + Y_AxisIndentation;
      int i = 0;

      foreach (Control app in mainPanel.Controls)
      {
        i++;
        if (locationX + app.Width + X_AxisIndentation < DataLauncherForm.activeAppPanelLauncher?.Width)
        {
          app.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataLauncherForm.sizeAppElement.Width + X_AxisIndentation;
          if (calculationOfElements) elementsOnTheLine++;
        }
        else
        {
          mainPanel.Height += (sizeElement.Height + Y_AxisIndentation);
          countLines++;
          locationX = 40;
          locationY += DataLauncherForm.sizeAppElement.Height + Y_AxisIndentation;
          app.Location = new System.Drawing.Point(locationX, locationY);
          locationX += DataLauncherForm.sizeAppElement.Width + X_AxisIndentation;
          calculationOfElements = false;
        }
      }
      mainPanel.Height += Y_AxisIndentation;
      Console.WriteLine($"Кол-во линий: {countLines}");
    }

    /// <summary>
    /// Добавление элемента в панель элементов.
    /// </summary>
    /// <param name="value">Экземпляр элемента.</param>
    public void AddControl(Control value)
    {
      Control addControl = null;
      if (mainPanel.Controls.Count > 1)
      {
        addControl = mainPanel.Controls[mainPanel.Controls.Count - 1];
      }

      sizeElement.Width = value.Width;
      if (sizeElement.Height < value.Height) sizeElement.Height = value.Height;
      mainPanel.Controls.Add(value);

      if (mainPanel.Controls.Count > 1)
      {
        mainPanel.Controls.SetChildIndex(value, mainPanel.Controls.Count - 2);
        mainPanel.Controls.SetChildIndex(addControl, mainPanel.Controls.Count - 1);
      }


      LocationApps();
    }

    /// <summary>
    /// Удаляят элемент из панели элементов.
    /// </summary>
    /// <param name="nameFile"></param>
    public void DeleteControl(string nameFile)
    {
      foreach (Control item in mainPanel.Controls)
      {
        if (item.Name == nameFile)
        {
          mainPanel.Controls.Remove(item);
          LocationApps();
          break;
        }
      }
    }

    /// <summary>
    /// Возвращает все элементы.
    /// </summary>
    /// <returns></returns>
    public ControlCollection GetControls()
    {
      return mainPanel.Controls;
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Задаёт начальные параметры элемента.
    /// </summary>
    public ScrollBarControl()
    {
      DoubleBuffered = true;
      UpdateStyles();
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

      Width = 100;
      Height = 100;
      BackColor = Color.Red;

      WidthScroll = 10;
      DistanceCaret = 0;
      mainPanel = new()
      {
        BackColor = Color.LightBlue,
        Name = "System.ScrollBarElement.mainPanel",
      };

      scrollBar = new()
      {
        Width = WidthScroll,
        Height = Height,
        Dock = DockStyle.Right,
      };
      scrollBar.BackColor = BackColorScroll;

      caretScroll = new()
      {
        Width = WidthScroll,
        Height = Height,
        Location = new Point(0, 0),
      };
      caretScroll.BackColor = BackColorCaret;

      BackColorScroll = Color.Orange;
      BackColorCaret = Color.Yellow;

      X_AxisIndentation = 10;
      Y_AxisIndentation = 20;
      mainPanel.Location = new Point(0, 0);
      scrollBar.Controls.Add(caretScroll);
      Controls.Add(mainPanel);
      Controls.Add(scrollBar);
    }

    #endregion
  }
}
