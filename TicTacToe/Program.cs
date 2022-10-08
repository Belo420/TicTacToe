﻿namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] boardValues = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            DrawABoard(boardValues);
            ChoicePlayerA(boardValues);
            ChoicePlayerB(boardValues);
            CheckForWinCondition(boardValues);
        }//suma wartosci 
        static internal void DrawABoard(string[,] boardValues)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[0,0]}    |  {boardValues[0,1]}     |  {boardValues[0,2]}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[1,0]}    |  {boardValues[1,1]}     |  {boardValues[1,2]}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($" {boardValues[2,0]}    |  {boardValues[2,1]}     |  {boardValues[2,2]}   ");
            Console.WriteLine("-------------------");
        }
        static internal void ChoicePlayerA(string[,] boardValues)
        {

            Console.WriteLine("Podaj wartosc do zakreslenia");
            int choice = int.Parse(Console.ReadLine());
            for(int i = 0; i < boardValues.GetLength(0); i++)
                for(int j = 0; j < boardValues.GetLength(1); j++)
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
        static internal bool CheckForWinCondition(string[,] boardValues)
        {
            for (int i = 0; i < boardValues.Length; i++)
            {
               
            }
            return false;
        }
    }
}