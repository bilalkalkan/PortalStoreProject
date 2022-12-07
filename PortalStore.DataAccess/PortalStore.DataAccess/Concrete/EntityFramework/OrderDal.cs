using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using PortalStore.DataAccess.Abstract;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Concrete.EntityFramework
{
    public class OrderDal : EfRepositoryBase<Order, PortalStoreContext>, IOrderDal
    {
        public OrderDal(PortalStoreContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<OrderdetailDto>> GetOrderList(Expression<Func<OrderdetailDto, bool>> predicate = null)
        {
           
                var result = from order in Context.Orders
                             join customer in Context.Customers on order.CustomerId equals customer.Id
                             join address in Context.Addresses on order.AddressId equals address.Id
                             select new OrderdetailDto()
                             {
                                 
                                 Id=order.Id,
                                 Address=address.AddressLine,
                                 CustomerFullName=customer.FirstName+" "+customer.LastName,
                                 CustomerId=customer.Id,
                                 AddressId=address.Id,
                                 TotalPrice=order.TotalPrice,
                             
                             };
                return predicate != null ? result.Where(predicate).ToList() : result.ToList();
            }
        
    }
}