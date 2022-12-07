using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Abstract
{
    public interface IAddressDal : IRepository<Address>
    {
       Task< List<AddressDetailDto>> GetAddresses(Expression<Func<AddressDetailDto,bool>>? predicate =null);
    }
}