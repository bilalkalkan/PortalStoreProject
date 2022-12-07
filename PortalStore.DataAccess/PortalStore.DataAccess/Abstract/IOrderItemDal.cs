using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using PortalStore.Entity.Concrete.DTOs.OrderItem;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Abstract
{
    public interface IOrderItemDal : IRepository<OrderItem>
    {
        Task<List<OrderItemDetailDto>> GetOrderItemDetails(Expression<Func<OrderItemDetailDto, bool>> predicate = null);
    }
}