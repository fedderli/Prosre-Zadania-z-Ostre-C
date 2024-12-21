namespace Board_Game__Simulator.interfaces.Mag;

public class Mag
{
    public int Sila { get; set; }
    public int Inteligencja { get; set; }
    public int Charyzma { get; set; }
    
    public Mag()
    {
        Sila = 6;
        Inteligencja = 9;
        Charyzma = 1;
    }
}