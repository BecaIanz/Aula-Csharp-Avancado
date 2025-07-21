namespace AppNamoro.Models;

public class Match
{
    public Guid ID { get; set; }
    public Guid MyMatchesID { get; set; }
    public Guid PeoplesMatchesID { get; set; }
    public User MyMatches { get; set; }
    public User PeoplesMatches { get; set; }
}