namespace Ponctual.Domain.Models;

public class Registro
{
    public int ID { get; set; }
    public int FuncionarioID { get; set; }
    public DateTime Momento { get; set; }

    public Funcionario Funcionario { get; set; }
}