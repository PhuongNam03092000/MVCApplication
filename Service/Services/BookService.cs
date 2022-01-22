using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Service.DTOs;
using Service.Intefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : IBookService
    {
        public readonly IMapper _mapper;
        public readonly IBookRepository _ibookRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookService(IMapper mapper,IBookRepository ibookRepository, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _ibookRepository = ibookRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> Create(BookDTO entity)
        {
            UploadFile(ref entity);
            var book = _mapper.Map<BookDTO,Book>(entity);
            book.status = true;
            return await _ibookRepository.Create(book);
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


        public async Task<bool> Update(BookDTO entity)
        {
            var oldBook = GetById(entity.id);
            Console.WriteLine(entity.listBookAuthor.Count());
            foreach(var item in oldBook.listBookAuthor){
                if(entity.listBookAuthor.Any(x =>  (x.authorId==item.authorId && x.bookId == item.bookId))==false){
                    entity.listBookAuthor.Add(item);
                }
            }
            foreach(var item in oldBook.listBookCategory){
                if(entity.listBookCategory.Any(x =>(x.categoryId==item.categoryId))==false){
                   entity.listBookCategory.Add(item);
                   
                }
            }
            var book = _mapper.Map<BookDTO, Book>(entity);
            Console.WriteLine(book.listBookAuthor.Count());
            return await _ibookRepository.Update(book);
        }

        public BookDTO GetById(int id)
        {
            var book =  _ibookRepository.GetById(id);
            return _mapper.Map<Book,BookDTO>(book);
        }

        private void UploadFile(ref BookDTO book){
            var path = "image/";
            if (book.image != null)
            {
                string fileEx = "jpg";
                if (book.image.ContentType == "image/png") { fileEx = "png"; }
                else if (book.image.ContentType == "image/gif") { fileEx = "gif"; }
                else if (book.image.ContentType == "image/jpeg") { fileEx = "jpeg"; }

                path += String.Format("{0}.{1}", Guid.NewGuid().ToString(), fileEx);
                book.fileImageUrl = path;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, path);
                book.image.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            Console.WriteLine("File path in Upload Image: " + path);
        }
    }
}
