using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : EFRepository<Book>, IBookRepository
    {
        public BookRepository(MVCApplicatonDbContext context):base(context)
        {

        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(book => book.nameOfBook.Contains(searchString));
            }

            Sort(sortOrder, ref query);
            query = query.Include(book => book.listBookAuthor).ThenInclude(ba => ba.author);
            query = query.Include(book => book.listBookCategory).ThenInclude(ba => ba.category);
            count = query.Count();
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsSplitQuery().ToList();
        }

        public static void Sort(string sortOrder, ref IQueryable<Book> query)
        {
            switch (sortOrder)
            {
                case "tens_desc":
                    query = query.OrderByDescending(book => book.nameOfBook);
                    break;
                case "tens":
                    query = query.OrderBy(book => book.nameOfBook);
                    break;
                case "mas_desc":
                    query = query.OrderByDescending(book => book.id);
                    break;
                case "mas":
                    query = query.OrderBy(book => book.id);
                    break;
                default:
                    query = query.OrderBy(book => book.id);
                    break;
            }
        }

        public void DeleteAllElement()
        {
            _context.Books.RemoveRange(_context.Books);
            _context.SaveChanges();

        }

        public void UpdateBookAuthor(Book book, List<BookAuthor> bookAuthorList)
        {
            foreach (var bookauthor in bookAuthorList)
            {
                if (!book.listBookAuthor.Any(item => item.authorId == bookauthor.authorId))
                {
                    book.listBookAuthor.Add(bookauthor);
                }
            }
            foreach (var bookauthor in book.listBookAuthor.ToArray())
            {
                if (!bookAuthorList.Any(item => item.authorId == bookauthor.authorId))
                {
                    book.listBookAuthor.Remove(bookauthor);
                }
            }
        }

        public void UpdateBookCategory(Book book, List<BookCategory> bookCategoryList)
        {
            foreach (var bookcategory in bookCategoryList)
            {
                if (!book.listBookCategory.Any(item => item.categoryId == bookcategory.categoryId))
                {
                    book.listBookCategory.Add(bookcategory);
                }
            }
            foreach (var bookcategory in book.listBookCategory.ToArray())
            {
                if (!bookCategoryList.Any(item => item.categoryId == bookcategory.categoryId))
                {
                    book.listBookCategory.Remove(bookcategory);
                }
            }
        }

    }
}
