namespace TFG.Products.Domain.Entities
{
    public class Category : BaseEntity
    {
        private List<Product> _products;
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            _products = new List<Product>();
        }

        public Category AddProduct(string name, string description, string image)
        {
            _products.Add(new Product(name, description, image));

            return this;
        }
    }
}
