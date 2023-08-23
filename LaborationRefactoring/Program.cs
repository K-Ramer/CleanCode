using System;
namespace LaborationRefactoring;

internal class Program
{
	static void Main(string[] args)
	{
		IUI io = new StringIO();
		IDAO dAO = new FileDAO();
        List<IGame> games = new List<IGame>() { new MooGame(io, dAO), new Mastermind(io, dAO) };

		Controller controller = new Controller(io, dAO, games);
		controller.Start();
	}
}

