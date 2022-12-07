using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PortalStore.Business.Abstract;
using PortalStore.DataAccess.Abstract;
using PortalStore.DataAccess.Concrete.EntityFramework;
using PortalStore.Entity.Concrete.DTOs.Category;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;



        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDto>> GetAll()
        {
            var datas =await _categoryDal.GetAllAsync();
            IList<CategoryDto> result = _mapper.Map<IList<CategoryDto>>(datas);
            return result;
        }

        public async Task<CategoryDto?> Get(int id)
        {
            var data =await _categoryDal.GetAsync(x=>x.Id==id);
            var result=_mapper.Map<CategoryDto>(data);
            return result;
        }

        public async Task<bool> Add(AddCategoryDto category)
        {
            var mapped = _mapper.Map<Category>(category);
            await _categoryDal.AddAsync(mapped);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _categoryDal.GetAsync(x => x.Id == id);
            await _categoryDal.DeleteAsync(data);
            return true;
        }

        public async Task<bool> Update(UpdateCategoryDto category)
        {
            var mapped = _mapper.Map<Category>(category);
            await _categoryDal.UpdateAsync(mapped);
            return true;
        }
    }
}