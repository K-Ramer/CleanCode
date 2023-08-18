using System;
namespace LaborationRefactoring
{ //get input, show
	internal interface IUI
	{
		
		public string GetUserName();
		public string GetGuess();
		public void StartNewGame(string answer);
        public void PrintMenu();

        public void PrintMooTopList(List<MooPlayer> results);
		public void ShowGuessFeedback(string answerFeedbackBullsOrCows);
		public void ShowRoundFeedback(int numberOfGuesses);
		public bool ContinueOrQuit();

    }
}

