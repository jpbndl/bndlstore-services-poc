using Marten.Schema;

namespace CatalogAPI.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            session.Store<Product>(GetPreconguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconguredProducts() => new List<Product>
        {
            new Product()
            {
                Id = new Guid("b1f7d8e2-5c3a-4d2e-9f3a-1c2b3a4d5e6f"),
                Name = "Piecos Pizza",
                Description = "A delicious cheese pizza with a crispy crust and fresh toppings.",
                ImageFile = "product-1.png",
                Price = 9.99M,
                Category = new List<string>() { "Pizza", "Food", "Fast Food" }
            },
            new Product()
            {
                Id = new Guid("17dab7b8-55a4-4f18-be19-5846ca57d6c8"),
                Name = "Dreamers Pizza",
                Description = "A delicious cheese pizza with a crispy crust and fresh toppings.",
                ImageFile = "product-1.png",
                Price = 9.99M,
                Category = new List<string>() { "Pizza", "Food", "Fast Food" }
            }
        };
    }
}
