using Launcher.Controls;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Elements;
using LauncherNet.Elements.LauncherElements;
using LauncherNet.Front;
using LauncherNet.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static LauncherNet.DataClass;

namespace LauncherNet.Settings
{
  public class SettingsForms
  {

    private bool openProgramm = true;
    private bool expand = false;
    private Point startPoint = new(0, 0);

    Size sizeForm;
    Location locationForm;

    /// <summary>
    /// Настройка формы лаунчера.
    /// </summary>
    /// <param name="launcher">"Экземпляр формы</param>
    public void SettingsLauncherForm(Form launcher)
    {
      DataClass.Expand expandForm = DataClass.Expand.Nope;

      launcher.Size = new Size(700, 600);
      launcher.MinimumSize = new Size(700, 600);
      launcher.WindowState = FormWindowState.Maximized;
      launcher.Text = "Launcher";
      launcher.FormBorderStyle = FormBorderStyle.None;
      launcher.KeyPreview = true;
      launcher.KeyDown += (s, a) => new HotKeys().CheckKeys(s, a);
      launcher.LostFocus += (s, a) => 
      {
        if (openProgramm)
        {
          launcher.Activate();
          launcher.Focus();
          openProgramm= false;
        }
      };


      launcher.SizeChanged += (s, a) =>
      {
        DataClass.sizeForm = launcher.Size;
        if (DataClass.activeAppPanelLauncher != null)
        {
          DataClass.activeAppPanelLauncher.Width = DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth;
          new SettingsForms().SizeElements();

          launcher.TopMost = true;
          launcher.TopMost = false;

        }
      };
      launcher.LocationChanged += (s, a) => DataClass.locationForm = new DataClass.Location(launcher.Location.X, launcher.Location.Y);
      launcher.FormClosing += (s, a) => new BackUpClass().SetCategory();
      launcher.MouseEnter += (s, a) =>
      {

        int pointX = Cursor.Position.X;
        int pointY = Cursor.Position.Y;

        DataClass.Location locationForm = DataClass.locationForm;
        Size sizeForm = DataClass.sizeForm;

        if (DataClass.launcher.WindowState != FormWindowState.Maximized)
        {
          if (pointX <= locationForm.X + 3 && pointY > locationForm.Y + sizeForm.Height - 3)
          {
            launcher.Cursor = Cursors.SizeNESW;
            expandForm = DataClass.Expand.LeftBottom;
          }
          else if (pointX >= locationForm.X + DataClass.sizeForm.Width - 3 && pointY > locationForm.Y + sizeForm.Height - 3)
          {
            launcher.Cursor = Cursors.SizeNWSE;
            expandForm = DataClass.Expand.RightBottom;
          }
          else if (pointX <= locationForm.X + 3)
          {
            launcher.Cursor = Cursors.SizeWE;
            expandForm = DataClass.Expand.Left;
          }
          else if (pointX >= locationForm.X + DataClass.sizeForm.Width - 3)
          {
            launcher.Cursor = Cursors.SizeWE;
            expandForm = DataClass.Expand.Right;
          }
          else if (pointY > locationForm.Y + sizeForm.Height - 3)
          {
            launcher.Cursor = Cursors.SizeNS;
            expandForm = DataClass.Expand.Bottom;
          }
        }
      };
      launcher.MouseLeave += (s, a) =>
      {
        launcher.Cursor = Cursors.Default;
        expandForm = DataClass.Expand.Nope;
      };
      launcher.MouseDown += (s, a) =>
      {
        startPoint = Cursor.Position;
        sizeForm = DataClass.launcher.Size;
        locationForm = new Location(DataClass.launcher.Location.X, DataClass.launcher.Location.Y);
        expand = true;
      };
      launcher.MouseMove += (s, a) =>
      {
        new SizeForm().ResizeForm(expandForm, expand, startPoint, locationForm, sizeForm);
      };
      launcher.MouseUp += (s, a) =>
      {
        expandForm = DataClass.Expand.Nope;
        expand = false;
      };

      DataClass.sizeForm = new Size(DataClass.screenSize.Width, DataClass.screenSize.Height);
      DataClass.locationForm = new DataClass.Location(launcher.Location.X, launcher.Location.Y);
    }

    /// <summary>
    /// Обновление элементов в лаунчере.
    /// </summary>
    /// <param name="launcher">Экземпляр формы</param>
    public void UpdateLauncher(Form launcher)
    {
      DataClass.appsElementLauncher = new List<Panel>();
      DataClass.mainAppsLauncher = new List<ScrollBarElement>();
      DataClass.categoryElementLauncher = new List<TextElement>();
      DataClass.controlAddApp = new List<ControlAddElement>();

      try
      {
        if (FontElements.FontCategory.Name.Contains("Parameter is not valid"))
          new SettingsForms().UpdateLauncher(DataClass.launcher);
      }
      catch
      {
        FontElements.UpdateFont();
      }

      launcher.Controls.Clear();
      launcher.Hide();
      DataClass.appsElementLauncher.Clear();
      new BackUpClass().SetCategory();
      new CreateElementsLauncherForm().LoadElements(launcher);
      new DesignElements().LoadDesignLauncher();
      Thread.Sleep(100);
      launcher.Show();
    }

    /// <summary>
    /// Настройки формы добавления приложений, категорий.
    /// </summary>
    /// <param name="functional"></param>
    public void SettingsFunctionalForm(Form functional)
    {
      functional.Width = 400;
      functional.FormBorderStyle = FormBorderStyle.None;
      functional.StartPosition = FormStartPosition.CenterScreen;
    }

    /// <summary>
    /// Настройки формы выбора обложки для приложения.
    /// </summary>
    /// <param name="imageSelection">Экземпляр формы</param>
    public void SettingsImageForm(Form imageSelection)
    {
      //imageSelection.Size = new Size((DataClass.sizeAppElement.Width * 5) + (10 * 4) + 80, (DataClass.sizeAppElement.Height * 2) + (22 * 1) + 120);
      imageSelection.Size = new Size(600, 600);
      imageSelection.StartPosition = FormStartPosition.CenterScreen;
      imageSelection.Text = "Выбор обложки";
      imageSelection.FormBorderStyle = FormBorderStyle.None;
      //
    }

    /// <summary>
    /// Настройка формы загрузки приложения.
    /// </summary>
    /// <param name="loadForm"></param>
    public void SettingsLoadForm(Form loadForm)
    {
      loadForm.Size = new Size(408, 150);
      loadForm.FormBorderStyle = FormBorderStyle.None;
      loadForm.Location = new Point((DataClass.screenSize.Width - loadForm.Width) / 2, ((DataClass.screenSize.Height - loadForm.Height) / 2));
      loadForm.BackColor = BackColorElements.HoverBackColorCategory;
    }

    /// <summary>
    /// Расчёт локации элементов с приложениями.
    /// </summary>
    public void LocationApps()
    {
      //DataClass.activeAppPanelLauncher.LocationApps();
    }

    /// <summary>
    /// Размер панели с элементамии приложений.
    /// </summary>
    public void SizeElements()
    {
      DataClass.categoriesElementLauncher.Height = DataClass.sizeForm.Height - DataClass.topElementLauncher.Height - DataClass.borderFormWidth;
      DataClass.activeAppPanelLauncher.Resize(DataClass.sizeForm.Width - DataClass.categoriesElementLauncher.Width - DataClass.borderFormWidth, DataClass.categoriesElementLauncher.Height);
    }
  }
}
