using Board_Game__Simulator.interfaces.Mag;
using Board_Game__Simulator.interfaces.Wojownik;
using Board_Game__Simulator.interfaces.Healer;
using Board_Game__Simulator_player;
using Board_Game__Simulator_board;

using Microsoft.VisualBasic.FileIO;
namespace Board_Game__Simulator_game;
using System.Threading;

public class Game
{
    public static List<Player> players = new List<Player>();
    public static void StartGame()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Przygotowanie do gry!!!");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Podaj ilość Graczy(2-4) :");
        
        int numberOfPlayers = int.Parse(Console.ReadLine());
        
        
        
        if (numberOfPlayers < 2 || numberOfPlayers > 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
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
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Podaj swoje imie");
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            string playerName = Console.ReadLine();
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Wybierz klasę swojej postaci: (Healer (1)/ Mag(2)/ Wojownik(3))");

            Console.ForegroundColor = ConsoleColor.Green;
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
                Console.ForegroundColor = ConsoleColor.Red;
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
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Wszyscy gracze w grze:");
        
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var player in players)
        {
            Console.WriteLine($"Gracz: {player.Name}, Klasa: {player.PlayerClass.GetType().Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("gra się rozpoczyna !!!!!!" );
        PlayerTurn();
    }
    
    public static void PlayerTurn()
    {
        var turnsAmount = 0;
        var endGame = false;
        while (!endGame)
        {
            foreach (var player in players)
            {
                turnsAmount++;
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                
                Console.WriteLine($"Tura Gracza {player.Name}, Klasa: {player.PlayerClass.GetType().Name}");
                
                player.Move();
                IsItInThePriceField(player);
                
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                
                Console.WriteLine($"{player.Name} kończy ture");
                
                if (player.Score == 50 || player.Position == 100)
                {
                    DisplayFinalResult(player, turnsAmount);
                    endGame = true;
                    break;
                }
            }
        }
    }

    public  static void IsItInThePriceField(Player player)
    {
        if (Board.SpecialFields.Contains(player.Position))
        {
            Board.RandomPrice(player);
        }
    }

    public  static void DisplayFinalResult(Player Winner, int turnsAmount)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Winner.Name} wygrywa całą gre");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"liczba wszystkich tur: {turnsAmount}");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("tabela z wynikami graczy:");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        foreach (var player in players)
        {
            Console.WriteLine(
                $"Gracz: {player.Name}, Klasa: {player.PlayerClass.GetType().Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
    
        Console.WriteLine("Specjalne Pola");
        foreach (var specialField in Board.SpecialFields)
        {
            Console.WriteLine($"{specialField}");
        }
    }
}