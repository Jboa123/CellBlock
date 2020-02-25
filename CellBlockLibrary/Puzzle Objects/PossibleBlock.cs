using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class PossibleBlock
    {
        public PossibleBlock(int index, int area, Cell cell, Grid grid)
        {
            Index = index;
            Area = area;
            DefinedCell = cell;
            Grid = grid;
        }
         
        private readonly Grid Grid;

        public Cell TopLeftCell{ get; set; }
        /// <summary>
        /// Dimensions of te block. [0] corresponds to x, [1] to y.
        /// </summary>
        public int[] Dimensions { get; set; } = new int[2];
        
        /// <summary>
        /// Hashset containing all the Cells contained within this object.
        /// </summary>
        public HashSet<Cell> Cells { get; set; } = new HashSet<Cell>();

        /// <summary>
        /// The block index that corresponds to this Possible Block. Equal to the Block index of the block that contains this object in the Block's Possible Blocks list.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The number of cells contained within the block. equal to Dimension[0]*Dimension[1]
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// A cell that contained an initial value. Must be 1 and only 1 per block
        /// </summary>
        public Cell DefinedCell { get; set; }

        /// <summary>
        /// Each cell contained in this Possible Block has the index of this Possible Block added to the Cell Possible Index
        /// </summary>
        public void FillCellsWithPossibleIndex()
        {
            foreach (Cell cell in Cells)
            {
                if (cell.PossibleIndexs.ContainsKey(this.Index))
                {
                    cell.PossibleIndexs[this.Index].Add(this);
                }else
                {
                    List<PossibleBlock> possibleBlocks = new List<PossibleBlock>();
                    possibleBlocks.Add(this);
                    cell.PossibleIndexs.Add(this.Index, possibleBlocks);
                }
            }
        }

        /// <summary>
        /// Sets the MainBlock of Index equal to this.Index to be this block. 
        /// Sets CertainCells, TopLeftCell, FinalDimensions, PossibleBlocks.
        /// Each Cell is this PossibleBlock is marked as owned.
        /// </summary>
        public void SetAsMainBlock()
        {
            Grid.Blocks[this.Index].CertainCells = this.Cells;
            Grid.Blocks[this.Index].TopLeftCell = this.TopLeftCell;
            Grid.Blocks[this.Index].FinalDimensions = this.Dimensions;
            Grid.Blocks[this.Index].PossibleBlocks.Clear();
            Grid.Blocks[this.Index].PossibleBlocks.Add(this);
            foreach (Cell cell in this.Cells)
            {
                if (cell.IsOwned == false)
                {
                    cell.SetOwnership(Grid.Blocks[this.Index]);
                }
            }
        }

    }
}
