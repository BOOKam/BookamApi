using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

            protected override void OnModelCreating (ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                List<IdentityRole> role = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(role);
            builder.Entity<Bus>()
                .HasOne(b => b.routes)
                .WithMany(r => r.Buses)
                .HasForeignKey(b => b.RouteId);
            builder.Entity<Booking>()
                .HasOne(b => b.user)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .IsRequired();

            builder.Entity<Booking>()
                .HasOne(b => b.bus)
                .WithMany()
                .HasForeignKey(b => b.BusId)
                .IsRequired(); 

            builder.Entity<Booking>()
                .HasOne(b => b.route)
                .WithMany()
                .HasForeignKey(b => b.RouteId)
                .IsRequired();

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            }
    }
}