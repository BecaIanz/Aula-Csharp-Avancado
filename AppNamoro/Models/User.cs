namespace AppNamoro.Models;

public class User
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public ICollection<Match> Matches1 { get; set; }
    public ICollection<Match> Matches2 { get; set; }
    
}