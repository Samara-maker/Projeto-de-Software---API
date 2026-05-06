using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WashApi.DataContexts;
using WashApi.Profiles;
using WashApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados
var connectionString = builder.Configuration.GetConnectionString("mysql");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32)))
);

// Controllers + JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ClienteProfile>();
    cfg.AddProfile<FuncionarioProfile>();
    cfg.AddProfile<EquipeProfile>();
    cfg.AddProfile<CategoriaServicoProfile>();
    cfg.AddProfile<ServicoProfile>();
});

// Services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<EquipeService>();
builder.Services.AddScoped<CategoriaServicoService>();
builder.Services.AddScoped<ServicoService>();
builder.Services.AddScoped<AgendamentoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();