using _24x0.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<F1RollService>();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddSingleton<SimulacaoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.MapGet("/rolar/pilotos", async (F1RollService service) =>
{
    var tasks = Enumerable.Range(0, 10).Select(_ => service.RolarPiloto());
    var pilotos = await Task.WhenAll(tasks);
    return Results.Ok(pilotos);
});

app.MapGet("/rolar/equipes", async (F1RollService service) =>
{
    var tasks = Enumerable.Range(0, 10).Select(_ => service.RolarEquipe());
    var equipes = await Task.WhenAll(tasks);
    return Results.Ok(equipes);
});

app.MapGet("/simular", (SimulacaoService sim, int forcaPiloto, int forcaEquipe) =>
{
    var resultado = sim.Simular(forcaPiloto, forcaEquipe);
    return Results.Ok(resultado);
});

app.Run();