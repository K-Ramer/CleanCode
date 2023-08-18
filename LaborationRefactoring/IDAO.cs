using System;
namespace LaborationRefactoring;

internal interface IDAO
	{
    public List<MooPlayer> GetMooResults();
    public void AddMooResults(string name, int numberOfGuesses);

}

