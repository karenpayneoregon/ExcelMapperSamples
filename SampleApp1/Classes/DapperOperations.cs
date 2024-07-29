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

    public DapperOperations()
    {
        _cn = new SqlConnection(DataConnections.Instance.Connection);
        SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
    }

    public async Task<List<NorthCustomer>> GetNorthWindCustomers() 
        => (await _cn.QueryAsync<NorthCustomer>(SqlStatements.GetNorthWindCustomersForExport)).AsList();

    public async Task<List<Order>> GetNorthWindOrders()
        => (await _cn.QueryAsync<Order>(SqlStatements.GetNorthWindOrders)).AsList();
}
