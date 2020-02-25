using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class GridAndCellIterations
    {

        public GridAndCellIterations(Grid grid)
        {
            this.Grid = grid;
            this.ChangeHasOccured = false;
            this.ProvesNoSolution = false;
        }

        private readonly Grid Grid;
        public bool ProvesNoSolution { get; set; }
        public bool ChangeHasOccured { get; set; }

        /// <summary>
        /// Loops though all Cells in the Grid. If there is only 1 PossibleIndex for the Cell then add this Cell to the relevant Block's MustContainCells Hashset.
        /// If there are 0 PossibleIndexs, there is no solution -> set ProvesNoSolution Property to true.
        /// </summary>

        public void CheckAllCellPossibleIndexs()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Cell cell = Grid.Cells[i, j];
                    if (cell.IsOwned == false)
                    {
                        CheckCellPossibleIndexs(cell);
                    }
                }
            }
        }

        /// <summary>
        /// For the input Cell. Checks the number of blocks that may have potential ownership.
        /// If count > 1. No new information ->No action
        /// Count == 1. The Cell's owner is determined -> Cell is marked as owned by the Block with Index = key of the PossibleIndex dictionary.
        /// Count == 0. Cell cannot be a memeber of any block -> This grid has no solution -> Set ProvesNoSultion property to true
        /// </summary>
        /// <param name="cell"></param>
        private void CheckCellPossibleIndexs(Cell cell)
        {
            int cellIndex = 0;
            if (cell.PossibleIndexs.Count == 1)
            {
                foreach (KeyValuePair<int, List<PossibleBlock>> index in cell.PossibleIndexs)
                {
                    cellIndex = index.Key;
                }
                if (cell.IsOwned == false)
                {
                    cell.SetOwnership(Grid.Blocks[cellIndex]);
                }
            }
            else if (cell.PossibleIndexs.Count == 0)
            {
                ProvesNoSolution = true;
            }
        }

        /// <summary>
        /// Loop through all Cells on the grid. Foreach Cell
        /// Checks the Cell: Is it a member of all PossibleBlocks for a Given Block? -> YES, set the Cell's ownership to that block -> mark HasCHanged as true
        /// If Cell is a member of all PossibleBlocks for multiple Blocks-> Grid has no Solution -> Mark ProvesNoSolution as true.
        /// </summary>
        public void CheckAllCellMembership()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Cell cell = Grid.Cells[i, j];
                    if (cell.IsOwned == false)
                    {
                        IsCellMemberOfAllPblock(cell);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the input Cell: Is it a member of all PossibleBlocks for a Given Block? -> YES, set the Cell's ownership to that block -> mark HasCHanged as true
        /// If Cell is a member of all PossibleBlocks for multiple Blocks-> Grid has no Solution -> Mark ProvesNoSolution as true.
        /// </summary>
        /// <param name="cell"></param>
        private void IsCellMemberOfAllPblock(Cell cell)
        {
            //If count is 0 no information is deduced -> Do nothing.
            //If count is 1, key will track the Index of the owning MainBlock-> Mark cell as owned
            //if Count > 1 then this grid has no solution -> 2 or more MainBlocks require ownership of this Cell 
            int count = 0, key = -1;
            foreach (KeyValuePair<int, List<PossibleBlock>> KVP in cell.PossibleIndexs)
            {
                if (CellIsSubset(cell, KVP.Key))
                {
                    key = KVP.Key;
                    count++;
                }
            }

            if (count == 1)
            {
                ChangeHasOccured = true;
                if (cell.IsOwned == false)
                {
                    cell.SetOwnership(Grid.Blocks[key]);
                }
            }
            else if (count > 1)
            {
                ProvesNoSolution = true;
            }
        }

        /// <summary>
        /// is the input Cell is a member of all Possible Blocks for the input MainBlock. If so return True;
        /// </summary>
        private bool CellIsSubset(Cell cell, int BlockIndex)
        {
            //The value stored at a key represents the number of possibleBlocks in Block[key].PossibleBlocks that the Cell is a member of.
            if (cell.PossibleIndexs[BlockIndex].Count == Grid.Blocks[BlockIndex].PossibleBlocks.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loops though all Blocks. Loops though each Possible Block For a Block. Loop though each Cell for a Possible Bock.
        /// The cell has the Blocks index add to Cell.PossibleIndexs
        /// </summary>
        public void FillCellIndex()
        {
            foreach (MainBlock block in Grid.Blocks)
            {
                block.MarkPossilbeReach();
            }
        }

        /// <summary>
        /// Loop through all Cells. Clear Possible Indexs Hashset.
        /// </summary>
        public void ClearCellPossibleIndexs()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Cell cell = Grid.Cells[i, j];

                    cell.PossibleIndexs.Clear();

                }
            }
        }
    }
}
