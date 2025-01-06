namespace Concert_Ticker_Booking_System;


public class BookingSystem
{
    private List<Concert> concerts = new List<Concert>();
    
    public void AddConcert(string name, string date, string location, int availableSeats)
    {
        concerts.Add(new Concert(name, date, location, availableSeats));
        Console.WriteLine($"Dodano koncert: {name}, Data: {date}, Lokalizacja: {location}, Dostępne miejsca: {availableSeats}");
    }
    
    public Ticket BookTicket(string concertName, decimal price, int seatNumber)
    {
        Concert concert = null;

        foreach (var c in concerts)
        {
            if (c.Name.Equals(concertName, StringComparison.OrdinalIgnoreCase))
            {
                concert = c;
                break;
            }
        }

        if (concert == null)
        {
            Console.WriteLine("Nie znaleziono koncertu o podanej nazwie.");
            return null;
        }

        return Ticket.BookTicket(concert, price, seatNumber);
    }
    
    public void DisplayConcerts(string filterLocation)
    {
        var filteredConcerts = new List<Concert>();

        foreach (var concert in concerts)
        {
            if (concert.Location.Equals(filterLocation, StringComparison.OrdinalIgnoreCase))
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