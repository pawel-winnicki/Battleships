namespace Battleships.Tests;

public class GridTests
{
    private Grid _grid = null!;

    [Fact]
    public void Try_WhenOutOfGrid_ShouldThrow()
    {
        _grid = new Grid(new List<ICollection<(int, int)>> {new List<(int, int)> {(0, 0)}});
        Assert.Throws<InvalidInputException>(() => _grid.Try(Grid.Size, 0));
    }

    [Fact]
    public void Try_WhenMiss_ShouldReturnNegativeResult()
    {
        var point = (0, 0);
        _grid = new Grid(new List<ICollection<(int, int)>> {new List<(int, int)> {(1,1)}});

        var result = _grid.Try(point.Item1, point.Item2);
        
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Try_WhenHit_ShouldReturnMissing()
    {
        var point = (0, 0);
        _grid = new Grid(new List<ICollection<(int, int)>> {new List<(int, int)> {point, (1,1)}});

        var result = _grid.Try(point.Item1, point.Item2);
        
        Assert.Equal(1, result);
    }

    [Fact]
    public void Try_WhenTryAlreadyTried_ShouldReturnNegativeResult()
    {
        var point = (0, 0);
        _grid = new Grid(new List<ICollection<(int, int)>> {new List<(int, int)> {point}});

        _grid.Try(point.Item1, point.Item2);
        var result = _grid.Try(point.Item1, point.Item2);
        
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Try_WhenTryLast_ShouldReturnZero()
    {
        var point = (0, 0);
        _grid = new Grid(new List<ICollection<(int, int)>> {new List<(int, int)> {point}});

        var result = _grid.Try(point.Item1, point.Item2);
        
        Assert.Equal(0, result);
    }

    [Fact]
    public void IsFinished_WhenNoMoreShips_ShouldReturnTrue()
    {
        _grid = new Grid(new List<ICollection<(int, int)>>());
        
        Assert.True(_grid.IsFinished());
    }
}
