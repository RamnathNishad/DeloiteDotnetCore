using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstCRUD.Models
{
    public class Customer
    {
        [Key]
        public int Cid { get; set; }

        public string CustomerName { get; set; }
        public string City {  get; set; }
        public string Country { get; set; }
    }
}
