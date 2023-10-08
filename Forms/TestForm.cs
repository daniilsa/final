using LauncherNet.DesignFront;
using LauncherNet.Front;

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
      this.Size = new(400, 400);
      Cyotek.Windows.Forms.ColorPickerDialog colorPickerDialog = new Cyotek.Windows.Forms.ColorPickerDialog();
      colorPickerDialog.BackColor = BackColorElements.MainDarkColor;
      colorPickerDialog.Show();

      Console.Clear();
      foreach (Control item in colorPickerDialog.Controls)
      {
        if (item != null && item.GetType() == new Button().GetType())
        {
          item.BackColor = BackColorElements.MainDarkColor;
        }

        if (item != null && item.GetType() == new Cyotek.Windows.Forms.ColorEditor().GetType())
        {
          foreach (Control i1 in item.Controls)
          {
            if (i1.GetType() == new Label().GetType())
              i1.ForeColor = FontElements.MainLightColorText;


            if (i1.GetType() == new NumericUpDown().GetType())
            {
              i1.ForeColor = FontElements.MainLightColorText;
              i1.BackColor = BackColorElements.AdditionalDarkColor;

            }
            Console.WriteLine(i1.GetType());
          }
        }
      }
    }

    private void TestForm_Load_1(object sender, EventArgs e)
    {
      this.FormBorderStyle = FormBorderStyle.None;
      Test();
    }

  }
}
