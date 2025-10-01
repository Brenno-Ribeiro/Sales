using SalesSoftware.Bll.Automapper;
using SalesSoftware.Bll.Intefaces;
using SalesSoftware.Bll.Services;
using SalesSoftware.Dal.Connetion;
using SalesSoftware.Dal.Interfaces;
using SalesSoftware.Dal.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Registrar AutoMapper e procurar profiles no assembly da BLL
IServiceCollection autoMapperServices = builder.Services.AddAutoMapper(typeof(AutoMapperSales).Assembly);

builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IBaseConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new BaseConnection(connectionString);
});


// Dependency Injection for Service
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
