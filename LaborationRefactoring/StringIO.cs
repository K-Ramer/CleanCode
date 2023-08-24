using System;

namespace LaborationRefactoring;

public class StringIO : IUI
{
    private static string GetString()
    {
        return Console.ReadLine();
    }

    private static void PrintString(string output)
    {
        Console.WriteLine(output);
    }


    public string GetGuess()
    {
        string input = GetString();

        while (!(input.Length <= 4 && int.TryParse(input, out _)))
        {
            PrintString("Invalid input. Please enter a valid number with up to 4 digits.");
            input = GetString();
        }

        return input;
    }

    public int GetNumber()
    {
        int choice;
        while(!int.TryParse(GetString(), out choice))
            PrintString("A number please.");

        return choice;
    }

    public string GetUserName()
    {
        PrintString("Enter your user name:\n");
        return GetString();
    }


    public void ShowGuessFeedback(string answerFeedbackBullsOrCows)
    {
        PrintString(answerFeedbackBullsOrCows + "\n");
    }

    public void ShowMenu(List<IGame>games)
    {
        PrintString("Menu\n\n");
        int IndexNr = 1;

        foreach(IGame game in games)
        {
            PrintString($"{IndexNr}. {game.GetGameName()}");
            IndexNr++;
        }

        PrintString($"{IndexNr}. Exit");
    }

    public void ShowMooTopList(List<MooPlayer> results)
    {

        PrintString("Player   games average");

        if (results.Count == 0)
        {
            PrintString("No results available.");
        }
        else
        {
            foreach (MooPlayer player in results)
            {
                PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfRoundsPlayed, player.AverageNumberOfGuesses()));
            }
        }
    }

    public void ShowRoundFeedback(int numberOfGuesses)
    {
        PrintString("Correct, it took " + numberOfGuesses + " guesses\n");
    }

    public void StartNewGame(string answer)
    {
        PrintString("New game:\n");

        //comment out or remove next line to play real games!
        PrintString("For practice, number is: " + answer + "\n");
    }


    public bool ContinueOrQuit()
    {
        while (true)
        {
            PrintString("\nContinue?");
            string playerInput = GetString().Trim().ToLower();

            if (playerInput == "y")
            {
                return true;
            }
            else if (playerInput == "n")
            {
                return false;
            }
            else
            {
                PrintString("Invalid response. Please enter 'y' or 'n'.");
            }
        }
    }


    public void WrongInput()
    {
        PrintString("No such choice. Try again.");
    }
}

