namespace LaborationRefactoring;

public class MooPlayer : IPlayer
{
    public string PlayerName { get; set; }
    public int NumberOfRoundsPlayed { get; set; }
    int numberOfGuesses;


    public MooPlayer(string name, int guesses)
    {
        this.PlayerName = name;
        NumberOfRoundsPlayed = 1;
        numberOfGuesses = guesses;
    }

    public void Update(int guesses)
    {
        numberOfGuesses += guesses;
        NumberOfRoundsPlayed++;
    }

    public double Average()
    {
        return (double)numberOfGuesses / NumberOfRoundsPlayed;
    }
}

	
