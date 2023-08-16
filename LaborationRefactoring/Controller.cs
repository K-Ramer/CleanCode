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
			int.TryParse(io.GetString(), out choice);


            switch (choice)
			{
				case 1:
					MooGame mooGame = new MooGame(io, dAO);
                    mooGame.RunGame();
					break;

				case 2:
					io.PrintString("Other game");
					break;

				default:
					io.PrintString("No such choice. Try again.");
					break;

            }

		}
	}
}

