using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class DisplaySolutionData : IDisplaySolutionData
    {
        public List<Grid> SolvedGrids { get; set; } = new List<Grid>();
        
        public Dictionary<int,int> PredefinedCells { get; set; }
        public List<int> GetIndexedList()
        {
            List<int> intList = new List<int>();
            for (int i = 1; i <= SolvedGrids.Count; i++)
            {
                intList.Add(i);
            }
            
            return intList;
        }
    }
}
