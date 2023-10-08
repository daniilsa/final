using Launcher.Controls;
using LauncherNet._Data;
using LauncherNet._DataStatic;
using LauncherNet._Front;
using LauncherNet.BackUp;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Elements.LauncherElements;
using LauncherNet.Front;
using LauncherNet.Functions;

namespace LauncherNet.Settings
{
  public class SettingsForms
  {

    private bool openProgramm = true;
    private bool expand = false;
    private Point startPoint = new(0, 0);
    private Size sizeForm;
    private DataStruct.Location locationForm;

    /// <summary>
    /// Настройка формы лаунчера.
    /// </summary>
    /// <param name="value">"Экземпляр формы</param>
    public void SettingsLauncherForm(Form value)
    {
      DataEnum.Expand expandForm = DataEnum.Expand.Nope;

      value.Size = new Size(700, 600);
      value.MinimumSize = new Size(700, 600);
      value.WindowState = FormWindowState.Maximized;
      value.Text = "Launcher";
      value.FormBorderStyle = FormBorderStyle.None;
      value.KeyPreview = true;
      value.KeyDown += (s, a) =>
      {
        if (s != null)
          new HotKeys().CheckKeys(s, a);
      };
      value.LostFocus += (s, a) =>
      {
        if (openProgramm)
        {
          value.Activate();
          value.Focus();
          openProgramm = false;
        }
      };
      value.SizeChanged += (s, a) =>
      {
        DataLauncherForm.sizeMainForm = value.Size;
        if (DataLauncherForm.activeAppPanelLauncher != null)
        {
          if (DataLauncherForm.categoriesElementLauncher != null)
          {
            DataLauncherForm.activeAppPanelLauncher.Width = DataLauncherForm.sizeMainForm.Width - DataLauncherForm.categoriesElementLauncher.Width - DataClass.borderFormWidth;
          }
          else
          {
            DataLauncherForm.activeAppPanelLauncher.Width = DataLauncherForm.sizeMainForm.Width - DataClass.borderFormWidth;
          }
          new SizeSettings().SizeElements();

          value.TopMost = true;
          value.TopMost = false;
        }
      };
      value.LocationChanged += (s, a) => DataLauncherForm.locationMainForm = new DataStruct.Location(value.Location.X, value.Location.Y);
      value.FormClosing += (s, a) =>
      {
        new LastSessionClass().SetCategory();
        if (DataClass.iconLauncher != null)
          new Tray().FromTray(DataClass.iconLauncher);
      };
      value.MouseEnter += (s, a) =>
      {

        int pointX = Cursor.Position.X;
        int pointY = Cursor.Position.Y;

        DataStruct.Location locationForm = DataLauncherForm.locationMainForm;
        Size sizeForm = DataLauncherForm.sizeMainForm;

        if (DataLauncherForm.launcher != null && DataLauncherForm.launcher.WindowState != FormWindowState.Maximized)
        {
          if (pointX <= locationForm.X + 3 && pointY > locationForm.Y + sizeForm.Height - 3)
          {
            value.Cursor = Cursors.SizeNESW;
            expandForm = DataEnum.Expand.LeftBottom;
          }
          else if (pointX >= locationForm.X + DataLauncherForm.sizeMainForm.Width - 3 && pointY > locationForm.Y + sizeForm.Height - 3)
          {
            value.Cursor = Cursors.SizeNWSE;
            expandForm = DataEnum.Expand.RightBottom;
          }
          else if (pointX <= locationForm.X + 3)
          {
            value.Cursor = Cursors.SizeWE;
            expandForm = DataEnum.Expand.Left;
          }
          else if (pointX >= locationForm.X + DataLauncherForm.sizeMainForm.Width - 3)
          {
            value.Cursor = Cursors.SizeWE;
            expandForm = DataEnum.Expand.Right;
          }
          else if (pointY > locationForm.Y + sizeForm.Height - 3)
          {
            value.Cursor = Cursors.SizeNS;
            expandForm = DataEnum.Expand.Bottom;
          }
        }
      };
      value.MouseLeave += (s, a) =>
      {
        value.Cursor = Cursors.Default;
        expandForm = DataEnum.Expand.Nope;
      };
      value.MouseDown += (s, a) =>
      {
        startPoint = Cursor.Position;
        sizeForm = value.Size;
        locationForm = new DataStruct.Location(value.Location.X, value.Location.Y);
        expand = true;
      };
      value.MouseMove += (s, a) =>
      {
        new SizeSettings().ResizeForm(expandForm, expand, startPoint, locationForm, sizeForm);
      };
      value.MouseUp += (s, a) =>
      {
        expandForm = DataEnum.Expand.Nope;
        expand = false;
      };

      DataLauncherForm.sizeMainForm = new Size(DataClass.screenSize.Width, DataClass.screenSize.Height);
      DataLauncherForm.locationMainForm = new DataStruct.Location(value.Location.X, value.Location.Y);
    }

