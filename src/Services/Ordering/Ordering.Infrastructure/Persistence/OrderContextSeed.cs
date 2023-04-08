using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetPreconfigureOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext));
        }
    }

    private static IEnumerable<Order> GetPreconfigureOrders()
    {
        return new List<Order>
        {
            new Order()
            {
                UserName="michael",
                FirstName="Michael",
                LastName="D-Killer",
                EmailAddress="dugle1605@gmail.com",
                AddressLine="Di An, Binh Duong",
                Country="Viet Nam",
                TotalPrice=350
            }
        };
    }
}