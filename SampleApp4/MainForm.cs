
using System.Diagnostics;
using System.Text;
using FluentValidation;
using Ganss.Excel;
using SampleApp4.Classes;
using SampleApp4.Data;
using SampleApp4.Models;

namespace SampleApp4;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }
    
    private async void ReadAndValidateButton_Click(object sender, EventArgs e)
    {
        SavedLabel.Text = string.Empty;
        RejectedLabel.Text = string.Empty;

        var (badRecords, saved, rejected) = await ImportOperations.Validate();

        ResultsTextBox.Clear();
        ResultsTextBox.Text = badRecords;
        RejectedLabel.Text = $"Rejected {rejected} records";
        SavedLabel.Text = $"Saved {saved} records";
    }
}
