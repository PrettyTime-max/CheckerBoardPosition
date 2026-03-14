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
    [Theory]
    [InlineData(1,2)]
    [InlineData(5,3)]
    [InlineData(6,2)]
    [InlineData(8,4)]
    [InlineData(6,8)]
    public void Constructor_ValidPosition_ReturnCorrectPositionOnX(byte x, byte y)
    {
        var position = new CheckerBoardPosition(x, y);
        Assert.Equal(x, position.X);
    }
    [Theory]
    [InlineData(9, 2)]
    [InlineData(0, 3)]
    [InlineData(10, 2)]
    [InlineData(11, 4)]
    public void Constructur_NotValidPosition_ReturnArgumentOutOfRangeExceptionOnX(byte x, byte y)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(x,y));
    }
    [Theory]
    [InlineData(1, 11)]
    [InlineData(4, 10)]
    [InlineData(6, 9)]
    [InlineData(8, 0)]
    public void Constructur_NotValidPosition_ReturnArgumentOutOfRangeExceptionOnY(byte x, byte y)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(x, y));
    }
    [Theory]
    [InlineData(1, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 2)]
    [InlineData(8, 4)]
    [InlineData(6, 8)]
    public void Constructor_ValidPosition_ReturnCorrectPositionOnY(byte x, byte y)
    {
        var position = new CheckerBoardPosition(x, y);
        Assert.Equal(y, position.Y);
    }
    [Theory]
    [InlineData("A1")]
    [InlineData("C6")]
    [InlineData("B8")]
    public void Parse_ValidPosition_ReturnCorrectPosition(string post)
    {
        var position = CheckerBoardPosition.Parse(post, null);
        Assert.Equal(post, position.ToString());
    }
    [Theory]
    [InlineData("A9")]
    [InlineData("Z6")]
    [InlineData("b8")]
    [InlineData("29")]
    [InlineData("GG")]
    public void Parse_NotValidPosition_ReturnFormatException(string post)
    {
        Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(post, null));
    }

}
