using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LauncherNet.DataClass;

namespace LauncherNet.Settings
{
  public  class SizeForm
  {

    public async void ResizeForm(DataClass.Expand expandForm, bool expand, Point startPoint, Location locationForm, Size sizeForm )
    {
      if (expandForm != DataClass.Expand.Nope && expand)
      {
        
        if (expandForm == DataClass.Expand.Left)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          //differenceWidth = DataClass.sizeAppElement.Width*2*(-1);
          
          DataClass.launcher.Size = new Size(sizeForm.Width - differenceWidth, DataClass.launcher.Size.Height);
          if (DataClass.launcher.Size.Width > DataClass.launcher.MinimumSize.Width)
            DataClass.launcher.Location = new Point(locationForm.X + differenceWidth, DataClass.launcher.Location.Y);
        }
        else if (expandForm == DataClass.Expand.Right)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          DataClass.launcher.Size = new Size(sizeForm.Width + differenceWidth, DataClass.launcher.Size.Height);
        }
        else if (expandForm == DataClass.Expand.Bottom)
        {
          int differenceHeight = Cursor.Position.Y - startPoint.Y;
          DataClass.launcher.Size = new Size(DataClass.launcher.Width, sizeForm.Height + differenceHeight);
        }
        else if (expandForm == DataClass.Expand.RightBottom)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          int differenceHeight = Cursor.Position.Y - startPoint.Y;
          DataClass.launcher.Size = new Size(sizeForm.Width + differenceWidth, sizeForm.Height + differenceHeight);
        }
        else if (expandForm == DataClass.Expand.LeftBottom)
        {
          int differenceWidth = Cursor.Position.X - startPoint.X;
          int differenceHeight = Cursor.Position.Y - startPoint.Y;
          DataClass.launcher.Size = new Size(sizeForm.Width - differenceWidth, sizeForm.Height + differenceHeight);
          if (DataClass.launcher.Size.Width > DataClass.launcher.MinimumSize.Width)
            DataClass.launcher.Location = new Point(locationForm.X + differenceWidth, DataClass.launcher.Location.Y);
        }
      }

    }
  }
}
