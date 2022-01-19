using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Author : BaseEntity
    {
        public string authorName { get; set; }
        public virtual IList<BookAuthor> listBookAuthor { get; set; }
    }
}
