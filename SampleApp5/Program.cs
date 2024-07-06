using Ganss.Excel;
using SampleApp5.Classes;

namespace SampleApp5;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Working with DateOnly[/]");

        var products = new ExcelMapper(@"Products.xlsx").Fetch<DateOnlyProduct>().ToList();
        foreach (var product in products)
        {
            Console.WriteLine(product.OfferEnd.ToString("MM/dd/yyyy"));
        }

        SpectreConsoleHelpers.ExitPrompt();
    }
}
record DateOnlyProduct(DateOnly OfferEnd);