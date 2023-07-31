namespace Battleships;

public class Game
{
    private readonly Grid _grid;

    public Game()
    {
        var random = new ShipsPositionsRandom(Grid.Size);
        var positions = random.PlaceShips(new Battleship(), new Destroyer(), new Destroyer());
        _grid = new Grid(positions);
    }
    public bool IsFinished() => _grid.IsFinished();

    public string NewMove(string move)
    {
        if (move.Length != 2)
        {
            throw new InvalidInputException();
        }

        var w = move.ToUpper()[0] - 'A';
        var h = move[1] - '0';

        var result = _grid.Try(w, h);
        if (result < 0)
        {
            return "miss";
        }

        return result == 0 ? "sink" : "hit";
    }
}
