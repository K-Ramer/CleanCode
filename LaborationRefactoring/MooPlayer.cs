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


    // Du har tagit bort Equals som jämför mot namn. Då kommer inte topplistan bli rätt när samma spelare spelar flera ggr.
    // Kan va att GetHashCode behövs också för att C# skall kunna jämföra objekt korrekt.

}


