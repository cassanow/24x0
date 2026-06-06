namespace _24x0.Model;

public class DesempenhoConstrutor
{
    public int Id { get; set; }
    public int ConstrutorId { get; set; }
    public Construtor Construtor { get; set; }
    public int Ano { get; set; }
    public double Pontos { get; set; }
    public int ForcaBase { get; set; }
}