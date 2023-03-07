namespace MedokStore.Domain.Entity
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Compound { get; set; }
        public string Capacity { get; set; }
        public string CompleteSet { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Gelery> Gelery { get; set; }
    }
}
