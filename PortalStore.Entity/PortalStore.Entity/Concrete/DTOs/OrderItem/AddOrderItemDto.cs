﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Entity.Concrete.DTOs.OrderItem
{
    public class AddOrderItemDto
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
