using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cupcakes.Models
{
    public class Cupcake
    {
        public int CupcakeId;
        public CupcakeType CupcakeType;
        public string Description;
        public bool GlutenFree;
        public decimal Price;
        public string ImageName;
        public byte[] PhotoFile;
        public string ImageMimeType;
        public IFormFile PhotoAvatar;
        public int BakeryId;
        public Object Bakery;
    }
}
