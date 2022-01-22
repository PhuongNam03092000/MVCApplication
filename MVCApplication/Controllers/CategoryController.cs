using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using Service.DTOs;
using Service.Helpers;
using Service.Intefaces;

namespace MVCApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: CategoryController
        public ActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var items = _categoryService.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            var category = new CategoryDTO();
            var vm = new CategoryViewModel()
            {
                categories = new PaginatedList<CategoryDTO>(items,count,pageIndex,pageSize),
                category = category,
                SearchString = searchString,
                SortOrder = sortOrder
            };
            return View(vm);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryService.GetById(id);
            return PartialView(@"~/Views/Category/Details.cshtml", category);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryViewModel vm)
        {
           if(ModelState.IsValid){
               var result = await _categoryService.Create(vm.category);
           }
           return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(category);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var categroy = _categoryService.GetById(id);
            if(categroy!=null){
                  return PartialView(@"~/Views/Category/DeleteConfirm.cshtml",categroy);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CategoryDTO category)
        {
           if(category!=null){
                category.status = false;
                await _categoryService.Update(category);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
