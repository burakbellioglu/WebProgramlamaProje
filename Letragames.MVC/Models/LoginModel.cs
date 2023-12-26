using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Letragames.MVC.Models
{
    public class LoginModel
    {

        [Required]
        [EmailAddress(ErrorMessage = "E mail adresini hatalı girdiniz")]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }

    }
}