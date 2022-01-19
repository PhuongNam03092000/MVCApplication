using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class CategoryDTO
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public bool status { get; set; }

        public IList<BookCategoryDTO> listBookCategory { get; set; }

    }
}
