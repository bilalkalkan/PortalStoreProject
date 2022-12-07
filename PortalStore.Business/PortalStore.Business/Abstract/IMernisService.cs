using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalStore.Entity.Concrete.DTOs.Customer;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.Business.Abstract
{
    public interface IMernisService
    {
        Task<bool> TcIdVerification(AddCustomerDto customer);
    }
}