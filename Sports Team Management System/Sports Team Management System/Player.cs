namespace Sports_Team_Management_Player;


public class Player
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Score { get; set; }
    
    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }
    
    
}