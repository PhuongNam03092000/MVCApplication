using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MVCApplicatonDbContext context):base(context)
        {

        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(categories => categories.categoryName.Contains(searchString));
            }
            Sort(sortOrder, ref query);

            count = query.Count();
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        private static void Sort(string sortOrder, ref IQueryable<Category> query)
        {
            switch (sortOrder)
            {
                case "tentl_desc":
                    query = query.OrderByDescending(categories => categories.categoryName);
                    break;
                case "tentl":
                    query = query.OrderBy(categories => categories.categoryName);
                    break;
                case "matl_desc":
                    query = query.OrderByDescending(categories => categories.id);
                    break;
                case "matl":
                    query = query.OrderBy(categories => categories.id);
                    break;
                default:
                    query = query.OrderBy(categories => categories.id);
                    break;
            }
        }
    }
}
