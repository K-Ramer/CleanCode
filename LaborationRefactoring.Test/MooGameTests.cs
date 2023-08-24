using System.Text.RegularExpressions;

namespace LaborationRefactoring.Test;

[TestClass]
public class MooGameTests
{

    [TestMethod]
    public void TestAnswer()
    {
        MooGame mooGame = new MooGame();
        string answer = mooGame.GenerateNewAnswer();

        Assert.IsNotNull(answer);
        Assert.IsTrue(answer.Length == 4);
        Assert.IsInstanceOfType(answer, typeof(string));
        Assert.IsTrue(Regex.IsMatch(answer, @"^\d+$"));
    }

    [TestMethod]
    public void TestAnswerGuessComparison()
    {
        string mockAnswer = "4025";

        string mockGuess1 = "0425";
        string mockGuess2 = "7777";
        string mockGuess3 = "4025";

        string expectedResultGuess1 = "BB,CC";
        string expectedResultGuess2 = ",";
        string expectedResultGuess3 = "BBBB,";

        MooGame mooGame = new MooGame();

        Assert.AreEqual(expectedResultGuess1, MooGame.CompareGuessToAnswer(mockAnswer, mockGuess1));
        Assert.AreEqual(expectedResultGuess2, MooGame.CompareGuessToAnswer(mockAnswer, mockGuess2));
        Assert.AreEqual(expectedResultGuess3, MooGame.CompareGuessToAnswer(mockAnswer, mockGuess3));
    }

    [TestMethod]
    public void TestTopListOrder()
    {
        MooGame mooGame = new MooGame();
        List<MooPlayer> mockResults = new List<MooPlayer>
        {
            new MooPlayer("Player1", 5),
            new MooPlayer("Player2", 3),
            new MooPlayer("Player3", 6)
        };

        MooGame.SortMooResults(mockResults);

        List<MooPlayer> expectedResultOrder = new List<MooPlayer>
        {
            new MooPlayer("Player2", 3),
            new MooPlayer("Player1", 5),
            new MooPlayer("Player3", 6),
        };

        CollectionAssert.AreEqual(expectedResultOrder, mockResults);
    }
}
