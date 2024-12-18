namespace Board_Game__Simulator.interfaces.Healer;

public interface IHealer
{
    int Sila { get; set; }
    int Inteligencja { get; set; }
    int Charyzma { get; set; }
}

public class Healer : IHealer
{
    public int Sila { get; set; }
    public int Inteligencja { get; set; }
    public int Charyzma { get; set; }
    public Healer()
    {
        Sila = 5;
        Inteligencja = 8;
        Charyzma = 6;   
    }
}