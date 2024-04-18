using Custom_Identity_practice.Data;
using Custom_Identity_practice.Models;

var builder = WebApplication.CreateBuilder(args);


// Get Connection String From AppSetting

var connectionString = builder.Configuration.GetConnectionString("default");



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


// Step 1: Configure Identity services
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    // Step 2: Configure password requirements
    // Set the minimum number of unique characters required in a password
    options.Password.RequiredUniqueChars = 0;

    // Specify whether the password must contain an uppercase letter
    options.Password.RequireUppercase = false;

    // Set the minimum required length for passwords
    options.Password.RequiredLength = 8;

    // Specify whether the password must contain a non-alphanumeric character
    options.Password.RequireNonAlphanumeric = false;

    // Specify whether the password must contain a lowercase letter
    options.Password.RequireLowercase = false;
})
// Step 3: Configure storage for user data using Entity Framework
.AddEntityFrameworkStores<AppDbContext>()
// Step 4: Add default token providers for password reset and email confirmation
.AddDefaultTokenProviders();

// Step 5: Build the application
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
