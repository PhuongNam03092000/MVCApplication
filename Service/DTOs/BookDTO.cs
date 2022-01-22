using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Service.DTOs
{
    public class BookDTO
    {
        public int id { get; set; }
        public string  nameOfBook {get;set;}
        public IFormFile image {get;set;}
        public string fileImageUrl { get; set; }
        public string content { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
        public bool status { get; set; }
        public virtual IList<BookAuthorDTO> listBookAuthor { get; set; }
        public virtual IList<BookCategoryDTO> listBookCategory { get; set; }

    }
}
