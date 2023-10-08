namespace LauncherNet.Elements.HelpElements
{
  internal class CreateElementsHelpForm
  {
    /// <summary>
    /// Загрузка всех эллементов на форму.
    /// </summary>
    /// <param name="value"></param>
    public void LoadElements(Form value)
    {
      Panel topPanel = new TopPanel().CreateTopPanel(value);
      Panel? categoriesPanel = new CategoriesElement().CreateCategoriesElement();

      value.Controls.Add(topPanel);
      value.Controls.Add(categoriesPanel);
    }
  }
}
