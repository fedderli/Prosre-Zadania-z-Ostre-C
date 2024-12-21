namespace Board_Game__Simulator.interfaces.Healer;


public class Healer : IKlasaPostaci
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