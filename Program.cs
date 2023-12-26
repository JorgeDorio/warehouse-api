using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:5173") // Allow requests from this origin
            .AllowAnyMethod()   // Allow any HTTP method
            .AllowAnyHeader();  // Allow any header
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();