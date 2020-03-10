using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class CloneGridAndSetBlock : ICloneGridAndSetBlock
    {
        IDeepCloneGrid _cloneGrid;
        public CloneGridAndSetBlock(IDeepCloneGrid deepCloneGrid)
        {
            _cloneGrid = deepCloneGrid;
        }

        public Grid OriginalGrid { get; set; }
        private List<Grid> GridPlusSetBlocks { get; set; }


        /// <summary>
        /// Finds the Largest Unsolved MainBlock. For each PossibleBlock in the MainBlock.PossibleBlock, Clones the Grid and sets the relevant PossibleBlock to be the Mainblock.
        /// Adds all the copied grids to a list and returns the list.
        /// </summary>
        /// <returns></returns>
        public List<Grid> GetGridsWithSetBlocks()
        {
            MainBlock largestUnsolved = GetLargestUnsolvedMainBlock();
            GridPlusSetBlocks = new List<Grid>();
            foreach (PossibleBlock possibleBlock in largestUnsolved.PossibleBlocks)
            {
                Grid newGrid = _cloneGrid.CloneGrid();
                PossibleBlock toTry = GetEquivalentPossibleBlock(possibleBlock, newGrid);
                toTry.SetAsMainBlock();
                GridPlusSetBlocks.Add(newGrid);
            }
            return GridPlusSetBlocks;
        }

        /// <summary>
        /// Finds and returns the PossibleBlock from the new Grid that is equivalent to the input PossibleBlock.
        /// </summary>
        /// <param name="originalPBlock"></param>
        /// <param name="newGrid"></param>
        /// <returns></returns>
        private PossibleBlock GetEquivalentPossibleBlock(PossibleBlock originalPBlock, Grid newGrid)
        {
            // equivalent PossibleBlocks will have the same index in MainBlock.PossibleBlocks in both the orignal and new Grid.
            int PBlockPosition = OriginalGrid.Blocks[originalPBlock.Index].PossibleBlocks.IndexOf(originalPBlock);
            return newGrid.Blocks[originalPBlock.Index].PossibleBlocks[PBlockPosition];
        }

        /// <summary>
        /// Finds the MainBlock with the largest area that has not been finalised
        /// </summary>
        /// <returns></returns>
        private MainBlock GetLargestUnsolvedMainBlock()
        {
            //create dummy block with area = 0. Will keep track of largest un finalised MainBlock.
            MainBlock largestUnsolved = new MainBlock() { Area = 0 };
            foreach (MainBlock MBlock in OriginalGrid.Blocks)
            {
                //If PossibleBlocks.counts != 0 then the Mainblock has not been finalised.
                if (MBlock.PossibleBlocks.Count != 1 && MBlock.Area > largestUnsolved.Area)
                {
                    largestUnsolved = MBlock;
                }
            }
            return largestUnsolved;
        }
        public void SetClonesOriginalGrid(Grid grid)
        {
            this.OriginalGrid = grid;
            _cloneGrid.OriginalGrid = grid;
        }
    }
}
