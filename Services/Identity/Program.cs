using CqrsExample;
using CqrsExample.Contracts;
using CqrsExample.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.ConfigureSwagger();

builder.Services.AddControllers(
    config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
    }).AddXmlDataContractSerializerFormatters();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/Authentication/swagger.json", "Authentication");
});

app.ConfigureExceptionHandler();
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();