namespace Concert_Ticker_Booking_System;

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