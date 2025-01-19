namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public Family? ButterflyFamily { get; set; }
        public int? Quantity { get; set; }
        public string Characteristics { get; set; }
        public DateTime CreatedDate { get; set; }
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
    }
}
