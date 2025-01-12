namespace Sports_Team_Management_Team;
using Sports_Team_Management_Player;

public class Team
{
    public static List<Player> Players = new List<Player>();
    public static void AddPlayer(string name, string position, int score)
    {
        Players.Add(new Player(name, position, score));
        Console.WriteLine($"Gracz {name} został dodany na pozycji {position} i zdobył w sumie {score} punkty");
    }
    public static void RemovePlayer(string name)
    {
        foreach (Player player in Players)
        {
            if (player.Name == name)
            {
                Players.Remove(player);
                Console.WriteLine($"gracz {name} na posycji {player.Position} został usuniety");
            }
        }
    }
    
    public static void DisplayStatistics()
    {
        foreach (var player in Players)
        {
            Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
        }
    }
    
    public static void DisplayAverage()
    {
        int average = 0;

        foreach (var player in Players)
        {
            average += player.Score;
        }
        average /= Players.Count;
        
        Console.WriteLine($"średnia ilos punktów to {average} dla wszystkich zawodnikow druzyny");
    }
}