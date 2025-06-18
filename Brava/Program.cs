using Brava.DbContext;
using Brava.Interfaces;
using Brava.Models;
using Brava.Repositories;
using Brava.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection String //
var connectionString = builder.Configuration.GetConnectionString("BravaDbContextConnection") ??
    throw new InvalidOperationException("Connection string 'BravaDbContextConnection' not found");

// Db Context & Entity Framework //
builder.Services.AddDbContext<BravaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<BravaDbContext>();

// Controllers w/ Views //
builder.Services.AddControllersWithViews()
    .AddViewOptions(options =>
    {
        options.HtmlHelperOptions.ClientValidationEnabled = true;
    });

// Repositories //
builder.Services.AddScoped<IInfoRepository, StaticInfoRepository>();
builder.Services.AddScoped<InfoService>();
builder.Services.AddScoped<IGummieRepository, GummieRepository>();
//builder.Services.AddScoped<IGummieRepository, MockGummieRepository>();
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
//builder.Services.AddScoped<IBatchRepository, MockBatchRepository>();
builder.Services.AddScoped<IFAQItemRepository, FAQItemRepository>();
builder.Services.AddScoped<IFAQCategoryRepository, FAQCategoryRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

DBInitializer.Seed(app);

app.Run();
