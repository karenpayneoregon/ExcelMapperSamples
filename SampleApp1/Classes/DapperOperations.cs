using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using SampleApp1.Classes.Configuration;
using SampleApp1.Models;
using kp.Dapper.Handlers;

// ReSharper disable ConvertConstructorToMemberInitializers

namespace SampleApp1.Classes;
internal class DapperOperations
{
    private IDbConnection _cn;

    /// <summary>
    /// Initializes a new instance of the <see cref="DapperOperations"/> class.
    /// Sets up the database connection and adds custom type handlers for Dapper.
    /// </summary>
    public DapperOperations()
    {
        _cn = new SqlConnection(DataConnections.Instance.Connection);
        SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
    }

    /// <summary>
    /// Retrieves a list of NorthWind customers from the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="NorthCustomer"/> objects.</returns>
    public async Task<List<NorthCustomer>> GetNorthWindCustomers() 
        => (await _cn.QueryAsync<NorthCustomer>(SqlStatements.GetNorthWindCustomersForExport)).AsList();

    /// <summary>
    /// Retrieves a list of NorthWind orders from the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Order"/> objects.</returns>
    public async Task<List<Order>> GetNorthWindOrders()
        => (await _cn.QueryAsync<Order>(SqlStatements.GetNorthWindOrders)).AsList();
}
