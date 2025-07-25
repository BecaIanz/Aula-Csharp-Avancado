namespace AppNamoro.Models;

public class User
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public ICollection<Match> MyMatches { get; set; }
    public ICollection<Match> PeoplesMatches { get; set; }
    
}