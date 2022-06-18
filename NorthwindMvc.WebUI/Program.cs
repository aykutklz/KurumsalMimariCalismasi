using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using NorthwindMvc.WebUI.Entities;
using NorthwindMvc.WebUI.Middlewares;
using NorthwindMvc.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDb;Trusted_Connection=true"));
builder.Services.AddIdentity<CustomIdentityUser,CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();

//Session Mimarimizin eklenmei
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
//Session'ýmýzda kullandýðýmýz httpcontextaccessor'u configure ettik.
//builder.Services.AddHttpContextAccessor();


//custom middleware için parametre göndereceðimiz root yolu deðiþkeni
var root = builder.Environment.ContentRootPath;

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

//Session'ýmýzý ekledik.
app.UseSession();

//custom middleware'in kullanýlmasý
app.UseFileServer();
app.UseNodeModules(root);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
