using WashApi.DataContexts;
using WashApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Controllers (OBRIGATÓRIO)
builder.Services.AddControllers();

// 🔥 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔥 AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 🔥 ClienteService (OBRIGATÓRIO pro seu erro)
builder.Services.AddScoped<ClienteService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 🔥 Controllers (OBRIGATÓRIO)
app.MapControllers();

app.Run();