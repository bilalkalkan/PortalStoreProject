using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.Address;
using PortalStore.Entity.Concrete.DTOs.Order;
using PortalStore.Entity.Concrete.DTOs.OrderItem;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.MVC.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        
        private readonly ISkuService _skuService;

        public OrderItemController(IOrderItemService orderItemService, ISkuService skuService)
        {
            _orderItemService = orderItemService;
            _skuService = skuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListOrderItems()
        {
            var result = await _orderItemService.GetAll();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> AddOrderItem( ) 
        {
          
            ViewBag.Skus = new SelectList(await _skuService.GetAll(),"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem(AddOrderItemDto orderItem)
        {
            orderItem.OrderId =Convert.ToInt32( TempData["orderId"].ToString());
            var result = await _orderItemService.Add(orderItem);
            return RedirectToAction("GetListOrderItems");
        }
    }
}
