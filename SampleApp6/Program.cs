using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using SampleApp6.Classes;

namespace SampleApp6;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Working with[/] [cyan]enum[/]");
        var excel = new ExcelMapper("Products.xlsx");
        var products = excel.Fetch<Wines>().ToList();

        AnsiConsole.MarkupLine(ObjectDumper.Dump(products).Replace("WineType:", "[cyan]WineType:[/]"));

        SpectreConsoleHelpers.ExitPrompt();
    }
}
public class Wines
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineType WineType { get; set; }
}
public enum WineType
{
    Red = 1,
    White = 2,
    Rose = 3
}