using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        public static void Main(string[] args)
        {

            string userInput;
            bool closeApp = false;
            while(!closeApp)
            {
                GameManager startNewGame = new GameManager();
                if (startNewGame.userPressExit)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    closeApp = true;
                    Console.WriteLine("Thank you for playing! Goodbye");
                    Console.ReadLine(); 
                }
                else
                {
                    Console.WriteLine("Would you like to start a new game? <Y/N>");
                    userInput = Console.ReadLine().ToUpper();

                    while (userInput.CompareTo("N") != 0 && userInput.CompareTo("Y") != 0)
                    {
                        Console.WriteLine("input is invalid, type <Y/N>");
                        userInput = Console.ReadLine().ToUpper();
                    }
                    if (userInput.CompareTo("N") == 0)
                    {
                        closeApp = true;
                    }
                    Ex02.ConsoleUtils.Screen.Clear();
                }
            }
        }



    }
}
