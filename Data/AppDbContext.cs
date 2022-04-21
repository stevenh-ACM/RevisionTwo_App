#nullable disable

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
