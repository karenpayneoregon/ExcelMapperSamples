
using System.Diagnostics;
using System.Text;
using FluentValidation;
using Ganss.Excel;
using SampleApp4.Classes;
using SampleApp4.Data;
using SampleApp4.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SampleApp4;

public partial class MainForm : Form
{
    private List<Products> _badProductsList;
    public MainForm()
    {
        InitializeComponent();
    }

    private async void ReadAndValidateButton_Click(object sender, EventArgs e)
    {
        ViewDataButton.Enabled = false;
        SavedLabel.Text = string.Empty;
        RejectedLabel.Text = string.Empty;

        var (badRecords, badList, saved, rejected) = await ImportOperations.Validate();

        _badProductsList = badList;

        ResultsTextBox.Clear();
        ResultsTextBox.Text = badRecords;
        RejectedLabel.Text = $"Rejected {rejected} records";
        SavedLabel.Text = $"Saved {saved} records";

        if (rejected > 0)
        {
            ViewDataButton.Enabled = true;
        }

    }

    private void ViewDataButton_Click(object sender, EventArgs e)
    {
        var f = new ResultsForm(_badProductsList);
        try
        {
            f.ShowDialog();
        }
        finally
        {
            f.Dispose();
        }
    }
}
