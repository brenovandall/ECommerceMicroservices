using Marten.Schema;

namespace Catalog.API.Data;

public class InitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync()) return;

        session.Store<Product>(GetPreconfiguredData());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredData()
    {
        return new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone",
                Description = "Latest model with advanced features",
                ImageFile = "https://example.com/images/smartphone.jpg",
                Price = 699.99m,
                Category = new List<string> { "Electronics", "Mobile" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Description = "High performance laptop for professionals",
                ImageFile = "https://example.com/images/laptop.jpg",
                Price = 999.99m,
                Category = new List<string> { "Electronics", "Computers" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smartwatch",
                Description = "Wearable technology for health tracking",
                ImageFile = "https://example.com/images/smartwatch.jpg",
                Price = 199.99m,
                Category = new List<string> { "Electronics", "Wearables" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                Description = "Portable and powerful tablet for all your needs",
                ImageFile = "https://example.com/images/tablet.jpg",
                Price = 499.99m,
                Category = new List<string> { "Electronics", "Mobile" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Earbuds",
                Description = "Noise-cancelling wireless earbuds",
                ImageFile = "https://example.com/images/earbuds.jpg",
                Price = 149.99m,
                Category = new List<string> { "Electronics", "Audio" }
            }
        };
    }
}
