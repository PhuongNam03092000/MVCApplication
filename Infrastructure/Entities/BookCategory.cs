using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BookCategory
    {
        public int bookId { get; set; }
        [ForeignKey(nameof(bookId))]
        public virtual Book book { get; set; }
        public int categoryId { get; set; }
        [ForeignKey(nameof(categoryId))]
        public virtual Category category { get; set; }
    }
}
