namespace LaborationRefactoring;

public class MooGame : IGame
{
    private const string GameName = "MooGame";

    IUI io;
    IDAO dAO;

    public MooGame()
    {

    }

    public MooGame(IUI io, IDAO dAO)
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

        bool playOn = true;
        string playerName = io.GetUserName();
        

        while (playOn)
        {
            string answer = GenerateNewAnswer();
            string playerGuess; 
            int numberOfGuesses = 0;
            string? answerFeedbackBullsOrCows = null;
           
            io.StartNewGame(answer);

            while (answerFeedbackBullsOrCows != "BBBB,")
            {
                numberOfGuesses++;
                playerGuess = io.GetGuess();
                
                answerFeedbackBullsOrCows = CompareGuessToAnswer(answer, playerGuess);
                io.ShowGuessFeedback(answerFeedbackBullsOrCows);
            }

            dAO.AddMooResults(playerName,numberOfGuesses);

            ShowTopList();

            io.ShowRoundFeedback(numberOfGuesses);

            playOn = io.ContinueOrQuit();
        }
    }

    public void ShowTopList()
    {
        List<MooPlayer> results = dAO.GetMooResults();
        SortMooResults(results);

        io.ShowMooTopList(results);
    }

    public static void SortMooResults(List<MooPlayer> results)
    {
        results.Sort((player1, player2) => player1.CalculateAverageNumberOfGuesses().CompareTo(player2.CalculateAverageNumberOfGuesses()));
    }

    public string GenerateNewAnswer()
    {
        Random randomGenerator = new Random();

        string randomFourDigitString = randomGenerator.Next(0, 10000).ToString("D4");
       
        return randomFourDigitString;
    }

    public static string CompareGuessToAnswer(string answer, string playerGuess)
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
}


