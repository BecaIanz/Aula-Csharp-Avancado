namespace AppNamoro.Models;

public class Match
{
    public Guid ID { get; set; }
    public Guid User1ID { get; set; }
    public Guid User2ID { get; set; }
    public User User1 { get; set; }
    public User User2 { get; set; }
}