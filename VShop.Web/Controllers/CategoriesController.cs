using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Index()
        {
            var result = await _categoryService.GetAllCategories();
            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.CreateCategory(categoryVM);

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(categoryVM);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var result = await _categoryService.FindCategoryById(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateCategory(CategoryVM);

                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(CategoryVM);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryViewModel>> DeleteCategory(int id)
        {
            var result = await _categoryService.FindCategoryById(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost(), ActionName("DeleteCategory")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _categoryService.DeleteCategoryById(id);

            if (!result)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
