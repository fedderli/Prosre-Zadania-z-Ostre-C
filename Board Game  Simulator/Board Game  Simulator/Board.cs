namespace Board_Game__Simulator_board;

public class Board
{
    public int boardSize { get; set; } = 100;

    public static void randomFields()
    {
        List<int> SpecialFields = new List<int>();
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

    public static void RandomPrice()
    {
        
    }

    public static void RandomPunishment()
    {
        
    }
}