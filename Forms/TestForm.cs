using Launcher.Controls;
using LauncherNet.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherNet.Forms
{
  public partial class TestForm : Form
  {
    public TestForm()
    {
      InitializeComponent();
    }

    private void Test()
    {
      this.BackColor = Color.Black;
      ControlAddElement controlAddElement = new ControlAddElement();
      controlAddElement.Location = new Point(0, 0);
      controlAddElement.Size = new Size(400, 200);

      this.Controls.Add(controlAddElement);
    }

    private void TestForm_Load_1(object sender, EventArgs e)
    {
      this.FormBorderStyle = FormBorderStyle.None;
      Test();
    }

  }
}
