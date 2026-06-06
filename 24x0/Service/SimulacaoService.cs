public class SimulacaoService
{
    private readonly Random _rng = new();

    public SimulacaoResult Simular(int forcaPiloto, int forcaEquipe)
    {
        double forcaBase = forcaPiloto * 0.55 + forcaEquipe * 0.45;
        
        double forcaNormalizada = Math.Clamp((forcaBase - 60) / 39.0, 0.0, 1.0);

        var corridas = new List<CorridaResult>();
        int vitorias = 0;

        for (int i = 1; i <= 24; i++)
        {
            double dificuldade;

            if (i <= 15)
                dificuldade = 1 + (4.0 * (i - 1) / 14);
            else
                dificuldade = 5 + (25.0 * (i - 16) / 8);
            
            double multiplicador = 1.0 + (1.0 - forcaNormalizada) * 4.0;
            dificuldade *= multiplicador;

            double forcaEfetiva = forcaNormalizada * 99;
            double chance = (forcaEfetiva / (forcaEfetiva + dificuldade)) * 100;
            chance = Math.Max(chance, 1);

            double roll = _rng.NextDouble() * 100;
            bool venceu = roll <= chance;

            if (venceu) vitorias++;

            corridas.Add(new CorridaResult(i, venceu, (int)chance));
        }

        return new SimulacaoResult(vitorias, corridas);
    }
}

public record CorridaResult(int Corrida, bool Venceu, int Chance);
public record SimulacaoResult(int TotalVitorias, List<CorridaResult> Corridas);