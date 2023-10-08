using LauncherNet._Data;

namespace LauncherNet.Settings
{
  public class SizeSettings
  {
    /// <summary>
    /// Изменение размеров формы
    /// </summary>
    /// <param name="expandForm">Граница изменения формы.</param>
    /// <param name="expand">Триггер изменения формы.</param>
    /// <param name="startPoint">Расположение курсора.</param>
    /// <param name="locationForm">Локация формы.</param>
    /// <param name="sizeForm">Размер формы.</param>
    public void ResizeForm(DataEnum.Expand expandForm, bool expand, Point startPoint, DataStruct.Location locationForm, Size sizeForm)
    {
      if (expandForm != DataEnum.Expand.Nope && expand && DataLauncherForm.launcher != null)
      {

        if (expandForm == DataEnum.Expand.Left)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          //differenceWidth = DataClass.sizeAppElement.Width*2*(-1);

          DataLauncherForm.launcher.Size = new Size(sizeForm.Width - differenceWidth, DataLauncherForm.launcher.Size.Height);
          if (DataLauncherForm.launcher.Size.Width > DataLauncherForm.launcher.MinimumSize.Width)
            DataLauncherForm.launcher.Location = new Point(locationForm.X + differenceWidth, DataLauncherForm.launcher.Location.Y);
        }
        else if (expandForm == DataEnum.Expand.Right)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          DataLauncherForm.launcher.Size = new Size(sizeForm.Width + differenceWidth, DataLauncherForm.launcher.Size.Height);
        }
        else if (expandForm == DataEnum.Expand.Bottom)
        {
          int differenceHeight = Cursor.Position.Y - startPoint.Y;
          DataLauncherForm.launcher.Size = new Size(DataLauncherForm.launcher.Width, sizeForm.Height + differenceHeight);
        }
        else if (expandForm == DataEnum.Expand.RightBottom)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          int differenceHeight = Cursor.Position.Y - startPoint.Y;
          DataLauncherForm.launcher.Size = new Size(sizeForm.Width + differenceWidth, sizeForm.Height + differenceHeight);
        }
        else if (expandForm == DataEnum.Expand.LeftBottom)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          int differenceHeight = Cursor.Position.Y - startPoint.Y;
          DataLauncherForm.launcher.Size = new Size(sizeForm.Width - differenceWidth, sizeForm.Height + differenceHeight);
          if (DataLauncherForm.launcher.Size.Width > DataLauncherForm.launcher.MinimumSize.Width)
            DataLauncherForm.launcher.Location = new Point(locationForm.X + differenceWidth, DataLauncherForm.launcher.Location.Y);
        }
      }

    }

    /// <summary>
    /// Размер панели с элементамии приложений.
    /// </summary>
    public void SizeElements()
    {
      if (DataLauncherForm.categoriesElementLauncher != null && DataLauncherForm.topElementLauncher != null)
      {
        DataLauncherForm.categoriesElementLauncher.Height = DataLauncherForm.sizeMainForm.Height - DataLauncherForm.topElementLauncher.Height - DataClass.borderFormWidth;
        DataLauncherForm.activeAppPanelLauncher?.Resize(DataLauncherForm.sizeMainForm.Width - DataLauncherForm.categoriesElementLauncher.Width - DataClass.borderFormWidth, DataLauncherForm.categoriesElementLauncher.Height);
      }
    }
  }
}
