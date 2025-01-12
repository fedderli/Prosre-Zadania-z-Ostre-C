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
    public static void FindPlayer()
    {
        Console.WriteLine("Po czym chcesz znalezc graczy");
        Console.WriteLine("1. po imieniu\n" +
                          "2. po pozycji\n" +
                          "3. ilosc punktow powyzej \n" +
                          "4. ilosc punktow ponizej \n" +
                          "5. ilosc punktow mniejsza niz srednia\n");
        String inputFind = Console.ReadLine();
        switch (inputFind)
        {
            case "1":
                Console.WriteLine("Podaj imie do szukania graczy:");
                String nameInput = Console.ReadLine();
                foreach (Player player in Players)
                {
                    if (player.Name == nameInput)
                    {
                        Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
                    }
                }
                break;
            case "2":
                Console.WriteLine("Podaj pozycje do szukania graczy:");
                var outsideHitter = "atakujacy";
                var libero = "libero";
                var setter = "rogrywajacy";
                var reciver = "przjmujacy";
                var middleBlocker = "środkowy";
                        
                Console.WriteLine("\t1. atakujacy \n" +
                                  "\t2. libero \n" +
                                  "\t3. rozgrywajacy \n" +
                                  "\t4. przyjmujacy \n" +
                                  "\t5. srodkowy");
                string positionInput = Console.ReadLine();
                string position = "";
                switch (positionInput)
                {
                    case "1":
                        position = outsideHitter;
                        break;
                    case "2":
                        position = libero;
                        break;
                    case "3":
                        position = setter;
                        break;
                    case "4":
                        position = reciver;
                        break;
                    case "5":
                        position = middleBlocker;
                        break;
                    default:
                        Console.WriteLine("cos poszlo nie tak");
                        break;
                }
                foreach (Player player in Players)
                {
                    if (player.Position == position)
                    {
                        Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
                    }
                }
                break;
            case "3":
                Console.WriteLine("Podaj ilosc punktów powyżej ktorych wyszukiwac zawodników");
                string morePointsInput = Console.ReadLine();
                int morePoints = Convert.ToInt32( morePointsInput );
                foreach (Player player in Players)
                {
                    if (player.Score > morePoints)
                    {
                        Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
                    }
                }
                break;
            case "4":
                Console.WriteLine("Podaj ilosc punktów ponizej ktorych wyszukiwac zawodników");
                string lessPointsInput = Console.ReadLine();
                int lessPoints = Convert.ToInt32( lessPointsInput );
                foreach (Player player in Players)
                {
                    if (player.Score < lessPoints)
                    {
                        Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
                    }
                }
                break;
            case "5":
                int average = 0;
                foreach (var player in Players)
                {
                    average += player.Score;
                }
                average /= Players.Count;
                foreach (Player player in Players)
                {
                    if (player.Score >= average)
                    {
                        Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
                    }
                }
                break;
            default:
                Console.WriteLine("cos poszlo nie tak");
                break;
        }
    }
    public static void AddScore()
    {
        Console.WriteLine("Podaj imie do dodania punktów:");
        String nameInput = Console.ReadLine();
        Console.WriteLine("Podaj ilosc punktów do dodania:");
        String scoreInput = Console.ReadLine();
        int score = Convert.ToInt32(scoreInput);
        foreach (Player player in Players)
        {
            if (player.Name == nameInput)
            {
                Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} zdobył {player.Score} punkty");
                player.Score += score;
                Console.WriteLine($"Gracz {player.Name} na pozycji {player.Position} dodano mu {score} i teraz ma {player.Score} punkty");
            }
        }
        
    }
}