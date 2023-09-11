using Launcher.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherNet.Design
{
  static public class DesignLauncherForm
  {
    #region Поля

    /// <summary>
    /// Цвет панели категории по умолчанию.
    /// </summary>
    static private Color _defaultColorCategory = Color.Green;

    /// <summary>
    /// Цвет панели категории при наведении мыши на элемент.
    /// </summary>
    static private Color _hoverColorCategory = Color.Yellow;

    /// <summary>
    /// Цвет панели категории при клике мыши на элемент.
    /// </summary>
    static private Color _clickColorCategory = Color.Red; 

    #endregion

    #region Свойства

    /// <summary>
    /// Задаёт значение цвета панели по умолчанию.
    /// </summary>
    static public Color DefaultColorCategory { set { _defaultColorCategory = value; } }

    /// <summary>
    /// Задаёт значение цвета при наведение мыши на элемент.
    /// </summary>
    static public Color HoverColorCategory { set { _hoverColorCategory = value; } }

    /// <summary>
    /// Задаёт значение цвета при клике на элемент.
    /// </summary>
    static public Color ClickColorCategory { set { _clickColorCategory = value; } }

    #endregion

    #region Методы

    /// <summary>
    /// Устанавливает цвет фона элемента при наведении сыши на элемент.
    /// </summary>
    /// <param name="value"></param>
    static public void SetHoverСolorCategory(CategoryPanelControl value)
    {
      value.BackColor = _hoverColorCategory;
    }

    /// <summary>
    /// Устанавливает цвет фона при клике на элемент.
    /// </summary>
    /// <param name="value"></param>
    static public void SetClickColorCategoryMethod(CategoryPanelControl value)
    {
      value.BackColor = _clickColorCategory;
    }

    /// <summary>
    /// Устанавливает цвет фона элемента по умолчанию.
    /// </summary>
    /// <param name="value"></param>
    static public void ResetColor(CategoryPanelControl value)
    {
      value.BackColor = _defaultColorCategory;
    } 

    #endregion





  }
}
