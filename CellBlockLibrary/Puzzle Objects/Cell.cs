using System;
using System.Collections.Generic;

namespace CellBlockLibrary
{
    public class Cell
    {
        /// <summary>
        /// i and j are integers that represent the x and y positions in the grid respectively.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public Cell(int i, int j, Grid grid)
        {
            this.XPos = i;
            this.YPos = j;
            this.Grid = grid;
        }



        private readonly Grid Grid;
        public int XPos { get; set; }
        public int YPos { get; set; }

        /// <summary>
        /// Hashset containing integers representing the index of the blocks that have potential ownership of the cell.
        /// </summary>
        public Dictionary<int, List<PossibleBlock>> PossibleIndexs { get; set; } = new Dictionary<int, List<PossibleBlock>>(); 

        /// <summary>
        /// Does this cell have garunteed ownership by a block. If so, returns true.
        /// </summary>
        public bool IsOwned { get; set; }

        /// <summary>
        /// Integer representing the index of the block that owns this cell.
        /// </summary>
        public int OwnedBy { get; set; }


        /// <summary>
        /// Does this cell have certain ownership by any block other that the one given. Returns true if the cell has ownership by a different block.
        /// </summary>
        /// <param name="MBlock"></param>
        /// <returns></returns>
        public bool IsOwnedByBlockOtherThan(MainBlock MBlock)
        {
            if (MBlock.Index != OwnedBy && IsOwned)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// This cell now belongs to the block of input index
        /// </summary>
        /// <param name="index"></param>
        public void SetOwnership(MainBlock MBlock)
        {
            this.IsOwned = true;
            this.OwnedBy = MBlock.Index;
            MBlock.CertainCells.Add(this);
            Grid.SolvedCellCount++;


            if (Grid.Blocks[MBlock.Index].PossibleBlocks.Count == 1)
            {
                this.PossibleIndexs.Clear();
                this.PossibleIndexs.Add(MBlock.Index, Grid.Blocks[MBlock.Index].PossibleBlocks); 
            }
        }


    }
}
