using System.Text.RegularExpressions;

namespace LaborationRefactoring.Test;

[TestClass]
public class MooGameTests
{
    [TestMethod]
    public void TestAnswer()
    {
        string answer = MooGame.GenerateNewAnswer();

        Assert.IsNotNull(answer);
        Assert.IsTrue(answer.Length == 4);
        Assert.IsInstanceOfType(answer, typeof(string));
        Assert.IsTrue(Regex.IsMatch(answer, @"^\d+$"));
    }

    [DataTestMethod]
    [DataRow("4025", "0425", "BB,CC")]
    [DataRow("4025", "7777", ",")]
    [DataRow("4025", "4025", "BBBB,")]
    public void TestAnswerGuessComparison(string answer, string guess, string expectedResult)
    {
        string actualResult = MooGame.CompareGuessToAnswer(answer, guess);

        Assert.AreEqual(expectedResult, actualResult);

    }

    [TestMethod]
    public void TestTopListOrder()
    {
        List<MooPlayer> actualResults = new List<MooPlayer>
        {
            new MooPlayer("Player1", 5),
            new MooPlayer("Player2", 3),
            new MooPlayer("Player3", 6)
        };

        MooGame.SortMooResults(actualResults);

        List<MooPlayer> expectedResultOrder = new List<MooPlayer>
        {
            new MooPlayer("Player2", 3),
            new MooPlayer("Player1", 5),
            new MooPlayer("Player3", 6),
        };

        CollectionAssert.AreEqual(expectedResultOrder, actualResults);
    }
}
