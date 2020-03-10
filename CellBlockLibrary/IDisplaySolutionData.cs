using System.Collections.Generic;

namespace CellBlockLibrary
{
    public interface IDisplaySolutionData
    {
        Dictionary<int,int> PredefinedCells { get; set; }
        List<Grid> SolvedGrids { get; set; }

        List<int> GetIndexedList();
    }
}