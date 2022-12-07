using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.Order;

namespace PortalStore.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;


        public OrderController(IOrderService orderService, ICustomerService customerService, IAddressService addressService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddOrder( )
        {
            ViewBag.addresses= new SelectList(await _addressService.GetAll(), "Id", "AddressLine");
            ViewBag.customers = new SelectList(await _customerService.GetAll(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDto order)
        {
            var result =await _orderService.Add(order);
            TempData["orderId"] = result.Id;
            return RedirectToAction("AddOrderItem", "OrderItem");
        }
    }
}
