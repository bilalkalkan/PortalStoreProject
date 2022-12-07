using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
    }
}