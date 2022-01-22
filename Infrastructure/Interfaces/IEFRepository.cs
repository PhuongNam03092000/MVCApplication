using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEFRepository<T> where T : class
    {
        IList<T> GetAll();
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        bool Delete(int id);
        T GetById(int id);
    }
}
