using Service.DTOs;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.Models
{
    public class AuthorViewModel
    {
        public PaginatedList<AuthorDTO> authors { get; set; }
        public AuthorDTO author { get; set; }
        public string SearchString {get;set;}
        public string SortOrder{get;set;}
    }
}
