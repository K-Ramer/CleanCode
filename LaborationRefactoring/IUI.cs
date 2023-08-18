using System;
namespace LaborationRefactoring;

internal interface IUI
{
	
	public string GetUserName();
	public string GetGuess();
	public int GetNumber();

    public void StartNewGame(string answer);
    public void ShowMenu();

    public void ShowMooTopList(List<MooPlayer> results);
	public void ShowGuessFeedback(string answerFeedbackBullsOrCows);
	public void ShowRoundFeedback(int numberOfGuesses);
	public bool ContinueOrQuit();

	public void WrongInput();

}

