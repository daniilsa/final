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

    private void Exit()
    {
      testElement1.ForeColor = Color.White;
      testElement1.BackColor = Color.Black;
      testElement1.Location = new Point(10, 10);
      testElement1.ChoiceElement = BorderButtonElement.Choice.Exit;

      testElement2.ForeColor = Color.White;
      testElement2.BackColor = Color.Black;
      testElement2.Location = new Point(testElement1.Location.X + testElement1.Width + 20, 10);
      testElement2.ChoiceElement = BorderButtonElement.Choice.Minimaze;

      testElement3.ForeColor = Color.White;
      testElement3.BackColor = Color.Black;
      testElement3.Location = new Point(testElement2.Location.X + testElement2.Width + 20, 10);
      testElement3.ChoiceElement = BorderButtonElement.Choice.Maximaze;
    }

    private void TestForm_Load_1(object sender, EventArgs e)
    {
      Exit();
    }
  }
}
