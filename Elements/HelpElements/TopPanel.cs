using LauncherNet._DataStatic;
using LauncherNet.Controls;
using LauncherNet.Functions;
using System.Runtime.InteropServices;

namespace LauncherNet.Elements.HelpElements
{
  internal class TopPanel
  {

    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr LoadLibrary(string libName);

    [DllImport("User32.dll")]
    public static extern IntPtr LoadIcon(IntPtr libHable, int lpIconName);

    /// <summary>
    /// Возвращает экземпляр верзней панели.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Panel CreateTopPanel(Form value)
    {
      MovingForm movingForm = new MovingForm();

      Panel topPanel = new()
      {
        Height = 50,
        Dock = DockStyle.Top,
        Cursor = Cursors.SizeAll,
      };
      topPanel.MouseDown += (s, a) => movingForm.CheckingToMoveAnElement(value, a);
      topPanel.MouseMove += (s, a) => movingForm.MovingAnElement(value);
      topPanel.MouseUp += (s, a) => movingForm.CheckingForSticking(value);

      PictureBox iconBox = CreateIconTopPanel(topPanel);
      Label helpText = CreateHelpText(topPanel, iconBox);

      BorderButtonControl? minimaze = null;
      BorderButtonControl? maximaze = null;
      BorderButtonControl? exit = null;
      CreatePanelButtons(value, topPanel, ref minimaze, ref maximaze, ref exit);

      topPanel.Controls.Add(iconBox);
      topPanel.Controls.Add(helpText);
      topPanel.Controls.Add(minimaze);
      //topPanel.Controls.Add(maximaze);
      topPanel.Controls.Add(exit);

      DataHelpForm.topElement = topPanel;
      return topPanel;
    }

    /// <summary>
    /// Создаёт икноку помощи для верхней панели.
    /// </summary>
    /// <param name="topPanel">Верхняя панель.</param>
    /// <returns></returns>
    private PictureBox CreateIconTopPanel(Panel topPanel)
    {
      Icon icon = Icon.FromHandle(LoadIcon(LoadLibrary("shell32"), 24));
      PictureBox iconBox = new()
      {
        Width = 48,
        Height = 48,
        BackgroundImage = new Icon(icon, new Size(256, 256)).ToBitmap(),
        BackgroundImageLayout = ImageLayout.Center,
      };
      iconBox.Location = new Point(10, (topPanel.Height / iconBox.Height) / 2);

      return iconBox;
    }

    /// <summary>
    /// Надпись помощи.
    /// </summary>
    /// <param name="topPanel"></param>
    /// <param name="iconBox"></param>
    /// <returns></returns>
    private Label CreateHelpText(Panel topPanel, PictureBox iconBox)
    {
      Label helpLabel = new()
      {
        Text = "Окно справки \"Launcher\".",
      };
      helpLabel.Size = TextRenderer.MeasureText(helpLabel.Text, helpLabel.Font);
      helpLabel.Location = new(iconBox.Width + iconBox.Location.X + 10, (topPanel.Height - helpLabel.Height) / 2);
      return helpLabel;
    }

    /// <summary>
    /// Кнопки управления формой.
    /// </summary>
    /// <param name="value">Экземляр формы.</param>
    /// <param name="topPanel">Экземляр верхнего меню.</param>
    /// <param name="minimaze">Кнопка скрыть (null)</param>
    /// <param name="maximaze">Кнопка На весь экран (null)</param>
    /// <param name="exit">Кнопка выхода (null)</param>
    private void CreatePanelButtons(Form value, Panel topPanel, ref BorderButtonControl? minimaze, ref BorderButtonControl? maximaze, ref BorderButtonControl? exit)
    {
      Size buttonSize = new(topPanel.Height, topPanel.Height);
      // Кнопка скрытия формы
      minimaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Minimaze,
        ForeColor = Color.Black,
        Dock = DockStyle.Right,
      };
      minimaze.MouseDown += (s, a) => new FunctionsForms().HideTheForm(value);
      // Кнопка "развернуть" форму на весь экран
      maximaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Maximaze,
        ForeColor = Color.Black,
        Dock = DockStyle.Right,
      };
      maximaze.MouseDown += (s, a) => new FunctionsForms().ExpandTheForm(value);
      // Кнопка закрытия формы
      exit = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ForeColor = Color.Black,
        ChoiceElement = BorderButtonControl.Choice.Exit,
        Dock = DockStyle.Right,
      };
      exit.MouseDown += (s, a) => new FunctionsForms().CloseForm(value);
    }
  }
}
