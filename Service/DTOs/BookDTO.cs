using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Service.DTOs
{
    public class BookDTO
    {
        public int id { get; set; }
        public IFormFile image {get;set;}
        public string imageUrl { get; set; }
        public string content { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
        public bool status { get; set; }
        public IList<BookAuthorDTO> listBookAuthor { get; set; }
        public IList<BookCategoryDTO> listBookCategory { get; set; }

    }
}
