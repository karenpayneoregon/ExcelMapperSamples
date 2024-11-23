using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleApp2.Models;

namespace SampleApp2.Classes;

internal class DapperOperations
{
    private IDbConnection _cn = new SqlConnection(ConnectionString());

    /// <summary>
    /// Resets the Customers table by deleting all records and reseeding the identity column.
    /// </summary>
    /// <remarks>
    /// This method executes two SQL commands:
    /// <list type="bullet">
    /// <item><description>DELETE FROM dbo.Customers - Deletes all records from the Customers table.</description></item>
    /// <item><description>DBCC CHECKIDENT (Customers, RESEED, 0) - Reseeds the identity column to start from 0.</description></item>
    /// </list>
    /// </remarks>
    public void Reset()
    {
        _cn.Execute($"DELETE FROM dbo.{nameof(Customers)}");
        _cn.Execute($"DBCC CHECKIDENT ({nameof(Customers)}, RESEED, 0)");
    }
}