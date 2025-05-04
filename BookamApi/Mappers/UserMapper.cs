using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.User;
using BookamApi.Models;

namespace BookamApi.Mappers
{
    public static class UserMapper
    {
        public static DisplayUserProfile userProfile (this User user)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            return new DisplayUserProfile{
                UserName = user.UserName,
                FullName = user.FullName,
                Phone = user.Phone,
                City = user.City,
                ZipCode = user.ZipCode,
                Address = user.Address,
                State = user.State
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public static User ToCreateUserProfileDto (this CreateUserProfileDto create)
        {
            return new User {
                FullName = create.FullName,
                Phone = create.Phone,
                City = create.City,
                ZipCode = create.ZipCode,
                Address = create.Address,
                State = create.State
            };
        }
        public static BookUserDto ToBookUserDto (this User user)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            return new BookUserDto{
                UserName = user.UserName,
                FullName = user.FullName,
                Phone = user.Phone
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }
}