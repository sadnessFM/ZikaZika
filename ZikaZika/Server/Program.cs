using Microsoft.EntityFrameworkCore;
using ZikaZika.Server.Data;
using ZikaZika.Server.Services.CategoryService;
using ZikaZika.Server.Services.ProductService;
using ZikaZika.Server.Services.StatsService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStatsService, StatsService>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseSwaggerUI();
app.UseSwagger();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 403)
    {
        context.Request.Path = "/AccessDenied";
        await next();
    }
});

app.MapFallbackToFile("index.html");

app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials()
);

app.Run();
