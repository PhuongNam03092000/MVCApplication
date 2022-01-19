using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Book : BaseEntity
    {
        public string nameOfBook { get; set; }
        public string fileImageUrl { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public string content { get; set; }
        public virtual IList<BookAuthor> listBookAuthor { get; set; }
        public virtual IList<BookCategory> listBookCategory { get; set; }
    }
}
