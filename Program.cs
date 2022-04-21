#nullable disable


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using RevisionTwo_App.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole();

// Add services to the container.


builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>

    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));

var app = builder.Build();

//Seed AcuCredentials
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.Logger.LogInformation("Production Environment");
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.Logger.LogInformation("Development Environment");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();