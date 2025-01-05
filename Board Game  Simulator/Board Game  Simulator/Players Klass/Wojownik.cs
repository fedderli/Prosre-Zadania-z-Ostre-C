namespace Board_Game__Simulator.interfaces.Wojownik;


public class Wojownik : IKlasaPostaci
{
    public int Sila { get; set; }
    public int Inteligencja { get; set; }
    public int Charyzma { get; set; }
    
    public Wojownik()
    {
        Sila = 10;
        Inteligencja = 4;
        Charyzma = 2;
    }
}

