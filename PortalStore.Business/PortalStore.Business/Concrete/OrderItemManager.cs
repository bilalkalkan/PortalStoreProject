using AutoMapper;
using PortalStore.Business.Abstract;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.DTOs.OrderItem;
using PortalStore.Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;
        private readonly ISkuService _skuService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderItemManager(IOrderItemDal orderItemDal, IMapper mapper, ISkuService skuService, IOrderService orderService)
        {
            _orderItemDal = orderItemDal;
            _mapper = mapper;
            _skuService = skuService;
            _orderService = orderService;
        }

        public async Task<OrderItemDetailDto> Get(int id)
        {
            var data = await _orderItemDal.GetAsync(x => x.Id == id);
            var mapped = _mapper.Map<OrderItemDetailDto>(data);
            return mapped;
        }

        public async Task<IList<OrderItemDetailDto>> GetAll()
        {
            var data = await _orderItemDal.GetOrderItemDetails();
            IList<OrderItemDetailDto> mapped = _mapper.Map<IList<OrderItemDetailDto>>(data);
            return mapped;
        }

        public async Task<bool> Add(AddOrderItemDto orderItem)
        {

            var productData = await _skuService.Get(orderItem.SkuId);
            var orderData = await _orderService.Get(orderItem.OrderId);
            orderData.TotalPrice = productData.Price * orderItem.Quantity;
            var orderMapped = _mapper.Map<UpdateOrderDto>(orderData);
            await _orderService.Update(orderMapped);



            var mapped = _mapper.Map<OrderItem>(orderItem);
            await _orderItemDal.AddAsync(mapped);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _orderItemDal.GetAsync(x => x.Id == id);
            await _orderItemDal.DeleteAsync(data);
            return true;
        }

        public async Task<bool> Update(UpdateOrderDto orderItem)
        {
            var mapped = _mapper.Map<OrderItem>(orderItem);
            await _orderItemDal.UpdateAsync(mapped);
            return true;
        }
    }
}
