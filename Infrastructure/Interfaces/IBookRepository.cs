using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBookRepository : IEFRepository<Book>
    {
        IEnumerable<Book> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        int Count();
    }
}
