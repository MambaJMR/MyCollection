using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Repositories;
using ItransitionMVC.Services;
using ItransitionMVC.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectItransition.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.AddScoped<ICustomCollectionRepository, CustomCollectionRepository>();
builder.Services.AddScoped<ICustomCollectionService, CustomCollectionService>();
builder.Services.AddScoped<ICollectionItemRepository, CollectionItemRepository>();
builder.Services.AddScoped<ICollectionItemService, CollectionItemService>();
builder.Services.AddScoped<UpLoadImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
