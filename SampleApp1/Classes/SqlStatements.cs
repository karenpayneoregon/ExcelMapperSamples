using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp1.Classes;
internal class SqlStatements
{
    public static string GetNorthWindOrders => 
        """
        SELECT     O.OrderID,
                   O.CustomerIdentifier,
                   C.CompanyName,
                   O.OrderDate
         FROM      dbo.Orders AS O
        INNER JOIN dbo.Customers AS C
           ON O.CustomerIdentifier = C.CustomerIdentifier;
        """;
    public static string GetNorthWindCustomersForExport => 
        """
        SELECT     C.CustomerIdentifier,
                   C.CompanyName,
                   C.ContactId,
                   C.Street,
                   C.City,
                   C.PostalCode,
                   C.CountryIdentifier,
                   C.Phone,
                   C.ContactTypeIdentifier,
                   CTI.ContactTitle,
                   CT.FirstName,
                   CT.LastName,
                   CO.[Name] AS CountryName
         FROM      dbo.Customers AS C
        INNER JOIN dbo.Contacts AS CT
           ON C.ContactId              = CT.ContactId
        INNER JOIN dbo.Countries AS CO
           ON C.CountryIdentifier      = CO.CountryIdentifier
        INNER JOIN dbo.ContactType AS CTI
           ON C.ContactTypeIdentifier  = CTI.ContactTypeIdentifier
          AND CT.ContactTypeIdentifier = CTI.ContactTypeIdentifier;
        """;
}
