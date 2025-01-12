namespace Concert_Ticker_Booking_System;


public class Concert
{
    public string Name { get; set; }
    public string Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; set; }
    public int TicketPrice { get; set; }

    public Concert(string name, string date, string location, int availableSeats, int ticketPrice)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
        TicketPrice = ticketPrice;
    }
}