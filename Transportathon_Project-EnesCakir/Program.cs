using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Transportathon_Project_EnesCakir.Configurations;
using Transportathon_Project_EnesCakir.Configurations.AutoMapper;
using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Helpers;
using Transportathon_Project_EnesCakir.Repository;
using Transportathon_Project_EnesCakir.Repository.Interfaces;
using Transportathon_Project_EnesCakir.Services;
using Transportathon_Project_EnesCakir.Services.Interfaces;
using Transportathon_Project_EnesCakir.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

#region Identity
builder.Services.AddDbContext<IdentityManagementDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequiredLength = 4;
}).AddEntityFrameworkStores<IdentityManagementDbContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
{
    opt.TokenLifespan = TimeSpan.FromHours(1);
});
#endregion

#region EmailService
builder.Services.Configure<EmailConfigurations>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();
#endregion

builder.Services.AddAutoMapper(conf =>
{
    conf.AddProfile<MappingProfile>();
});

builder.Services.ConfigureApplicationCookie(conf =>
{
    var cookieBuilder = new CookieBuilder();
    cookieBuilder.Name = "AuthCookie";
    conf.Cookie = cookieBuilder;

    conf.LoginPath = new PathString("/Auth/SignIn");
    conf.LogoutPath = new PathString("/Home/Index");
    conf.ExpireTimeSpan = TimeSpan.FromDays(10);
    conf.SlidingExpiration = true;
});

builder.Services.Configure<SecurityStampValidatorOptions>(opt =>
{
    opt.ValidationInterval = TimeSpan.FromMinutes(5);
});

#region repository instances lifecycle
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region service instances lifecycle
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestTypeService, RequestTypeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
#endregion

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddScoped<IImageHelper, ImageHelper>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
