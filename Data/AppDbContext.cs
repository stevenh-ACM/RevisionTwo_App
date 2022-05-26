#nullable disable

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RevisionTwo_App.Models;

namespace RevisionTwo_App.Data
{
    public class AppDbContext : IdentityDbContext<DemoUser>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {  }

        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Addr> Addrs { get; set; }
        public DbSet<AR_Bill> AR_Bills { get; set; }
        public DbSet<AR_BillDetail> AR_BillDetails { get; set; }
        public DbSet<CRCase> CRCases { get; set; }
        public DbSet<CO> Contacts { get; set; }
        public DbSet<OP> Opportunities { get; set; }
        public DbSet<SO> SalesOrders { get; set; }
        public DbSet<SP> Shipments { get; set; }
        public DbSet<SPDetail> ShipmentDetails { get; set; }
    }
}
