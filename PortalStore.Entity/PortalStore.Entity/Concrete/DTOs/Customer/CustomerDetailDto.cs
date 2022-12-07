using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Entity.Concrete.DTOs.Customer
{
    public class CustomerDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Int64 TCID { get; set; }
        public DateTime BirthDate { get; set; }
        public string GSM { get; set; }

    }
}
