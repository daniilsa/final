using Launcher.Controls;
using LauncherNet.DesignFront;
using LauncherNet.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LauncherNet.Front
{
  public class DesignElements
  {
    /// <summary>
    /// Настраивает внешний вид всех элементов на форме.
    /// </summary>
    public void Load()
    {
      try
      {
        if (FontElements.FontCategory.Name.Contains("Parameter is not valid")) 
          new SettingsForms().UpdateLauncher(DataClass.launcher);
        else
        {
          DesignForm(DataClass.launcher);
          DesignTopElement(DataClass.topElement);
          DesignCategoriesElement(DataClass.categoriesElement);

          if (DataClass.categoryElement != null)
            foreach (TextElement value in DataClass.categoryElement)
            {
              DesignCategoryElement(value);
            }

          if (DataClass.mainAppsControl != null)
            foreach (Panel value in DataClass.mainAppsControl)
            {
              DesignAppsElement(value);
            }
        }
      }
      catch
      {
        
        new SettingsForms().UpdateLauncher(DataClass.launcher);
      }
    }

    /// <summary>
    /// Настраивает внешний вид формы.
    /// </summary>
    private void DesignForm(Form value)
    {
      value.BackColor = BackColorElements.BackColorForm;
    }

    /// <summary>
    /// Настраивает внешний вид верхней панели.
    /// </summary>
    private void DesignTopElement(Panel value)
    {
      value.BackColor = BackColorElements.BackColorTopElement;
    }

    /// <summary>
    /// Настраивает внешний вид  элемента со всеми категориями.
    /// </summary>
    private void DesignCategoriesElement(Panel value)
    {
      value.BackColor = BackColorElements.BackColorCategoriesElement;
    }

    /// <summary>
    /// Настраивает внешний вид элемента категории.
    /// </summary>
    private void DesignCategoryElement(TextElement value)
    {
      value.Font = FontElements.FontCategory;
      value.ForeColor = FontElements.DefaultForeColorCategory;

      value.MouseEnter += (s, e) =>
      {
        if (value != DataClass.activeCategoryPanel) value.BackColor = BackColorElements.HoverBackColorCategory;
      };
      value.MouseLeave += (s, e) =>
      {
        if (value != DataClass.activeCategoryPanel) value.BackColor = BackColorElements.DefaultBackColorCategory;
      };
      value.MouseDown += (s, e) =>
      {
        DataClass.lastCategoryPanel.ForeColor = FontElements.DefaultForeColorCategory;
        DataClass.lastCategoryPanel.BackColor = BackColorElements.DefaultBackColorCategory;
        value.BackColor = BackColorElements.ActiveBackColorCategory;
        value.ForeColor = FontElements.ActiveForeColorCategory;
      };

      if (DataClass.activeCategoryPanel != null)
      {
        DataClass.activeCategoryPanel.ForeColor = FontElements.ActiveForeColorCategory;
        DataClass.activeCategoryPanel.BackColor = BackColorElements.ActiveBackColorCategory;
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента со всеми приложениями.
    /// </summary>
    private void DesignAppsElement(Panel value)
    {
      value.BackColor = BackColorElements.BackColorMainApps;
      foreach (Panel panel in value.Controls)
      {
        DesignAppElement(panel);
      }
    }

    /// <summary>
    /// Настраивает внешний вид элемента с приложением.
    /// </summary>
    private void DesignAppElement(Panel value)
    {
      if (value.Controls[0].GetType() == new PictureBox().GetType() && value.Controls[1].GetType() == new TextElement().GetType())
      {

        PictureBox picture = value.Controls[0] as PictureBox;
        picture.BackgroundImageLayout = ImageLayout.Zoom;
        picture.BackColor = BackColorElements.BackColorAppElement;

        string pathFile = DataClass.categoriesPathFiles + "\\" + picture.Tag.ToString();
        string pathImages = DataClass.pathImages + "\\" + picture.Tag.ToString() + "\\";

        if (File.Exists(pathImages + picture.Name + ".jpg"))
        {

          using (var imgStream = File.OpenRead(pathImages + picture.Name + ".jpg"))
          {
            picture.BackgroundImage = Image.FromStream(imgStream);
          }
        }
        else
        {
          try
          {
            using (var imgStream = File.OpenRead(@$"{DataClass.pathImages}\Default.jpg"))
            {
              picture.BackgroundImage = Image.FromStream(imgStream);
            }
          }
          catch
          {
            picture.BackColor = Color.Red;
          }
        }

        TextElement text = value.Controls[1] as TextElement;
        text.BackColor = BackColorElements.DefaultBackColorTextApp;
        text.Font = FontElements.FontApp;
        text.ForeColor = FontElements.ForeColorApp;
      }
    }

  }
}
