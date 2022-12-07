using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace PortalStore.Entity.Concrete.Entities
{
    public class OrderItem : BaseEntity
    {
        public int SkuId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual SKU Sku { get; set; }
        public virtual Order Order { get; set; }
    }
}