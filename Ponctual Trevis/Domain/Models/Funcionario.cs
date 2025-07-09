namespace Ponctual.Domain.Models;

public class Funcionario
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public bool EhAdm { get; set; }

    public ICollection<Registro> Registros { get; set; } = [];
}