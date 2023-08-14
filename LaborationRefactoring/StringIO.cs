using System;

namespace LaborationRefactoring
{
    public class StringIO : IUI
    {
        public string GetString()
        {
            return Console.ReadLine();
        }

        public void PrintMenu()
        {
            PrintString("Menu");
        }

        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }

        public void PrintTopList(List<IPlayer> output)
        {
            foreach(IPlayer player in output)
            {
                PrintString(player.PlayerName);
            }
        }
    }
}

