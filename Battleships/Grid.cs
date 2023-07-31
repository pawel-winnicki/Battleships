namespace Battleships;

public class Grid
{
    public const int Size = 10;
    
    private readonly IList<ICollection<(int, int)>> _ships;

    public bool IsFinished() => _ships.Count == 0;

    public Grid(IList<ICollection<(int, int)>> ships)
    {
        _ships = ships;
    }

    public int Try(int w, int h)
    {
        if (w < 0 || h < 0 || w >= Size || h >= Size)
        {
            throw new InvalidInputException();
        }

        var missing = -1;
        foreach (var ship in _ships)
        {
            var result = ship.Remove((w, h));
            if (result)
            {
                missing = ship.Count;
            }
        }

        if (missing == 0)
        {
            var sunk = _ships.Single(s => s.Count == 0);
            _ships.Remove(sunk);
        }

        return missing;
    }
}


