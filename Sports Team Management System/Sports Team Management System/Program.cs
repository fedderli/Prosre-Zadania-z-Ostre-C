using System;
namespace Sports_Team_Management_System;
using Sports_Team_Management_Team;

internal class Program
{
    public static void Main(string[] args)
    {
        Team.AddPlayer("Mariusz", "atakujacy", 10);
        Team.AddPlayer("Kamil", "środkowy", 8);
        
        Team team = new Team();

        var end = false;

        while (end == false)
        {
            Console.WriteLine("Co chcesz zrobić ? \n" +
                              "1. dodaj gracza \n" +
                              "2. usun gracza \n" +
                              "3. wyswietl statystyki druzyny \n" +
                              "4. oblicz srednia punktow druzyny \n" +
                              "5. wyszukaj zawodnika \n" +
                              "6. zaktualizuj wynik zawodnika \n " +
                              "");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Podaj imie zawodnika: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Wybierz pozycje: ");
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
                    string inputPosition = Console.ReadLine();
                    var position = "";
                    switch (inputPosition)
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
                    Console.WriteLine("podaj wynik zawodnika: ");
                    int score = int.Parse(Console.ReadLine());
                    
                    Team.AddPlayer(name, position, score);
                    break;
                case "2":
                    Console.WriteLine("Podaj imie zawodnika do usuniecia: ");
                    string nameToRemove = Console.ReadLine();
                    Team.RemovePlayer(nameToRemove);
                    break;
                case "3":
                    Team.DisplayStatistics();
                    break;
                case "4":
                    Team.DisplayAverage();
                    break;
                
            }
        }
    }
}