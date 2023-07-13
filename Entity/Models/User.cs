
using Microsoft.AspNetCore.Identity;

namespace Entity.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Address? Address { get; set; }
        public Basket Basket { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
