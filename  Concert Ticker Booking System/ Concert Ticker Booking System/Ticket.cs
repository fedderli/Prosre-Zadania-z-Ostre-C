namespace Concert_Ticker_Booking_System;


public class Ticket
{
    public Concert Concert { get; private set; }
    public int Price { get; private set; }
    public int SeatNumber { get; private set; }
    
    public Ticket(Concert concert, int price, int seatNumber)
    {
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }

    public static Ticket BookTicket(Concert concert, int ticketPrice, int seatNumber)
    {
        if (concert.AvailableSeats <= 0)
        {
            Console.WriteLine("Brak dostępnych miejsc na ten koncert.");
            return null;
        }

        concert.AvailableSeats--;
        return new Ticket(concert, ticketPrice, seatNumber);
    }
}