using board;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Position pos = new Position(3, 4);

            Console.WriteLine("Position: " + pos);

            Console.ReadLine();
        }
    }
}