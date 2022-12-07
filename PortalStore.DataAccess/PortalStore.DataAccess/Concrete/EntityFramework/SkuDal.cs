using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.SKU;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Concrete.EntityFramework
{
    public class SkuDal : EfRepositoryBase<SKU, PortalStoreContext>, ISkuDal
    {
        public SkuDal(PortalStoreContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<SkuDetailDto>> GetSkuDetail(Expression<Func<SkuDetailDto, bool>>? predicate = null)
        {
            var result = from sku in Context.Skus
                         join category in Context.Categories on sku.CategoryId equals category.Id
                         select new SkuDetailDto
                         {
                             Id = sku.Id,
                             Name = sku.Name,
                             Description = sku.Description,
                             OldPrice = sku.OldPrice,
                             Price = sku.Price,
                             CategoryId = category.Id,
                             CategoryName = category.Name
                         };
            return predicate != null ? result.Where(predicate).ToList() : result.ToList();
        }
    }
}