namespace Board_Game__Simulator_board;
using Board_Game__Simulator_player;

public class Board
{
    public int boardSize { get; set; } = 100;
    public static List<int> SpecialFields = new List<int>();

    public static void randomFields()
    {
        
        Random rnd = new Random();
        
        for (int i = 1; i < 40; i++)
        {
            
            int newField = rnd.Next(1,101);


            if (!SpecialFields.Contains(newField))
            {
                SpecialFields.Add(newField);
                
            }
        }
        
    }

    public static void RandomPrice(Player player)
    {
        string PlayerClass = player.PlayerClass.GetType().Name;
        Random rnd = new Random();
        int price = rnd.Next(1, 6);
        if (price == 1)
        {
            
            Console.WriteLine("trafiłes na pszczole");
            int allergy = rnd.Next(1, 10000);
            if (allergy == 3144)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("pszczola cie uzadliłą , trcisz wszystkie punkty poniewaz masz alergie");
                player.AddScore( -player.Score);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Pszczoła daje ci miód dzieki czemu zdowbywasz 7 ponktów");
                player.AddScore(7);
            }
        }

        else if (price == 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int extraRoll = rnd.Next(1, 7);
            Console.WriteLine($"Otrzymujesz dodatkowy rzut kostką i wyrzucasz {extraRoll}!");
            player.Position += extraRoll; 
        }
        else if (price == 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"trafiłes na swinksa który zadaje ci pytanie: \n" +
                              $"ile to 2+2*2");
            switch (PlayerClass)
            {
                case "Mag":
                    Console.WriteLine("Dzieki twojej inteligencji Maga Sfinks cię przepuszcza i Dostajesz 15 punktów");
                    player.AddScore(15);
                    break;
                case "Healer":
                    Console.WriteLine("Dzieki twojej haryzmie Healera Sfinks cię przepuszcza i Dostajesz 10 punktów");
                    player.AddScore(10);
                    break;
                case "Wojownik":
                    Console.WriteLine("Dzieki twojej sile Wojownika niszczysz Sfinks i Dostajesz 5 punktów");
                    player.AddScore(5);
                    break;
            }
        }
        else if (price == 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Trafiłes na złodzieja ");
            switch (PlayerClass)
            {
                case "Mag":
                    Console.WriteLine("Dzieki twojej umjejetnosci czytania umysłów Maga przewidziałeś ze złodziejej chce cie okrasc przez co ochroniłes swoje punkty");
                    player.AddScore(0);
                    break;
                case "Healer":
                    Console.WriteLine("Healer nie umie sie obronic przed złodziejem i traci 5 punktów");
                    player.AddScore(-5);
                    break;
                case "Wojownik":
                    Console.WriteLine("Dzieki twojej sile Wojownika niszczysz złodzieja i Dostajesz 10 punktów");
                    player.AddScore(10);
                    break;
            }
        }
        else if (price == 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("trafiłęs na pułapke ");
            switch (PlayerClass)
            {
                case "Mag":
                    Console.WriteLine("Jako mag byłes bardzo ostrozny i zawsze wszystko sprawdzałes dzieki temu udało ci sie uniknac wszystkich pułapek i znaleść skarb zyskujesz 20 punktów");
                    player.AddScore(0);
                    break;
                case "Healer":
                    Console.WriteLine("Jako healer wpadłes w pułapke ");
                    player.AddScore(-5);
                    break;
                case "Wojownik":
                    Console.WriteLine("Dzieki twojej sile Wojownika wpadasz i niszczysz pułąpke gdzie znajdujesz pare monet i Dostajesz 10 punktów");
                    player.AddScore(10);
                    break;
            }
        }
        
    }
    
}