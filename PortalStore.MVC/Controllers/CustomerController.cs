using Microsoft.AspNetCore.Mvc;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.Customer;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListCustomer()
        {
            var result = await _customerService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDto customer)
        {
            var result = await _customerService.Add(customer);
            return RedirectToAction("GetListCustomer");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
           
            var result = await _customerService.Delete(id);
            return RedirectToAction("GetListCustomer");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            var data = await _customerService.Get(id);

            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCustomer(UpdateCustomerDto customer)
        {
            var data = await _customerService.Update(customer);
            return RedirectToAction("GetListCustomer");
        }
    }
}