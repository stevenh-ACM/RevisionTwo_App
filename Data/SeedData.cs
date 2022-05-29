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
                    IsChecked = true,
                    SiteUrl = "https://acu-demos.us/acumaticaerp",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "MyTenant",
                    Branch = "main",
                    Locale = "en-US"

                },

                new Credential
                {
                    IsChecked = false,
                    SiteUrl = "http://localhost/acumaticaerp",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "Company",
                    Branch = "",
                    Locale = "en-US"

                },

                new Credential
                {
                    IsChecked = false,
                    SiteUrl = "https://acu-demos.us/mystoreinstance",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "MyStore",
                    Branch = "MYSTORE",
                    Locale = "en-US"

                },

                new Credential
                {
                    IsChecked = false,
                    SiteUrl = "https://acu-demos.us/phonerepairshop",
                    UserName = "admin",
                    Password = "123",
                    Tenant = "MyTenant",
                    Branch = "Yogifon",
                    Locale = "en-US"

                }
            );
            context.SaveChanges();
        }
    }
}