    /// <summary>
    /// Обновление элементов в лаунчере.
    /// </summary>
    /// <param name="value">Экземпляр формы</param>
    public void UpdateLauncher(Form value)
    {
      new CheckingFiles().CheckingChangesFiles();
      DataLauncherForm.appsElementLauncher = new List<Panel>();
      DataLauncherForm.mainAppsLauncher = new List<ScrollBarControl>();
      DataLauncherForm.categoryElementLauncher = new List<TextControl>();
      DataLauncherForm.controlAddApp = new List<ControlAddControl>();

      try
      {
        if (DataLauncherForm.launcher != null && FontElements.FontCategory.Name.Contains("Parameter is not valid"))
          new SettingsForms().UpdateLauncher(DataLauncherForm.launcher);
      }
      catch
      {
        FontElements.UpdateFont();
      }

      value.Controls.Clear();
      DataLauncherForm.appsElementLauncher.Clear();
      new LastSessionClass().SetCategory();
      new CreateElementsLauncherForm().LoadElements(value);
      new DesignLauncherForm().LoadDesignLauncher();
      Thread.Sleep(100);
    }

    /// <summary>
    /// Настройки формы добавления приложений, категорий.
    /// </summary>
    /// <param name="value"></param>
    public void SettingsFunctionalForm(Form value)
    {
      value.Width = 400;
      value.FormBorderStyle = FormBorderStyle.None;
      value.StartPosition = FormStartPosition.CenterScreen;
    }

    /// <summary>
    /// Настройки формы выбора обложки для приложения.
    /// </summary>
    /// <param name="value">Экземпляр формы</param>
    public void SettingsImageForm(Form value)
    {
      value.Size = new Size(600, 600);
      value.StartPosition = FormStartPosition.CenterScreen;
      value.Text = "Выбор обложки";
      value.FormBorderStyle = FormBorderStyle.None;
      //
    }

    /// <summary>
    /// Настройка формы загрузки приложения.
    /// </summary>
    /// <param name="value"></param>
    public void SettingsLoadForm(Form value)
    {
      value.Size = new Size(408, 150);
      value.FormBorderStyle = FormBorderStyle.None;
      value.Location = new Point((DataClass.screenSize.Width - value.Width) / 2, (DataClass.screenSize.Height - value.Height) / 2);
      value.BackColor = BackColorElements.AdditionalDarkColor;
    }

    /// <summary>
    /// Настройки формы помощи.
    /// </summary>
    /// <param name="value"></param>
    public void SettingsHelpForm(Form value)
    {
      value.FormBorderStyle = FormBorderStyle.None;
      value.Size = new(800, 600);
      value.StartPosition = FormStartPosition.CenterScreen;
      value.FormClosed += (s, a) =>
        {
          DataHelpForm.helpForm = null;
        };
    }
  }
}
