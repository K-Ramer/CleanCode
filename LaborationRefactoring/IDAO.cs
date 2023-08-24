using System;
namespace LaborationRefactoring;

public interface IDAO
{
    public List<MooPlayer> GetMooResults();
    public void AddMooResults(string name, int numberOfGuesses);

}

