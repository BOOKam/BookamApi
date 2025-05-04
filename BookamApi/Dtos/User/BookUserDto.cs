using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.User
{
    public class BookUserDto
    {
       public string UserName { get; set; } = string.Empty;
       public string FullName { get; set; } = string.Empty;
       public string Phone { get; set; } = string.Empty;
    }
}