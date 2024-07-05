using SampleApp4.Classes;
using SampleApp4.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SampleApp4;
public partial class ResultsForm : Form
{
    private BindingSource _bindingSource = new();
    private SortableBindingList<ProductItem> _bindingList;
    public ResultsForm()
    {
        InitializeComponent();
    }
    public ResultsForm(List<Products> products)
    {
        InitializeComponent();

        List<ProductItem> results = products
            .Select<Products, ProductItem>(container => container).ToList();

        _bindingList = new SortableBindingList<ProductItem>(results);
        _bindingSource.DataSource = _bindingList;
        dataGridView1.DataSource = _bindingSource;
        Shown += ResultsForm_Shown;

    }

    private void ResultsForm_Shown(object? sender, EventArgs e)
    {
        dataGridView1.Columns["Process"].DisplayIndex = 0;
        dataGridView1.ExpandColumns();
    }

    private void ProcessButton_Click(object sender, EventArgs e)
    {
        List<ProductItem> products = _bindingList.Where(pc => pc.Process).ToList();
        if (products.Count> 0)
        {
            // save data, in this case two properties product name and supplier
        }
    }
}
