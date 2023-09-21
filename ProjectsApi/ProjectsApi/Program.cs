using Microsoft.EntityFrameworkCore;
using ProjectsApi.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMsSql = builder.Configuration.GetConnectionString("ProjectContext");
var connectionStringMySql = builder.Configuration.GetConnectionString("ProjectContextMySql");

builder.Services.AddDbContext<ProjectContext>(options =>
           options.UseSqlServer(connectionStringMsSql));

builder.Services.AddDbContext<MySQLProjectContext>(options =>
           options.UseMySql(
           connectionStringMySql, ServerVersion.AutoDetect(connectionStringMySql)));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
