using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Data
{
    public class BudgetContextSeed
    {
        public static async Task SeedAsync(BudgetContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Category.Any())
                {
                    var categoryData = System.IO.File.ReadAllText("../Infrastructure/Data/DataSeed/Categories.json");

                    var category = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    foreach (var item in category)
                    {
                        context.Category.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Record.Any())
                {
                    var recordData = System.IO.File.ReadAllText("../Infrastructure/Data/DataSeed/Records.json");


                    var record = JsonSerializer.Deserialize<List<Record>>(recordData);

                    foreach (var item in record)
                    {
                        context.Record.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BudgetContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
