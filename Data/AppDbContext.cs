#nullable disable

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RevisionTwo_App.Models.App;

using RevisionTwo_App.Models;

namespace RevisionTwo_App.Data
{
    public class AppDbContext : IdentityDbContext<DemoUser>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {  }

        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Address_App> Address_App { get; set; }
        public DbSet<Bill_App> Bill_App { get; set; }
        public DbSet<BillDetail_App> BillDetail_App { get; set; }
        public DbSet<Case_App> Case_App { get; set; }
        public DbSet<Contact_App> Contact_App { get; set; }
        public DbSet<Opportunity_App> Opportunity_App { get; set; }
        public DbSet<SalesOrder_App> SalesOrder_App { get; set; }
        public DbSet<Shipment_App> Shipment_App { get; set; }
        public DbSet<ShipmentDetail_App> ShipmentDetail_App { get; set; }
    }
}
