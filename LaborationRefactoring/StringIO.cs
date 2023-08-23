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

    public void ShowMenu()
    {
        PrintString("Menu\n\n1. MooGame\n2. Other Game\n3. Quit");
    }

    public void ShowMooTopList(List<MooPlayer> results)
    {
        PrintString("Player   games average");
        
        foreach (MooPlayer player in results)
        {
            PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfRoundsPlayed, player.AverageNumberOfGuesses()));
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
        PrintString("\nContinue?");

        string playerInput = GetString().ToLower().Substring(0, 1);

        while (playerInput != "y" && playerInput != "n")
        {
            Console.Write("Invalid response. Please enter 'y' or 'n': ");
            playerInput = GetString().ToLower().Substring(0, 1);
        }

        if (playerInput == "y")
            return true;

        else
            return false;
    }


    public void WrongInput()
    {
        PrintString("No such choice. Try again.");
    }
}

