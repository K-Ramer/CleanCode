using System;
namespace LaborationRefactoring
{
	internal interface IDAO
	{
        internal void ReadResultsFromFile();
        public void AddResultsToFile(string name, int numberOfGuesses);

    }
}

