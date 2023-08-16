using System;
using System.IO;
using System.Collections.Generic;
//test

namespace LaborationRefactoring;

internal class MooGame
{
    IUI io;
    IDAO dAO;

    public MooGame(IUI io, IDAO dAO)
    {
        this.io = io;
        this.dAO = dAO;
    }

    public void RunGame()
    {

        bool playOn = true;
        io.PrintString("Enter your user name:\n");
        string playerName = io.GetString();

        while (playOn)
        {
            string goal = makeGoal();


            io.PrintString("New game:\n");
            //comment out or remove next line to play real games!
            io.PrintString("For practice, number is: " + goal + "\n");
            string guess = io.GetString();

            int numberOfGuesses = 1;
            string bbcc = checkBC(goal, guess);
            io.PrintString(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                guess = io.GetString();
                io.PrintString(guess + "\n");
                bbcc = checkBC(goal, guess);
                io.PrintString(bbcc + "\n");
            }
            dAO.AddResultsToFile(playerName,numberOfGuesses);
            showTopList();
            
            io.PrintString("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
            string answer = io.GetString();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                playOn = false;
            }
        }
    }
    static string makeGoal()
    {
        Random randomGenerator = new Random();
        string goal = "";
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            while (goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }
            goal = goal + randomDigit;
        }
        return goal;
    }

    static string checkBC(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        guess += "    ";     // if player entered less than 4 chars
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }


    static void showTopList()
    {
        StreamReader input = new StreamReader("result.txt");
        
        List<MooPlayer> results = new List<MooPlayer>();
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            MooPlayer pd = new MooPlayer(name, guesses);
            int pos = results.IndexOf(pd);
            if (pos < 0)
            {
                results.Add(pd);
            }
            else
            {
                results[pos].Update(guesses);
            }


        }
        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player   games average");
        foreach (MooPlayer p in results)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfRoundsPlayed, p.Average()));
        }
        input.Close();
    }
}


