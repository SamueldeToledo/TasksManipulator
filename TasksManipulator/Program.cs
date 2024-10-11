using TasksManipulator.Application.Interfaces;
using TasksManipulator.Application.Mappings;
using TasksManipulator.Application.Services;
using TasksManipulator.Domain.Interfaces;
using TasksManipulator.Infraestructure.Context;
using TasksManipulator.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(DTOMappingProfiles));
builder.Services.AddScoped<ITasksService,TasksService>();
builder.Services.AddScoped<ITasks, TasksRepository>();
builder.Services.AddScoped<FileManipulator>();
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
