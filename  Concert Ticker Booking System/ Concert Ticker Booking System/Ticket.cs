namespace Concert_Ticker_Booking_System;

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