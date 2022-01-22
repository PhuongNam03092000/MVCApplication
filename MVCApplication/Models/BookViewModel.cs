using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTOs;
using Service.Helpers;

namespace MVCApplication.Models
{
    public class BookViewModel
    {
        public PaginatedList<BookDTO> books {get;set;}
        public BookDTO book {get;set;}
        public string SearchString {get;set;}
        public string SortOrder{get;set;}
        public  IList<int> Authors { get; set; }
        public  IList<int> Categories { get; set; }
        
    }
}