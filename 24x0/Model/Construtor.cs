namespace _24x0.Model;

public class Construtor
{
    public int Id { get; set; } 
    public string Nome { get; set; }    

    public List<DesempenhoConstrutora> Historico { get; set; } = new List<DesempenhoConstrutora>();
}