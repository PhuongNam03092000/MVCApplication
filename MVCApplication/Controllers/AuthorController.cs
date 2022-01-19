using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using Service.DTOs;
using Service.Helpers;
using Service.Intefaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;   
        }
        public ActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var items = _authorService.Filter(sortOrder, searchString, pageIndex, pageSize, out count).OrderBy(item => item.authorName);
            var authorItems = Enumerable.Empty<int>();
            var categoryItems = Enumerable.Empty<int>();
            var author = new AuthorDTO();
            var vm = new AuthorViewModel()
            {
                authors = new PaginatedList<AuthorDTO>(items,count,pageIndex,pageSize),
                author = author,
                SearchString = searchString,
                SortOrder = sortOrder
            };
            return View(vm);
        }
        public async Task<ActionResult> Details(int id)
        {
            var author = await _authorService.GetById(id);
            return PartialView(@"~/Views/Author/Details.cshtml", author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var author = vm.author;
                await _authorService.Create(author);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Update(authorDTO);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int authorId)
        {
            var author = await _authorService.GetById(authorId);
            return PartialView(@"~/Views/Author/DeleteConfirm.cshtml",author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AuthorDTO author)
        {
            if(author!=null){
                author.status = false;
                await _authorService.Update(author);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
