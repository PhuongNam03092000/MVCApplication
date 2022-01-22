using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using Service.DTOs;
using Service.Helpers;
using Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private BookDTO bookTemp ;
        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
        }

        // GET: BookController
        public ActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            ViewBag.CategoryList = _categoryService.GetAll().Where(item => item.status == true).ToList();
            ViewBag.AUthorList = _authorService.GetAll().Where(item => item.status == true).ToList();
            int pageSize = 4;
            int count;
            var bookDTO = new BookDTO();
            var items = _bookService.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            var authorItems = new List<int>();
            var categoryItems = new List<int>();
            var vm = new BookViewModel()
            {
                book = bookDTO,
                books = new PaginatedList<BookDTO>(items, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                Authors = authorItems,
                Categories = categoryItems
            };
            return View(vm);
        }
        private void GetAuthorList() => ViewBag.AuthorList = _authorService.GetAll().Where(item => item.status == true);
        private void GetCategoryList() => ViewBag.CategoryList = _categoryService.GetAll().Where(item => item.status == true);

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {

            var vm = new BookViewModel();
            vm.book = _bookService.GetById(id);
            GetAuthorList();
            GetCategoryList();
            vm.Authors = vm.book.listBookAuthor.Select(item => item.authorId).ToList();
            vm.Categories = vm.book.listBookCategory.Select(item => item.categoryId).ToList();
            return PartialView(@"~/Views/Book/Details.cshtml", vm);
        }
        // POST: BookController/Create

        private void PassData(BookViewModel vm, int? bookId)
        {
            if (vm.Authors != null && vm.Authors.ToArray().Length != 0)
            {
                vm.book.listBookAuthor = new List<BookAuthorDTO>();
                foreach (var authorID in vm.Authors)
                {
                    var bookAuthorDTO = new BookAuthorDTO { book = vm.book, authorId = authorID,bookId = bookId==null?default(int):bookId.Value };
                    vm.book.listBookAuthor.Add(bookAuthorDTO);
                }
            }
            if (vm.Categories != null && vm.Categories.ToArray().Length != 0)
            {
                vm.book.listBookCategory = new List<BookCategoryDTO>();
                foreach (var categoryID in vm.Categories)
                {
                    var bookCategoryDTO = new BookCategoryDTO { book = vm.book, categoryId = categoryID, bookId = bookId==null?default(int):bookId.Value };
                    vm.book.listBookCategory.Add(bookCategoryDTO);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                PassData(vm,null);
                var result = await _bookService.Create(vm.book);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public void Edit(int id)
        {
             
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BookViewModel vm)
        {
            PassData(vm,vm.book.id);
            await _bookService.Update(vm.book);
            return RedirectToAction(nameof(Index));
        }

   

    }
}
