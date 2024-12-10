namespace Board_Game__Simulator.interfaces.Mag;

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

    // Konstruktor, który ustawia wartości domyślne
    public Wojownik()
    {
        Sila = 10;           // Większa siła
        Inteligencja = 4;     // Mniejsza inteligencja
        Charyzma = 2;         // Średnia charyzma
    }
}

//IWojownik wojownik = new Wojownik();