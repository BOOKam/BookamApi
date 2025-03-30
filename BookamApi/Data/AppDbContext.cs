using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookamApi.Data
{ 
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
            public DbSet<Booking> Booking {get; set;}
            public DbSet<Payment> Payment {get; set;}
            public DbSet<Routes> Routes {get; set;}
            public DbSet<Bus> Bus {get; set;}
    }
}