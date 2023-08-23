using System;
namespace LaborationRefactoring;

internal class Mastermind : IGame
{
    private const string GameName = "Mastermind"; 

    IUI io;
    IDAO dAO;

    public Mastermind(IUI io, IDAO dAO)
    {
        this.io = io;
        this.dAO = dAO;
    }

    public string GetGameName()
    {
        return GameName;
    }

    public void RunGame()
    {
        Console.WriteLine("You are playing Mastermind. Lucky you!");
        Thread.Sleep(1500);
    }
}

