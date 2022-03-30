namespace TFG.Products.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; private set; }
        public Category? Category { get; private set; }

        public Product(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
