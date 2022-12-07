using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Entity.Concrete.DTOs.Order
{
    public class OrderdetailDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public int AddressId { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
