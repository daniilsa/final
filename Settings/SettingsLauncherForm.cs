using LauncherNet._Data;
using LauncherNet.BackUp;
using LauncherNet.Functions;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LauncherNet._Data.DataEnum;

namespace LauncherNet.Settings
{
  internal class SettingsLauncherForm
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
    public void SettingsForm(Form value)
    {
      SettingsSize(value);
      FirstSettings(value);
      Mouse(value);
      Key(value);

  


      DataLauncherForm.sizeMainForm = new Size(DataClass.screenSize.Width, DataClass.screenSize.Height);
      DataLauncherForm.locationMainForm = new DataStruct.Location(value.Location.X, value.Location.Y);
    }

    /// <summary>
    /// Первоначальные настройки формы.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    private void FirstSettings(Form value)
    {
      value.WindowState = FormWindowState.Maximized;
      value.Text = "Launcher";
      value.FormBorderStyle = FormBorderStyle.None;
      value.LostFocus += (s, a) =>
      {
        if (openProgramm)
        {
          value.Activate();
          value.Focus();
          openProgramm = false;
        }
      };
      value.LocationChanged += (s, a) => DataLauncherForm.locationMainForm = new DataStruct.Location(value.Location.X, value.Location.Y);
      value.FormClosing += (s, a) =>
      {
        new LastSessionClass().SetCategory();
        if (DataClass.iconLauncher != null)
          new Tray().FromTray(DataClass.iconLauncher);
      };
    }

    /// <summary>
    /// Настройка размеров формы.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    private void SettingsSize(Form value)
    {
      value.Size = new Size(700, 600);
      value.MinimumSize = new Size(700, 600);
      value.MaximumSize = DataClass.screenSize;
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
    }

    /// <summary>
    /// Отработка событий клавиш.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    private void Key(Form value)
    {
      value.KeyPreview = true;
      value.KeyDown += (s, a) =>
      {
        if (s != null)
          new HotKeys().CheckKeys(s, a);
      };

    }

    /// <summary>
    /// Отработка событий мыши.
    /// </summary>
    /// <param name="value">"Экземпляр формы.</param>
    private void Mouse(Form value)
    {
      DataEnum.Expand expandForm = DataEnum.Expand.Nope;
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
    }

  }
}
