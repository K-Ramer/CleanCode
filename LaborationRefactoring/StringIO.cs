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
            PrintString("Menu\n\n1. MooGame\n2. Other Game");
        }

        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }

        public void PrintTopList(List<IPlayer> output) //NOT DONE
        {
            foreach(IPlayer player in output)
            {
                PrintString(player.PlayerName);
            }
        }
    }
}

