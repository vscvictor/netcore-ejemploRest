#region USING

using BP.Comun.Logs;
using BP.Comun.Rest.Interfaces;
using BP.Comun.Rest;
using Microsoft.OpenApi.Models;
using WSEjercicioRest.Dominio.Interfaces.Services.ServiceName;
using WSEjercicioRest.Infraestructura.Services.ServiceName;
using WSEjercicioRest.Repositorio.Services.User;

#endregion

#region MAIN API

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region REPOSITORIOS
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApi, Api>();
#endregion REPOSITORIOS

#region INFRAESTRUCTURA
builder.Services.AddScoped<IUserIfraestructure, UserInfraestructure>();
#endregion INFRAESTRUCTURA

#region SOAP
//builder.Services.AddSingleton<IConsumirSoap, ConsumirSoap>();
#endregion INFRAESTRUCTURA

#region CONFIGURADORES PROPIEDADES

//builder.Services.AddSingleton<IPropiedadesApi, PropiedadesApi>();

#endregion

#region POLITICA PARA DOMINIO CRUZADO 

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                   .AllowAnyMethod()
                                                   .AllowAnyHeader()));
#endregion POLITICA PARA DOMINIO CRUZADO

#region SWAGGER HEADER

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.1.0",
        Title = "WSEjercicioRest",
        Description = "Servicio base para invocar servicios externos",
        Contact = new OpenApiContact
        {
            Name = "Banco Pichincha",
            Email = "devops@pichincha.com",
            Url = new Uri("https://www.pichincha.com"),
        }
    });

});

#endregion SWAGGER

#region MANEJO DE VERSIONES DE API

builder.Services.AddApiVersioning(options => options.UseApiBehavior = true);
builder.Services.AddApiVersioning(options => options.AssumeDefaultVersionWhenUnspecified = true);

#endregion MANEJO DE VERSIONES DE API FIN



#region INICIALIZAR COMPONENTE DE LOGS
builder.Services.AddLogs();
#endregion INICIALIZAR COMPONENTE DE LOGS

builder.Services.AddHealthChecks();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{

}
app.UseHealthChecks("/api/v1/ServicioBase/HealthChecks");
app.UseHealthChecks("/api/v1/ServicioBase/HealthChecksServicio");

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");

#region SWAGGER DOCUMENT

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WSEjercicioRest.API V1");
});
#endregion Swagger

app.MapControllers();
app.Run();

