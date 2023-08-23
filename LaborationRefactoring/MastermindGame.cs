using System;
using System.Text;

namespace LaborationRefactoring;

internal class Mastermind : IGame
{
    private const string GameName = "Mastermind";

    IUI io;
    IDAO dAO;

    public Mastermind(IUI io, IDAO dAO)
    {
        this.io = io;
        this.dAO = dAO;
    }

    public string GetGameName()
    {
        return GameName;
    }

    public void RunGame()
    {
        Console.WriteLine("You are playing Mastermind");
    }
}

    //    bool playOn = true;
    //    string playerName = io.GetUserName();


    //    while (playOn)
    //    {
    //        string answer = GenerateNewAnswer();
    //        string playerGuess;
    //        int numberOfGuesses = 0;
    //        string? answerFeedbackBullsOrCows = null;

    //        io.StartNewGame(answer);

    //        while (answerFeedbackBullsOrCows != "BBBB,")
    //        {
    //            numberOfGuesses++;
    //            playerGuess = io.GetGuess();

    //            answerFeedbackBullsOrCows = CompareGuessToAnswer(answer, playerGuess);
    //            io.ShowGuessFeedback(answerFeedbackBullsOrCows);
    //        }

    //        dAO.AddMooResults(playerName, numberOfGuesses);

    //        ShowTopList();

    //        io.ShowRoundFeedback(numberOfGuesses);

    //        playOn = io.ContinueOrQuit();
    //    }
    //}

    //private string GenerateNewAnswer()
    //{
        
    //        string allowedLetters = "rbgywb";
    //        Random randomGenerator = new Random();
    //        char[] code = new char[4];

    //        for (int i = 0; i < code.Length; i++)
    //        {
    //            int randomIndex = randomGenerator.Next(allowedLetters.Length);
    //            code[i] = allowedLetters[randomIndex];
    //        }

    //        return new string(code);  
    //}
    





    


