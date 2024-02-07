using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class RestaurantBranch
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Street { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        public bool Open { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
