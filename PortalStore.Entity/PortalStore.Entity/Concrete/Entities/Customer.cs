using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace PortalStore.Entity.Concrete.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Int64 TCID { get; set; }
        public DateTime BirthDate { get; set; }
        public string GSM { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}