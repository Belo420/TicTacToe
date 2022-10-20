using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

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
            string input = Console.ReadLine();
            int choice;
            if(!int.TryParse(input, out choice))
            {
                Console.WriteLine("Podaj liczbe a nie litere");
            }

            if (choice >= 1 && choice <= 9)
            {
                for (int i = 0; i < boardValues.GetLength(0); i++)
                    for (int j = 0; j < boardValues.GetLength(1); j++)
                    {
                        if (boardValues[i, j] == choice.ToString())
                        {
                            boardValues[i, j] = "X";
                        }
                    }
            }
            else
            {
                Console.WriteLine("Wybrales wartosc z poza zakresu. Za kare tracisz ruch");
            }
            DrawABoard(boardValues);
        }
        static internal void ChoicePlayerB(string[,] boardValues)
        {
            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Podaj liczbe a nie litere");
            }
            if (choice >= 1 && choice <= 9)
            {
                for (int i = 0; i < boardValues.GetLength(0); i++)
                    for (int j = 0; j < boardValues.GetLength(1); j++)
                    {
                        if (boardValues[i, j] == choice.ToString())
                        {
                            boardValues[i, j] = "O";
                        }

                    }
            }
            else
            {
                Console.WriteLine("Wybrales wartosc z poza zakresu. Za kare tracisz ruch");
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
        static internal void SaveToFile(Scores scores, string path)
        {
            using (StreamWriter file = File.CreateText(path + @"\scores.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, scores);
            }
        }
        static internal Scores ReadFromFile(string path)
        {
            using (StreamReader file = File.OpenText(path + @"\scores.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Scores scores = (Scores)serializer.Deserialize(file, typeof(Scores));
                return scores;
            }
        }
        static internal void ShowStats(Scores scores)
        {
            Console.WriteLine($"Statystyki: \nWygrane Gracza pierwszego: {scores.Player1.wins}\nPrzegrane Gracza pierwszego: {scores.Player1.loses}");
            Console.WriteLine($"Wygrane Gracza drugiego: {scores.Player2.wins}\nPrzegrane Gracza drugiego: {scores.Player2.loses}");
            Console.WriteLine($"Remisy: {scores.pats}");
        }
        static internal bool CheckForPat(string[,] boardValues, Scores scores, string path)
        {
            string arrayString = string.Empty;
            Regex regex = new Regex(@"[0-9]");
            foreach (string boardValue in boardValues)
            {
                arrayString += boardValue;
            }
            if(regex.IsMatch(arrayString) == false)
            {
                Console.WriteLine("Remis.");
                scores.pats++;
                SaveToFile(scores, path);
                return true;
            }
            return false;
                    
        }
        static internal void Game()
        {
            string path = Directory.GetCurrentDirectory();
            while (true)
            {
                
                string[,] boardValues = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
                Console.WriteLine("Wybierz opcje \n1. Nowa gra \n2. Statystyki \n3. Exit");
                string input = Console.ReadLine();
                int menu;
                if (!int.TryParse(input, out menu))
                {
                    Console.WriteLine("Podaj liczbe a nie litere");
                }
                Scores scores = new Scores()
                {
                    Player1 = new Player1(),
                    Player2 = new Player2()
                };
                
                if (!File.Exists(path + @"\scores.json")) //Avoiding of overwriting future data with zeros, creating stats file it id dont exists
                {
                    SaveToFile(scores, path);
                }
                else
                {
                    scores = ReadFromFile(path);
                }
                switch (menu)
                {
                    case 1:
                        {
                            while (true)
                            {
                                Console.WriteLine("Gracz 1 wybiera: ");
                                DrawABoard(boardValues);
                                ChoicePlayerA(boardValues);
                                if (CheckForWinConditionRows(boardValues) == true)
                                {
                                    Console.WriteLine("Wygrana przez rząd wierszy");
                                    Console.WriteLine("Wygrał Gracz 1");
                                    scores.Player1.wins++;
                                    scores.Player2.loses++;
                                    SaveToFile(scores, path);
                                    break;
                                }
                                if (CheckForWinConditionDiagonal(boardValues) == true)
                                {
                                    Console.WriteLine("Wygrana przez przekątną");
                                    Console.WriteLine("Wygrał Gracz 1");
                                    scores.Player1.wins++;
                                    scores.Player2.loses++;
                                    SaveToFile(scores, path);
                                    break;
                                }
                                if (CheckForWinConditionColumn(boardValues) == true)
                                {
                                    Console.WriteLine("Wygrana przez rząd kolumn");
                                    Console.WriteLine("Wygrał Gracz 1");
                                    scores.Player1.wins++;
                                    scores.Player2.loses++;
                                    SaveToFile(scores, path);
                                    break;
                                }
                                if (CheckForPat(boardValues, scores, path) == true)
                                {
                                    break;
                                }
                                Console.WriteLine("Gracz 2 wybiera: ");
                                ChoicePlayerB(boardValues);
                                if (CheckForWinConditionRows(boardValues) == true)
                                {
                                    Console.WriteLine("Wygrana przez rząd wierszy");
                                    Console.WriteLine("Wygrał Gracz 2");
                                    scores.Player2.wins++;
                                    scores.Player1.loses++;
                                    SaveToFile(scores, path);
                                    break;
                                }
                                if (CheckForWinConditionDiagonal(boardValues) == true)
                                {
                                    Console.WriteLine("Wygrana przez przekątną");
                                    Console.WriteLine("Wygrał Gracz 2");
                                    scores.Player2.wins++;
                                    scores.Player1.loses++;
                                    SaveToFile(scores, path);
                                    break;
                                }
                                if (CheckForWinConditionColumn(boardValues) == true)
                                {
                                    Console.WriteLine("Wygrana przez rząd kolumn");
                                    Console.WriteLine("Wygrał Gracz 2");
                                    scores.Player2.wins++;
                                    scores.Player1.loses++;
                                    SaveToFile(scores, path);
                                    break;
                                }
                                if (CheckForPat(boardValues, scores, path) == true)
                                {
                                    break;
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            ShowStats(scores);
                            break;
                        }
                    case 3:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}
