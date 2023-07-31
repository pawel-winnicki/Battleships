namespace Battleships.Tests;

public class ShipsPositionsRandomTests
{
    private readonly ShipsPositionsRandom _random; 

    public ShipsPositionsRandomTests()
    {
        _random = new ShipsPositionsRandom(Grid.Size);
    }

    [Fact]
    public void PlaceShips_WhenThreeShips_ShouldNotOverlap()
    {
        var result = _random.PlaceShips(new Battleship(), new Destroyer(), new Destroyer());
        var positions = result.SelectMany(r => r).ToHashSet();
        
        Assert.Equal(positions.Count, result.SelectMany(r => r).Count());
    }
}
