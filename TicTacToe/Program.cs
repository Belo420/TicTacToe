namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] boardValues = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            DrawABoard(boardValues);
            ChoicePlayerA(boardValues);
            ChoicePlayerB(boardValues);
            CheckForWinCondition(boardValues);
        }//suma wartosci 
        static internal void DrawABoard(int[,] boardValues)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[0,0]}    |  {boardValues[0,1]}     |  {boardValues[0,2]}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[1,0]}    |  {boardValues[1,1]}     |  {boardValues[1,2]}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[2,0]}    |  {boardValues[2,1]}     |  {boardValues[2,2]}   ");
            Console.WriteLine("-------------------");
        }
        static internal void ChoicePlayerA(int[,] boardValues)
        {

            Console.WriteLine("Podaj wartosc do zakreslenia");
            int choice = int.Parse(Console.ReadLine());
            for(int i = 0; i < boardValues.GetLength(0); i++)
                for(int j = 0; j < boardValues.GetLength(1); j++)
                {
                    if (boardValues[i, j] == choice)
                    {
                        boardValues[i, j] = 'O';
                    }
                    
                }
            DrawABoard(boardValues);
        }
        static internal void ChoicePlayerB(int[,] boardValues)
        {

            Console.WriteLine("Podaj wartosc do zakreslenia");
           // int choice = int.Parse(Console.ReadLine());
            //if (choice < 4)
            //    boardValues[0, choice - 1] = "O";
            //if (choice < 7)
            //    boardValues[1, choice - 1] = "O";
            //if (choice < 10)
            //    boardValues[2, choice - 1] = "O";
            DrawABoard(boardValues);
        }
        static internal bool CheckForWinCondition(int[,] boardValues)
        {
            for (int i = 0; i < boardValues.Length; i++)
            {
               
            }
            return false;
        }
    }
}