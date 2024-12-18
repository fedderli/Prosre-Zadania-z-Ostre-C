using Board_Game__Simulator.interfaces.Mag;
using Board_Game__Simulator.interfaces.Wojownik;
using Board_Game__Simulator.interfaces.Healer;
using Board_Game__Simulator_player;

namespace Board_Game__Simulator_game;
using System.Threading;

public class Game
{
    public static List<Player> players = new List<Player>();
    public static void StartGame()
    {
        
        Console.WriteLine("Przygotowanie do gry!!!");
        Console.WriteLine("Podaj ilość Graczy(2-4) :");
        int numberOfPlayers = int.Parse(Console.ReadLine());

        if (numberOfPlayers < 2 || numberOfPlayers > 4)
        {
            Console.WriteLine("zła ilość graczy >:( Więc gra postanawia Wybuchnąć");
            Thread.Sleep(1000);
            Console.WriteLine("rozpoczynam autodestrukcję");
            Console.WriteLine(3);
            Thread.Sleep(1000);
            Console.WriteLine(2);
            Thread.Sleep(1000);
            Console.WriteLine(1);
            Thread.Sleep(1000);
            Console.WriteLine("Boooooooooooooooooooooooooooooooooooom!!!!!!!!!!!!!!!!!!!!!");
            return;
        }

        for (int i = 1; i <= numberOfPlayers; i++)
        {



            Console.WriteLine("Podaj swoje imie");
            string playerName = Console.ReadLine();

            Console.WriteLine("Wybierz klasę swojej postaci: (Healer (1)/ Mag(2)/ Wojownik(3))");
            int playerClassChoice = int.Parse(Console.ReadLine());

            Player player = new Player() { Name = playerName };

            if (playerClassChoice == 1)
            {
                player.PlayerClass = new Healer();
                Console.WriteLine($"{playerName} wybrał klasę Healer");
            }
            else if (playerClassChoice == 2)
            {
                player.PlayerClass = new Mag();
                Console.WriteLine($"{playerName} wybrał klasę Mag");
            }
            else if (playerClassChoice == 3)
            {
                player.PlayerClass = new Wojownik();
                Console.WriteLine($"{playerName} wybrał klasę Wojownik");
            }
            else
            {
                Console.WriteLine("nie ma takiej klasy >:( Więc gra postanawia Wybuchnąć");
                Thread.Sleep(1000);
                Console.WriteLine("rozpoczynam autodestrukcję");
                Console.WriteLine(3);
                Thread.Sleep(1000);
                Console.WriteLine(2);
                Thread.Sleep(1000);
                Console.WriteLine(1);
                Thread.Sleep(1000);
                Console.WriteLine("Boooooooooooooooooooooooooooooooooooom!!!!!!!!!!!!!!!!!!!!!");
                return;
            }
            
            players.Add(player);
        }
        Console.WriteLine("Wszyscy gracze w grze:");
        foreach (var player in players)
        {
            Console.WriteLine($"Gracz: {player.Name}, Klasa: {player.PlayerClass.GetType().Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
        Console.WriteLine("gra się rozpoczyna !!!!!!" );
        PlayerTurn();
    }

    public static void PlayerTurn()
    {
        var endGame = false;
        while (!endGame)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Tura Gracza {player.Name}, Klasa: {player.PlayerClass.GetType().Name}");
                
                player.Move();
                Console.WriteLine($"{player.Name} kończy ture");
                Thread.Sleep(1000);
            }
        }
    }

    public  static void IsItInThePriceField()
    {
        
    }

    public  static void DispalyFinalResult()
    {
        
    }
}