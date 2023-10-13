using LauncherNet._Data;
using LauncherNet._Front;
using LauncherNet.Elements.SettingsApplicationFormElements;
using LauncherNet.Settings;
using System.Windows.Forms;

namespace LauncherNet.Forms
{
  public partial class SettingsApplicationForm : Form
  {
    public SettingsApplicationForm(string? text, bool startApplication)
    {
      InitializeComponent();
      Load(text, startApplication);
    }

    private new async void Load(string? text, bool startApplication)
    {
      new SettingsAuxiliaryForms().SettingUpFormWithApplicationSettings(this);
      if (startApplication)
      {
        new CreateElementsSettingsApplicationForm().CreateElementsDownloadForm(this, text);
        DataSettingsApplicationForm.Form = this;
        new DesignSettingsApplicationForm().LoadDesignSettingsApplicationForm(false);
        await Task.Delay(1000);
        Thread start = new Thread(() => StartForm());
        start.Start();
        await Task.Delay(3000);

        new CreateElementsSettingsApplicationForm().SetText(this, "Давайте настроем всё под ВАС", new Font(DataSettingsApplicationForm.HelloText.Font.FontFamily, DataSettingsApplicationForm.HelloText.Font.Size - 5));
        await Task.Delay(3000);
      }
      StratFormSettings();
    }

    private async void StartForm()
    {
      DataSettingsApplicationForm.Form?.Invoke(() =>
      {
        DataSettingsApplicationForm.Form.Opacity = 0;
      });
      if (DataSettingsApplicationForm.HelloText != null)
      {
        double i = 0;
        while (i <= 1)
        {
          await Task.Delay(1);
          DataSettingsApplicationForm.Form?.Invoke(() =>
          {
            DataSettingsApplicationForm.Form.Opacity = i;
          });
          i += 0.05;

        }
        await Task.Delay(1);
        DataSettingsApplicationForm.Form?.Invoke(() =>
        {
          DataSettingsApplicationForm.Form.Opacity = 1;
        });

      }
      else return;

    }

    private void StratFormSettings()
    {
      DataSettingsApplicationForm.Form = this;
      new CreateElementsSettingsApplicationForm().CreaeteElementForm(this);

    }

  }
}
