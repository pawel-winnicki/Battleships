namespace Battleships;

public class ShipsPositionsRandom
{
    private readonly int _size;

    public ShipsPositionsRandom(int size)
    {
        _size = size;
    }
    
    public IList<ICollection<(int, int)>> PlaceShips(params IShip[] ships)
    {
        var random = new Random();
        var positions = new List<ICollection<(int, int)>>();
        foreach (var ship in ships)
        {
            var placed = false;
            do
            {
                var horizontal = random.Next() % 2 == 0;
                var start = random.Next(_size - ship.Length);
                var constCoordinate = random.Next(_size);
                var newCooridanates = Enumerable.Range(start, ship.Length)
                    .Select(i => horizontal ? (i, constCoordinate) : (constCoordinate, i)).ToHashSet();
                var collision = false;
                foreach (var coordinates in positions)
                {
                    var occupied = coordinates.Except(newCooridanates).Count() != coordinates.Count;
                    if (occupied)
                    {
                        collision = true;
                    }
                }

                if (collision) continue;
                positions.Add(newCooridanates);
                placed = true;
            } while (!placed);
        }

        return positions;
    }
}
