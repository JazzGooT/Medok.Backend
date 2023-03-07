namespace MedokStore.Domain.Entity
{
    public class Gelery
    {
        public Guid GeleryId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
