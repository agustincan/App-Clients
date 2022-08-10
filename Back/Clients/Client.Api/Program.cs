using Client.Persistence.Database;
using Client.Service.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(Assembly.Load("Client.Service.EventHandler"));
builder.Services.AddTransient<IClientQueries, ClientQueries>();

builder.Services.AddDbContext<AppDbContext>(options =>
   //options.UseSqlServer(
   //    Configuration.GetConnectionString("DefaultConnection"),
   //    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog")
   //)
   options.UseNpgsql(builder.Configuration.GetConnectionString("CnnPg1")
   //opt => opt.MigrationsHistoryTable("__EFMigrationsHistory", "Transport")
   )
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
