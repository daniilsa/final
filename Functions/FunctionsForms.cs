namespace LauncherNet.Functions
{
  internal class FunctionsForms
  {
    /// <summary>
    /// Свернуть приложение.
    /// </summary>
    /// <param name="value">Экземпляр формы.</param>
    public void HideTheForm(Form value)
    {
      value.WindowState = FormWindowState.Minimized;
    }

    /// <summary>
    /// Развернуть форму на весь экран.
    /// </summary>
    /// <param name="value">Экземпляр формы.</param>
    public void ExpandTheForm(Form value)
    {
      if (value.WindowState == FormWindowState.Maximized) value.WindowState = FormWindowState.Normal;
      else value.WindowState = FormWindowState.Maximized;
    }

    /// <summary>
    /// Закрывает форму.
    /// </summary>
    /// <param name="value">Экземпляр формы.</param>
    public void CloseForm(Form value)
    {
      value.Close();
    }

    /// <summary>
    /// Закрывает программу.
    /// </summary>
    public void ExitProgramm()
    {
      if (DataClass.TrayActive)
        new Tray().InTray(DataClass.iconLauncher);
      else Application.Exit();
    }
  }
}
