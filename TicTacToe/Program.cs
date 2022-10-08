namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game();
        }
        static internal void DrawABoard(string[,] boardValues)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[0, 0]}    |  {boardValues[0, 1]}     |  {boardValues[0, 2]}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[1, 0]}    |  {boardValues[1, 1]}     |  {boardValues[1, 2]}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[2, 0]}    |  {boardValues[2, 1]}     |  {boardValues[2, 2]}   ");
            Console.WriteLine("-------------------");
        }
        static internal void ChoicePlayerA(string[,] boardValues)
        {

            Console.WriteLine("Podaj wartosc do zakreslenia");
            int choice = int.Parse(Console.ReadLine());
            for (int i = 0; i < boardValues.GetLength(0); i++)
                for (int j = 0; j < boardValues.GetLength(1); j++)
                {
                    if (boardValues[i, j] == choice.ToString())
                    {
                        boardValues[i, j] = "X";
                    }

                }
            DrawABoard(boardValues);
        }
        static internal void ChoicePlayerB(string[,] boardValues)
        {
            int choice = int.Parse(Console.ReadLine());
            for (int i = 0; i < boardValues.GetLength(0); i++)
                for (int j = 0; j < boardValues.GetLength(1); j++)
                {
                    if (boardValues[i, j] == choice.ToString())
                    {
                        boardValues[i, j] = "O";
                    }

                }
            DrawABoard(boardValues);
        }
        static internal bool CheckForWinConditionRows(string[,] boardValues)
        {
            for (int i = 0; i < boardValues.GetLength(0); i++)
                if (boardValues[i, 0] == boardValues[i, 1] || boardValues[i, 1] == boardValues[i, 2])
                {
                    return true;
                }
            return false;
        }
        static internal bool CheckForWinConditionColumn(string[,] boardValues)
        {
            for (int i = 0; i < boardValues.GetLength(0); i++)
                if (boardValues[0, i] == boardValues[1, i] || boardValues[1, i] == boardValues[2, i])
                {
                    return true;
                }
            return false;
        }
        static internal bool CheckForWinConditionDiagonal(string[,] boardValues)
        {
            if (boardValues[0, 0] == boardValues[1, 1] || boardValues[1, 1] == boardValues[2, 2])
            {
                return true;
            }
            if (boardValues[2, 0] == boardValues[1, 1] || boardValues[1, 1] == boardValues[0, 2])
            {
                return true;
            }
            return false;
        }
        static internal void Game()
        {
            string[,] boardValues = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            while (true)
            {
                DrawABoard(boardValues);
                Console.WriteLine("Gracz 1 wybiera: ");
                ChoicePlayerA(boardValues);
                Console.WriteLine("Gracz 2 wybiera: ");
                ChoicePlayerB(boardValues);
                CheckForWinConditionRows(boardValues);
                CheckForWinConditionColumn(boardValues);
                CheckForWinConditionDiagonal(boardValues);
                
            }

        }
        static internal bool CheckForWin(string[,] boardValues)
        {
            return false;
        }
    }
}