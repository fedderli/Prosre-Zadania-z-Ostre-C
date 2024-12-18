namespace Board_Game__Simulator.interfaces.Wojownik;

public interface IWojownik
{
    int Sila { get; set; }
    int Inteligencja { get; set; }
    int Charyzma { get; set; }
}

public class Wojownik : IWojownik
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

//IWojownik wojownik = new Wojownik();