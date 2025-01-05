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

    }
}