using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Intefaces
{
    public interface IAuthorService
    {
        IList<AuthorDTO> GetAll();
        IList<AuthorDTO> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        Task<bool> Create(AuthorDTO entity);
        Task<bool> Update(AuthorDTO entity);
        bool Delete(int id);
        Task<AuthorDTO> GetById(int id);
    }
}
