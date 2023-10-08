using LauncherNet._Front;
using LauncherNet.Elements.ImageFormElements;
using LauncherNet.Settings;

namespace LauncherNet.Forms
{
  public partial class ImageSelectionForm : Form
  {
    /// <summary>
    /// Возвращает или задаёт имя приложения.
    /// </summary>
    public string NameFile { get; set; }

    /// <summary>
    /// Возвращает или задаёт имя категории.
    /// </summary>
    public string NameCategory { get; set; }

    /// <summary>
    /// Загрузка формы.
    /// </summary>
    public new void Load()
    {
      bool next = true;
      new SettingsForms().SettingsImageForm(this);
      new CreateElementsImageForm().LoadElements(this, NameCategory, NameFile, ref next);
      if (!next)
      {
        DataClass.InternetСonnection = false;
        Close();
      }
      new DesignImageSelectionForm().LoadDesignImageSelection();
    }

    /// <summary>
    /// Первоначальная настройка формы.
    /// </summary>
    public ImageSelectionForm()
    {
      InitializeComponent();
      DoubleBuffered = true;
      NameFile = string.Empty;
      NameCategory = string.Empty;
    }
  }
}
