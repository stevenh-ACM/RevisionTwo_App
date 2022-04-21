#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevisionTwo_App.Models;

namespace RevisionTwo_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {  }

        public DbSet<Credential> Credentials { get; set; }
    }
}
