using Ganss.Excel;
using SampleApp1.Models;
using System.Diagnostics;

namespace SampleApp1.Classes;
public class ExcelMapperOperations
{
    private const string NorthSheetName = "Customers";
    private const string NorthFileNameForCustomers = "ExcelFiles\\NorthCustomers.xlsx";
    private const string NorthFileNameForCustomersChanged = "ExcelFiles\\NorthCustomersChanged.xlsx";

    /// <summary>
    /// Exports a list of NorthWind customers to an Excel file asynchronously.
    /// </summary>
    /// <remarks>
    /// This method retrieves customer data from the database using Dapper and saves it to an Excel file
    /// using the ExcelMapper library. The exported Excel file will contain the customer data in a sheet
    /// named "Customers".
    /// </remarks>
    /// <returns>A task that represents the asynchronous export operation.</returns>
    public async Task ExportNorthCustomersToExcel()
    {
        var ops = new DapperOperations();
        var customers = await ops.GetNorthWindCustomers();
        await new ExcelMapper().SaveAsync(NorthFileNameForCustomers, customers, NorthSheetName);
        Debug.WriteLine($"Done {nameof(ExportNorthCustomersToExcel)}");
    }

    /// <summary>
    /// Modifies the details of a specific NorthWind customer in an Excel file and saves the changes to a new file.
    /// </summary>
    /// <remarks>
    /// This method reads customer data from an existing Excel file, modifies the details of the customer with 
    /// CustomerIdentifier equal to 1, and saves the changes to a new Excel file. If the original file does not exist, 
    /// a message box is displayed indicating the missing file.
    /// </remarks>
    /// <returns>
    /// A string indicating the result of the operation. Returns "File save" if the changes are successfully saved to 
    /// the new file, "Nothing found" if the customer with the specified identifier is not found, and "Done ModifyTrackNorthCustomer" 
    /// if the original file does not exist.
    /// </returns>
    public string ModifyTrackNorthCustomer()
    {
        var fileName = NorthFileNameForCustomers;
        var newFileName = "ExcelFiles\\NorthCustomersChanged.xlsx";

        if (File.Exists(fileName))
        {
            // TrackObjects is set to true to track changes (which is the default) its set here so if 
            // you want to disable then set TrackObjects to false.
            ExcelMapper excel = new() { TrackObjects = true };

            var customers = excel.Fetch<NorthCustomer>(fileName, NorthSheetName).ToList();

            var customer = customers.FirstOrDefault(x => x.CustomerIdentifier == 1);

            if (customer is null) return "Nothing found";

            customer.CompanyName = "Mary Jones";
            customer.ContactTitle = "Owner";
            customer.ContactTypeIdentifier = 7;
            customer.FirstName = "Tina";
            customer.LastName = "Smith";

            /*
             * We save to a new file to keep the original file intact.
             * If you change the original file, the changes will be saved.
             */
            excel.Save(newFileName);
            return "File save";
        }
        else
        {
            MessageBox.Show($"{NorthFileNameForCustomers} does not exist.");
        }

        return $"Done {nameof(ModifyTrackNorthCustomer)}";
    }

    /// <summary>
    /// Reads a list of people with nested address information from an Excel file asynchronously.
    /// </summary>
    /// <remarks>
    /// This method uses the ExcelMapper library to fetch data from an Excel file named "Nested.xlsx".
    /// The data is mapped to the <see cref="Person"/> class, which includes nested <see cref="Address"/> information.
    /// The results are written to the Visual Studio Output window for debugging purposes.
    /// </remarks>
    /// <returns>A task that represents the asynchronous fetch operation.</returns>
    public async Task PersonAddressNested()
    {
        ExcelMapper excel = new();
        var people = await excel.FetchAsync<Person>("ExcelFiles\\Nested.xlsx");
        Debug.WriteLine(ObjectDumper.Dump(people));
    }

    /// <summary>
    /// Reads data from an Excel file where the header is not located at the first row.
    /// </summary>
    /// <remarks>
    /// This method uses the ExcelMapper library to fetch data from an Excel file named "Header1.xlsx" 
    /// in the "People" sheet. The header row is specified to be at row number 9, and the minimum row 
    /// number to start reading data is set to 2.
    /// </remarks>
    /// <returns>A task that represents the asynchronous read operation.</returns>
    public async Task HeaderNotAtFirstRow()
    {
        ExcelMapper excel = new()
        {
            HeaderRowNumber = 9,
            MinRowNumber = 2
        };

        var people = (await excel.FetchAsync<Person>("ExcelFiles\\Header1.xlsx", "People")).ToList();
        Debug.WriteLine(ObjectDumper.Dump(people));
    }

    /// <summary>
    /// Deletes specific Excel files if they exist.
    /// </summary>
    /// <remarks>
    /// This method checks for the existence of predefined Excel files and deletes them if they are found.
    /// The files targeted for deletion are "ExcelFiles\NorthCustomers.xlsx" and "ExcelFiles\NorthCustomersChanged.xlsx".
    /// </remarks>
    public static void RemoveFiles()
    {
        List<string> files = [NorthFileNameForCustomers, NorthFileNameForCustomersChanged];

        foreach (var file in files.Where(File.Exists))
        {
            File.Delete(file);
        }
    }
}
