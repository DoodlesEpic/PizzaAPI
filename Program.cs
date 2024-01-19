using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add our own services
builder.Services.AddScoped<PizzaService>();
builder.Services.AddSqlite<PizzaContext>("Data Source=PizzaAPI.db");

// Add the authentication services
builder.Services.AddDbContext<IdentityContext>(
    options => options.UseSqlite("Data Source=PizzaAPI.db")
);
builder.Services.AddAuthorization();
builder
    .Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<IdentityContext>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapIdentityApi<IdentityUser>();

// Seed the database with some data for testing if it's empty
app.CreateDbIfEmpty();

app.Run();
