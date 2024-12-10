using Microsoft.EntityFrameworkCore;
using DocumentConverter.App.Data;
using DocumentConverter.App.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the database context to the container.
builder.Services.AddDbContext<DocumentConverterAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Non-prod settings
if (app.Environment.IsDevelopment())
{
    SeedDatabase(app);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Seed the database with default data.
void SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<DocumentConverterAppContext>();
        context.Database.EnsureCreated();

        // Add default user
        if (!context.Users.Any())
        {
            context.Users.Add(
                new User
                {

                    UserId = Guid.NewGuid(),
                    UploadLimit = 1000,
                    DownloadLimit = 1000,
                    FileSizeLimit = 1 * 1024 * 1024 // 1 MB
                }
            );

            context.SaveChanges();
        }
    }
}
