using LauncherNet.DesignFront;

namespace LauncherNet.Elements.LoadFormElements
{
  internal class MainElement
  {
    /// <summary>
    /// Возвращает экземпляр элемента с загрузкой приложения.
    /// </summary>
    /// <param name="loadForm"></param>
    /// <returns></returns>
    public Panel CreateMainElement(Form loadForm)
    {
      Panel main = CreateMainElements(loadForm);
      PictureBox leftElement = CreateLeftElement(main);
      Label startProgrammText = CreateHeaderTextElement(loadForm, leftElement);
      Label infoProgress = CreateInfoElement(loadForm, leftElement);
      Panel progressBar = CreateProgressBar(loadForm, main, leftElement, infoProgress.Width);

      startProgrammText.Location = new Point(progressBar.Location.X, progressBar.Location.Y - startProgrammText.Height * 2);
      infoProgress.Location = new Point(progressBar.Location.X, progressBar.Location.Y + progressBar.Height + infoProgress.Height);

      main.Controls.Add(leftElement);
      main.Controls.Add(progressBar);
      main.Controls.Add(startProgrammText);
      main.Controls.Add(infoProgress);

      return main;
    }

    /// <summary>
    /// Главная панель.
    /// </summary>
    /// <param name="loadForm"></param>
    /// <returns></returns>
    private Panel CreateMainElements(Form loadForm)
    {
      Panel main = new()
      {
        Width = loadForm.Width,
        Height = loadForm.Height
      };
      return main;
    }

    /// <summary>
    /// Возвращает элемент, который находится слева на панеле.
    /// </summary>
    /// <param name="main"></param>
    /// <returns></returns>
    private PictureBox CreateLeftElement(Panel main)
    {
      PictureBox leftPanel = new()
      {
        Dock = DockStyle.Left,
        Width = main.Width / 10 / 2,
        BackColor = Color.FromArgb(223, 155, 44)
      };

      return leftPanel;
    }

    /// <summary>
    /// Возваращет элемеент информации о запуске программы.
    /// </summary>
    /// <param name="loadForm"></param>
    /// <param name="leftElement"></param>
    /// <returns></returns>
    private Label CreateHeaderTextElement(Form loadForm, PictureBox leftElement)
    {
      Label startProgrammText = new()
      {
        Text = "ЗАПУСК ПРОГРАММЫ",
        //checkProgrammText.Font = new FontElements().GetHeaderFont();
        ForeColor = leftElement.BackColor
      };
      startProgrammText.Size = TextRenderer.MeasureText(startProgrammText.Text, loadForm.Font);
      return startProgrammText;
    }

    /// <summary>
    /// Возвращает элемент информации о проверке ресурсов.
    /// </summary>
    /// <param name="loadForm"></param>
    /// <param name="leftElement"></param>
    /// <returns></returns>
    private Label CreateInfoElement(Form loadForm, PictureBox leftElement)
    {
      Label infoProgress = new()
      {
        Text = "Обработка данных. Это может занять некоторое время",
        ForeColor = leftElement.BackColor
      };
      infoProgress.Size = TextRenderer.MeasureText(infoProgress.Text, loadForm.Font);
      return infoProgress;
    }

    /// <summary>
    /// Возвращает элемент прогресс бара.
    /// </summary>
    /// <param name="loadForm">Элемент формы.</param>
    /// <param name="main">Главная панель.</param>
    /// <param name="leftElement">Левый элемент.</param>
    /// <param name="width">Ширина элемента.</param>
    /// <returns></returns>
    private Panel CreateProgressBar(Form loadForm, Panel main, PictureBox leftElement, int width)
    {
      Panel panelProgressBar = new()
      {
        Width = width,
        BackColor = BackColorElements.MainDarkColor,
        Height = 20
      };
      panelProgressBar.Location = new Point(leftElement.Location.X + leftElement.Width + 20, (main.Height - panelProgressBar.Height) / 2);

      Panel progressBar = new()
      {
        Location = new Point(-40, 0),
        Width = 50,
        BackColor = Color.FromArgb(223, 155, 44),
        Height = 20
      };

      System.Windows.Forms.Timer timer = new()
      {
        Interval = 10
      };
      timer.Tick += (s, ev) =>
      {
        if (!DataClass.DownloadStage)
        {
          if (progressBar.Location.X <= (panelProgressBar as Panel).Width)
          {
            progressBar.Location = new Point(progressBar.Location.X + 2, 0);
          }
          else
          {
            progressBar.Location = new Point(-40, 0);
          }
        }
        else
        {
          DataClass.DownloadStage = true;
          loadForm.Close();
        }
      };
      timer.Start();

      loadForm.Width = panelProgressBar.Location.X + panelProgressBar.Width + 20;

      panelProgressBar.Controls.Add(progressBar);
      return panelProgressBar;
    }
  }
}
