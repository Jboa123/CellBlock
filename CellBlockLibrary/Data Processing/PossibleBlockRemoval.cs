using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class PossibleBlockRemoval
    {
        public PossibleBlockRemoval(Grid grid)
        {
            this.Grid = grid;
            ChangeHasOccured = false;
            ProvesNoSolution = false;
        }

        private readonly Grid Grid;
        /// <summary>
        ///Keeps track of a change in Grid.Blocks[ALL].PossibleBlocks.
        /// </summary>
        public bool ChangeHasOccured { get; set; }
        public bool ProvesNoSolution { get; set; }

        /// <summary>
        /// Loops through all MainBlocks. Removes invalid PossibleBlocks. If there 
        /// </summary>
        public void RemoveImposBlocksAndsetCertain()
        {
            foreach (MainBlock MBlock in Grid.Blocks)
            {
                RemoveImpossibleBlocks(MBlock);
                if(MBlock.PossibleBlocks.Count ==1)
                {
                    PossibleBlock pBlock = MBlock.PossibleBlocks[0];
                    pBlock.SetAsMainBlock();
                }else if(MBlock.PossibleBlocks.Count == 0)
                {
                    ProvesNoSolution = true;
                }
            }
        }

        /// <summary>
        /// For the input MainBlock. Loops through all PossibleBlocks, removes invalid PossibleBlocks based if they do not contain Block's MustContainCells or if the PossibleBlocks
        /// containa cell owned by a different block.
        /// If a PossibleBlokc is removed the changed has occured property is marked as true.
        /// </summary>
        /// <param name="MBlock"></param>
        private void RemoveImpossibleBlocks(MainBlock MBlock)
        {
            //All valid Possible Blocks will be added to templist. The MainBlock.PossibleBlocks will be replaced with tempList at the end of the method.
            List<PossibleBlock> newPBlockList = new List<PossibleBlock>();

            //If the PossibleBlock is valid it is added to the new list.
            foreach (PossibleBlock pBlock in MBlock.PossibleBlocks)
            {
                if (IsPBlockValid(pBlock, MBlock))
                {
                    newPBlockList.Add(pBlock);
                }
            }

            // if newPBock.count is different to the orignal MainBlock.PossibleBlocks.count then a change has occured and atleast 1 PossibleBlock has been removed
            if (newPBlockList.Count != MBlock.PossibleBlocks.Count)
            {
                ChangeHasOccured = true;
            }

            //Set PossibleBlocks List to the newly refined list
            MBlock.PossibleBlocks = newPBlockList;
        }

        /// <summary>
        /// Input a PossibleBlock if its valid it is returned. Else return NULL
        /// </summary>
        /// <param name="pBlock"></param>
        /// <returns></returns>
        private bool IsPBlockValid(PossibleBlock pBlock, MainBlock MBlock)
        {
            // Does the Possible Block contian all the Cells int MainBlock.CertainCells?
            if (MBlock.CertainCells.IsSubsetOf(pBlock.Cells))
            {
                //All the Cells in a possible block are looped through. Keeps track to check if all Cells are valid members of the Possible Block.
                bool isValid = true;

                // Loop through each cell in this Possible Block
                foreach (Cell cell in pBlock.Cells)
                {
                    //Is the Cell owned by a different MainBlock?
                    if (cell.IsOwnedByBlockOtherThan(MBlock))
                    {
                        //If Cell is owned by other block then this Possible Block is no longer valid.
                        isValid = false;
                        break;
                    }
                }
                //If the Possible Block is valid return it. Possible block must be superset of MainBlock.CertainCells && not contain a Cell owned by a different MainBlock
                if (isValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
