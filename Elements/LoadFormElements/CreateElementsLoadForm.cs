namespace LauncherNet.Elements.LoadFormElements
{
  public class CreateElementsLoadForm
  {

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="loadForm">Экземляр формы.</param>
    public void LoadElements(Form loadForm)
    {
      Panel mainPanel = new MainElement().CreateMainElement(loadForm);
      loadForm.Controls.Add(mainPanel);
    }
  }
}
