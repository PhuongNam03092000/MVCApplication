using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Intefaces
{
    public interface IBookService
    {
        IList<BookDTO> GetAll();
        IList<BookDTO> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        bool Create(BookDTO entity);
        bool Update(BookDTO entity);
        bool Delete(int id);
        BookDTO GetById(int id);
    }
}
