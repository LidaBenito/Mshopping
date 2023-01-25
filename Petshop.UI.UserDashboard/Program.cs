
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
var cnn = builder.Configuration.GetConnectionString("BentiStore");
builder.Services.AddDbContext<BentiShopContext>(options => options.UseSqlServer(cnn));
builder.Services.AddScoped<ProductRepository, EfProductRepository>();
builder.Services.AddScoped<CategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<OrderRepository, EFOrderRepository>();
builder.Services.AddScoped<OrderInfoRepository, EFOrderInfoRepository>();
builder.Services.AddScoped<PaymentService, EFPayIrService>();
builder.Services.AddScoped<OrderInfoService, EFOrderInfoService>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<OrderRepository, EFOrderRepository>();
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
