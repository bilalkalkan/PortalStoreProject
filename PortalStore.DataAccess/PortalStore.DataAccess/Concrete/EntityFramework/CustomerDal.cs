using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Concrete.EntityFramework
{
    public class CustomerDal : EfRepositoryBase<Customer, PortalStoreContext>, ICustomerDal
    {
        public CustomerDal(PortalStoreContext context) : base(context)
        {
        }
    }
}