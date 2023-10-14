using LauncherNet.DesignFront;
using LauncherNet.Front;

namespace LauncherNet.Forms
{
  public partial class TestForm : Form
  {

    public TestForm()
    {
      InitializeComponent();
      Test();
    }

    private void Test()
    {
      this.Size = new(400, 400);

     HelpProvider helpProvider = new HelpProvider();
      
    }

    private void TestForm_Load_1(object sender, EventArgs e)
    {
      this.FormBorderStyle = FormBorderStyle.None;
      Test();
    }

    private void TestForm_KeyDown(object sender, KeyEventArgs e)
    {
   
    }
  }
}
