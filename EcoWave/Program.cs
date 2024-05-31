using EcoWave.Data;
using EcoWave.Models;
using EcoWave.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString));
builder.Services.AddControllersWithViews();

// Register repositories
builder.Services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IRepository<ItemReciclado>, ItemRecicladoRepository>();
builder.Services.AddScoped<IRepository<Recompensa>, RecompensaRepository>();
builder.Services.AddScoped<IRepository<Amigo>, AmigoRepository>();
builder.Services.AddScoped<IRepository<ReconhecimentoItem>, ReconhecimentoItemRepository>();
builder.Services.AddScoped<IRepository<Localizacao>, LocalizacaoRepository>();
builder.Services.AddScoped<IRepository<Configuracao>, ConfiguracaoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
