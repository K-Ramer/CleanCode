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

    public void UpdateGuesses(int guesses)
    {
        numberOfGuesses += guesses;
        NumberOfRoundsPlayed++;
    }

    public double CalculateAverageNumberOfGuesses()
    {
        return (double)numberOfGuesses / NumberOfRoundsPlayed;
    }

    public override bool Equals(object obj)
    {
        return PlayerName.Equals(((MooPlayer)obj).PlayerName);
    }

    public override int GetHashCode()
    {
        return PlayerName.GetHashCode();
    }
}

	
