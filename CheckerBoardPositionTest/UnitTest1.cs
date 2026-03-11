namespace CheckerBoardPosition.Test;
public class MovementColumn
{
    [Fact]
    public void MoveFromB1OnB2_ReturnCorrectResult()
    {
        var start = CheckerBoardPosition.Parse("B1", null);
        var finish = CheckerBoardPosition.Parse("B2", null);
        var deltaX = start.X - finish.X;
        var deltaY = start.Y - finish.Y;
        Assert.Equal(0, deltaX);
        Assert.Equal(-1, deltaY);
    }
    [Theory]
    [InlineData("B1","B2")]
    [InlineData("A1","A2")]
    [InlineData("C1","C2")]
    [InlineData("A1","B2")]
    public void MoveFromB1OnB2_ReturnCorrectResult1(string post1, string post2)
    {
        var start = CheckerBoardPosition.Parse(post1, null);
        var finish = CheckerBoardPosition.Parse(post2, null);
        var deltaX = start.X - finish.X;
        var deltaY = start.Y - finish.Y;
        Assert.Equal(post1[0] - post2[0], deltaX);
        Assert.Equal(post1[1] - post2[1], deltaY);
    }
}
