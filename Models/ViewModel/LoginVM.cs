using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _23DH113573_MyStore.Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        [Display(Name ="Tên đăng nhập")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Mật Khẩu")]
        public string Password { get; set; }
    }
}