using System.Collections;

namespace TFG.Products.Application.Queries.GetProductsByCategory
{
    public record ProductEntry(int Id, string Name, string Description, string Image);

    public class GetProductsByCategoryIdResponse : IEnumerable<ProductEntry>
    {
        private readonly List<ProductEntry> _products;

        public GetProductsByCategoryIdResponse()
        {
            _products = new List<ProductEntry>();
        }

        public void Add(ProductEntry productEntry)
            => _products.Add(productEntry);

        public IEnumerator<ProductEntry> GetEnumerator()
            => _products.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
