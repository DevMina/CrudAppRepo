using CrudApp.Application.Implementation;
using CrudApp.Application.Interfaces;
using CrudApp.Core.Entities;
using CrudApp.Core.Interfaces;
using CrudApp.Infrastructure.Data;
using CrudApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CrudDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRepository<Employee>, Repository<Employee>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowAll");
//app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
