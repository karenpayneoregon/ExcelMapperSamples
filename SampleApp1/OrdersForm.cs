using SampleApp1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ganss.Excel;
using SampleApp1.Models;

namespace SampleApp1;
public partial class OrdersForm : Form
{
    public OrdersForm()
    {
        InitializeComponent();
        Shown += OrdersForm_Shown;
    }

    private async void OrdersForm_Shown(object? sender, EventArgs e)
    {
        DapperOperations operations = new DapperOperations();
        List<Order> orders = await operations.GetNorthWindOrders();
        dataGridView1.DataSource = orders;
    }

    private void ExportButton_Click(object sender, EventArgs e)
    {
        List<Order> orders = (List<Order>)dataGridView1.DataSource;
        new ExcelMapper().Save("Orders.xlsx", orders, "Orders");
    }
}
