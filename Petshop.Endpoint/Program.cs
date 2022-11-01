using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Categories;
using Petshop.Contract.Products;
using Petshop.Infra.Categories;
using Petshop.Infra.Common;
using Petshop.Infra.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
var cnn = builder.Configuration.GetConnectionString("BentiStore");
builder.Services.AddDbContext<BentiShopContext>(options => options.UseSqlServer(cnn));
builder.Services.AddScoped<ProductRepository, EfProductRepository>();
builder.Services.AddScoped<CategoryRepository, EfCategoryRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
