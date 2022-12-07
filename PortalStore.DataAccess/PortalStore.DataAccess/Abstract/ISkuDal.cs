using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using PortalStore.Entity.Concrete.DTOs.SKU;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Abstract
{
    public interface ISkuDal : IRepository<SKU>
    {
        Task<List<SkuDetailDto>> GetSkuDetail(Expression<Func<SkuDetailDto, bool>>? predicate = null);
    }
}