using Microsoft.EntityFrameworkCore;
using UpSchool.Persistence.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UpStorageDbContext>(opt=>opt.UseMySQL(builder.Configuration.GetConnectionString("MySQLDB")!));
builder.Services.AddCors(options =>
options.AddPolicy("AllowAll",
builder => builder
.AllowAnyMethod()
.AllowCredentials()
.SetIsOriginAllowed((host) => true)
.AllowAnyHeader())


);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
