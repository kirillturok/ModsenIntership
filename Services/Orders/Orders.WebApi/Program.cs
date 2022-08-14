using FluentValidation;
using Products.Application.DTO;
using Products.Application.Mapper;
using Products.Application.Services;
using Products.Application.Validation;
using Products.Repository;
using Products.Repository.Contracts;
using Products.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IValidator<CreateOrderDto>, CreateOrderValidator>();
builder.Services.AddScoped<IValidator<UpdateOrderDto>, UpdateOrderValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateOrderValidator>();

//builder.Services.ConfigureSwagger();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    /*app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/Events/swagger.json", "Events");
    });*/
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
