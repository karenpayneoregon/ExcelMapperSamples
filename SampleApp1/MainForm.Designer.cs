namespace SampleApp1;

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
        ExportNothCustomersToExcelButton = new Button();
        ModifyTrackNorthCustomerButton = new Button();
        PersonAddressNestedButton = new Button();
        HeaderNotAtFirstRowButton = new Button();
        SuspendLayout();
        // 
        // ExportNothCustomersToExcelButton
        // 
        ExportNothCustomersToExcelButton.Location = new Point(12, 21);
        ExportNothCustomersToExcelButton.Name = "ExportNothCustomersToExcelButton";
        ExportNothCustomersToExcelButton.Size = new Size(370, 29);
        ExportNothCustomersToExcelButton.TabIndex = 0;
        ExportNothCustomersToExcelButton.Text = "Export North Customers from SQL-Server to Excel";
        ExportNothCustomersToExcelButton.UseVisualStyleBackColor = true;
        ExportNothCustomersToExcelButton.Click += ExportNorthCustomersToExcelButton_Click;
        // 
        // ModifyTrackNorthCustomerButton
        // 
        ModifyTrackNorthCustomerButton.Location = new Point(12, 70);
        ModifyTrackNorthCustomerButton.Name = "ModifyTrackNorthCustomerButton";
        ModifyTrackNorthCustomerButton.Size = new Size(370, 29);
        ModifyTrackNorthCustomerButton.TabIndex = 1;
        ModifyTrackNorthCustomerButton.Text = "Read North Excel file, modify and save";
        ModifyTrackNorthCustomerButton.UseVisualStyleBackColor = true;
        ModifyTrackNorthCustomerButton.Click += ModifyTrackNorthCustomerButton_Click;
        // 
        // PersonAddressNestedButton
        // 
        PersonAddressNestedButton.Location = new Point(12, 118);
        PersonAddressNestedButton.Name = "PersonAddressNestedButton";
        PersonAddressNestedButton.Size = new Size(370, 29);
        PersonAddressNestedButton.TabIndex = 2;
        PersonAddressNestedButton.Text = "Nested Person/Address (see output window)";
        PersonAddressNestedButton.UseVisualStyleBackColor = true;
        PersonAddressNestedButton.Click += PersonAddressNestedButton_Click;
        // 
        // HeaderNotAtFirstRowButton
        // 
        HeaderNotAtFirstRowButton.Location = new Point(12, 170);
        HeaderNotAtFirstRowButton.Name = "HeaderNotAtFirstRowButton";
        HeaderNotAtFirstRowButton.Size = new Size(370, 29);
        HeaderNotAtFirstRowButton.TabIndex = 3;
        HeaderNotAtFirstRowButton.Text = "Header not at first row (see output window)";
        HeaderNotAtFirstRowButton.UseVisualStyleBackColor = true;
        HeaderNotAtFirstRowButton.Click += HeaderNotAtFirstRowButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(HeaderNotAtFirstRowButton);
        Controls.Add(PersonAddressNestedButton);
        Controls.Add(ModifyTrackNorthCustomerButton);
        Controls.Add(ExportNothCustomersToExcelButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Excel Mapper samples";
        ResumeLayout(false);
    }

    #endregion

    private Button ExportNothCustomersToExcelButton;
    private Button ModifyTrackNorthCustomerButton;
    private Button PersonAddressNestedButton;
    private Button HeaderNotAtFirstRowButton;
}
