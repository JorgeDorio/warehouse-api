using Microsoft.EntityFrameworkCore;
using Warehouse;
using Warehouse.Data;
using Warehouse.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(Settings.ConnectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AddressService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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