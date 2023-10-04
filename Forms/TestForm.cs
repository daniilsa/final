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

    }

    private void TestForm_Load_1(object sender, EventArgs e)
    {
      this.FormBorderStyle = FormBorderStyle.None;
      Test();
      contextMenuStrip1.Renderer = new MyRenderer();
    }

    private void button1_MouseDown(object sender, MouseEventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {


    }

    private void toolStripButton1_MouseEnter(object sender, EventArgs e)
    {
      ToolStripItem tsi = (ToolStripItem)sender;

      // Create semi-transparent picture.
      Bitmap bm = new Bitmap(tsi.Width, tsi.Height);
      for (int y = 0; y < tsi.Height; y++)
      {
        for (int x = 0; x < tsi.Width; x++)
          bm.SetPixel(x, y, Color.FromArgb(150, Color.White));
      }

      // Set background.
      tsi.BackgroundImage = bm;
    }

    private void toolStripButton1_CheckStateChanged(object sender, EventArgs e)
    {
    }


    private class MyRenderer : ToolStripProfessionalRenderer
    {
      public MyRenderer() : base(new MyColors()) { }
    }

    private class MyColors : ProfessionalColorTable
    {
      public override Color MenuItemSelected
      {
        get { return Color.Yellow; }
      }
      public override Color MenuItemSelectedGradientBegin
      {
        get { return Color.Orange; }
      }
      public override Color MenuItemSelectedGradientEnd
      {
        get { return Color.Yellow; }
      }
    }

    private void toolStripLabel2_MouseEnter(object sender, EventArgs e)
    {
      ToolStripItem tsi = (ToolStripItem)sender;

      // Create semi-transparent picture.
      Bitmap bm = new Bitmap(tsi.Width, tsi.Height);
      for (int y = 0; y < tsi.Height; y++)
      {
        for (int x = 0; x < tsi.Width; x++)
          bm.SetPixel(x, y, Color.FromArgb(150, Color.Red));
      }

      // Set background.
      tsi.BackgroundImage = bm;
    }

    private void button2_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
        contextMenuStrip1.Show(button2, button2.Width, 0);
    }
  }
}
