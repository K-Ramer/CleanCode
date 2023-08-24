using System;
namespace LaborationRefactoring;

public interface IUI
{
	
	public string GetGuess();
	public int GetNumber();
	public string GetUserName();

	public void ShowGuessFeedback(string answerFeedbackBullsOrCows);
    public void ShowMenu(List<IGame>games);
    public void ShowMooTopList(List<MooPlayer> results);
	public void ShowRoundFeedback(int numberOfGuesses);
    public void StartNewGame(string answer);

	public bool ContinueOrQuit();

	public void PromptForNewChoiceInput();

}

