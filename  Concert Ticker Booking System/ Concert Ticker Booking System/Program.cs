﻿using System;
using System.Collections.Generic;
namespace Concert_Ticker_Booking_System;


public class Program
{
    public static void Main(string[] args)
    {
        BookingSystem bookingSystem = new BookingSystem();
        bookingSystem.AddConcert("Test", "12.12.2000", "Warszawa", 500, 300);
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("System Rezerwacji Biletów na Koncerty");
            Console.WriteLine("1 - Dodaj koncert\n2 - Wyświetl koncerty według lokalizacji\n3 - Rezerwuj bilet\n4 - Koniec\nWybierz opcję: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Podaj nazwę koncertu: ");
                    string name = Console.ReadLine();
                    Console.Write("Podaj datę koncertu: ");
                    string date = Console.ReadLine();
                    Console.Write("Podaj lokalizację koncertu: ");
                    string location = Console.ReadLine();
                    Console.Write("Podaj liczbę dostępnych miejsc: ");
                    int availableSeats = int.Parse(Console.ReadLine());
                    Console.Write("Podaj cenę biletu: ");
                    int ticketPrice = int.Parse(Console.ReadLine());

                    bookingSystem.AddConcert(name, date, location, availableSeats, ticketPrice);
                    break;

                case "2":
                    Console.Write("Podaj lokalizację: ");
                    string filterLocation = Console.ReadLine();

                    Console.WriteLine($"\nKoncerty w lokalizacji: {filterLocation}");
                    bookingSystem.DisplayConcerts(c => c.Location.Equals(filterLocation, StringComparison.OrdinalIgnoreCase));
                    break;

                case "3":
                    Console.Write("Podaj nazwę koncertu: ");
                    string concertName = Console.ReadLine();
                    Console.Write("Podaj numer miejsca: ");
                    int seatNumber = int.Parse(Console.ReadLine());
                    var ticket = bookingSystem.BookTicket(concertName, seatNumber);
                    if (ticket != null)
                    {
                        Console.WriteLine($"\nZarezerwowano bilet na koncert: {ticket.Concert.Name}, Miejsce: {ticket.SeatNumber}, Cena: {ticket.Price} PLN");
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
