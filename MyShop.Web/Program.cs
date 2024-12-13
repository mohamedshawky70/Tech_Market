using Microsoft.EntityFrameworkCore;
using MyShop.Web.Data;
using MyShop.Web.Repository;
using NToastNotify;
using Microsoft.AspNetCore.Identity;
using MyShop.Web.Migrations;
using MyShop.Web.Models;
using MyShop.Web.ViewModels;
using MyShop.Web.Classes;
using Stripe;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc().AddNToastNotifyToastr(
    new NToastNotify.ToastrOptions()
    {
        
        MessageClass="",
        ProgressBar = true,
        PositionClass = ToastPositions.TopRight,
        PreventDuplicates = true,
        CloseButton = true,
        
    }
    ) ;



builder.Services.AddDbContext<ApplicationDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));



builder.Services.AddIdentity<MoreToUser, IdentityRole>(option =>
{
option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(2);
option.SignIn.RequireConfirmedAccount = false; //don't confirmg                       
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultUI()
.AddDefaultTokenProviders();
builder.Services.Configure<StripeData>(builder.Configuration.GetSection("Stripe")); //الداتا اللي في سترايب هيخزنها في المتغيرات اللي في كلاس إستريب داتا


builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
builder.Services.AddScoped(typeof(ShopingCard));
builder.Services.AddScoped(typeof(OrderHeader));
builder.Services.AddScoped(typeof(OrederHeader_ShopingCardVM));
builder.Services.AddScoped(typeof(OrderHeader_OrderDetailsVM));
builder.Services.AddScoped(typeof(DashboardVM));
builder.Services.AddScoped(typeof(MoreToUser));
builder.Services.AddScoped(typeof(OrderDetails));
builder.Services.AddScoped(typeof(IdentityRole));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:Secretkey").Get<string>();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "Customer",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Product}/{action=Index}/{id?}");

app.Run();
