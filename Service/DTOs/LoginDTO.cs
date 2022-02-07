using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username không được bỏ trống")]
        public string username { get; set; }
        [Required(ErrorMessage ="Password không được bỏ trống")]
        public string password { get; set; }
    }
}
