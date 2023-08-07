using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class GameManager
    {
        private const int desiredSolutionLength = 4;
        private const int solutionIsCorrect = 0;
        

        Random random = new Random();

        private Board m_board;
        private string[,] m_arreyOfGuess;

        private readonly int r_numberOfGuess;
        private readonly string r_solution;

        private int m_turn;

        private bool m_gameFinished; 
        private bool m_userPressExit;

        public GameManager()
        {
            initGame(out r_numberOfGuess, out m_arreyOfGuess, out r_solution);

            runGame();
        }

        public bool userPressExit
        {
            get
            {
                return m_userPressExit;
            }
        }

        private void runGame()
        {
            while (!m_gameFinished && m_turn<r_numberOfGuess)
            {
                m_board.printBoard();
                Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
                string guess = getValidNewGuess(Console.ReadLine().Replace(" ", string.Empty));
               if(m_userPressExit)
                {
                    break;
                }

                string guessScore = getGuessScore(guess);
                enterGuessToGuessArrey(m_turn, guess, guessScore);
                if (guess.CompareTo(r_solution) == solutionIsCorrect)
                {
                    gameWon();
                }
                m_turn++;
            }
            if(m_turn >= r_numberOfGuess)
            {
                gameLost();

            }
        }

        private void gameLost()
        {
            m_board.solution = r_solution;
            m_board.printBoard();
            Console.WriteLine(string.Format("No more guesses allowed. You Lost", m_turn + 1));
        }

        private void enterGuessToGuessArrey(int i_turn, string i_guess, string i_guessScore)
        {
            m_arreyOfGuess[i_turn, 0] = i_guess;
            m_arreyOfGuess[i_turn, 1] = i_guessScore;
            m_board.gameBoard = m_arreyOfGuess;
        }
        private void gameWon()
        {
            m_board.solution = r_solution;
            m_board.printBoard();
            m_gameFinished = true;
            Console.WriteLine(string.Format("You guessed after {0} steps!", m_turn+1));
           
        }
        private string getGuessScore(string i_userGuess)
        {
           string inputScore = "";
           for(int i = 0; i < i_userGuess.Length;i++)
           {
                if (i_userGuess[i].CompareTo(r_solution[i]) ==0)
                {
                    inputScore = 'V' + inputScore;
                }
                else if(r_solution.Contains(i_userGuess[i]))
                {
                    inputScore += 'X';
                }
           }
           while(inputScore.Length < 4)
            {
                inputScore += ' ';
            }
            return inputScore;
        }
        private string getValidNewGuess(string i_userInput)
        {
            bool userIputIsVaild = false;
            while (!userIputIsVaild)
            {
                userIputIsVaild = true;
                if (i_userInput.CompareTo("Q")==0)
                {
                    m_userPressExit = true; 
                }
                else if (i_userInput.Length == desiredSolutionLength)
                {
                    if (i_userInput.Distinct().Count() != i_userInput.Count())
                    {
                        Console.WriteLine("You cannot repeat letters, type new guess:");
                        i_userInput = Console.ReadLine().Replace(" ", string.Empty);
                        userIputIsVaild = false;
                    }
                    else
                    {
                        foreach (char letter in i_userInput)
                        {
                            if (letter > 'H' || letter < 'A')
                            {
                                Console.WriteLine("The letters should be between 'A' to 'H', type new guess:");
                                i_userInput = Console.ReadLine().Replace(" ", string.Empty);
                                userIputIsVaild = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("There need to be {0} letters in your guess, type new guess:", desiredSolutionLength));
                    i_userInput = Console.ReadLine().Replace(" ", string.Empty);
                    userIputIsVaild = false;
                }
            }
            return i_userInput;
        }
        private void initGame(out int i_numberOfGuess, out string[,] i_arreyOfGuess, out string i_solution)
        {
            m_gameFinished = false;
            m_userPressExit = false;
            m_turn = 0;

            i_solution = getNewSolution();
            Console.Write("Enter number of guess: ");
            i_numberOfGuess = getValidInput(Console.ReadLine());
            i_arreyOfGuess = new string[i_numberOfGuess, 2];
            m_board = new Board(i_arreyOfGuess);
        }
        private string getNewSolution()
        {
            string solution = "";
            while (solution.Length < desiredSolutionLength)
            {
                char newLetter = (Char)random.Next(65, 72);
                if (!solution.Contains(newLetter))
                {
                    solution += newLetter;
                }
            }
            return solution;
        }
        public static int getValidInput(string i_userInputInString)
        {
            bool inputIsValid = false;
            int userInput = 0;
            while (!inputIsValid)
            {
                if (int.TryParse(i_userInputInString, out userInput))
                {
                    if (userInput >= 4 && userInput <= 10)
                    {
                        inputIsValid = true;
                    }
                    else
                    {
                        Console.Write("The number should be a between 4 and 10, Please try again: ");
                        i_userInputInString = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("The input should be a number, Please try again: ");
                    i_userInputInString = Console.ReadLine();
                }
            }
            return userInput;
        }
    }
}
