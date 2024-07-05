namespace SampleApp4.Models;

#pragma warning disable CS8618

public class ProductItem
{
    public int RowIndex { get; set; }
    public bool Process { get; set; } = false;
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Supplier { get; set; }


    public static implicit operator ProductItem(Products product) =>
        new()
        {
            ProductId = product.ProductID,
            ProductName = product.ProductName,
            Supplier = product.Supplier,
            RowIndex = product.RowIndex
        };
}

