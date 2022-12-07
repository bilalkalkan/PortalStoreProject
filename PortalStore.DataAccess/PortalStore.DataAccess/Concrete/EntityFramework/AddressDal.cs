using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Concrete.EntityFramework
{
    public class AddressDal : EfRepositoryBase<Address, PortalStoreContext>, IAddressDal
    {

        public AddressDal(PortalStoreContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<AddressDetailDto>> GetAddresses(Expression<Func<AddressDetailDto, bool>>? predicate = null)
        {
            var result = from address in Context.Addresses
                         join customer in Context.Customers on address.CustomerId equals customer.Id
                         select new AddressDetailDto()
                         {
                             Id = address.Id,
                             CustomerId = customer.Id,
                             AddressLine = address.AddressLine,
                             City = address.City,
                             Country = address.Country,
                             CustomerFullName = customer.FirstName + " " + customer.LastName,
                             District = address.District,
                             ZipCode = address.ZipCode
                         };
            return predicate != null ? result.Where(predicate).ToList() : result.ToList();
        }
    }
}