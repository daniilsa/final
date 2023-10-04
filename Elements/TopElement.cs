using LauncherNet.Controls;
using LauncherNet.Functions;
using LauncherNet.Settings;

namespace LauncherNet.Elements
{
  internal class TopElement
  {
    #region Поля

    /// <summary>
    /// Стартовая позиция.
    /// </summary>
    private Point startPoint = new(0, 0);

    #endregion

    #region Методы 

    /// <summary>
    /// Создаёт и настраивает экземпляр верхней панели.
    /// </summary>
    /// <param name="value">Экземпляр формы.</param>
    public Panel CreateTopElement(Form value)
    {
      // Вся верхняя панель
      Panel topPanel = new()
      {
        Dock = DockStyle.Top,
        Height = 50,
        Cursor = Cursors.SizeAll,
      };
      topPanel.MouseDown += (s, a) => CheckingToMoveAnElement(a);
      topPanel.MouseMove += (s, a) => MovingAnElement();
      topPanel.MouseUp += (s, a) => CheckingForSticking();

      Size buttonSize = new(topPanel.Height, topPanel.Height);

      // Кнопка "скрыть" форму
      BorderButtonControl minimaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Minimaze,
        ForeColor = Color.White,
        Dock = DockStyle.Right,
      };
      minimaze.MouseDown += (s, a) => HideTheForm(value);

      // Кнопка "развернуть" форму на весь экран
      BorderButtonControl maximaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Maximaze,
        ForeColor = Color.White,
        Dock = DockStyle.Right,
      };
      maximaze.MouseDown += (s, a) => ExpandTheForm(value);

      // Кнопка закрыть программу
      BorderButtonControl exit = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ForeColor = Color.White,
        ChoiceElement = BorderButtonControl.Choice.Exit,
        Dock = DockStyle.Right,
      };
      exit.MouseDown += (s, a) =>
      {
        if (DataClass.trayActive)
          new Tray().InTray(DataClass.iconLauncher);
        else Application.Exit();
      };

      topPanel.Controls.Add(minimaze);
      topPanel.Controls.Add(maximaze);
      topPanel.Controls.Add(exit);


      return topPanel;
    }

    /// <summary>
    /// Проверки для перемещения элемента.
    /// </summary>
    private void CheckingToMoveAnElement(MouseEventArgs e)
    {
      DataClass.drag = true;
      startPoint = new Point(e.X, e.Y);
      if (DataClass.launcher?.WindowState == FormWindowState.Maximized)
      {
        DataClass.launcher.WindowState = FormWindowState.Normal;
        DataClass.launcher.Location = new Point(e.X - (DataClass.launcher.Width / 2), 0);
        startPoint = DataClass.launcher.Location;
      }

      if ((DataClass.stickingForm == DataClass.Sticking.Top || DataClass.stickingForm == DataClass.Sticking.Bottom) && DataClass.launcher != null)
      {
        DataClass.launcher.Size = DataClass.sizeStickingForm;
        DataClass.launcher.Location = DataClass.locationStickingForm.LocationElement;
        startPoint = DataClass.launcher.Location;
        DataClass.stickingForm = DataClass.Sticking.Nope;
      }
      else if ((DataClass.stickingForm == DataClass.Sticking.Left || DataClass.stickingForm == DataClass.Sticking.Right) && DataClass.launcher != null)
      {
        DataClass.launcher.Size = DataClass.sizeStickingForm;
        DataClass.stickingForm = DataClass.Sticking.Nope;
      }

      new SettingsForms().SizeElements();
    }

    /// <summary>
    /// Перемещение элемента.
    /// </summary>
    private void MovingAnElement()
    {
      if (DataClass.drag && DataClass.launcher != null)
      {
        DataClass.launcher.Location = new Point(Cursor.Position.X - startPoint.X, Cursor.Position.Y - startPoint.Y);
      }
    }

    /// <summary>
    /// Проверяет "прилипание" элемента к границам экрана.
    /// </summary>
    private void CheckingForSticking()
    {
      DataClass.drag = false;
      if (DataClass.launcher != null)
      {
        if (DataClass.launcher.Location.Y < 0)
        {
          DataClass.sizeStickingForm = DataClass.launcher.Size;
          DataClass.stickingForm = DataClass.Sticking.Top;
          DataClass.locationStickingForm.LocationElement = new Point(DataClass.launcher.Location.X, 0);
          DataClass.launcher.Location = new Point(0, 0);
          DataClass.launcher.Width = DataClass.screenSize.Width;
          DataClass.launcher.Height = DataClass.screenSize.Height / 2;

        }
        else if (DataClass.launcher.Location.X < 0)
        {
          DataClass.sizeStickingForm = DataClass.launcher.Size;
          DataClass.stickingForm = DataClass.Sticking.Left;
          DataClass.locationStickingForm.LocationElement = new Point(DataClass.launcher.Location.X, 0);
          DataClass.launcher.Location = new Point(0, 0);
          DataClass.launcher.Width = DataClass.screenSize.Width / 2;
          DataClass.launcher.Height = DataClass.screenSize.Height;
        }
        else if (DataClass.launcher.Location.X + DataClass.launcher?.Width > DataClass.screenSize.Width)
        {
          DataClass.sizeStickingForm = DataClass.launcher.Size;
          DataClass.stickingForm = DataClass.Sticking.Right;
          DataClass.locationStickingForm.LocationElement = new Point(DataClass.launcher.Location.X, 0);
          DataClass.launcher.Location = new Point(DataClass.screenSize.Width / 2, 0);
          DataClass.launcher.Width = DataClass.screenSize.Width / 2;
          DataClass.launcher.Height = DataClass.screenSize.Height;
        }
        else if (DataClass.launcher.Location.Y + DataClass.launcher.Height > DataClass.screenSize.Height)
        {
          DataClass.sizeStickingForm = DataClass.launcher.Size;
          DataClass.stickingForm = DataClass.Sticking.Bottom;
          DataClass.locationStickingForm.LocationElement = new Point(DataClass.launcher.Location.X, 0);
          DataClass.launcher.Location = new Point(0, DataClass.screenSize.Height / 2);
          DataClass.launcher.Width = DataClass.screenSize.Width;
          DataClass.launcher.Height = DataClass.screenSize.Height / 2;
        }
      }
    }

    /// <summary>
    /// Свернуть приложение.
    /// </summary>
    /// <param name="value"></param>
    private void HideTheForm(Form value)
    {
      value.WindowState = FormWindowState.Minimized;
    }

    /// <summary>
    /// Развернуть форму на весь экран.
    /// </summary>
    /// <param name="value"></param>
    private void ExpandTheForm(Form value)
    {
      if (value.WindowState == FormWindowState.Maximized) value.WindowState = FormWindowState.Normal;
      else value.WindowState = FormWindowState.Maximized;
    }

    /// <summary>
    /// Закрывает программу.
    /// </summary>
    private void ExitProgramm()
    {
      Application.Exit();
    }

    #endregion

  }
}
