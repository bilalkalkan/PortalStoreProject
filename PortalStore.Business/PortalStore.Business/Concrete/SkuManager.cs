using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PortalStore.Business.Abstract;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.SKU;
using PortalStore.Entity.Concrete.Entities;


namespace PortalStore.Business.Concrete
{
    public class SkuManager : ISkuService
    {
        private readonly IMapper _mapper;
        private readonly ISkuDal _skuDal;

        public SkuManager(IMapper mapper, ISkuDal skuDal)
        {
            _mapper = mapper;
            _skuDal = skuDal;
        }

        public async Task<IList<SkuDetailDto>> GetAll()
        {
            var datas = await _skuDal.GetSkuDetail();
            IList<SkuDetailDto> mappeDto = _mapper.Map<IList<SkuDetailDto>>(datas);
            return mappeDto;
        }

        public async Task<SKU?> Get(int id)
        {
            var data = await _skuDal.GetAsync(x => x.Id == id);
           SkuDetailDto result = _mapper.Map<SkuDetailDto>(data);
            return data;
        }

        public async Task<bool> Add(SkuAddDto sku)
        {
            var mapped = _mapper.Map<SKU>(sku);
            await _skuDal.AddAsync(mapped);
            return true;
        }

        public async Task<bool> Update(SkuUpdateDto sku)
        {
            var mapped = _mapper.Map<SKU>(sku);
            await _skuDal.UpdateAsync(mapped);
            return true;
        }

        public async Task<bool> Delete(SKU sku)
        {
            var mapped = _mapper.Map<SKU>(sku);
            await _skuDal.DeleteAsync(sku);
            return true;
        }
    }
}