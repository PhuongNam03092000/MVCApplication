using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class AuthorDTO
    {
        public int id { get; set; }
        [Required]
        public string authorName { get; set; }
        public bool status { get; set; }
        public virtual IList<BookAuthorDTO> listBookAuthor { get; set; }
    }
}
