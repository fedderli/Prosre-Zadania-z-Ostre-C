using System;
namespace Sports_Team_Management_System;
using Sports_Team_Management_Team;

internal class Program
{
    public static void Main(string[] args)
    {
        Team team = new Team();

        var end = false;

        while (end == false)
        {
            Console.WriteLine("Co chcesz zrobić ? \n" +
                              "1. dodaj gracza \n" +
                              "2. usun gracza \n" +
                              "3. wyswietl statystyki druzyny \n " +
                              "4. oblicz srednia punktow druzyny \n" +
                              "5. wyszukaj zawodnika \n" +
                              "6. zaktualizuj wynik zawodnika \n " +
                              "");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    
            }
        }
    }
}