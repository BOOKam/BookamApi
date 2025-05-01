using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Models;

namespace BookamApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user, IList<string> userRoles);
    }
}