using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        public readonly MVCApplicatonDbContext _context;
        public EFRepository(MVCApplicatonDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entity)
        {
            _context.Set<T>();
            await _context.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return  _context.Set<T>().Find(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _context.Set<T>();
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
        
            return result > 0 ? true : false;
        }
    }
}
