//using LauncherNet._Data;
using System.Net.Mail;
using System.Windows.Forms;

namespace LauncherNet.Controls
{
  public class ScrollBarControl : Control
  {

    #region Поля



    public enum ScrollControls
    {
      Categories,
      Apps
    }

   

    /// <summary>
    /// Размеры добавляемого элемента.
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
    /// Смена локации main.
    /// </summary>
    private bool expectationMain = false;

    /// <summary>
    /// Экземпляр панели, в которую добавляются элементы из вне.
    /// </summary>
    private readonly Panel mainPanel;

    #endregion

    #region Свойства

    #region Public


    public ScrollControls ScrollElements { get; set; }

    /// <summary>
    /// Возвращает или задаёт свойство "свеже открытой" панели. Свойство нужно для расчёта локации элемента при его открытии.
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

    /// <summary>
    /// Прокрутка колесика мыши.
    /// </summary>
    /// <param name="e">Данные для обработки события прокрутки колесика мыши на элементе.</param>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);
      if (mainPanel.Height > Height && !expectationMain)
      {
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
      if (mainPanel.Height > Height)
      {
        int stopLocation = (mainPanel.Height - Height) * (-1);
        int distance = mainPanel.Location.Y - sizeElement.Height - Y_AxisIndentation;
        if (mainPanel.Location.Y >= stopLocation)
        {
          while (!expectationMain && mainPanel.Location.Y >= stopLocation)
          {
            expectationMain = true;
            if (mainPanel.Location.Y >= distance)
            {
              await Task.Delay(1);
              mainPanel.Location = new Point(0, mainPanel.Location.Y - 10);
              expectationMain = false;
            }
            else
            {
              expectationMain = false;
              break;
            }
          }
        }
      }
    }

    public async void MouseWheelUp()
    {
      if (mainPanel.Height > Height)
      {
        int stopLocation = 0;
        int distance = mainPanel.Location.Y + sizeElement.Height + Y_AxisIndentation;
        if (mainPanel.Location.Y <= stopLocation)
        {
          while (!expectationMain && mainPanel.Location.Y <= stopLocation)
          {
            expectationMain = true;
            if (mainPanel.Location.Y <= distance)
            {
              await Task.Delay(1);
              mainPanel.Location = new Point(0, mainPanel.Location.Y + 10);
              expectationMain = false;
            }
            else
            {
              expectationMain = false;
              break;
            }
          }
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

      mainPanel.Width = Width;
      mainPanel.Location = new Point(mainPanel.Location.X, 0);

      //TODO: Расчитать момент расчёта локации
      if (elementsOnTheLine * (sizeElement.Width + X_AxisIndentation) >= mainPanel.Width)
        LocationApps();

      else if ((elementsOnTheLine + 1) * (sizeElement.Width + X_AxisIndentation) <= mainPanel.Width)
        LocationApps();
    }

    /// <summary>
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    private void LocationApps()
    {
      if (ScrollElements == ScrollControls.Apps)
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
          if (locationX + app.Width + X_AxisIndentation < this.Width)
          {
            app.Location = new System.Drawing.Point(locationX, locationY);
            locationX += app.Width + X_AxisIndentation;
            if (calculationOfElements) elementsOnTheLine++;
          }
          else
          {
            mainPanel.Height += (sizeElement.Height + Y_AxisIndentation);
            countLines++;
            locationX = 40;
            locationY += app.Height + Y_AxisIndentation;
            app.Location = new System.Drawing.Point(locationX, locationY);
            locationX += app.Width + X_AxisIndentation;
            calculationOfElements = false;
          }
        }
        mainPanel.Height += Y_AxisIndentation;
      }
      else
      {
        int locationX = 0;
        int locationY = 0;
        mainPanel.Height = 0;
        foreach (Control app in mainPanel.Controls)
        {
          app.Location = new Point(locationX, locationY);
          locationY += app.Height;
          mainPanel.Height += app.Height;
        }
      }
    }

    /// <summary>
    /// Добавление элемента в панель элементов.
    /// </summary>
    /// <param name="value">Экземпляр элемента.</param>
    public void AddControl(Control value)
    {

      Control? addControl = null;
      if (ScrollElements == ScrollControls.Apps)
      {
        if (mainPanel.Controls.Count > 1)
        {
          addControl = mainPanel.Controls[mainPanel.Controls.Count - 1];
        }

        sizeElement.Width = value.Width;
        if (sizeElement.Height < value.Height) sizeElement.Height = value.Height;
        mainPanel.Controls.Add(value);

        if (mainPanel.Controls.Count > 1)
        {
          try
          {
            mainPanel.Controls.SetChildIndex(value, mainPanel.Controls.Count - 2);
            mainPanel.Controls.SetChildIndex(addControl, mainPanel.Controls.Count - 1);
          }
          catch
          { 
          
          }
        }
      }
      else
      {
        mainPanel.Controls.Add(value);
        mainPanel.Width = Width;
        sizeElement.Width = mainPanel.Width;
        value.Width = sizeElement.Width;

        if (mainPanel.Controls.Count > 1)
        {
          addControl = mainPanel.Controls[mainPanel.Controls.Count-2];
          mainPanel.Controls.SetChildIndex(value, mainPanel.Controls.Count - 2);
          mainPanel.Controls.SetChildIndex(addControl, mainPanel.Controls.Count - 1);
        }

        if (mainPanel.Controls.Count > 0)
        {
          foreach (Control item in mainPanel.Controls)
          {
            item.Width = mainPanel.Width;
          }
        }
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
      mainPanel = new()
      {
        BackColor = Color.LightBlue,
        Name = "System.ScrollBarElement.mainPanel",
      };

      X_AxisIndentation = 10;
      Y_AxisIndentation = 20;
      mainPanel.Location = new Point(0, 0);

      Controls.Add(mainPanel);
    }

    public ScrollBarControl(int width) : this()
    { 
      Width = width;
    }

    #endregion
  }
}
