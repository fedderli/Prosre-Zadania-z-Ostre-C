
namespace Board_Game__Simulator_player;

public class Player
{
    public string Name {get; set;}
    public int Position { get; set; } = 0;
    public int Score { get; set; } = 0;
    public object PlayerClass { get; set; }

    public void Move()
    {
        Random random = new Random();
        int diceRoll = random.Next(1, 7);
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Thread.Sleep(1000);
        Console.WriteLine($"{Name} rzucił kostką i wyrzucił : {diceRoll}");
        
        
        Position += diceRoll;

        if (Position > 100)
        {
            int overStep = Position - 100;
            Position = 100 - overStep;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Thread.Sleep(500);
            Console.WriteLine($"{Name} przekroczył Mete i cofa się o {overStep} pola");
        }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(500);
            Console.WriteLine($"{Name} porusza się  na pole {Position}");
        


    }

    public void AddScore(int points)
    {
        Score += points;
        Console.WriteLine($"{Name} zdobywa {points} punktów! Obecny wynik : {Score} ");
    }
}