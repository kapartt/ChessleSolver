using System.Collections.Generic;

namespace ChessleSolver.Entities
{
    public class PgnDatabase
    {
        public PgnDatabase()
        {
            LinesAndCounts = new Dictionary<string, int>();
        }

        public void CreateDatabase()
        {
            var pgnLines = PgnLoader.LoadPgnLines();

            foreach (var pgnLine in pgnLines)
            {
                if (pgnLine.StartsWith("1."))
                {
                    var splittedPgnLine = pgnLine.Split();
                    
                    var lineForDictionary = "";
                    var sixthMoveIndex = 0;

                    while (splittedPgnLine[sixthMoveIndex] != "6.")
                    {
                        lineForDictionary += splittedPgnLine[sixthMoveIndex];
                        lineForDictionary += " ";
                        sixthMoveIndex++;
                    }

                    if(LinesAndCounts.TryGetValue(lineForDictionary, out var val))
                    {
                        LinesAndCounts[lineForDictionary] = val + 1;
                    }
                    else
                    {
                        LinesAndCounts[lineForDictionary] = 1;
                    }
                }
            }
        }


        public Dictionary<string, int> LinesAndCounts { get; set; }
    }
}
