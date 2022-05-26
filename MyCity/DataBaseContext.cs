using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCity
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyCity;Username=postgres;Password=kadjitnichegonekral");
        }
    }
}
