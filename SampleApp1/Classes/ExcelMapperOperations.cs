using Ganss.Excel;
using SampleApp1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp1.Classes;
public class ExcelMapperOperations
{
    private const string NorthSheetName = "Customers";
    private const string NorthFileNameForCustomers = "ExcelFiles\\NorthCustomers.xlsx";
    private const string NorthFileNameForCustomersChanged = "ExcelFiles\\NorthCustomersChanged.xlsx";

    public async Task ExportNorthCustomersToExcel()
    {
        var ops = new DapperOperations();
        var customers = await ops.GetNorthWindCustomers();
        await new ExcelMapper().SaveAsync(NorthFileNameForCustomers, customers, NorthSheetName);
        Debug.WriteLine($"Done {nameof(ExportNorthCustomersToExcel)}");
    }

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

    public async Task PersonAddressNested()
    {
        ExcelMapper excel = new();
        var people = await excel.FetchAsync<Person>("ExcelFiles\\Nested.xlsx");
        Debug.WriteLine(ObjectDumper.Dump(people));
    }

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
    public static void RemoveFiles()
    {
        List<string> files = [NorthFileNameForCustomers, NorthFileNameForCustomersChanged];

        foreach (var file in files.Where(File.Exists))
        {
            File.Delete(file);
        }
    }
}
