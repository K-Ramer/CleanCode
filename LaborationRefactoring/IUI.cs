using System;
namespace LaborationRefactoring
{
	internal interface IUI
	{
		public string GetString();
		public void PrintString(string output);
		public void PrintMenu();
		public void PrintTopList(List<IPlayer> output);
	}
}

