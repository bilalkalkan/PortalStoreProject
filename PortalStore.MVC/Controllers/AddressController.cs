using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.Address;

namespace PortalStore.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;

        public AddressController(IAddressService addressService, ICustomerService customerService)
        {
            _addressService = addressService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAddress()
        {
            var result =await _addressService.GetAll();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddAddress( )
        {
            ViewBag.data = new SelectList(await _customerService.GetAll(),"Id" , "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressDto address)
        {
            var result = await _addressService.Add(address);
            return RedirectToAction("GetListAddress");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = _addressService.Delete(id);
            return RedirectToAction("GetListAddress");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(int id)
        {
            var result = await _addressService.Get(id);
            ViewBag.data = new SelectList(await _customerService.GetAll(), "Id", "FirstName");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto address)
        {
            var result = await _addressService.Update(address);
            return RedirectToAction("GetListAddress");
        }

    }
}
