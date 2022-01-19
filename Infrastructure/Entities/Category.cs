using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Category : BaseEntity
    {
        public string categoryName { get; set; }
        public virtual IList<BookCategory> listBookCategory { get; set; }
    }
}
