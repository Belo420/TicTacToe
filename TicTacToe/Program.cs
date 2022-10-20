using Newtonsoft.Json;

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
                if (boardValues[i, 0] == boardValues[i, 1] && boardValues[i, 1] == boardValues[i, 2])
                {
                    return true;
                }
            return false;
        }
        static internal bool CheckForWinConditionColumn(string[,] boardValues)
        {
            for (int i = 0; i < boardValues.GetLength(0); i++)
                if (boardValues[0, i] == boardValues[1, i] && boardValues[1, i] == boardValues[2, i])
                {
                    return true;
                }
            return false;
        }
        static internal bool CheckForWinConditionDiagonal(string[,] boardValues)
        {
            if (boardValues[0, 0] == boardValues[1, 1] && boardValues[1, 1] == boardValues[2, 2])
            {
                return true;
            }
            if (boardValues[2, 0] == boardValues[1, 1] && boardValues[1, 1] == boardValues[0, 2])
            {
                return true;
            }
            return false;
        }
        static internal void Game()
        {
            string[,] boardValues = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            DrawABoard(boardValues);
            Console.WriteLine("Wybierz opcje \n1. Nowa gra \n2. Statystyki \n3. Exit");
            int menu = int.Parse(Console.ReadLine());
            Scores scores = new Scores()
            {
                Player1 = new Player1(),
                Player2 = new Player2() 
            };
            using (StreamWriter file = File.CreateText(@"c:\Gry\scores.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, scores);
            }
           
            switch (menu)
            {
                case 1:
                    {
                        while (true)
                        {
                            Console.WriteLine("Gracz 1 wybiera: ");
                            ChoicePlayerA(boardValues);
                            if (CheckForWinConditionRows(boardValues) == true)
                            {
                                Console.WriteLine("Wygrana przez rząd wierszy");
                                break;
                            }
                            if (CheckForWinConditionDiagonal(boardValues) == true)
                            {
                                Console.WriteLine("Wygrana przez przekątną");
                                break;
                            }
                            if (CheckForWinConditionColumn(boardValues) == true)
                            {
                                Console.WriteLine("Wygrana przez rząd kolumn");
                                break;
                            }
                            Console.WriteLine("Gracz 2 wybiera: ");
                            ChoicePlayerB(boardValues);
                            if (CheckForWinConditionRows(boardValues) == true)
                            {
                                Console.WriteLine("Wygrana przez rząd wierszy");
                                break;
                            }
                            if (CheckForWinConditionDiagonal(boardValues) == true)
                            {
                                Console.WriteLine("Wygrana przez przekątną");
                                break;
                            }
                            if (CheckForWinConditionColumn(boardValues) == true)
                            {
                                Console.WriteLine("Wygrana przez rząd kolumn");
                                break;
                            }
                        }
                        break;
                    }
            }
           
        }
    }
}