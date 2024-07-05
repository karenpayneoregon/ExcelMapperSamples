#nullable disable
namespace SampleApp4.Models;

public class ProductContainer : Products
{
    private bool _process;

    public ProductContainer(int id)
    {
        ProductID = id;
    }

    public ProductContainer()
    {

    }

    public bool Process
    {
        get => _process;
        set
        {
            if (value == _process) return;
            _process = value;
            OnPropertyChanged();
        }
    }
}