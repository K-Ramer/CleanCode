using System;
namespace LaborationRefactoring
{
	internal class Controller
	{
		IUI io;
		IDAO dAO;

		public Controller(IUI io, IDAO dAO)
		{
			this.io = io;
			this.dAO = dAO;
		}

		public void Start()
		{
			io.PrintMenu();

			int choice;
			int.TryParse(Console.ReadLine(), out choice);


            switch (choice)
			{
				case 1:
					MooGame mooGame = new MooGame(io, dAO);
                    mooGame.RunGame();
					break;

				case 2:
					Console.WriteLine("Other game");
					break;

				default:
                    Console.WriteLine("No such choice. Try again.");
					break;

            }

		}
	}
}

