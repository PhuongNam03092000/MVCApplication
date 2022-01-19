using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Intefaces
{
    public interface ICategoryService
    {
        IList<CategoryDTO> GetAll();
        IList<CategoryDTO> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        Task<bool> Create(CategoryDTO entity);
        Task<bool> Update(CategoryDTO entity);
        bool Delete(int id);
        Task<CategoryDTO> GetById(int id);
    }
}
