using LauncherNet._Data;

namespace LauncherNet.Elements.ImageFormElements
{
  public class CreateElementsImageForm
  {

    /// <summary>
    /// Загрузка элементов на форму.
    /// </summary>
    /// <param name="imageForm">Экземляр формы.</param>
    /// <param name="nameCategory">Имя категории.</param>
    /// <param name="nameFile">Имя добавляемого файла.</param>
    public void LoadElements(Form imageForm, string nameCategory, string nameFile, ref bool next)
    {
      DataImageSelectionForm.imageSelectionForm = imageForm;
      DataLauncherForm.locationImage = string.Empty;
      Panel? mainPanel = new ImageSelectionElement().CreateImageSelection(nameFile, ref next);
      if (!next) return;

      Panel bottomPanel = new BottomElement().CreateBottomElement(imageForm, mainPanel, nameFile, nameCategory);

      DataImageSelectionForm.mainAppsSelectionForm = mainPanel;
      DataImageSelectionForm.bottomElementSelectionForm = bottomPanel;

      imageForm.Controls.Add(mainPanel);
    }
  }
}
