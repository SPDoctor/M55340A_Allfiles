namespace ElectricStore.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
