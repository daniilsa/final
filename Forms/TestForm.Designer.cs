namespace LauncherNet.Forms
{
  partial class TestForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
<<<<<<< HEAD
      this.SuspendLayout();
      // 
      // TestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Name = "TestForm";
      this.Text = "TestForm";
      this.Load += new System.EventHandler(this.TestForm_Load_1);
      this.ResumeLayout(false);

    }

    #endregion
=======
      testElement1 = new Controls.BorderButtonElement();
      testElement2 = new Controls.BorderButtonElement();
      testElement3 = new Controls.BorderButtonElement();
      SuspendLayout();
      // 
      // testElement1
      // 
      testElement1.ChoiceElement = LauncherNet.Controls.BorderButtonElement.Choice.Nope;
      testElement1.ForeColor = Color.White;
      testElement1.Location = new Point(3, 12);
      testElement1.Name = "testElement1";
      testElement1.Size = new Size(50, 50);
      testElement1.TabIndex = 0;
      testElement1.Text = "testElement1";
      // 
      // testElement2
      // 
      testElement2.ChoiceElement = LauncherNet.Controls.BorderButtonElement.Choice.Nope;
      testElement2.ForeColor = Color.White;
      testElement2.Location = new Point(59, 12);
      testElement2.Name = "testElement2";
      testElement2.Size = new Size(50, 50);
      testElement2.TabIndex = 1;
      testElement2.Text = "testElement2";
      // 
      // testElement3
      // 
      testElement3.ChoiceElement = LauncherNet.Controls.BorderButtonElement.Choice.Nope;
      testElement3.ForeColor = Color.White;
      testElement3.Location = new Point(152, 12);
      testElement3.Name = "testElement3";
      testElement3.Size = new Size(50, 50);
      testElement3.TabIndex = 2;
      testElement3.Text = "testElement3";
      // 
      // TestForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(testElement3);
      Controls.Add(testElement2);
      Controls.Add(testElement1);
      Name = "TestForm";
      Text = "TestForm";
      Load += TestForm_Load_1;
      ResumeLayout(false);
    }

    #endregion

    private Controls.BorderButtonElement testElement1;
    private Controls.BorderButtonElement testElement2;
    private Controls.BorderButtonElement testElement3;
>>>>>>> e7ab0e6a4aec6a4e47cb71bec0d9ef36d6e9208f
  }
}