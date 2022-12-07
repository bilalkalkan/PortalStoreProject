using PortalStore.Entity.Concrete.DTOs.SKU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalStore.Entity.Concrete.DTOs.Category;

namespace PortalStore.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IList<CategoryDto>> GetAll();
        Task<CategoryDto?> Get(int id);
        Task<bool> Add(AddCategoryDto category);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateCategoryDto category);
    }
}