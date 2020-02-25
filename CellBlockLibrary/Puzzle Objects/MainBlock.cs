using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class MainBlock
    {

        public MainBlock(int index, int area, Cell cell,Grid grid)
        {
            this.Index = index;
            this.Area = area;
            this.DefinedCell = cell;
            this.Grid = grid;
        }
        public MainBlock()
        {

        }

        private readonly Grid Grid;
        public int Index { get; set; }

        public int Area { get; set; }

        public Cell DefinedCell { get; set; }

        public List<PossibleBlock> PossibleBlocks { get; set; } = new List<PossibleBlock>();

        public HashSet<Cell> CertainCells { get; set; } = new HashSet<Cell>();

        public Cell TopLeftCell{ get; set; }

        public int[] FinalDimensions { get; set; } = new int[2];

  




        /// <summary>
        /// Add the This.index to the Possible Index of all cells contained within all Possible Blocks of this block
        /// </summary>
        public void MarkPossilbeReach()
        {
            foreach (PossibleBlock pblock in PossibleBlocks)
            {
                pblock.FillCellsWithPossibleIndex();
            }
        }
        


    }
}

