using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BookAuthor
    {
        public int bookId { get; set; }
        [ForeignKey(nameof(bookId))]
        public virtual Book book { get; set; }
        public int authorId { get; set; }
        [ForeignKey(nameof(authorId))]
        public virtual Author author { get; set; }
    }
}
