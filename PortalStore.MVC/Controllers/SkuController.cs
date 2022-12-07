using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.SKU;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.MVC.Controllers
{
    public class SkuController : Controller
    {
        private readonly ISkuService _skuService;
        private readonly ICategoryService _categoryService;

        public SkuController(ISkuService skuService, ICategoryService categoryService)
        {
            _skuService = skuService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListSku()
        {
            var result = await _skuService.GetAll();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> AddSku()
        {

            ViewBag.data = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSku(SkuAddDto sku)
        {
            var result = await _skuService.Add(sku);
            return RedirectToAction("GetListSku");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSku(int id)
        {
            var data = _skuService.Get(id);
            var result = await _skuService.Delete(data.Result);
            return RedirectToAction("GetListSku");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSku(int id)
        {
            var result = await _skuService.Get(id);
            ViewBag.data = new SelectList(await _categoryService.GetAll(), "Id", "Name", result.CategoryId);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSku(SkuUpdateDto sku)
        {

            var result = await _skuService.Update(sku);
            return RedirectToAction("GetListSku");
        }

    }
}