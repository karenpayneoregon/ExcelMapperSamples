using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SampleApp5;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: DateOnly";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
