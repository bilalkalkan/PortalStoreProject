using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.SKU;
using PortalStore.Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Business.Abstract
{
    public interface IAddressService
    {
        Task<IList<AddressDetailDto>> GetAll();
        Task<AddressDetailDto> Get(int id);
        Task<bool> Add(AddAddressDto address);
        Task<bool> Delete( int id);
        Task<bool> Update(UpdateAddressDto address);
    }
}
