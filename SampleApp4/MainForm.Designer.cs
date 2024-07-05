namespace SampleApp4;

partial class MainForm
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
        ReadAndValidateButton = new Button();
        ResultsTextBox = new TextBox();
        label1 = new Label();
        SavedLabel = new Label();
        RejectedLabel = new Label();
        ViewDataButton = new Button();
        SuspendLayout();
        // 
        // ReadAndValidateButton
        // 
        ReadAndValidateButton.Location = new Point(12, 12);
        ReadAndValidateButton.Name = "ReadAndValidateButton";
        ReadAndValidateButton.Size = new Size(94, 29);
        ReadAndValidateButton.TabIndex = 1;
        ReadAndValidateButton.Text = "Validate";
        ReadAndValidateButton.UseVisualStyleBackColor = true;
        ReadAndValidateButton.Click += ReadAndValidateButton_Click;
        // 
        // ResultsTextBox
        // 
        ResultsTextBox.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ResultsTextBox.Location = new Point(12, 111);
        ResultsTextBox.Multiline = true;
        ResultsTextBox.Name = "ResultsTextBox";
        ResultsTextBox.ScrollBars = ScrollBars.Both;
        ResultsTextBox.Size = new Size(776, 358);
        ResultsTextBox.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 74);
        label1.Name = "label1";
        label1.Size = new Size(411, 20);
        label1.TabIndex = 3;
        label1.Text = "Row                 Property name                                           Value";
        // 
        // SavedLabel
        // 
        SavedLabel.AutoSize = true;
        SavedLabel.Location = new Point(124, 16);
        SavedLabel.Name = "SavedLabel";
        SavedLabel.Size = new Size(61, 20);
        SavedLabel.TabIndex = 4;
        SavedLabel.Text = "Saved 0";
        // 
        // RejectedLabel
        // 
        RejectedLabel.AutoSize = true;
        RejectedLabel.Location = new Point(124, 36);
        RejectedLabel.Name = "RejectedLabel";
        RejectedLabel.Size = new Size(79, 20);
        RejectedLabel.TabIndex = 5;
        RejectedLabel.Text = "Rejected 0";
        // 
        // ViewDataButton
        // 
        ViewDataButton.Enabled = false;
        ViewDataButton.Location = new Point(694, 12);
        ViewDataButton.Name = "ViewDataButton";
        ViewDataButton.Size = new Size(94, 29);
        ViewDataButton.TabIndex = 6;
        ViewDataButton.Text = "Data";
        ViewDataButton.UseVisualStyleBackColor = true;
        ViewDataButton.Click += ViewDataButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 481);
        Controls.Add(ViewDataButton);
        Controls.Add(RejectedLabel);
        Controls.Add(SavedLabel);
        Controls.Add(label1);
        Controls.Add(ResultsTextBox);
        Controls.Add(ReadAndValidateButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Validate WorkSheet";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button ReadAndValidateButton;
    private TextBox ResultsTextBox;
    private Label label1;
    private Label SavedLabel;
    private Label RejectedLabel;
    private Button ViewDataButton;
}
