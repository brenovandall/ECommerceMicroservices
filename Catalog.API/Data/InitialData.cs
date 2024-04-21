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
        var faker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.ImageFile, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1m, 1000m))
            .RuleFor(p => p.Category, f => new List<string> { f.Commerce.Categories(1)[0], f.Commerce.Categories(1)[0] });

        var products = faker.Generate(10);

        return products;
    }
}
