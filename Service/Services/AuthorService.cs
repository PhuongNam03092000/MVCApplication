using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Service.DTOs;
using Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly IAuthorRepository _iauthorRepository;
        public readonly IMapper _mapper;
        public AuthorService(IAuthorRepository iauthorRepository, IMapper mapper)
        {
            _iauthorRepository = iauthorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(AuthorDTO entity)
        {
            var listAuthor = _iauthorRepository.GetAll();
            var author = _mapper.Map<AuthorDTO, Author>(entity);
            var duplicate = listAuthor.Any(item => item.authorName.Equals(author.authorName));
            Console.WriteLine(duplicate);
            if (duplicate == true)
            {
                var oldAuthor = listAuthor.FirstOrDefault(item => item.authorName.Equals(author.authorName));
                if (oldAuthor.status == false)
                {
                    oldAuthor.status = true;
                    return await _iauthorRepository.Update(oldAuthor);
                }else{
                    return false;
                }
               

            }else{
                author.status= true;
                 return await _iauthorRepository.Create(author);
            }
         
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<AuthorDTO> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var result = _iauthorRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return _mapper.Map<IList<Author>, IList<AuthorDTO>>(result.ToList());
        }

        public IList<AuthorDTO> GetAll()
        {

            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(_iauthorRepository.GetAll()).ToList();
        }

        public AuthorDTO GetById(int id)
        {
            var author  = _iauthorRepository.GetById(id);
            return _mapper.Map<Author, AuthorDTO>(author);
        }

        public async Task<bool> Update(AuthorDTO entity)
        {
            var author = _mapper.Map<AuthorDTO, Author>(entity);
            return await _iauthorRepository.Update(author);
        }
    }
}
