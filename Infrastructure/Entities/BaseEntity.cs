using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
        public bool status { get; set; }
    }
}
