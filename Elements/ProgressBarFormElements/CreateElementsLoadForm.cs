using LauncherNet._Data;

namespace LauncherNet.Elements.ProgressBarForm
{
  public class CreateElementsLoadForm
  {

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="loadForm">Экземляр формы.</param>
    public void LoadElements(Form loadForm, string text)
    {
      Panel mainPanel = new MainElement().CreateMainElement(loadForm, text);
      DataLoadForm.Form = loadForm;
      loadForm.Controls.Add(mainPanel);
    }
  }
}
