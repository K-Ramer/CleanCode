namespace LaborationRefactoring;

internal class Controller
{
    IUI io;
    List<IGame> games;

    public Controller(IUI io, List<IGame> games)
    {
        this.io = io;
        this.games = games;
    }

    public void Start()
    {
        io.ShowMenu(games);

        while (true)
        {
            int selectedIndex = io.GetNumber() - 1;

            if (selectedIndex >= 0 && selectedIndex < games.Count)
            {
                IGame selectedGame = games[selectedIndex];
                selectedGame.RunGame();
                io.ShowMenu(games);
            }
            else if (selectedIndex == games.Count)
            {
                Environment.Exit(0);
            }
            else
            {
                io.PromptForNewChoiceInput();
            }

        }
    }
}

