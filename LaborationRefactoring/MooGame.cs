using System;
using System.IO;
using System.Collections.Generic;

namespace LaborationRefactoring;

internal class MooGame
{
    IUI io;
    IDAO dAO;

    // Om uppgiften går ut på att refaktorisera för att kunna ha fler spel så borde det nog finnas ett IGame interface?
    // Borde väl minst kunna köra ett spel, säga vad det heter och ge ut sin topplista?
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
                // Här kanske jag lurade dig lite.
                // Om jag fattar originalkoden, utan att ha kört den, så ser det ut som den skriver ut ungefär:
                // New game:
                // For practice, number is: 1234
                // ,
                // {gissning} (input och output)
                // B,C
                // {gissning} (input och output)
                // B,CC
                // ...

                // Nya koden kommer skriva:
                // New game:
                // For practice, number is: 1234
                // {gissning} (input bara)
                // B,C
                // {gissning} (input bara)
                // B,CC
                // ...

                // DVS nya koden saknar första jämförelsen (jag hade bara skrivit ut "," i StartNewGame...)
                // Samt att printa ut gissningen.
                numberOfGuesses++;
                playerGuess = io.GetGuess();

                answerFeedbackBullsOrCows = compareGuessToAnswer(answer, playerGuess);
                io.ShowGuessFeedback(answerFeedbackBullsOrCows);
            }

            dAO.AddMooResults(playerName,numberOfGuesses);

            // Lägg dessa två rader i egen funktion så kan du även lägga in listan som du gör i början där.
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
                // Vad händer här om answer = 4444, guess = 1234
                // Borde det inte ge B,CCC?
                // Ser ut som gamla koden också kommer ge det men det känns inte rätt.
                // Om ni skulle skriva unit test så skulle jag ställa upp ett och försöka lösa det.
                cows++;
            }
        }

        string bullsSubstring = BullsString.Substring(0, bulls);
        string cowsSubstring = CowsString.Substring(0, cows);

        return $"{bullsSubstring},{cowsSubstring}";
    }

    private List<MooPlayer> sortToplist() // Kanske ska heta getSortedToplist?
    {
        var results = dAO.GetMooResults();

        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

        return results;
    }


}


