namespace Battleships;

public interface IShip
{
    public int Length { get; }
}

public class Battleship : IShip
{
    public int Length => 5;
}

public class Destroyer : IShip
{
    public int Length => 4;
}
