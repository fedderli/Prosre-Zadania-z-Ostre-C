using System;
using System.Collections.Generic;

public class Concert
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; set; }

    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
    }
}

public class Ticket
{
    public Concert Concert { get; private set; }
    public decimal Price { get; private set; }
    public int SeatNumber { get; private set; }
    
    public Ticket(Concert concert, decimal price, int seatNumber)
    {
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }

    public static Ticket BookTicket(Concert concert, decimal price, int seatNumber)
    {
        if (concert.AvailableSeats <= 0)
        {
            Console.WriteLine("Brak dostępnych miejsc na ten koncert.");
        }

        concert.AvailableSeats--;
        return new Ticket(concert, price, seatNumber);
    }
}

public class BookingSystem
{
    private List<Concert> concerts = new List<Concert>();
    
    public void AddConcert(string name, DateTime date, string location, int availableSeats)
    {
        concerts.Add(new Concert(name, date, location, availableSeats));
        Console.WriteLine($"Dodano koncert: {name}, Data: {date}, Lokalizacja: {location}, Dostępne miejsca: {availableSeats}");
    }
    public Ticket BookTicket(string concertName, decimal price, int seatNumber)
    {
        Concert concert = null;
        foreach (var c in concerts)
        {
            if (c.Name == concertName)
            {
                concert = c;
                break;
            }
        }
        
        if (concert == null)
        {
            Console.WriteLine("Nie znaleziono koncertu o podanej nazwie.");
        }
        
        return Ticket.BookTicket(concert, price, seatNumber);
    }
    
    public void DisplayConcerts(Func<Concert, bool> filter)
    {
        var filteredConcerts = new List<Concert>();

        foreach (var concert in concerts)
        {
            if (filter(concert))  
            {
                filteredConcerts.Add(concert);
            }
        }

        if (filteredConcerts.Count == 0)
        {
            Console.WriteLine("Brak koncertów spełniających kryteria.");
            return;
        }

        foreach (var concert in filteredConcerts)
        {
            Console.WriteLine($"Nazwa: {concert.Name}, Data: {concert.Date}, Lokalizacja: {concert.Location}, Dostępne miejsca: {concert.AvailableSeats}");
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        BookingSystem bookingSystem = new BookingSystem();
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("=== System Rezerwacji Biletów na Koncerty ===");
            Console.WriteLine("1 - Dodaj koncert\n2 - Wyświetl koncerty według lokalizacji\n3 - Rezerwuj bilet\n4 - Koniec\nWybierz opcję: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Podaj nazwę koncertu: ");
                    string name = Console.ReadLine();
                    Console.Write("Podaj datę koncertu (yyyy-MM-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Podaj lokalizację koncertu: ");
                    string location = Console.ReadLine();
                    Console.Write("Podaj liczbę dostępnych miejsc: ");
                    int availableSeats = int.Parse(Console.ReadLine());

                    bookingSystem.AddConcert(name, date, location, availableSeats);
                    break;

                case "2":
                    Console.Write("Podaj lokalizację: ");
                    string filterLocation = Console.ReadLine();

                    Console.WriteLine($"\n=== Koncerty w lokalizacji: {filterLocation} ===");
                    bookingSystem.DisplayConcerts(c => c.Location.Equals(filterLocation, StringComparison.OrdinalIgnoreCase));
                    break;

                case "3":
                    Console.Write("Podaj nazwę koncertu: ");
                    string concertName = Console.ReadLine();
                    Console.Write("Podaj cenę biletu: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Podaj numer miejsca: ");
                    int seatNumber = int.Parse(Console.ReadLine());

                    try
                    {
                        var ticket = bookingSystem.BookTicket(concertName, price, seatNumber);
                        Console.WriteLine($"\nZarezerwowano bilet na koncert: {ticket.Concert.Name}, Cena: {ticket.Price}, Miejsce: {ticket.SeatNumber}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nBłąd: {ex.Message}");
                    }
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Zakończono działanie");
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie.");
                    break;
            }
        }
    }
}