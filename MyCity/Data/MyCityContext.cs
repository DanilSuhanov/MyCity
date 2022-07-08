using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCity.Models;

namespace MyCity.Data
{
    public class MyCityContext : DbContext
    {
        public MyCityContext (DbContextOptions<MyCityContext> options)
            : base(options)
        {
        }

        public DbSet<MyCity.Models.User> User { get; set; }
    }
}
