using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class Board
    {
        

        private string[,] m_gameBoard;
        private string solutionToPresent;
        public Board(string[,] inputBoardArrey) 
        {
            solutionToPresent = "####";
            m_gameBoard = inputBoardArrey;
        }

        public string[,] gameBoard
        {
            get 
            {
                return m_gameBoard; 
            }
            set 
            {
                m_gameBoard = value; 
            }
        }

        public string solution
        {
            set { solutionToPresent = value; }
        }
        
        public void printBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Current board status:\n");

            Console.WriteLine("|Pins:    |Result:  |");
            Console.WriteLine("|=========|=========|");
            Console.WriteLine(string.Format("| {0} {1} {2} {3} |         |", 
                solutionToPresent[0], solutionToPresent[1], solutionToPresent[2], solutionToPresent[3]));
            Console.WriteLine("|=========|=========|");
            for (int i = 0; i < this.m_gameBoard.GetLength(0); i++)
            {Console.Write("|");
                for (int j = 0; j < this.m_gameBoard.GetLength(1); j++)
                {
                    

                    if (m_gameBoard[i, j]==null || m_gameBoard[i, j].CompareTo("")==0)
                    {
                        Console.Write("         |");
                    }
                    else
                    {
                        Console.Write(string.Format(" {0} {1} {2} {3} |",
                            m_gameBoard[i, j][0], m_gameBoard[i, j][1], m_gameBoard[i, j][2], m_gameBoard[i, j][3]));
                    }

                }
                Console.WriteLine("\n|=========|=========|");

            }
            Console.WriteLine("");
        }
    }
}
