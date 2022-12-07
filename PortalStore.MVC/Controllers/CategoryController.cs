using Microsoft.AspNetCore.Mvc;
using PortalStore.Business.Abstract;
using PortalStore.Entity.Concrete.DTOs.Category;

namespace PortalStore.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListCategory()
        {
            var result =await _categoryService.GetAll();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> AddCategory( )
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto category)
        {
            var result = await _categoryService.Add(category);
            return RedirectToAction("GetListCategory");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
           
            var result =await _categoryService.Delete(id);
            return RedirectToAction("GetListCategory");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {

            var result = await _categoryService.Get(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
        {

            var result = await _categoryService.Update(category);
            return RedirectToAction("GetListCategory");
        }
    }
}
