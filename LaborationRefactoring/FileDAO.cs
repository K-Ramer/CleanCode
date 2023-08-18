using System;
namespace LaborationRefactoring;

internal class FileDAO : IDAO
{
	public FileDAO()
	{
	}

	public List<MooPlayer> GetMooResults()
	{
        using StreamReader inputFromResults = new StreamReader("result.txt");

        List<MooPlayer> results = new List<MooPlayer>();

        string lineValue;
        while ((lineValue = inputFromResults.ReadLine()) != null)
        {
            string[] nameAndScore = lineValue.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);

            MooPlayer player = new MooPlayer(name, guesses);

            int pos = results.IndexOf(player);
            if (pos < 0)
            {
                results.Add(player);
            }
            else
            {
                results[pos].Update(guesses);
            }
        }

        return results;

    }

	public void AddMooResults(string name, int numberOfGuesses)
	{
        using StreamWriter output = new StreamWriter("result.txt", append: true);
        output.WriteLine(name + "#&#" + numberOfGuesses);
    }
}

