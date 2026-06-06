using _24x0.Context;
using Microsoft.EntityFrameworkCore;

public class F1RollService
{
    private readonly IDbContextFactory<AppDbContext> _dbFactory;
    private readonly Random _rng = new();

    public F1RollService(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<PilotoRollResult> RolarPiloto()
    {
        await using var db = await _dbFactory.CreateDbContextAsync();

        var count = await db.DesempenhosPiloto.CountAsync();
        var desemp = await db.DesempenhosPiloto
            .Include(d => d.Piloto)
            .Skip(_rng.Next(count))
            .FirstAsync();

        return new PilotoRollResult(desemp.Piloto.Nome, desemp.Ano, desemp.Pontos, desemp.ForcaBase);
    }

    public async Task<EquipeRollResult> RolarEquipe()
    {
        await using var db = await _dbFactory.CreateDbContextAsync();

        var count = await db.DesempenhosConstrutor.CountAsync();
        var desemp = await db.DesempenhosConstrutor
            .Include(d => d.Construtor)
            .Skip(_rng.Next(count))
            .FirstAsync();

        return new EquipeRollResult(desemp.Construtor.Nome, desemp.Ano, desemp.Pontos, desemp.ForcaBase);
    }
}

public record PilotoRollResult(string Nome, int Ano, double Pontos, int Forca);
public record EquipeRollResult(string Nome, int Ano, double Pontos, int Forca);