using Wallet.Application.Services;
using Wallet.Domain.Repositories;
using Wallet.Infraestructure.Persistence.Config;
using Wallet.Infraestructure.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Configurar conexión a BD
builder.Services.AddSingleton<DatabaseConnection>();

// Registrar repositorios y servicios
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<WalletService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.MapGet("/are_you_here", () => "I'm Here!");
app.MapControllers();
app.Run();