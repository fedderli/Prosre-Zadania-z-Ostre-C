namespace Board_Game__Simulator.interfaces.Mag;

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

    // Konstruktor, który ustawia wartości domyślne
    public Healer()
    {
        Sila = 5;           // Średnia siła
        Inteligencja = 8;    // Wysoka inteligencja
        Charyzma = 6;        // Dobra charyzma
    }
}