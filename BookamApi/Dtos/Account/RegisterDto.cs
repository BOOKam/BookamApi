using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username {get; set;}
        
        [Required]
        [EmailAddress]
        public string? Email {get; set;}
        
        [Required]
        [MinLength(8)]
        public string? Password {get; set;}
    }
}