using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Services;

var builder = WebApplication.CreateBuilder(args);

// Access the connection string from the environment variable
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
var apiUrl = Environment.GetEnvironmentVariable("API_URL");

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
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

// Allow CORS requests from any origin
app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Context>();
    context.Database.Migrate();
}

app.Run();