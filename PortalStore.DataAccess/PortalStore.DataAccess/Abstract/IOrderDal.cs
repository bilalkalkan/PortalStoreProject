using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        Task<List<OrderdetailDto>> GetOrderList(Expression<Func<OrderdetailDto,bool>>predicate=null);
    }
}