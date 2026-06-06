namespace _24x0.Model;

public class DesempenhoPiloto
{
    public int Id { get; set; }
    public int PilotoId { get; set; }
    public Piloto Piloto { get; set; }
    public int Ano { get; set; }
    public double Pontos { get; set; }
    public int ForcaBase { get; set; }
}