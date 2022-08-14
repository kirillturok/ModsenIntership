using MediatR;
using Products.Application.Extensions;
using Products.WebApi;
using Products.WebApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddApplication();
builder.Services.ConfigureSqlContext(builder.Configuration);

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
