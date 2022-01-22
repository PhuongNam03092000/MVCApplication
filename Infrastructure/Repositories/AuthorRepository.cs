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
    public class AuthorRepository :  EFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(MVCApplicatonDbContext context) : base(context)
        {

        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = _context.Authors.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(author => author.authorName.Contains(searchString));
            }
            Sort(sortOrder, ref query);
            query = query.Where(item => item.status==true);
            query = query.Include(author => author.listBookAuthor);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        private static void Sort(string sortOrder, ref IQueryable<Author> query)
        {
            switch (sortOrder)
            {
                case "tentg_desc":

                    query = query.OrderByDescending(author => author.authorName);
                    break;

                case "tentg":

                    query = query.OrderBy(author => author.authorName);
                    break;

                case "matg_desc":
                    query = query.OrderByDescending(author => author.id);
                    break;

                case "matg":
                    query = query.OrderBy(author => author.id);
                    break;

                default:
                    query = query.OrderBy(author => author.id);
                    break;

            }
        }

        
    }
}
