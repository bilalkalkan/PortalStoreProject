using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.OrderItem;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Concrete.EntityFramework
{
    public class OrderItemDal : EfRepositoryBase<OrderItem, PortalStoreContext>, IOrderItemDal
    {
        public OrderItemDal(PortalStoreContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<OrderItemDetailDto>> GetOrderItemDetails(Expression<Func<OrderItemDetailDto, bool>> predicate = null)
        {
            var result = from orderItem in Context.OrderItems
                         join sku in Context.Skus on orderItem.SkuId equals sku.Id
                         join order in Context.Orders on orderItem.OrderId equals order.Id
                         select new OrderItemDetailDto()
                         {
                             Id= orderItem.Id,
                             SkuName=sku.Name,
                             Quantity=orderItem.Quantity,
                             UnitPrice=sku.Price,
                             TotalPrice=order.TotalPrice,
                             
                         };
            return predicate != null ? result.Where(predicate).ToList() : result.ToList();
        }
    }
}