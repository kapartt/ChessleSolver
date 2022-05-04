using System.IO;

namespace ChessleSolver.Entities
{
    public static class PgnLoader
    {
        public static string[] LoadPgnLines()
        {
            return File.ReadAllLines(@"database.pgn");
        }
    }
}
