using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTOs;
using Service.Helpers;

namespace MVCApplication.Models
{
    public class CategoryViewModel
    {
        public PaginatedList<CategoryDTO> categories {get;set;}
        public CategoryDTO category {get;set;}
        public string SearchString {get;set;}
        public string SortOrder{get;set;}
    }
}