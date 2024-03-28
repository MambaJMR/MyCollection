using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Hubs;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.ICommentsAndLike;
using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Interfaces.IElementService;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models;
using ItransitionMVC.Repositories;
using ItransitionMVC.Repositories.CustomElement;
using ItransitionMVC.Repositories.LikeAndComments;
using ItransitionMVC.Services;
using ItransitionMVC.Services.CommentsService;
using ItransitionMVC.Services.ElementsServise;
using ItransitionMVC.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ProjectItransition.Repositories;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// .AddJsonOptions(x =>
//x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddIdentity<CustomUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.Configure<ElasticSettings>(builder.Configuration.GetSection(nameof(ElasticSettings)));
builder.Services.AddSignalR();
builder.Services.AddScoped<ICustomCollectionRepository, CustomCollectionRepository>();
builder.Services.AddScoped<ICustomCollectionService, CustomCollectionService>();

builder.Services.AddScoped<ICollectionItemRepository, CollectionItemRepository>();
builder.Services.AddScoped<ICollectionItemService, CollectionItemService>();

builder.Services.AddScoped<IStringElementRepository, StringElementRepository>();
builder.Services.AddScoped<IStringElementService, StringElementService>();

builder.Services.AddScoped<IIntElementRepository, IntElementRepository>();
builder.Services.AddScoped<IIntElementService,IntElementService>();

builder.Services.AddScoped<IDateElementRepository, DateElementRepository>();
builder.Services.AddScoped<IDateElementService, DateElementService>();

builder.Services.AddScoped<IBoolElementRepository, BoolElementRepository>();
builder.Services.AddScoped<IBoolElementService, BoolElementService>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IElasticService, ElasticService>();
builder.Services.AddScoped<UpLoadImageService>();
builder.Services.AddScoped<TagService>();

builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapHub<ItemHub>("Home/ItemView");

app.Run();
