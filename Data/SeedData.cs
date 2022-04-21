#nullable disable

using RevisionTwo_App.Models;

using Microsoft.EntityFrameworkCore;

namespace RevisionTwo_App.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (AppDbContext context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context == null || context.Credentials == null)
            {
                throw new ArgumentNullException("Null AppDbContext");
            }

            // Look for any entries.
            if (context.Credentials.Any())
            {
                return;   // DB has been seeded
            }

            context.Credentials.AddRange(
                new Credential
                {
                    SiteUrl = "https://acu-demos.us/acumaticaerp",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "MyTenant",
                    Branch = "main",
                    Locale = "en-US"

                },

                new Credential
                {
                    SiteUrl = "https://acu-demos.us/acumaticaerp",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "Company",
                    Branch = "USA",
                    Locale = "en-US"

                },

                new Credential
                {
                    SiteUrl = "https://acu-demos.us/acumaticaerp",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "MyStore",
                    Branch = "MYSTORE",
                    Locale = "en-US"

                },

                new Credential
                {
                    SiteUrl = "https://acu-demos.us/acumaticaerp",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "Company",
                    Branch = "other",
                    Locale = "en-US"

                }
            );
            context.SaveChanges();
        }
    }
}