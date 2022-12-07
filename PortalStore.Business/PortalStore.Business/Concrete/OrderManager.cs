using AutoMapper;
using PortalStore.Business.Abstract;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
       
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
            
        }

        public async Task<OrderdetailDto> Get(int id)
        {
            var data =await _orderDal.GetAsync(x => x.Id == id);
            var mapped=_mapper.Map<OrderdetailDto>(data);
            return mapped;
        }

        public async Task<IList<OrderdetailDto>> GetAll()
        {
            var data = await _orderDal.GetAllAsync();
            IList<OrderdetailDto> mapped = _mapper.Map<IList<OrderdetailDto>>(data);
            return mapped;
        }

        public async Task<Order> Add(AddOrderDto order)
        {
            
           var mapped = _mapper.Map<Order>(order);
           var result=  _orderDal.AddAsync(mapped);
            return result.Result;

        }

        public async Task<bool> Delete(int id)
        {
            var data = await _orderDal.GetAsync(x => x.Id == id);
            var result = _orderDal.DeleteAsync(data);
            return true;
        }
        public async Task<bool> Update(UpdateOrderDto order)
        {
            var mapped=_mapper.Map<Order>(order);
            await _orderDal.UpdateAsync(mapped);
            return true;
        }

       
    }
}
