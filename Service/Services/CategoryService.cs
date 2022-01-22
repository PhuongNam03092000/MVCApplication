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
    public class CategoryService : ICategoryService
    {
        public readonly IMapper _mapper;
        public readonly ICategoryRepository _icategoryRepository;
        public CategoryService(IMapper mapper, ICategoryRepository icategoryRepository)
        {
            _mapper = mapper;
            _icategoryRepository = icategoryRepository;
        }
        public async Task<bool> Create(CategoryDTO entity)
        {
            var category = _mapper.Map<CategoryDTO,Category>(entity);
            var listCategory = _icategoryRepository.GetAll();
            var duplicate = listCategory.Any(item => item.categoryName.Equals(category.categoryName));
            if(duplicate){
                var oldCategory = listCategory.FirstOrDefault(item => item.categoryName.Equals(category.categoryName));
                if(oldCategory.status==false){
                    oldCategory.status = true;
                    return await _icategoryRepository.Update(oldCategory);
                }else{
                    return false;
                }
            }else{
                category.status = true;
                return await _icategoryRepository.Create(category);
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CategoryDTO> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var list = _icategoryRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return _mapper.Map<IList<Category>, IList<CategoryDTO>>(list.ToList());
        }

        public IList<CategoryDTO> GetAll()
        {
           return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_icategoryRepository.GetAll()).ToList();
        }

        public CategoryDTO GetById(int id)
        {
           var category =  _icategoryRepository.GetById(id);
           return _mapper.Map<Category,CategoryDTO>(category);
        }

        public async Task<bool> Update(CategoryDTO entity)
        {
            var category = _mapper.Map<CategoryDTO,Category>(entity);
            return await _icategoryRepository.Update(category);
        }
    }
}
