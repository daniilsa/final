using LauncherNet.DesignFront;
using LauncherNet.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
