using System;
namespace LaborationRefactoring;

internal class Program
{
	static void Main(string[] args)
	{
		IUI io;
		IDAO dAO;

		io = new StringIO();
        dAO = new FileDAO();

		Controller controller = new Controller(io, dAO);
		controller.Start();
	}
}

