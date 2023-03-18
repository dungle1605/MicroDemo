using Catalog.API.Configuration;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(DatabaseSettings dbSettings)
    {
        var client = new MongoClient(dbSettings.ConnectionString);
        var database = client.GetDatabase(dbSettings.DatabaseName);

        Products = database.GetCollection<Product>(dbSettings.ConnectionString);
        CatalogContextSeed.SeedData(Products);
    }
    public IMongoCollection<Product> Products { get; }
}