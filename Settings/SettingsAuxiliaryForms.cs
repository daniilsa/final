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
  /// <summary>
  /// Настройки вспомогтальных форм.
  /// </summary>
  public class SettingsAuxiliaryForms
  {

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
      value.Size = new Size(408, 170);
      value.Location = new Point((DataClass.screenSize.Width - value.Width) / 2, (DataClass.screenSize.Height - value.Height) / 2);
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

    public void SettingUpFormWithApplicationSettings(Form value)
    {
      value.FormBorderStyle = FormBorderStyle.None;
      value.Size = new(800, 600);
      value.StartPosition = FormStartPosition.CenterScreen;

    }
  }
}
