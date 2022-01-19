using AutoMapper;
using Infrastructure.Entities;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
            CreateMap<BookCategory, BookCategoryDTO>().ReverseMap();
        }
    }
}
