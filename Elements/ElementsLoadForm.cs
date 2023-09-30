using LauncherNet.DesignFront;
using LauncherNet.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LauncherNet.Elements
{
  public class ElementsLoadForm
  {

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="loadForm">Экземляр формы.</param>
    public void LoadElements(Form loadForm)
    {
      loadForm.Controls.Add(MainPanel(loadForm));
    }

    private Panel MainPanel(Form loadForm)
    {
      Panel main = new()
      {
        Width = loadForm.Width,
        Height = loadForm.Height
      };

      Panel leftPanel = new()
      {
        Dock = DockStyle.Left,
        Width = main.Width / 10 / 2,
        BackColor = Color.FromArgb(223, 155, 44)
      };

      Label checkProgrammText = new()
      {
        Text = "ЗАПУСК ПРОГРАММЫ",
        //checkProgrammText.Font = new FontElements().GetHeaderFont();
        ForeColor = leftPanel.BackColor
      };
      checkProgrammText.Size = TextRenderer.MeasureText(checkProgrammText.Text, loadForm.Font);

      Label infoProgress = new()
      {
        Text = "Обрабатываем данные. Это может занять некоторое время",
        ForeColor = leftPanel.BackColor
      };
      infoProgress.Size = TextRenderer.MeasureText(infoProgress.Text, loadForm.Font);

      Panel progressBar = CreateProgressBar(loadForm, main, leftPanel, infoProgress.Width);

      
      checkProgrammText.Location = new Point(progressBar.Location.X, progressBar.Location.Y - checkProgrammText.Height * 2);
      infoProgress.Location = new Point(progressBar.Location.X, progressBar.Location.Y+progressBar.Height + infoProgress.Height);

      main.Controls.Add(leftPanel);
      main.Controls.Add(progressBar);
      main.Controls.Add(checkProgrammText);
      main.Controls.Add(infoProgress);

      return main;
    }

    /// <summary>
    /// Возвращает элемент прогресс бара.
    /// </summary>
    /// <param name="main"></param>
    /// <param name="leftPanel"></param>
    /// <returns></returns>
    private Panel CreateProgressBar(Form loadForm, Panel main, Panel leftPanel, int width)
    {
      Panel panelProgressBar = new()
      {
        Width = width,
        BackColor = BackColorElements.BackColorTopElement,
        Height = 20
      };
      panelProgressBar.Location = new Point(leftPanel.Location.X + leftPanel.Width + 20, (main.Height - panelProgressBar.Height) / 2);

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
        if (!DataClass.downloadStage)
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
          DataClass.downloadStage = true;
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
