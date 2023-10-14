using AccessData.EntityFramework.SQL;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

//inicializacion de repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
builder.Services.AddScoped<IRepositorioEspecie, RepositorioEspecie>();
builder.Services.AddScoped<IRepositorioAmenaza, RepositorioAmenaza>();
builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();     


//inicializacion de casos de uso
builder.Services.AddScoped<IAddUser, AddUserUC>();
builder.Services.AddScoped<IAddEcosystem, AddEcosystemUC>();
builder.Services.AddScoped<IAddSpecies, AddSpeciesUC>();
builder.Services.AddScoped<IGetEcosystem, GetEcosystemsUC>();
builder.Services.AddScoped<ILogin, LoginUC>();
builder.Services.AddScoped<IGetThreats,  GetThreatsUC>();
builder.Services.AddScoped<IGetCountries, GetCountriesUC>();
builder.Services.AddScoped<IObtenerPaisPorCodigo, ObtenerPaisPorCodigoUC>();
builder.Services.AddScoped<IGetSpecies, GetSpeciesUC>();
builder.Services.AddScoped<IGetEcosystemById, GetEcosystemByIdUC>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
