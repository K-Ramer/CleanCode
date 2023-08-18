using System;

namespace LaborationRefactoring
{
    public class StringIO : IUI
    {
        private string GetString()
        {
            return Console.ReadLine();
        }
        public string GetUserName()
        {
            PrintString("Enter your user name:\n");
            return GetString();
        }

        public void StartNewGame(string answer)
        {
            PrintString("New game:\n");

            //comment out or remove next line to play real games!
            PrintString("For practice, number is: " + answer + "\n");
        }

        public string GetGuess()
        {
            string playerGuess = GetString();
            PrintString(playerGuess + "\n");
            return playerGuess;
        }

        public void PrintMenu()
        {
            PrintString("Menu\n\n1. MooGame\n2. Other Game");
        }

        private void PrintString(string output)
        {
            Console.WriteLine(output);
        }

        public void PrintMooTopList(List<MooPlayer> results)
        {
            PrintString("Player   games average");
            
            foreach (MooPlayer player in results)
            {
                PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfRoundsPlayed, player.Average()));
            }
            
        }

        public void ShowGuessFeedback(string answerFeedbackBullsOrCows)
        {
            PrintString(answerFeedbackBullsOrCows + "\n");
        }

        public void ShowRoundFeedback(int numberOfGuesses) //Move "keep playing?"
        {
            PrintString("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
        }

        public bool ContinueOrQuit()
        {
            string playerInput = GetString();
            if (playerInput != null && playerInput != "" && playerInput.Substring(0, 1) == "n")
            {
                return false;
            }
            else
                return true;
        }
    }
}

