
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
        Console.WriteLine($"{Name} rzucił kostką i wyrzucił : {diceRoll}");

        Position += diceRoll;
        Console.WriteLine($"{Name} porusza się  na pole {Position}");
    }

    public void AddScore()
    {
        
    }
}