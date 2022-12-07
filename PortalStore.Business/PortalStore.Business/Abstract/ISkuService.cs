using PortalStore.Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalStore.Entity.Concrete.DTOs.SKU;


namespace PortalStore.Business.Abstract
{
    public interface ISkuService
    {
        Task<IList<SkuDetailDto>> GetAll();
        Task<SKU?> Get(int id);
        Task<bool> Add(SkuAddDto sku);
        Task<bool> Update(SkuUpdateDto sku);
        Task<bool> Delete(SKU sku);
    }
}