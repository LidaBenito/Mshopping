
var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Basket>(c => SessionBasket.GetBasket(c));

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

app.UseEndpoints(endpoint =>

{
    endpoint.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}/Page{pageNumber}");

    endpoint.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{pageNumber}");

    endpoint.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}");
    endpoint.MapDefaultControllerRoute();
}
    );
app.Run();
