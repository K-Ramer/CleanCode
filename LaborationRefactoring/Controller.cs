using System;
namespace LaborationRefactoring;

internal class Controller
{
	IUI io;
	IDAO dAO;
	List<IGame> games;

    public Controller(IUI io, IDAO dAO, List<IGame> games)
	{
		this.io = io;
		this.dAO = dAO;
		this.games = games;
	}

	public void Start()
	{
		io.ShowMenu(games);
        int selectedIndex = io.GetNumber() - 1;

        if (selectedIndex >= 0 && selectedIndex < games.Count)
        {
            IGame selectedGame = games[selectedIndex];
            selectedGame.RunGame();
        }
		else if (selectedIndex == games.Count)
		{
			Environment.Exit(0);
		}
        else
        {
			io.WrongInput();
            Thread.Sleep(1500);
        }

  //      switch (io.GetNumber())
		//{
		//	case 1:
		//		games.First().RunGame();
		//		break;

		//	case 2:
				
		//		break;

  //          case 3:
		//		Environment.Exit(0);
  //                  break;

  //          default:
		//		io.WrongInput();
  //                  Thread.Sleep(1500);
  //                  break;

  //          }

	}
}

