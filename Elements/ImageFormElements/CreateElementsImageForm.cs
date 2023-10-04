using Launcher.Controls;
using LauncherNet.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Front;
using LauncherNet.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    public void LoadElements(Form imageForm, string nameCategory, string nameFile)
    {
      DataClass.imageSelectionForm = imageForm;
      DataClass.locationImage = string.Empty;
      Panel mainPanel = new ImageSelectionElement().CreateImageSelection(nameFile);
      Panel bottomPanel = new BottomElement().CreateBottomElement(imageForm, mainPanel, nameFile, nameCategory);

      DataClass.mainAppsSelectionForm = mainPanel;
      DataClass.bottomElementSelectionForm = bottomPanel;

      imageForm.Controls.Add(mainPanel);
    }
  }
}
