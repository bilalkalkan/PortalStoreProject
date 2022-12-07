using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Customer;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IList<CustomerDetailDto>> GetAll();

        Task<CustomerDetailDto?> Get(int id);

        Task<bool> Add(AddCustomerDto addCustomer);

        Task<bool> Delete(int id);

        Task<bool> Update(UpdateCustomerDto customer);
    }
}