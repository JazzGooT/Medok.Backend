namespace MedokStore.Domain.Entity
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
