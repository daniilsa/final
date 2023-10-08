using LauncherNet.Controls;
using LauncherNet.Functions;

namespace LauncherNet.Elements.LauncherElements
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
      MovingForm movingForm = new MovingForm();
      movingForm.CheckSticking = true;
      topPanel.MouseDown += (s, a) => movingForm.CheckingToMoveAnElement(value, a);
      topPanel.MouseMove += (s, a) => movingForm.MovingAnElement(value);
      topPanel.MouseUp += (s, a) => movingForm.CheckingForSticking(value);

      Size buttonSize = new(topPanel.Height, topPanel.Height);

      // Кнопка "скрыть" форму
      BorderButtonControl minimaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Minimaze,
        Dock = DockStyle.Right,
      };
      minimaze.MouseDown += (s, a) => new FunctionsForms().HideTheForm(value);

      // Кнопка "развернуть" форму на весь экран
      BorderButtonControl maximaze = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Maximaze,
        Dock = DockStyle.Right,
      };
      maximaze.MouseDown += (s, a) => new FunctionsForms().ExpandTheForm(value);

      // Кнопка закрыть программу
      BorderButtonControl exit = new()
      {
        Size = buttonSize,
        Cursor = Cursors.Hand,
        ChoiceElement = BorderButtonControl.Choice.Exit,
        Dock = DockStyle.Right,
      };
      exit.MouseDown += (s, a) => new FunctionsForms().ExitProgramm();

      topPanel.Controls.Add(minimaze);
      topPanel.Controls.Add(maximaze);
      topPanel.Controls.Add(exit);


      return topPanel;
    }

    #endregion
  }
}
