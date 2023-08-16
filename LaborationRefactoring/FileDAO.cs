using System;
namespace LaborationRefactoring;

internal class FileDAO : IDAO
{
	public FileDAO()
	{
	}

	public void ReadResultsFromFile()
	{
        StreamReader resultsFromFile = new StreamReader("result.txt");
    }

	public void AddResultsToFile(string name, int numberOfGuesses)
	{
        StreamWriter output = new StreamWriter("result.txt", append: true);
        output.WriteLine(name + "#&#" + numberOfGuesses);
        output.Close();
    }
}

