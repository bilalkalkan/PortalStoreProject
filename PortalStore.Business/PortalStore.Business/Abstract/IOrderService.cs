using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Business.Abstract
{
    public interface IOrderService
    {
        Task<IList<OrderdetailDto>> GetAll();
        Task<OrderdetailDto> Get(int id);
        Task<Order> Add(AddOrderDto order);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateOrderDto order);
    }
}
