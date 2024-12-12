using DocumentConverter.App.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDatabase(builder.Configuration)
    .AddServices()
    .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

DbConfig.RunMigrations(app);
RouteConfig.ConfigureRoutes(app);

// Non-prod settings
if (app.Environment.IsDevelopment())
{
    DbConfig.SeedDatabase(app);
}

app.Run();
