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

            switch (io.GetNumber())
			{
				case 1:
					MooGame mooGame = new MooGame(io, dAO);
                    mooGame.RunGame();
					break;

				case 2:
					//Put other game here
					break;

                case 3:
					Environment.Exit(0);
                    break;

                default:
					io.WrongInput();
                    Thread.Sleep(1500);
                    break;

            }

		}
	}
}

