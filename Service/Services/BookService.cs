using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Service.DTOs;
using Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Service.Services
{
    public class BookService : IBookService
    {
        public readonly IMapper _mapper;
        public readonly IBookRepository _ibookRepository;
        public BookService(IMapper mapper,IBookRepository ibookRepository)
        {
            _mapper = mapper;
            _ibookRepository = ibookRepository;
        }
        public bool Create(BookDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<BookDTO> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var list = _ibookRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return _mapper.Map<IList<Book>, IList<BookDTO>>(list.ToList());
        }

        public IList<BookDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BookDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
