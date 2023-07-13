using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Address
    {
        public int UserId { get; set; }
        public string AddressName { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
