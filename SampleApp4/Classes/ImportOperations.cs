using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Excel;
using SampleApp4.Data;
using SampleApp4.Models;

namespace SampleApp4.Classes;
internal class ImportOperations
{
    public static async Task<(string badRecord, int saved, int rejected)> Validate(string fileName = "Products.xlsx")
    {
        ExcelMapper excel = new();
        var products = (await excel.FetchAsync<Products>(fileName, nameof(Products))).ToList();
        
        List<Products> goodList = [];
        StringBuilder builder = new();

        int rejected = 0;

        for (int index = 0; index < products.Count; index++)
        {
            var validator = new ProductsValidator();
            var result = await validator.ValidateAsync(products[index]);
            if (result.IsValid == false)
            {
                rejected++;

                foreach (var error in result.Errors)
                {
                    builder.AppendLine($"{index + 1,-10} {error.PropertyName,-30}{error.AttemptedValue}");
                }
            }
            else
            {
                goodList.Add(products[index]);
            }

        }

        var saved = 0;
        if (goodList.Count > 0)
        {
            await using var context = new Context();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            context.Products.AddRange(goodList);
            saved = await context.SaveChangesAsync();

        }

        return (builder.ToString(), saved, rejected);

    }
}
