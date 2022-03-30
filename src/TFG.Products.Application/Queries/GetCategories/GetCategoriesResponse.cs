using System.Collections;

namespace TFG.Products.Application.Queries.GetCategories
{
    public record CategoryEntry(int Id, string Name, string Description);

    public class GetCategoriesResponse : IEnumerable<CategoryEntry>
    {
        private readonly List<CategoryEntry> _categories;

        public GetCategoriesResponse()
        {
            _categories = new List<CategoryEntry>();
        }

        public void Add(CategoryEntry entry)
            => _categories.Add(entry);

        public IEnumerator<CategoryEntry> GetEnumerator()
            => _categories.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
