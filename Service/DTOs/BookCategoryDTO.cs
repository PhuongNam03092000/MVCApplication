using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class BookCategoryDTO
    {
        public int bookId { get; set; }
        public int categoryId { get; set; }
        public Book book { get; set; }
        public Category category {get;set;}
    }
}
