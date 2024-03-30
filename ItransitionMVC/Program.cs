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
using Microsoft.AspNetCore.Localization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectItransition.Repositories;
using System.Globalization;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResurse).GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        };

    });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
       new CultureInfo("ru-RU"),
       new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "ru-RU", uiCulture: "ru-RU");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
//builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
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
builder.Services.AddScoped<IOrderByService, OrderByService>();

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
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapHub<ItemHub>("Home/ItemView");

app.Run();
