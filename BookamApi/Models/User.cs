using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookamApi.Models
{
    public class User : IdentityUser
    {
       public string FullName { get; set; } = string.Empty;
       public string Phone { get; set; } = string.Empty;
       public string City { get; set; } = string.Empty;
       public int ZipCode { get; set; }
       public string Address {get; set;} = string.Empty;
       public string State {get; set;} = string.Empty;
    }
}