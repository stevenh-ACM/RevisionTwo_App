//#nullable disable

//using RevisionTwo_App.Models;

//using Microsoft.EntityFrameworkCore;

//namespace RevisionTwo_App.Data;

//public static class SeedData
//{
//    public static void Initialize(IServiceProvider serviceProvider)
//    {
//        using (AppDbContext context = new AppDbContext(
//            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
//        {
//            if (context == null || context.AcuAuths == null)
//            {
//                throw new ArgumentNullException("Null AppDbContext");
//            }

//            // Look for any entries.
//            if (context.AcuAuths.Any())
//            {
//                return;   // DB has been seeded
//            }

//            context.AcuAuths.AddRange(
//                new AcuAuth
//                {
//                    SiteUrl = "https://acu-demos.us/acumaticaerp",
//                    UserName = "admin",
//                    Password = "123",
//                    Tenant = "MyTenant",
//                    Branch = "main",
//                    Locale = "en-US"

//                },

//                new AcuAuth
//                {
//                    SiteUrl = "https://acu-demos.us/acumaticaerp",
//                    UserName = "admin",
//                    Password = "123",
//                    Tenant = "Company",
//                    Branch = "USA",
//                    Locale = "en-US"

//                },

//                new AcuAuth
//                {
//                    SiteUrl = "https://acu-demos.us/acumaticaerp",
//                    UserName = "admin",
//                    Password = "123",
//                    Tenant = "MyStore",
//                    Branch = "MYSTORE",
//                    Locale = "en-US"

//                },

//                new AcuAuth
//                {
//                    SiteUrl = "https://acu-demos.us/acumaticaerp",
//                    UserName = "admin",
//                    Password = "123",
//                    Tenant = "Company",
//                    Branch = "other",
//                    Locale = "en-US"

//                }
//            );
//            context.SaveChanges();
//        }
//    }
//}