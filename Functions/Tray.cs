namespace LauncherNet.Functions
{
  public class Tray
  {
    /// <summary>
    /// Сворачивает приложение в трей.
    /// </summary>
    /// <param name="icon"></param>
    public void InTray(NotifyIcon? icon)
    {
      if (icon != null)
      {
        if (icon.Visible != true && DataClass.launcher!=null)
        {
          DataClass.launcher.ShowInTaskbar = false;
          DataClass.launcher.Hide();
          icon.Visible = true;
        }
      }
    }

    /// <summary>
    /// Разворачивает приложение из трэя.
    /// </summary>
    /// <param name="icon"></param>
    public void FromTray(NotifyIcon? icon)
    {
      if (icon != null)
      {
        try
        {
          if (DataClass.launcher != null && icon.Visible != false)
          {
            DataClass.launcher.ShowInTaskbar = true;
            DataClass.launcher.Show();
            icon.Visible = false;
          }
        }
        catch
        {
          // Что-тро ругается, когда закрываем приложение)
        }
      }
    }

    /// <summary>
    /// Возвращает элемент трея.
    /// </summary>
    /// <returns></returns>
    public NotifyIcon CreateTrayElement()
    {

      NotifyIcon icon = new()
      {
        Text = "Launcher",
        Icon = new Icon(@$"{DataClass.pathFiles}\IconLauncher.ico")
      };
      ContextMenuStrip? contextMenuStrip = CreateContextMenuStrip(icon);

      icon.MouseDoubleClick += (s, a) => FromTray(icon);
      icon.MouseDown += (s, a) =>
      {
        if (a.Button == MouseButtons.Right)
        {
          contextMenuStrip.Show(Cursor.Position);
        }
      };

      return icon;
    }

    /// <summary>
    /// Возвращает элемент контекстного меню у Tray.
    /// </summary>
    /// <param name="icon"></param>
    /// <returns></returns>
    private ContextMenuStrip? CreateContextMenuStrip(NotifyIcon? icon)
    {
      if (icon != null)
      {
        ContextMenuStrip menuStrip = new ContextMenuStrip();
        menuStrip.Items.Add("Открыть");
        menuStrip.Items.Add("Добавить категорию");
        menuStrip.Items.Add("Выход");

        menuStrip.Items[0].MouseDown += (s, a) => FromTray(icon);

        if (DataClass.launcher != null)
          menuStrip.Items[1].MouseDown += (s, a) => new FunctionsCategories().StartFunction(DataClass.launcher, DataClass.FunctionCategory.AddCategory, null, null);
      
        menuStrip.Items[2].MouseDown += (s, a) =>
        {
          icon.Visible = false;
          Application.Exit();
        };

        return menuStrip;
      }
      return null;
    }

  }
}
