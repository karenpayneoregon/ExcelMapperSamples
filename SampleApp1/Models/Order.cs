using Ganss.Excel;

namespace SampleApp1.Models;
#nullable disable
public class Order
{
    public int OrderID { get; set; }
    public int CustomerIdentifier { get; set; }
    public string CompanyName { get; set; }
    [DataFormat(0xe)]
    public DateOnly OrderDate { get; set; }

}
