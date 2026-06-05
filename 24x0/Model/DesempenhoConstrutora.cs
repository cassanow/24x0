namespace _24x0.Model;

public class DesempenhoConstrutora
{
    public int Id { get; set; }
    public int Ano { get; set; }
    public int ForcaBase { get; set; } 
    
    public int ConstrutoraId { get; set; }
    public Construtor Construtor { get; set; }
}