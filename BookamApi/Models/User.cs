using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookamApi.Models
{
    public class User : IdentityUser
    {
       public float wallet {get; set;} = 0; 
    }
}