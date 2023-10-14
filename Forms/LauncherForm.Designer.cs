namespace LauncherNet
{
  partial class LauncherForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.helpProvider1 = new System.Windows.Forms.HelpProvider();
      this.SuspendLayout();
      // 
      // helpProvider1
      // 
      this.helpProvider1.HelpNamespace = "C:\\Users\\user\\Desktop\\final-main-debug-WorkProgramm-SettingsColor — копия — копия" +
    "\\bin\\Debug\\net6.0-windows7.0\\Help\\index.html";
      // 
      // LauncherForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(606, 391);
      this.Name = "LauncherForm";
      this.helpProvider1.SetShowHelp(this, true);
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    public HelpProvider helpProvider1;
  }
}