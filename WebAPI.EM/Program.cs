using AccessData.EntityFramework.SQL;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
//using Microsoft.AspNetCore.Authorizaton

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//inicializacion de repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
builder.Services.AddScoped<IRepositorioEspecie, RepositorioEspecie>();
builder.Services.AddScoped<IRepositorioAmenaza, RepositorioAmenaza>();
builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
builder.Services.AddScoped<IRepositorioControlDeCambios, RepositorioControlDeCambios>();
builder.Services.AddScoped<IRepositorioConfiguracion, RepositorioConfiguracion>();
builder.Services.AddScoped<IRepositorioEstadoConservacion, RepositorioEstadoConservacion>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


//inicializacion de casos de uso
builder.Services.AddScoped<IAddUser, AddUserUC>();
builder.Services.AddScoped<IAddEcosystem, AddEcosystemUC>();
builder.Services.AddScoped<IAddSpecies, AddSpeciesUC>();
builder.Services.AddScoped<IGetEcosystem, GetEcosystemsUC>();
builder.Services.AddScoped<ILogin, LoginUC>();
builder.Services.AddScoped<IObtenerUsuario, ObtenerUsuarioUC>();
builder.Services.AddScoped<IGetThreats, GetThreatsUC>();
builder.Services.AddScoped<IGetCountries, GetCountriesUC>();
builder.Services.AddScoped<IObtenerPaisPorCodigo, ObtenerPaisPorCodigoUC>();
builder.Services.AddScoped<IGetSpecies, GetSpeciesUC>();
builder.Services.AddScoped<IGetEcosystemById, GetEcosystemByIdUC>();
builder.Services.AddScoped<IRemoveById, RemoveByIdUC>();
builder.Services.AddScoped<IAddSpecieToEcosystem, AddSpecieToEcosystemUC>();
builder.Services.AddScoped<IGetEspeciesPorNombre, GetEspeciesPorNombreUC>();
builder.Services.AddScoped<IFiltrado, FiltradoUC>();
builder.Services.AddScoped<IGetAmenazaById, GetAmenazaByIdUC>();
builder.Services.AddScoped<IGetEstadosConservacion, GetEstadosConservacionUC>();
builder.Services.AddScoped<IUpdateEcosystem, UpdateEcosystemUC>();
builder.Services.AddScoped<IUpdateSpecie, UpdateSpecieUC>();
builder.Services.AddScoped<IUpdateSettings, UpdateSettingsUC>();
builder.Services.AddScoped<IGetSettings, GetSettingsUC>();
builder.Services.AddScoped<IFindSettingsByName, FindSettingsByNameUC>();
builder.Services.AddScoped<IGetSpecieById, GetSpecieByIdUC>();
builder.Services.AddScoped<IFiltrarDadaUnaEspecie, FiltrarDadaUnaEspecieUC>();
builder.Services.AddScoped<IAddChangeTracking,  AddChangeTrackingUC>();
builder.Services.AddScoped<IGetPosiblesEcosistemas, GetPosiblesEcosistemasUC>();
builder.Services.AddScoped<IGuardarPaises, GuardarPaisesUC>();


var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebAPI.EM.xml");

builder.Services.AddSwaggerGen(opciones =>
{
    //Se agrega la opcion de autenticarse en Swagger
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estandar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name =  "Authorization", //a traves de ese header manda el token
        Type = SecuritySchemeType.ApiKey
    });

    opciones.OperationFilter<SecurityRequirementsOperationFilter>();

    // Se agregan las opciones para la documentacion de swagger
    opciones.IncludeXmlComments(rutaArchivo);
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Plataforma Educativa Ecosistemas Marinos",
        Description = "Tiene como objetivo proporcionar información detallada sobre la\r\nvida marina y los diferentes ecosistemas " +
        "acuáticos.",
        Contact = new OpenApiContact
        {
            Email = "ana&belen@gmail.com"
        },
        Version = "v1"
    });
});

//Configurar la autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
            GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

//Configurar la autorizacion
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .RequireAuthenticatedUser().Build();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
