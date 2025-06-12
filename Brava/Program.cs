using Brava.Interfaces;
using Brava.Models;
using Brava.Repositories;
using Brava.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInfoRepository, StaticInfoRepository>();
builder.Services.AddScoped<InfoService>();
builder.Services.AddScoped<IGummieRepository, MockGummieRepository>();
builder.Services.AddScoped<IBatchRepository, MockBatchRepository>();

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

app.Run();
