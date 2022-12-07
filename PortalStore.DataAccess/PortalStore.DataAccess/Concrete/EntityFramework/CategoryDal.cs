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
    public class CategoryDal : EfRepositoryBase<Category, PortalStoreContext>, ICategoryDal
    {
        public CategoryDal(PortalStoreContext context) : base(context)
        {
        }
    }
}