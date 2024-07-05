using System.Diagnostics;
using Ganss.Excel;
using SampleApp1.Classes;
using SampleApp1.Models;


namespace SampleApp1;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        ExcelMapperOperations.RemoveFiles();
    }

    private const string NorthSheetName = "Customers";
    private const string NorthFileNameForCustomers = "ExcelFiles\\NorthCustomers.xlsx";


    /// <summary>
    /// Read data from database and export to Excel with column headers, no formatting.
    /// </summary>
    private async void ExportNorthCustomersToExcelButton_Click(object sender, EventArgs e)
    {

        ExcelMapperOperations emo = new();
        await emo.ExportNorthCustomersToExcel();    
    }

    /// <summary>
    /// An example which reads in the file created above, make changes and save back to a new
    /// file but with the same file name.
    /// </summary>
    private void ModifyTrackNorthCustomerButton_Click(object sender, EventArgs e)
    {
        ExcelMapperOperations emo = new();
        emo.ModifyTrackNorthCustomer();
    }

    /// <summary>
    /// Example to read each row of data from Excel and return
    /// <see cref="Person"/> with <see cref="Address"/> property.
    ///
    /// Results are written to Visual Studio Output window.
    /// </summary>
    private async void PersonAddressNestedButton_Click(object sender, EventArgs e)
    {
        ExcelMapperOperations emo = new();
        await emo.PersonAddressNested();
    }

    /// <summary>
    /// Sample were the first row is 10, read nested data
    /// 
    /// Results are written to Visual Studio Output window.
    /// </summary>
    private async void HeaderNotAtFirstRowButton_Click(object sender, EventArgs e)
    {
        ExcelMapperOperations emo = new();
        await emo.HeaderNotAtFirstRow();
    }


}
