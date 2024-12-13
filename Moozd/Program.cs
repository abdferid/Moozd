using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MoozdDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoozdDb")));

// Register Identity services (includes UserManager and SignInManager)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Optional: configure options like password policy, lockout, etc.
})
.AddEntityFrameworkStores<MoozdDbContext>()  // Use your custom DbContext here
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login"; // Redirect to the correct login page
    options.AccessDeniedPath = "/Admin/Account/AccessDenied"; // Optional: specify an access denied path
});

// Add application services
builder.Services.AddScoped<IMottoDAL, MottoEFDAL>();
builder.Services.AddScoped<IMottoService, MottoManager>();
builder.Services.AddScoped<IValidator<Motto>, MottoValidator>();
builder.Services.AddScoped<IAboutDAL, AboutEFDAL>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IValidator<About>, AboutValidator>();
builder.Services.AddScoped<IServiceHeaderDAL, ServiceHeaderEFDAL>();
builder.Services.AddScoped<IServiceHeaderService, ServiceHeaderManager>();
builder.Services.AddScoped<IValidator<ServiceHeader>, ServiceHeaderValidator>();
builder.Services.AddScoped<IServiceDAL, ServiceEFDAL>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IValidator<Service>, ServiceValidator>();
builder.Services.AddScoped<IServicesTextDAL, ServicesTextEFDAL>();
builder.Services.AddScoped<IServicesTextService, ServicesTextManager>();
builder.Services.AddScoped<IValidator<ServicesText>, ServicesTextValidator>();
builder.Services.AddScoped<IStepDAL, StepEFDAL>();
builder.Services.AddScoped<IStepService, StepManager>();
builder.Services.AddScoped<IValidator<Step>, StepValidator>();
builder.Services.AddScoped<IProjectDAL, ProjectEFDAL>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IValidator<Project>, ProjectValidator>();
builder.Services.AddScoped<IProjectImageDAL, ProjectImageEFDAL>();
builder.Services.AddScoped<IProjectImageService, ProjectImageManager>();
builder.Services.AddScoped<IValidator<ProjectImage>, ProjectImageValidator>();
builder.Services.AddScoped<SignInManager<IdentityUser>>();

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

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Configure routes with area support
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=About}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
