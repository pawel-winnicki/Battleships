using Battleships;

Console.WriteLine("Welcome to Battleships!");
Console.WriteLine("Select fields from A0 to J9");
var game = new Game();
do
{
    Console.Write("Select field: ");
    var move = Console.ReadLine()!;
    try
    {
        Console.WriteLine(game.NewMove(move));
    }
    catch (InvalidInputException)
    {
        Console.WriteLine("Please input correct field!");
    }
} while (!game.IsFinished());

Console.WriteLine("You won!");
