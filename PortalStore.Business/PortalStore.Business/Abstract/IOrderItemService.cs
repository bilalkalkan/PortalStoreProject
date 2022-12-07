using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Business.Abstract
{
    public interface IOrderItemService
    {
        Task<IList<OrderItemDetailDto>> GetAll();
        Task<OrderItemDetailDto> Get(int id);
        Task<bool> Add(AddOrderItemDto orderItem);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateOrderDto orderItem);
    }
}
