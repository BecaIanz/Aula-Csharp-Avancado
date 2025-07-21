namespace AppNamoro.Models;

public class Match
{
    public ICollection<User> User1 { get; set; } = [];
    public ICollection<User> User2 { get; set; } = [];
}