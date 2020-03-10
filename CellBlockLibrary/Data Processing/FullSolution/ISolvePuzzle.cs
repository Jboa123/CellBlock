using System.Collections.Generic;

namespace CellBlockLibrary
{
    public interface ISolvePuzzle
    {
        Queue<Grid> UnsolvedGrids { get; set; }
        void FindAllSolutions();
    }
}