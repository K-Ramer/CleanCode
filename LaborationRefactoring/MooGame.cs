using System;
using System.IO;
using System.Collections.Generic;

namespace LaborationRefactoring;

internal class MooGame
{
    IUI io;
    IDAO dAO;

    public MooGame(IUI io, IDAO dAO)
    {
        this.io = io;
        this.dAO = dAO;
    }

    public void RunGame()
    {

        bool playOn = true;
        string playerName = io.GetUserName();
        List<MooPlayer> topList = new List<MooPlayer>();

        while (playOn)
        {
            string answer = generateNewAnswer();
            string playerGuess; 
            int numberOfGuesses = 0;
            string? answerFeedbackBullsOrCows = null;
           
            io.StartNewGame(answer);

            while (answerFeedbackBullsOrCows != "BBBB,")
            {
                numberOfGuesses++;
                playerGuess = io.GetGuess();
                
                answerFeedbackBullsOrCows = compareGuessToAnswer(answer, playerGuess);
                io.ShowGuessFeedback(answerFeedbackBullsOrCows);
            }

            dAO.AddMooResults(playerName,numberOfGuesses);

            topList = sortToplist();
            io.ShowMooTopList(topList);

            io.ShowRoundFeedback(numberOfGuesses);

            playOn = io.ContinueOrQuit();
        }
    }

    private string generateNewAnswer()
    {
        Random randomGenerator = new Random();

        string randomFourDigitString = randomGenerator.Next(0, 10000).ToString("D4");
       
        return randomFourDigitString;
    }

    private string compareGuessToAnswer(string answer, string playerGuess)
    {
        int bulls = 0, cows = 0;
        const string BullsString = "BBBB";
        const string CowsString = "CCCC";

        if (playerGuess.Length < 4)
        {
            playerGuess = playerGuess.PadRight(4);
        }

        for (int i = 0; i < 4; i++)
        {
            if (answer[i] == playerGuess[i])
            {
                bulls++;
            }
            else if (playerGuess.Contains(answer[i]))
            {
                cows++;
            }
        }

        string bullsSubstring = BullsString.Substring(0, bulls);
        string cowsSubstring = CowsString.Substring(0, cows);

        return $"{bullsSubstring},{cowsSubstring}";
    }
    
    private List<MooPlayer> sortToplist()
    { 
        var results = dAO.GetMooResults();

        results.Sort((player1, player2) => player1.AverageNumberOfGuesses().CompareTo(player2.AverageNumberOfGuesses()));

        return results;
    }

   
}


